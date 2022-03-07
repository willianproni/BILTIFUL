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
        public List<ItemCompra> itenscompra { get; set; }
        public List<Producao> producao { get; set; }
        public List<ItemProducao> itensproducao { get; set;}
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
            compras = new List<Compra>(); //
            itenscompra = new List<ItemCompra>(); //adicionar arquivos
            producao = new List<Producao>(); //
            itensproducao = new List<ItemProducao>();//
            vendas = new List<Venda>();//
            itensvenda = new List<ItemVenda>();//
            inadimplentes = new List<string>();
            bloqueados = new List<string>();
            
            try
            {
                StreamReader sr;
                string line;

                if (!Directory.Exists("Arquivos"))
                {
                    Directory.CreateDirectory("Arquivos");
                }

                //LISTA CONTROLE
                if (File.Exists("Arquivos\\Controle.dat"))
                {
                    sr = new StreamReader("Arquivos\\Controle.dat");//le o arquivo controle
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        codigos.Add(int.Parse(line));//adicionando na minha lista codigo linha por linha
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                else
                {
                    StreamWriter streamWriter = new StreamWriter("Arquivos\\Controle.dat");
                    streamWriter.WriteLine("0");//produto
                    streamWriter.WriteLine("0");//materia prima
                    streamWriter.WriteLine("0");//venda
                    streamWriter.WriteLine("0");//compra
                    streamWriter.Close();

                }

                //LISTA CLIENTES
                if (File.Exists("Arquivos\\Clientes.dat"))
                {
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
                }

                //LISTA FORNECEDORES
                if (File.Exists("Arquivos\\Fornecedor.dat"))
                {
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
                }

                //LISTA PRODUTOS
                if (File.Exists("Arquivos\\Cosmetico.dat"))
                {
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
                }

                //LISTA MATERIA PRIMA
                if (File.Exists("Arquivos\\Materia.dat"))
                {
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
                }

                //LISTA INADIMPLENTES
                if (File.Exists("Arquivos\\Risco.dat"))
                {
                    sr = new StreamReader("Arquivos\\Risco.dat");//le o arquivo controle
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        inadimplentes.Add(line);//adicionando na minha lista codigo linha por linha
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }

                //LISTA BLOQUEADOS
                if (File.Exists("Arquivos\\Bloqueado.dat"))
                {
                    sr = new StreamReader("Arquivos\\Bloqueado.dat");//le o arquivo controle
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        bloqueados.Add(line);//adicionando na minha lista codigo linha por linha
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }

                //COMPRA
                if (File.Exists("Arquivos\\Compra.dat"))
                {
                    sr = new StreamReader("Arquivos\\Compra.dat");
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        string cod = line.Substring(0, 5);
                        DateTime dcompra = DateTime.Parse(line.Substring(5, 10));
                        long cnpj = long.Parse(line.Substring(15, 14));
                        string valor = line.Substring(29, 7);
                        compras.Add(new Compra(cod,dcompra,cnpj,valor));
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }

                //ITEM COMPRA
                if (File.Exists("Arquivos\\ItemCompra.dat"))
                {
                    sr = new StreamReader("Arquivos\\ItemCompra.dat");
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        string cod = line.Substring(0, 5);
                        DateTime dcompra = DateTime.Parse(line.Substring(5, 10));
                        string materiaprima = line.Substring(15, 6);
                        string quantidade = line.Substring(21, 5);
                        string valoruni = line.Substring(26, 5);
                        string valortotal = line.Substring(31, 6);
                        itenscompra.Add(new ItemCompra(cod,dcompra,materiaprima,quantidade,valoruni,valortotal));
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }

                //Producao
                if (File.Exists("Arquivos\\Producao.dat"))
                {
                    sr = new StreamReader("Arquivos\\Producao.dat");
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        string cod = line.Substring(0, 5);
                        DateTime dproducao = DateTime.Parse(line.Substring(5, 10));
                        string produto = line.Substring(15,5);
                        string quantidade = line.Substring(20, 5);
                        producao.Add(new Producao(cod, dproducao, produto, quantidade));
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }

                //itens producao
                if (File.Exists("Arquivos\\ItemProducao.dat"))
                {
                    sr = new StreamReader("Arquivos\\ItemProducao.dat");
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        string cod = line.Substring(0, 5);
                        DateTime dproducao = DateTime.Parse(line.Substring(5, 10));
                        string mprima = line.Substring(15, 6);
                        string quantidadeMateriaPrima = line.Substring(21, 5);
                        itensproducao.Add(new ItemProducao(cod, dproducao, mprima, quantidadeMateriaPrima));
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
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
        public Controle(Compra compra)
        {
            if (compra != null)
            {
                try//envia cliente para arquivo como novo cliente]try
                {
                    StreamWriter sw = new StreamWriter("Arquivos\\Compra.dat", append: true);
                    sw.WriteLine(compra.ConverterParaEDI());
                    sw.Close();
                    Console.WriteLine("Compra cadastrada cadastrado com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
        public Controle(ItemCompra itemcompra)
        {
            if (itemcompra != null)
            {
                try//envia cliente para arquivo como novo cliente]try
                {
                    StreamWriter sw = new StreamWriter("Arquivos\\ItemCompra.dat", append: true);
                    sw.WriteLine(itemcompra.ConverterParaEDI());
                    sw.Close();
                    Console.WriteLine("Item de Compra cadastrado cadastrado com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
        public Controle(Producao producao)
        {
            if (producao != null)
            {
                try//envia cliente para arquivo como novo cliente]try
                {
                    StreamWriter sw = new StreamWriter("Arquivos\\Producao.dat", append: true);
                    sw.WriteLine(producao.ConverterParaEDI());
                    sw.Close();
                    Console.WriteLine("Produção cadastrada com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        public Controle(ItemProducao itemproducao)
        {
            if (itemproducao != null)
            {
                try//envia cliente para arquivo como novo cliente]try
                {
                    StreamWriter sw = new StreamWriter("Arquivos\\ItemProducao.dat", append: true);
                    sw.WriteLine(itemproducao.ConverterParaEDI());
                    sw.Close();
                    Console.WriteLine("Item de produção cadastrado com sucesso!");
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
    }

}
