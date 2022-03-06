using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;

namespace BILTIFUL.Core.Controles
{
    public class Controle
    {
        //uma lista para cada arquivos que eu tiver
        public List<int> codigos { get; set; }
        public List<Cliente> clientes { get; set; }
        public List<Produto> produtos { get; set; }
        public List<Fornecedor> fornecedores { get; set; }
        public List<MPrima> materiasprimas { get; set; }
        public List<Compra> compras { get; set; }
        public List<ItemCompra> itemcompra { get; set; }
        public List<Venda> vendas { get; set; }
        public List<ItemVenda> itensvenda { get; set; }
        public List<string> inadimplentes { get; set; }
        public List<string> bloqueados { get; set; }


        
        public Controle()//esse construtora instanciará todas as listas qnd feito
        {
            //instancia cada lista qnd o programa é iniciado
            codigos = new List<int>();
            clientes = new List<Cliente>();
            produtos = new List<Produto>();
            fornecedores = new List<Fornecedor>();
            materiasprimas = new List<MPrima>();
            inadimplentes = new List<string>();
            bloqueados = new List<string>();

            try
            {
                //LISTA CONTROLE
                StreamReader sr = new StreamReader("Arquivos\\Controle.dat");//le o arquivo controle
                string line = sr.ReadLine();
                while (line != null)
                {
                    codigos.Add(int.Parse(line));//adicionando na minha lista codigo linha por linha
                    line = sr.ReadLine();
                }
                sr.Close();

                //LISTA CLIENTES
                sr = new StreamReader("Arquivos\\Clientes.dat");
                line = sr.ReadLine();
                while (line != null)
                {
                    long cpf = long.Parse(line.Substring(0, 11));
                    string nome = line.Substring(11, 50).Trim();
                    DateTime dnascimento = DateTime.Parse(line.Substring(61, 10));
                    Sexo sexo = (Sexo)char.Parse(line.Substring(71, 1));
                    DateTime ucompra = DateTime.Parse(line.Substring(72, 10));
                    DateTime dcadastro = DateTime.Parse(line.Substring(82, 10));
                    Situacao situacao = (Situacao)char.Parse(line.Substring(92, 1));
                    clientes.Add(new Cliente(cpf, nome, dnascimento, sexo, ucompra, dcadastro, situacao));
                    line = sr.ReadLine();
                }
                sr.Close();

                //LISTA FORNECEDORES
                sr = new StreamReader("Arquivos\\Fornecedor.dat");
                line = sr.ReadLine();
                while (line != null)
                {
                    long cnpj = long.Parse(line.Substring(0, 14));
                    string rsocial = line.Substring(14, 50).Trim();
                    DateTime dabertura = DateTime.Parse(line.Substring(64, 10));
                    DateTime ucompra = DateTime.Parse(line.Substring(74, 10));
                    DateTime dcadastro = DateTime.Parse(line.Substring(84, 10));
                    Situacao situacao = (Situacao)char.Parse(line.Substring(94, 1));
                    fornecedores.Add(new Fornecedor(cnpj, rsocial, dabertura, ucompra, dcadastro, situacao));
                    line = sr.ReadLine();
                }
                sr.Close();

                //LISTA PRODUTOS
                sr = new StreamReader("Arquivos\\Cosmetico.dat");
                line = sr.ReadLine();
                while (line != null)
                {
                    string cbarras = line.Substring(0, 12);
                    string nome = line.Substring(12, 20).Trim();
                    string vvendas = line.Substring(32, 5);
                    DateTime uvenda = DateTime.Parse(line.Substring(37, 10));
                    DateTime dcadastro = DateTime.Parse(line.Substring(47, 10));
                    Situacao situacao = (Situacao)char.Parse(line.Substring(57, 1));
                    produtos.Add(new Produto(cbarras, nome, vvendas, uvenda, dcadastro, situacao));
                    line = sr.ReadLine();
                }
                sr.Close();

                //LISTA MATERIA PRIMA
                sr = new StreamReader("Arquivos\\Materia.dat");
                line = sr.ReadLine();
                while (line != null)
                {
                    string cod = line.Substring(0, 6);
                    string nome = line.Substring(6, 20).Trim();
                    DateTime ucompra = DateTime.Parse(line.Substring(26, 10));
                    DateTime dcadastro = DateTime.Parse(line.Substring(36, 10));
                    Situacao situacao = (Situacao)char.Parse(line.Substring(46, 1));
                    materiasprimas.Add(new MPrima(cod, nome, ucompra, dcadastro, situacao));
                    line = sr.ReadLine();
                }
                sr.Close();

                //LISTA INADIMPLENTES
                sr = new StreamReader("Arquivos\\Risco.dat");//le o arquivo controle
                line = sr.ReadLine();
                while (line != null)
                {
                    inadimplentes.Add(line);//adicionando na minha lista codigo linha por linha
                    line = sr.ReadLine();
                }
                sr.Close();

                //LISTA BLOQUEADOS
                sr = new StreamReader("Arquivos\\Bloqueado.dat");//le o arquivo controle
                line = sr.ReadLine();
                while (line != null)
                {
                    bloqueados.Add(line);//adicionando na minha lista codigo linha por linha
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public Controle(Cliente cliente)
        {
            if (cliente != null)
            {
                try//envia cliente para arquivo como novo cliente]try
                {
                    StreamWriter sw = new StreamWriter("Arquivos\\Clientes.dat", append: true);
                    sw.WriteLine(cliente.ConverterParaEDI());
                    sw.Close();
                    Console.WriteLine("Cliente cadastrado com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
        public Controle(Fornecedor fornecedor)
        {
                       
            
            if (fornecedor != null)
            {
                try//envia cliente para arquivo como novo cliente]try
                {
                    StreamWriter sw = new StreamWriter("Arquivos\\Fornecedor.dat", append: true);
                    sw.WriteLine(fornecedor.ConverterParaEDI());
                    sw.Close();
                    Console.WriteLine("Fornecedor cadastrado com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
        public Controle(Produto produto)
        {
            if (produto != null)
            {
                try//envia cliente para arquivo como novo cliente]try
                {
                    StreamWriter sw = new StreamWriter("Arquivos\\Cosmetico.dat", append: true);
                    sw.WriteLine(produto.ConverterParaEDI());
                    sw.Close();
                    Console.WriteLine("Produto cadastrado com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }

        }
        public Controle(MPrima materiaprima)
        {
            if (materiaprima != null)
            {
                try//envia cliente para arquivo como novo cliente]try
                {
                    StreamWriter sw = new StreamWriter("Arquivos\\Materia.dat", append: true);
                    sw.WriteLine(materiaprima.ConverterParaEDI());
                    sw.Close();
                    Console.WriteLine("Materia prima cadastrado com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
        public Controle(long chave)
        {
            string schave = "" + chave;
            if (CadastroService.ValidaCpf(schave))
            {
                try//envia cliente para arquivo como novo cliente]try
                {
                    StreamWriter sw = new StreamWriter("Arquivos\\Risco.dat", append: true);
                    sw.WriteLine(schave);
                    sw.Close();
                    Console.WriteLine("Cliente cadastrado como inadimplente!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            if (CadastroService.ValidaCnpj(schave))
            {
                try//envia cliente para arquivo como novo cliente]try
                {
                    StreamWriter sw = new StreamWriter("Arquivos\\Bloqueado.dat", append: true);
                    sw.WriteLine(schave);
                    sw.Close();
                    Console.WriteLine("Fornecedor bloqueado!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
        public Controle(long chave,string funcao)
        {
            string schave = "" + chave;
            if (CadastroService.ValidaCpf(schave))
            {

            }
            if (CadastroService.ValidaCnpj(schave))
            { 

            }
        }
    }

}
