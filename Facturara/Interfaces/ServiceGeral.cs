using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using DAL.Extensions.Extensions;
using Microsoft.EntityFrameworkCore;
using Model.Models.Gene;
using Model.Models.SJM;
using Newtonsoft.Json;
using SGPMAPI.SharedClasses;
using EF = DAL.BL.EF;

namespace SGPMAPI.Interfaces
{
    public class ServiceGeral : InterGeral
    {
        public readonly SGPMContext ApIcontext;
        private readonly IGenericRepository<object> _peRepository;
        public ServiceGeral(SGPMContext descricaoAPi, IGenericRepository<object> peRepository)
        {
            ApIcontext = descricaoAPi;
            _peRepository = peRepository;
        }
        
        public async Task<object> AddOrUpdateAsync(object entity)
        {
            var tipo = entity.GetType();
            var keyProp = tipo.GetProperties()
                .FirstOrDefault(prop => prop.GetCustomAttribute<KeyAttribute>() != null);
            if (keyProp == null)
                throw new Exception("A entidade precisa ter a chave.");
            var keyVal = keyProp.GetValue(entity)?.ToString() ?? "";
            var dbSet = ApIcontext.GetType().GetProperties()
                .FirstOrDefault(p =>
                    p.PropertyType.IsGenericType &&
                    p.PropertyType.GenericTypeArguments[0] == tipo)
                ?.GetValue(ApIcontext);
            if (dbSet == null)
                throw new Exception($"Não existe uma tabela com o nome {tipo.Name}.");
            var existe = SQL.CheckExist(keyProp.Name, tipo.Name, $@"{keyProp.Name}='{keyVal}'");
            var method = existe
                ? nameof(DbContext.Update)
                : nameof(DbContext.Add);
             typeof(DbContext)
                .GetMethod(method, new[] { typeof(object) })!
                .Invoke(ApIcontext, new[] { entity });

            await ApIcontext.SaveChangesAsync();
            return entity;
        }

     
        private bool DeveConter(string senha)
        {
            var re = "^(?:(?:(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]))|(?:(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\\]))|(?:(?=.*[0-9])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\\]))|(?:(?=.*[0-9])(?=.*[a-z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\\]))).{6,32}$";
            if (!Regex.IsMatch(senha, re))
            {
                return false;
            }
            return true;
        }
        public int AlterarSenha(string novaSenha, string entra, string login, string antigaSenha)
        {
            var qry = $"update Usuario set senha='{novaSenha}',priEntrada=0,Passwordexperaem='' where login='{login}' and senha='{antigaSenha}'";
            return SQL.SqlCmd(qry);
        }
        readonly Cryptografia _objCrypto = new();
        public async Task<ServiceResponse<Usuario>> TrocarSenha(Busca  busca)
        {
            ServiceResponse<Usuario> serviceResponse = new ServiceResponse<Usuario>();
            if (DeveConter(busca.alterou.Trim()))
            {
                try
                {
                    var antigasenhacryptagrafada = _objCrypto.Crypto(busca.inseriu.Trim(), true);
                    var novasenhacryptagrafada = _objCrypto.Crypto(busca.alterou.Trim(), true);

                    var check = SQL.CheckExist(
                        $"select login from usuario where login='{busca.descricao.Trim()}' and senha='{antigasenhacryptagrafada.Trim()}'");
                    if (!check)
                    {
                        serviceResponse.Dados = new Usuario();
                        serviceResponse.Mensagem = $"Não foi possível executar a operação.\nUsuário inexistente na nossa base de dados\nContacte o administrador!";
                        serviceResponse.Sucesso = false;
                        return serviceResponse;
                    }
                    var valor = AlterarSenha(novasenhacryptagrafada.Trim(), 1.ToString(), busca.descricao.Trim(), antigasenhacryptagrafada.Trim());
                    if (valor==0)
                    {
                        serviceResponse.Dados = new Usuario();
                        serviceResponse.Mensagem = $"Não foi possível executar a operação. Contacte o administrador!";
                        serviceResponse.Sucesso = false;
                        return serviceResponse;
                    }
                    var dt = SQL.GetRowToEnt<Usuario>($"login='{busca.descricao.Trim()}' and senha='{novasenhacryptagrafada.Trim()}'");
                    serviceResponse.Dados = dt;
                    serviceResponse.Mensagem = "";
                    serviceResponse.Sucesso = true;
                    return serviceResponse;
                }
                catch (Exception ex)
                {

                    serviceResponse.Dados = new Usuario();
                serviceResponse.Mensagem = $"Não foi possível executar a operação. Contacte o administrador!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
            }
            serviceResponse.Dados = new Usuario();
            serviceResponse.Mensagem = $"A senha deve conter pelo menos uma letra maiúscula\nminúscula, caracter especial e número";
            serviceResponse.Sucesso = false;
            return serviceResponse;
        }


        
        public async Task<PaginationResponseBl<List<object>>> GetGrades(ModeloPaginacao model)
        {
            var nimdescricao = model.nimdescricao;
            if (nimdescricao == "vazioxvt")
            {
                nimdescricao = "";
            }
            int currentNumber = model.currentNumber;
            int pagesize = model.pagesize;
            var tabela = model.Tabela;
            var camposel = model.Camposelecao;
            var camposOrderbCamposOrby = model.CamposOrdyby;
            int num3 = pagesize;
            int num2 = (currentNumber - 1) * pagesize;
            try
            {
                int num1 = 50;
                pagesize = pagesize < num1 ? pagesize : num1;
                var interpolatedStringHandler = $@"select count(*) from {tabela} where 
lTrim(rTrim({camposel})) like '%{nimdescricao.Trim()}%'
select * from {tabela} where lTrim(rTrim({camposel})) like '%{nimdescricao.Trim()}%' 
order by {camposOrderbCamposOrby} OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
                var ddd= await ConvertToPaginationpeviw(await _peRepository.
                     GetObjectPaginationf(currentNumber, pagesize, interpolatedStringHandler));
             return ddd;
            }
            catch
            {
                throw;
            }
        }
       
        private async Task<PaginationResponseBl<List<object>>> ConvertToPaginationpeviw(
            PaginationResponseBl<List<object>> professor)
        {
            return new PaginationResponseBl<List<object>>(professor.TotalCount, GetConvertTovie(professor.Data),
                professor.CurrentPageNumber, professor.PageSize);
        }


        private List<T> GetConvertTovie<T>(List<T> professorData)
        {
            List<T> convertToProfessorview = new List<T>();
          

            return convertToProfessorview;
        }
       

      

        public async Task<bool> Editar(object modelo1)
        {
            var fff = JsonConvert.SerializeObject(modelo1);
            //var modelo = JsonConvert.DeserializeObject<T>(fff);
            if (modelo1 == null)
                throw new TaskCanceledException("Anolect não existe");
            int num = await _peRepository.Editar(modelo1) ? 1 : 0;
            if (num == 0)
                throw new TaskCanceledException("Nao foi possivel eliminar Anolect");
            var flag = num != 0;
            return flag;
        }



        public async Task<bool> Eliminargradel(string id, string tabela, string nomecolunachave)
        {
            try
            {


                var dt = await _peRepository.GetDataTable($"select {nomecolunachave} from {tabela} where {nomecolunachave}='{id}'");
                if (dt.HasRows())
                {

                    bool num = SQL.SqlCmd($"delete {tabela} where {nomecolunachave}='{id}'") > 0;
                    return num;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


       
        public async Task<bool> Eliminar<T>( T? entity, string id,string nomecolunaxave) where T : class, new()
        {
            bool flag;
            try
            {
                var entidade = entity.GetType();
                var modelo = entity;
                var dt = await _peRepository.GetDataTable($"select * from {entidade.Name} where {nomecolunaxave}='{id}'");
                if (dt.HasRows())
                {
                    modelo = dt.Rows[0].DrToEntity<T>();
                }
                if (modelo == null)
                    throw new TaskCanceledException($"{entidade.Name} não existe");
                int num = await _peRepository.Eliminar(modelo) ? 1 : 0;
                if (num == 0)
                    throw new TaskCanceledException($"Nao foi possível eliminar {entidade.Name}");
                flag = false;
            }
            catch
            {
                throw;
            }
            return flag;
        }

        public async Task<T> Criar<T>(T? entity, string stamp = "") where T : class, new()
        {
            try
            {
              var ret= await EF.Save(entity);
              if (ret.ret > 0)
              {
                  return entity;
              }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return null;
        }

        public async Task<ServiceResponse<Selectview>> Comboboxes(string tabela, string campo1, string campo2, string condicao = "")
        {
            if (condicao.ToLower().Equals("vazio"))
            {
                condicao = "";
            }
            if (!condicao.IsNullOrEmpty())
            {
                condicao = $" where {condicao}";
            }

            var chave = tabela;
            if (tabela.Equals("Paise"))
            {
                tabela = $"Paises";
            }
            if (tabela.ToLower().Equals("status"))
            {
                chave = $"Statu";
            }
            ServiceResponse<Selectview> serviceResponse = new ServiceResponse<Selectview>();

            var dt = await _peRepository.GetDataTable($" select '' Chave,''Descricao,''Ordem union all " +
                                                      $" select {chave}stamp Chave, convert(nvarchar(max), {campo1}) Descricao, convert(nvarchar(max), {campo2})  " +
                                                      $"Ordem from {tabela} {condicao} order by Ordem asc");
            var sss = dt.DtToList<Selects>();
            List<Selects?> estudanteList = sss;
            var e = new Selectview();
            e.Selects = estudanteList;
            serviceResponse.Dados = e;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }

    }


}
