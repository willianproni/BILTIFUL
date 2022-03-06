using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Core.Controles
{
    public class Controle
    {
        //uma lista para cada arquivos que eu tiver
        public List<int> codigos { get; set; }
        public List<Cliente> clientes { get; set; }
        public List<Produto> produtos  { get; set; }
        public List<Fornecedor> fornecedores { get; set; }
        public List<MPrima> materiasprimas { get; set; }
        public List<Compra> compras { get; set; }
        public List<ItemCompra> itemcompra { get; set; }
        public List<Venda> vendas { get; set; }
        public List<ItemVenda> itensvenda { get; set; }


        
        public Controle()//esse construtora instanciará todas as listas qnd feito
        {
            //instancia cada lista qnd o programa é iniciado
            codigos = new List<int>();
            clientes = new List<Cliente>();
            produtos = new List<Produto>();
            fornecedores = new List<Fornecedor>();
            materiasprimas = new List<MPrima>();

            try
            {
                StreamReader sr = new StreamReader("Arquivos\\Controle.dat");//le o arquivo controle
                string line = sr.ReadLine();
                while(line != null)
                {
                    codigos.Add(int.Parse(line));//adicionando na minha lista codigo linha por linha
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
    }
    
}
