using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Security.Policy;
namespace SistemaCadastro
{
    internal class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=sql10.freemysqlhosting.net;user id=sql10668343;password=4k2aswLbr6;database=sql10668343");
        public string mensagem;

        public bool insereCliente(Cliente novoCliente)
        {
            MySqlCommand cmd = new MySqlCommand("sp_insereCliente", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nome", novoCliente.NomeCliente);
            cmd.Parameters.AddWithValue("cpf", novoCliente.CpfCliente);
            cmd.Parameters.AddWithValue("email", novoCliente.EmailCliente);
            cmd.Parameters.AddWithValue("endereco", novoCliente.EnderecoCliente);
            cmd.Parameters.AddWithValue("bairro", novoCliente.BairroCliente);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = "Erro:" + erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        public DataTable listaClientes()
        {
            MySqlCommand cmd = new MySqlCommand("sp_listaCliente", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
        public DataTable listaPets()
        {
            MySqlCommand cmd = new MySqlCommand("sp_listaPet", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
        
        public bool deletaCliente(int codCliente)
        {
            MySqlCommand cmd = new MySqlCommand("sp_deletaCliente", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codCli", codCliente);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
        public bool alteraCliente(Cliente c, int codCliente)
        {
            MySqlCommand cmd = new MySqlCommand("sp_alteraCliente", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codCli", codCliente);
            cmd.Parameters.AddWithValue("nome", c.NomeCliente);
            cmd.Parameters.AddWithValue("cpf", c.CpfCliente);
            cmd.Parameters.AddWithValue("email", c.EmailCliente);
            cmd.Parameters.AddWithValue("endereco", c.EnderecoCliente);
            cmd.Parameters.AddWithValue("bairro", c.BairroCliente);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
        public bool inserePet(Pet novoPet)
        {
            MySqlCommand cmd = new MySqlCommand("sp_inserePet", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nome", novoPet.NomePet);
            cmd.Parameters.AddWithValue("raca", novoPet.RacaPet);
            cmd.Parameters.AddWithValue("porte", novoPet.PortePet);
            cmd.Parameters.AddWithValue("tipo", novoPet.TipoPet);
            cmd.Parameters.AddWithValue("cor", novoPet.CorPet);
            cmd.Parameters.AddWithValue("codCli", novoPet.DonoPet);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
        public bool deletaPet(int codPet)
        {
            MySqlCommand cmd = new MySqlCommand("sp_deletaPet", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codP", codPet);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
        public bool alteraPet(Pet p, int codPet)
        {
            MySqlCommand cmd = new MySqlCommand("sp_alteraPet", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codP", codPet);
            cmd.Parameters.AddWithValue("nome", p.NomePet);
            cmd.Parameters.AddWithValue("tipo", p.TipoPet);
            cmd.Parameters.AddWithValue("cor", p.CorPet);
            cmd.Parameters.AddWithValue("raca", p.RacaPet);
            cmd.Parameters.AddWithValue("porte", p.PortePet);
            cmd.Parameters.AddWithValue("codCli", p.DonoPet);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
        public bool verifica(string user, string pass)
        {
            string senhaHash = Hash.makeHash(pass);
            MySqlCommand cmd = new MySqlCommand("sp_consultaLogin", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nomeU", user);
            cmd.Parameters.AddWithValue("senhaU", senhaHash);
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds); 
                if (ds.Tables[0].Rows.Count > 0) 
                    return true;
                else
                    return false;

            }
            catch (MySqlException er)
            {
                mensagem = "Erro" + er.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
        public bool insereUsuarios(Usuario u)
        {
            MySqlCommand cmd = new MySqlCommand("sp_insereUser", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nomeU", u.NomeUser);
            cmd.Parameters.AddWithValue("senhaU", u.SenhaUser);
            cmd.Parameters.AddWithValue("emailU", u.EmailUser);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
