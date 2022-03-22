using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILTIFUL.Core.Entidades;

using System.Data;
using System.Data.SqlClient;

namespace BILTIFUL.Core.Banco
{
    public class bd_biltiful
    {
        public static string datasource = @"DESKTOP-KGQAT74";//instancia do servidor
        public static string database = "biltiful"; //Base de Dados
        public static string username = "sa"; //usuario da conexão
        public static string password = "246810"; //senha

        static string connString = @"Data Source=" + datasource + ";Initial Catalog="
                            + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

        SqlConnection connection = new SqlConnection(connString);

        //--------------------------------------

        public void InserirClienteBD(Cliente cliente)
        {
            using (connection)
            {
                connection.Close();
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("adicionar_cliente", connection);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@cpf_cliente", SqlDbType.NVarChar).Value = cliente.CPF;
                sql_cmnd.Parameters.AddWithValue("@nome_cliente", SqlDbType.NVarChar).Value = cliente.Nome;
                sql_cmnd.Parameters.AddWithValue("@data_nascimento", SqlDbType.DateTime).Value = cliente.DataNascimento;
                sql_cmnd.Parameters.AddWithValue("@sexo", SqlDbType.Char).Value = (char)cliente.Sexo;
                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void LocalizarCliente(string cpf)
        {
            Console.WriteLine("\t\tCliente");
            Console.WriteLine("===============================");

            connection.Open();

            string sql = "select cpf_cliente, nome_cliente, convert(varchar,data_nascimento, 103), sexo, situacao_cliente from tb_cliente where cpf_cliente =" + cpf;

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("\t\t\tCPF: {0}\n" +
                                          "\t\t\tNome: {1}\n" +
                                          "\t\t\tData Nascimento: {2}\n" +
                                          "\t\t\tSexo: {3}\n" +
                                          "\t\t\tSituação: {4}", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    }
                }
            }
            connection.Close();
        }

        public void ExibirRegistroClientes()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tCliente");
            Console.WriteLine("\t\t\t===============================");

            connection.Open();

            string sql = "select cpf_cliente, nome_cliente, convert(varchar,data_nascimento, 103), sexo, situacao_cliente from tb_cliente";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        Console.WriteLine("\n\t\t\tCPF: {0}\n" +
                                          "\t\t\tNome: {1}\n" +
                                          "\t\t\tData Nascimento: {2}\n" +
                                          "\t\t\tSexo: {3}\n" +
                                          "\t\t\tSituação: {4}", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    }
                }
            }
            connection.Close();
        }

        public void BuscaCpfClienteBD(string cpf)
        {
            using (connection)
            {
                connection.Close();
                connection.Open();
                string sql = "select cpf_cliente, nome_cliente from tb_cliente where cpf_cliente =" + cpf;

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("CPF: {0}\n" +
                                              "Nome: {1}\n", reader.GetString(0), reader.GetString(1));
                        }
                    }
                }

                connection.Close();
            }
        }

        //---------------------------- FORNECEDOR

        public void InserirFornecedorBD(Fornecedor fornecedor)
        {
            using (connection)
            {
                connection.Close();
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("adicionar_fornecedor", connection);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@cnpj_fornecedor", SqlDbType.NVarChar).Value = fornecedor.CNPJ;
                sql_cmnd.Parameters.AddWithValue("@razao_social", SqlDbType.NVarChar).Value = fornecedor.RazaoSocial;
                sql_cmnd.Parameters.AddWithValue("@data_abertura", SqlDbType.DateTime).Value = fornecedor.DataAbertura;
                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void LocalizarFornecedor(string cnpj)
        {
            Console.WriteLine("\n\t\t\tFornecedor");
            Console.WriteLine("\t\t\t===============================");

            connection.Open();

            string sql = "select cnpj_fornecedor, razao_social, convert(varchar,data_abertura, 103), convert(varchar,ultima_compra, 103), situacao_fornecedor from tb_fornecedor where cnpj_fornecedor =" + cnpj;

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("\t\t\tCNPJ: {0}\n" +
                                          "\t\t\tRazão Social: {1}\n" +
                                          "\t\t\tData Abertura: {2}\n" +
                                          "\t\t\tUltima Compra: {3}\n" +
                                          "\t\t\tSituação: {4}", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    }
                }
            }
            connection.Close();
        }

        public void ExibirRegistroFornecedor()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\tFornecedor");
            Console.WriteLine("\t\t\t===============================");

            connection.Open();

            string sql = "select cnpj_fornecedor, razao_social, convert(varchar,data_abertura, 103), convert(varchar,ultima_compra, 103), situacao_fornecedor from tb_fornecedor";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("\n\t\t\tCNPJ: {0}\n" +
                                          "\t\t\tRazão Social: {1}\n" +
                                          "\t\t\tData Abertura: {2}\n" +
                                          "\t\t\tUltima Compra: {3}\n" +
                                          "\t\t\tSituação: {4}", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    }
                }
            }
            connection.Close();
        }

        //----------------------------  PRODUTO

        public void InserirProdutoBD(Produto produto)
        {
            using (connection)
            {
                connection.Close();
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("adicionar_produto", connection);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@codiga_barra", SqlDbType.NVarChar).Value = produto.CodigoBarras;
                sql_cmnd.Parameters.AddWithValue("@nome_produto", SqlDbType.NVarChar).Value = produto.Nome;
                sql_cmnd.Parameters.AddWithValue("@valor_venda", SqlDbType.Decimal).Value = produto.ValorVenda;
                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void LocalizarProduto(string produto)
        {
            Console.WriteLine("\t\t\tProduto");
            Console.WriteLine("===============================");

            connection.Open();

            string sql = "select codigo_barra, nome_produto, valor_venda, convert(varchar, ultima_venda, 103), convert(varchar, data_cadastro, 103), situacao_produto from tb_produto where codigo_barra =" + produto;

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("\t\tCodigo Produto: {0}\n" +
                                          "\t\tNome Produto: {1}\n" +
                                          "\t\tValor Venda {2}\n" +                 
                                          "\t\tUltima Compra: {3}\n" +
                                          "\t\tData Cadastro: {4}\n" +
                                          "\t\tSituação: {5}", reader.GetString(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    }
                }
            }
            connection.Close();
        }

        //---------------------------- MATÉRIA PRIMA

        public void InserirMateriaPrimaBD(MPrima materiaprima)
        {
            using (connection)
            {
                connection.Close();
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("adicionar_materia_prima", connection);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@nome_mat_prima", SqlDbType.NVarChar).Value = materiaprima.Nome;
                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void InserirVendaDB(Venda venda)
        {

        }

        public void InserirItemVendaBD(ItemVenda itemvenda)
        {

        }
    }
}
