using PdfSharp.Pdf.Content.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models.Gene;

namespace DAL.BL
{

    public class UtilizadorNegocio
    {
        #region Instancias

        Conexsao conexao = new();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Usuario";

        string sqlDefault = "SELECT milStamp, NomeLogin, CASE WHEN Ativo='True' THEN 'Ativo' ELSE 'Inativo' END AS Ativo, NomeLogin, Senha, tipoPerfil, DataCadastro FROM Usuario ";

        string sqlDataSource = "SELECT milStamp, Nome, CASE WHEN Ativo='True' THEN 'Ativo' ELSE 'Inativo' END AS Ativo, NomeLogin, Senha, tipoPerfil, DataCadastro FROM Usuario ";

        #endregion

        #region Métodos Publicos 

        public bool Inserir(Utilizador user)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(user));
        }
        public bool Alterar(string tabela, Utilizador user, string campo, string cond)
        {
            return conexao.Atualizar(tabela, PreencheParametros(user), campo, cond);
        }


        public bool Excluir(string tabela, string campo, string chave)
        {
            return conexao.Excluir(tabela, campo, chave);
        }

        public DataTable Tabela(string tabela, string nomecoluna, string valorColuna)
        {
            return Geral.GetGen2Dt($"select * from {tabela} where {nomecoluna} ='{valorColuna}'");
        }
        public DataTable VerificaTabela(string selecionado)
        {
            return Geral.GetGen2Dt(selecionado);
        }
        public DataTable Tabelas(string tabela, string nomecoluna, string valorColuna, string senha, string valorSenha)
        {
            var qry = $"select * from {tabela} where {nomecoluna} ='{valorColuna}' and senha='{valorSenha}'";
            return Geral.GetGen2Dt(qry);
        }
        public int AlterarSenha(string novaSenha, string entra, string login, string antigaSenha)
        {
            var qry = $"update Usuario set senha='{novaSenha}',priEntrada={entra} where login='{login}' and senha='{antigaSenha}'";
            return conexao.AlterarSenha(qry);
        }
        public DataTable Tabela2(string qry)
        {
            return Geral.GetGen2Dt(qry);
        }
        public DataTable PesquisarPorNome(string nome)
        {
            return conexao.Pesquisar($"{sqlDefault} WHERE Nome LIKE '%{nome}%' ORDER BY Nome");
        }

        public DataTable PesquisarPorUsuario(string nomeLogin)
        {
            return conexao.Pesquisar($"{sqlDefault} WHERE NomeLogin = '{nomeLogin}' ORDER BY NomeLogin");
        }

        public string PesquisarUsuarioSenha(string senha)
        {
            var dtUsuario = conexao.Pesquisar($"{sqlDefault} WHERE Ativo = 'True' AND Senha = '{senha}'");

            if (dtUsuario.Rows.Count > 0)
            {
                return Convert.ToString(dtUsuario.Rows[0]["milStamp"].ToString());
            }
            return "";
        }

        public DataTable PesquisarUsuarioAtivos()
        {
            return conexao.Pesquisar($"{sqlDefault} WHERE Ativo = 'True'");
        }

        public DataTable PesquisarPorFormulario(int formulario)
        {
            return conexao.Pesquisar($"{sqlDefault} WHERE Formulario = {formulario}");
        }

        public DataTable PesquisarPorPemissaoUsuarios(string milStamp)
        {
            return conexao.Pesquisar($"{sqlDefault} WHERE milStamp ='{milStamp}'  ORDER BY Formulario");
        }

        public DataTable CarregarGridUsuario()
        {
            return conexao.Pesquisar($"{sqlDataSource} ORDER BY Nome");
        }

        #endregion

        #region Metodos Privados
        public int VerificaCodigo(string codunidade, string unidade)
        {
            return Geral.VerificaCodigo(codunidade, unidade);
        }
        private List<SqlParametros> PreencheParametros(Utilizador u)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>
            {
                new("paStamp", u.PaStamp),
                new("codUsuario", u.CodUsuario),
                new("nome", u.Nome),
                new("Medico", u.Medico),
                new("login", u.Login),
                new("senha", u.Senha),
                new("priEntrada", u.PriEntrada),
                new("activopa", u.ActivoMil),
                new("inseriu", u.Inseriu),
                new("inseriuDataHora", u.InseriuDataHora),
                new("alterou", u.Alterou),
                new("alterouDataHora", u.AlterouDataHora),
                new("tipoPerfil", u.Perfil),
                new("Sexo", u.Sexo)
            };


            return lstParametros;
        }

        #endregion

    }
}
