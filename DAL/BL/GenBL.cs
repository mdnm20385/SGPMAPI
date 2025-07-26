using System.Data;
using System.Diagnostics;
using System.Reflection;
using DAL.Classes;
using Microsoft.Data.SqlClient;

namespace DAL.BL
{
	public static class GenBl
    {

       
        //DMZ.BL.Classes.GenBl Descricaodocs
        private static List<PropertyInfo> props;
        public static string Descricaodocs(string docdesc)
        {
            var ret ="";

            switch (docdesc.ToLower().Trim())
            {
                case "factura":
                    ret="Invoice";
                    break;
                case "cotação":
                    ret="Quotation";
                    break;
                case "venda a dinheiro":
                    ret="Cash Sale";
                    break;
            }
            return ret;

        }
		
        public static (bool StkExiste, string Messagem) CheckStock<T>(T entity, DataTable dt,bool usalote, bool pos = false) where T : class
        {
            _props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //var pkName = GetPropName("stamp", entity.GetType().Namespace);
           // var clocalstamp = GetValue(pkName, entity);
			string filhastamp;
			//var data =Convert.ToDateTime(Utilities.GetProperty("Data", entity).GetValue(entity, null));
			var movstk =GetValue("Movstk", entity).ToBool(); //Utilities.GetProperty("Movstk", entity).GetValue(entity, null).ToBool();
			var codmovstk = GetValue("Codmovstk", entity).ToDecimal(); //Utilities.GetProperty("Codmovstk", entity).GetValue(entity, null).ToDecimal();
            var ccusto = "";
            if (pos)
            {
                ccusto = GetValue("Ccusto", entity)==null?"":GetValue("Ccusto", entity).ToString();  
            }
                
			if (!movstk) return (true, "");
			foreach (var r in dt.AsEnumerable())
			{
				if (r == null) continue;
                if (r.RowState== DataRowState.Deleted) continue;
				filhastamp = r[0].ToString();
				if (r["Servico"].ToBool()) continue;
				if (string.IsNullOrEmpty(r["ststamp"].ToString())) continue;
                if (r["Armazem"].ToDecimal() == 0)
                {
                    return (false, $"O artigo:{r["descricao"]} tem armazem vazio. Verifique ");
                }
				if (codmovstk > 50)
				{
					string querry;
                    querry =$@"Select * from STExtratoficha('{r["ststamp"].ToString().Trim()}') where Armazemstamp='{r["Armazemstamp"].ToString().Trim()}'"; 
					var crTst = SQL.GetGenDt(querry);
					if (crTst?.Rows.Count > 0)
					{
						var stock = crTst.Rows[0]["stock"].ToDecimal();
                        var quant = r["Quant"].ToDecimal();
                        if (r.RowState == DataRowState.Modified)
                        {
                            var quant2 = SQL.GetValue($"select quant from {dt.TableName.Trim()} where {dt.TableName.Trim()}stamp ='{filhastamp.Trim()}'").ToDecimal();
                            quant = (quant2 > quant) ? quant2-quant : quant-quant2;  
                        }

						if (stock < quant)
						{
							if (usalote && r["Usalote"].ToBool() && !string.IsNullOrEmpty(r["Lote"].ToString()))
							{
								return (false, $"Desculpe mas o artigo: {r["Descricao"]} lote {r["Lote"]} não tem stock suficiente. \r\n Stock existente: {stock} \r\n Não pode gravar!");
							}
                            if (pos)
                            {
                                var verificar = SQL.GetGenDt($"select Ccu_Arm.codarm from Ccu_Arm inner join CCu on Ccu_Arm.Ccustamp = CCu.Ccustamp where ccu.Descricao='{ccusto}'");
                                if (!(verificar?.Rows.Count > 0)) continue;
                                var arm = "";
                                for (var i = 0; i < verificar.Rows.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        arm = $"'{verificar.Rows[i]["codarm"]}'";
                                    }
                                    else
                                    {
                                        arm = arm + $",'{verificar.Rows[i]["codarm"]}'";
                                    }
                                }
                                var xx = $"select top 1 Stock,Codarm,Descricao from Starm where Stock>0 and ltrim(rtrim(Ref))='{r["ref"].ToString().Trim()}' and Starm.codarm in ({arm})";
                                var starm = SQL.GetGenDt(xx);
                                if (starm?.Rows.Count > 0)
                                {
                                    if (starm.Rows[0]["Stock"].ToDecimal()>r["Quant"].ToDecimal())
                                    {
                                        r["armazem"] = starm.Rows[0]["Codarm"];
                                        r["Descarm"] = starm.Rows[0]["Descricao"];
                                    }
                                    else
                                    {
                                        return (false, $"Desculpe mas o artigo: {r["Descricao"]} não tem stock suficiente. \r\n {starm.Rows[0]["Stock"]} Unidades de stock existente \r\n Não pode gravar!");    
                                    }
                                }
                                else
                                {
                                    return (false, $"Desculpe mas o artigo: {r["Descricao"]} não tem stock suficiente. \r\n {stock} Unidades de stock existente \r\n Não pode gravar!");
                                }
                            }
                            else
                            {
                                return (false, $"Desculpe mas o artigo: {r["Descricao"]} não tem stock suficiente. \r\n {stock} Unidades de stock existente \r\n Não pode gravar!");      
                            }
							
						}
                    }
                    else
                    {
                        return (false, $"Desculpe mas o artigo: {r["Descricao"]} não tem stock.\r\n Não pode gravar!");
                    }
                }
            }
			return (true, "");
		}

        public static (bool StkExiste, string Messagem) CheckStock(DataTable dt)
        {
            foreach (var r in dt.AsEnumerable())
            {
                if (r == null) continue;
                if (r["Servico"].ToBool()) continue;
                if (string.IsNullOrEmpty(r["Ref"].ToString())) continue;
                if (r["Armazem"].ToDecimal() == 0)
                {
                    return (false, "O armazem está vazio. Verifique ");
                }
                var querry = $@"select (Stock-Reserva) as StockPermitido from 
                                Starm where ref='{r["Ref"].ToString().Trim()}' and Codarm={r["Armazem"].ToDecimal()}";//

                var crTst = SQL.GetGenDt(querry);
                if (!(crTst?.Rows.Count > 0)) continue;
                var stock = crTst.Rows[0]["StockPermitido"].ToDecimal();
                if (stock < r["Quant"].ToDecimal())
                {
                    return (false, $"Desculpe mas o artigo: {r["Descricao"]} não tem stock suficiente. \r\n {stock} Unidades de stock existente \r\n Não pode gravar!");
                }
            }
            return (true, "");
		}

		public static void TotaisLinhas(DataRow dr,bool ivaIncluso =false)
		{
            if (dr==null) return;
			if (dr.RowState == DataRowState.Deleted) return;
            var ivc = ivaIncluso || dr["Ivainc"].ToBool();

            decimal valorIva = 0;
            decimal mvalorIva = 0;
            if (ivc)
            {
                valorIva = dr["Preco"].ToDecimal()-dr["Preco"].ToDecimal() / (1 + dr["Txiva"].ToDecimal() / 100);
                dr["Subtotall"] = (dr["Quant"].ToDecimal() * dr["Preco"].ToDecimal() / (1 + dr["Txiva"].ToDecimal() / 100)).ToRound();

                 mvalorIva = dr["mPreco"].ToDecimal()-dr["mPreco"].ToDecimal() / (1 + dr["Txiva"].ToDecimal() / 100);
                dr["mSubtotall"] = (dr["Quant"].ToDecimal() * dr["mPreco"].ToDecimal() / (1 + dr["Txiva"].ToDecimal() / 100)).ToRound();
            }
            else
            {
                dr["Subtotall"] = (dr["Quant"].ToDecimal() * dr["Preco"].ToDecimal()).ToRound();
                dr["mSubtotall"] = (dr["Quant"].ToDecimal() * dr["mPreco"].ToDecimal()).ToRound();
            }
			var subtotal = dr["Subtotall"].ToDecimal();
            var msubtotal = dr["mSubtotall"].ToDecimal();
            if (dr["perdesc"].ToDecimal() >0)
            {
                if (ivc)
                {
                    dr["Descontol"] = ((subtotal-valorIva) * dr["Perdesc"].ToDecimal() / 100).ToRound(); 
                     dr["mDescontol"] = ((msubtotal-mvalorIva) * dr["Perdesc"].ToDecimal() / 100).ToRound(); 
                    dr["Subtotall"]=dr["Subtotall"].ToDecimal()-dr["Descontol"].ToDecimal();
                    dr["mSubtotall"]=dr["mSubtotall"].ToDecimal()-dr["mDescontol"].ToDecimal();
                }
                else
                {
                    dr["Descontol"] = (subtotal * dr["Perdesc"].ToDecimal() / 100).ToRound(); 
                    dr["mDescontol"] = (msubtotal * dr["Perdesc"].ToDecimal() / 100).ToRound();
                    dr["Subtotall"]=dr["Subtotall"].ToDecimal()-dr["Descontol"].ToDecimal();
                    dr["mSubtotall"]=dr["mSubtotall"].ToDecimal()-dr["mDescontol"].ToDecimal();
                }
            }
            else if (dr["Descontol"].ToDecimal() >0)
            {
                if (ivc)
                {
                    dr["Perdesc"]=(dr["Descontol"].ToDecimal()/(subtotal-valorIva).ToDecimal()*100).ToDecimal().ToRound(); 
                    dr["mDescontol"] = ((msubtotal-mvalorIva) * dr["Perdesc"].ToDecimal() / 100).ToRound(); 
                    dr["Subtotall"]=dr["Subtotall"].ToDecimal()-dr["Descontol"].ToDecimal();
                    dr["mSubtotall"]=dr["mSubtotall"].ToDecimal()-dr["mDescontol"].ToDecimal();
                }
                else
                {
                    dr["Perdesc"]=(dr["Descontol"].ToDecimal()/subtotal*100).ToRound(); 
                    dr["mDescontol"] = (msubtotal * dr["Perdesc"].ToDecimal() / 100).ToRound();
                    dr["Subtotall"]=dr["Subtotall"].ToDecimal()-dr["Descontol"].ToDecimal();
                    dr["mSubtotall"]=dr["mSubtotall"].ToDecimal()-dr["mDescontol"].ToDecimal();
                }
            }
            var ivaposdesconto = SQL.GetField("Ivaposdesconto", "param").ToBool();
            if (ivaposdesconto)
            {
                dr["valival"] = ((subtotal-dr["Descontol"].ToDecimal()) * dr["Txiva"].ToDecimal() / 100).ToRound();
                dr["mvalival"] = ((msubtotal-dr["mDescontol"].ToDecimal()) * dr["Txiva"].ToDecimal() / 100).ToRound();
            }
            else
            {
                dr["valival"] = (subtotal * dr["Txiva"].ToDecimal() / 100).ToRound(); 
                dr["mvalival"] = (msubtotal * dr["Txiva"].ToDecimal() / 100).ToRound();
            }
            dr["Totall"] = (subtotal - dr["Descontol"].ToDecimal() + dr["valival"].ToDecimal()).ToRound();
            dr["mTotall"] = (msubtotal - dr["mDescontol"].ToDecimal() + dr["mvalival"].ToDecimal()).ToRound();
		}
        public static void TotaisLinhasItem(DataRow dr)
        {
            if (dr == null) return;
            if (dr.RowState == DataRowState.Deleted) return;
            var quant = dr["Quant"].ToDecimal();
            var preco = dr["Preco"].ToDecimal();
            var txiva = dr["Txiva"].ToDecimal();
            var perdesc = dr["Perdesc"].ToDecimal();
            var ivc = dr["Ivainc"].ToBool();
            dr["Subtotall"] = ivc ? (quant * preco / (1 + txiva / 100), 1) : (quant * preco, 1);
            var subtotal = dr["Subtotall"].ToDecimal();
            dr["Descontol"] = (subtotal * perdesc / 100, 1);
            var descontol = dr["Descontol"].ToDecimal();
            dr["valival"] = ((subtotal - descontol) * txiva / 100, 1);
            var valiva = dr["valival"].ToDecimal();
            dr["Totall"] = (subtotal - descontol + valiva, 1);
        }

        private static PropertyInfo[] _props;
	
        private static void NewMethod(DataRow dr, string moedavenda, bool Sempreconamoedadevenda, decimal valor, decimal aredondamento)
        {
            var txcambio = SQL.ExecCambio(moedavenda);
            if (!Sempreconamoedadevenda)
            {
                dr["Preco"] = valor;
                if (txcambio > 0)
                {
                    dr["mpreco"] = (valor / txcambio).ToRound();
                }
            }
            else
            {
                dr["Preco"] = (valor * txcambio).ToRound();
                dr["mpreco"] = valor;
            }
            dr["Cambiousd"] = txcambio;
        }

        private static object GetValue<T>(string campo, T ent) where T : class
        {
            object valor = null;
            var p = _props.ToList().FirstOrDefault(x => x.Name.ToLower().Equals(campo.ToLower()));
            if (p!=null)
            {
                valor= p.GetValue(ent, null);
            }

            return valor;
        }
        private static string GetPropName(string campo,string nomeclasse = null)
        {
            if (nomeclasse==null)
            {
                return _props.ToList().FirstOrDefault(x => x.Name.ToLower().Contains(campo.ToLower()) && x.Name.Trim().ToLower().Contains(nomeclasse.ToLower().Trim())).Name;
            }
            return _props.ToList().FirstOrDefault(x => x.Name.ToLower().Contains(campo.ToLower())).Name;
        }

     	public static (bool Correcto, string Messagem) CheckSaldo(DataTable formaspdt)
		{
			(bool Correcto, string Messagem) vals = (false, "Deve inserir a tesouraria!");
			if (formaspdt == null) return vals;
			var val = formaspdt.AsEnumerable().Sum(x => x.Field<decimal>("Valor")).ToDecimal();
			foreach (var r in formaspdt.AsEnumerable())
			{
				if (r == null) continue;
                var contasstamp = r["Contasstamp"].ToString().Trim();
                var conta = r["Contatesoura"].ToString();
				var dt = SQL.GetGenDt($"select saldo,Noneg from contas where ltrim(rtrim(Contasstamp))='{contasstamp}'");
				if (dt?.Rows.Count == 0) continue;
                var saldo = dt.Rows[0]["saldo"].ToDecimal();
                if (saldo < val)
                {
                    if (dt.Rows[0]["Noneg"].ToBool())
                    {
                        vals.Correcto = false;
                        vals.Messagem = $"A conta {conta} não tem saldo suficiente! \r\n Saldo disponínel é: {saldo} meticais! ";
                        return vals;
                    }
                }
                vals.Correcto = true;
                vals.Messagem = "";
            }
            return vals;
		}
        public static DataTable ClCc2(string no)
        {            
            var dt = SQL.GetGenDt($"select * from Clccf() where Clstamp='{no}' order by Convert(decimal,nrdoc) asc,Convert(date,data)");
            return dt;
        }
		public static decimal MesaValor(decimal no)
		{
			 decimal valor = 0;
			 var qry = $@"select debito from  cc left join rcll on 
						cc.ccstamp = rcll.ccstamp where no ={no} 
						and cc.origem in ('FT') and debito-debitof>0 order by no";
			 var dt = SQL.GetGenDt(qry);
			 if (dt?.Rows.Count>0)
			 {
				 valor = dt.Rows[0]["debito"].ToDecimal();
			 }
			 return valor;
		}
		public static DataTable ExtratoProduto(string dData1, string dData2, string chkArmazem,string referec)
		{
            var qry =$"select * from STExtrato('{referec}','{dData1}','{dData2}') where saldo<>0  {chkArmazem} order by ordem, dataordem ";
			return SQL.GetGenDt(qry);
		}
        public static DataTable ExtratoProdutoFam(DateTime dData1, DateTime dData2, string familia)
        {
           var qry = $@"SELECT iif(year(data2)='1900',CONVERT(char(12), 0, 104),CONVERT(char(12), data2, 104)) as data,ref,descricao,descmovstk,nrdoc,entrada,saida,saldo from (
	                SELECT *,sum(entrada-saida) over(PARTITION BY ref  order by tmp2.data2 rows unbounded preceding) as saldo,Familia=(SELECT top 1 dbo.st.Familia FROM st WHERE Referenc =tmp2.ref) FROM (
	                select * from (
		                Select 0 as data2,ref,descricao,descmovstk='Saldo Alterior',nrdoc=0,isnull(SUM(entrada),0) entrada,isnull(SUM(saida),0) saida,ordem=1 from mstk where CONVERT(date, data) < '{dData1.Date.ToSqlDate()}' GROUP BY ref,descricao
		                union ALL
		                Select data as data2,ref,descricao,descmovstk,nrdoc,entrada,saida,ordem=2  from mstk	where CONVERT(date, data) >= '{dData1.Date.ToSqlDate()}' and CONVERT(date, data)<='{dData2.Date.ToSqlDate()}'
	                )tmp1)tmp2)tmp3 where  tmp3.Familia ='{familia}' ORDER BY tmp3.Ref,tmp3.ordem";

            return SQL.GetGenDt(qry);
        }
		public static DataTable DiTrf(string distamp)
		{
			var qry = $@"select Referenc =ref,Descricao,Quant,totall as Valor,
                        Convert(varchar,di.data,103) as Data,di.descarm as Saida,descarm2 as Entrada,Nome,numero,Ccusto
                        from di join dil on di.Distamp=dil.Distamp where trf=1 and di.Distamp='{distamp.Trim()}'";
			return SQL.GetGenDt(qry);
		}
		public static DataTable DiMstk(string distamp)
		{
			var qry = $@"select Ref,descricao,quant=IIF( Entrada=0, Saida,Entrada),
						data=Convert(varchar,data,103),Nome,
						Armazem=(select descricao from Armazem where Codigo=Codarm),
						Ccusto=(select Ccusto from di where Distamp=Mstk.Distamp),Nrdoc as numero,Documento
						from Mstk where Origem='DI' and distamp='{distamp.Trim()}'";

			return SQL.GetGenDt(qry);
		}
		public static DataTable DiMvt(string distamp)
		{
			var qry = $@"mvt.Titulo,Local,Dcheque,valor =iif(Entrada=0,Saida,entrada),mvt.Banco,Nrdoc,Ccusto,Distamp,
						 Numero from mvt join Formasp on mvt.Formaspstamp=formasp.Formaspstamp 
						 where mvt.Origem='DI' and Distamp='{distamp.Trim()}'";
			return SQL.GetGenDt(qry);
		}
		
        public static DataTable PrintCaixa( DateTime dDatCaixa,decimal nNumCaixa)
        {
            var qry = $@"SELECT grupo,ordem,consumo,ref,descricao,SUM(quant) Qtt,Preco,perdesc,SUM(totall) Totall FROM (
 	                         Select grupo=1,ordem=0,consumo='',ref='',descricao='Saldo Inicial',quant=0,Preco=0,perdesc=0,totall=inicial
 	                          from Caixa where data='{dDatCaixa.ToSqlDate()}' and numero={nNumCaixa}
	                          union all 
	                        Select grupo=1,ordem=1,consumo='Normal',Factl.ref,Factl.descricao,Factl.quant,Factl.Preco,factl.perdesc,Factl.totall
 	                         from factl inner join (Select ccstamp from RCLL inner join mvt on rcll.rclstamp=mvt.rclstamp 
 	                        where mvt.datcaixa='{dDatCaixa.ToSqlDate()}' and mvt.numcaixa={nNumCaixa}) tmp1 on Factl.Factstamp=tmp1.ccstamp and factl.perdesc=0
	                        union all
	                        Select grupo=1,ordem=2,consumo='Com Desconto',Factl.ref,Factl.descricao,Factl.quant,Factl.Preco,factl.perdesc,Factl.totall
 	                         from factl inner join (Select ccstamp from RCLL inner join mvt on rcll.rclstamp=mvt.rclstamp 
 	                        where mvt.datcaixa='{dDatCaixa.ToSqlDate()}' and mvt.numcaixa={nNumCaixa})tmp1
 	                         on Factl.Factstamp=tmp1.ccstamp and factl.perdesc between 1 and 99
	                        union all  
	                        Select grupo=1,ordem=3,consumo='Consumo Interno',Factl.ref,Factl.descricao,Factl.quant,Preco=0,factl.perdesc,totall=0
 	                         from factl inner join (Select ccstamp from RCLL inner join mvt on rcll.rclstamp=mvt.rclstamp 
 	                        where mvt.datcaixa='{dDatCaixa.ToSqlDate()}' and mvt.numcaixa={nNumCaixa})tmp1
 	                         on Factl.Factstamp=tmp1.ccstamp and factl.perdesc=100
	                         union all
	                         select grupo=1,ordem=4,consumo='Saidas',ref='',descricao,quant=0,Preco=0,perdesc=0,totall=(saida*-1)
	                         from mvt where saida<>0 and mvt.datcaixa='{dDatCaixa.ToSqlDate()}' and mvt.numcaixa={nNumCaixa}
	                         union all
	                         select grupo=2,ordem=5,consumo='',ref='',descricao='',quant=0,Preco=0,perdesc=0,totall=0
                             union all
	                         select grupo=2,ordem=6,consumo='',ref='',descricao='',quant=0,Preco=0,perdesc=0,totall=0
	                         union all
	                         select grupo=2,ordem=7,consumo='Formas de Pagamento',ref='',ftpagar.descricao,quant=0,Preco=0,perdesc=0, totall=SUM(ftpagar.valor2)
	                         from mvt inner join ftpagar on mvt.rclstamp=ftpagar.rclstamp 
	                         where mvt.datcaixa='{dDatCaixa.ToSqlDate()}' and mvt.numcaixa={nNumCaixa} and ftpagar.valor <> 0 
	                         group by ftpagar.descricao	 	 
 	                        )tmp1 group by consumo,ref,descricao,Preco,perdesc,grupo,ordem order by grupo,ordem";
            return SQL.GetGenDt(qry);
        }
        public static DataTable PrintPos(string factstamp,decimal no)
        {
            var querry = $@"Select fact.Nomedoc,Fact.data,fact.sigla,Fact.NO,Fact.dataven,fact.nome,fact.Morada,fact.nuit,fact.Moeda,fact.subtotal,
			    fact.totaliva,fact.total,fact.perdesc,fact.obs,Factl.Preco,Factl.perdesc as Perdescl,factl.unidade,factl.subtotall,factl.totall,
			    factl.quant,factl.descricao,factl.ref,factl.txiva,factl.valival,factl.composto, fact.Anulado,fact.numero,fact.coment,fact.desconto,
			    factl.tit,factl.ivainc from Fact left join Factl on Fact.factstamp = Factl.factstamp WHERE
                    Fact.mesa={no} and Fact.factstamp ='{factstamp}'
                 Order By Fact.numero,Factl.Ordem";
            return SQL.GetGenDt(querry);
        }

       
        public static DataTable GetCc(string stamp, string nomeFuncao,string tabela)
        {
            var dt = SQL.GetGenDt($"select * from {nomeFuncao.Trim()}() where {tabela.Trim()}stamp='{stamp.Trim()}'  order by origem,nrdoc");
            return dt;
        }
        public static DataTable PeCc(decimal no,string cMoedaBase)
        {
            var lista = new List<SqlParameter>();
            var moeda = new SqlParameter("@cMoedaBase", SqlDbType.Char) {Value = cMoedaBase};
            lista.Add(moeda);
            var p = new SqlParameter("@no", SqlDbType.Int) {Value = no};
            lista.Add(p);
            return SQL.SqlSP("GetPeCC",lista);
        }
      
        public static DataTable GetContas(string usrstamp)
        {
            var str = $@"select descpos as Descricao,Cast(0 as decimal) as valor,conta, cx,conta as contas,Contasstamp,Codtz,Titulo =iif(cx=1,'NUMERARIO','TRANSF. BANCARIA') from Usrcontas where Usrstamp='{usrstamp.Trim()}' order by cx desc ";
            return SQL.GetGenDt(str);
        }
      
        public static DataTable CambiaLinhas(DataTable dt,decimal TaxaCambio,string MoedaCambio,string Moeda)
        {
            foreach (var dr in dt.AsEnumerable())
            {
                if (TaxaCambio>0)
                {
                    dr["mpreco"] =(dr["Preco"].ToDecimal()/TaxaCambio).ToRound();
                }                
                dr["moeda"] =Moeda;
                dr["moeda2"] =MoedaCambio;
                dr["Cambiousd"] =TaxaCambio;
                TotaisLinhas(dr);
            }
            return dt;            
        }
    }
}
