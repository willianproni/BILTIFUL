using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Core.Controle
{
    public class Controle
    {
        //uma lista para cada arquivos que eu tiver
        public List<string> codigos { get; set; }
        public List<Cliente> clientes { get; set; }
        public List<Produto> produtos  { get; set; }
        public List<Fornecedor> fornecedores { get; set; }
        public Controle()//esse construtora instanciará todas as listas qnd feito
        {
            //instancia cada lista qnd o programa é iniciado
            codigos = new List<string>();
            clientes = new List<Cliente>();
            produtos = new List<Produto>();
            fornecedores = new List<Fornecedor>();

            try
            {
                StreamReader sr = new StreamReader("Arquivos\\Controle.dat");//le o arquivo controle
                string line = sr.ReadLine();
                while(line != null)
                {
                    codigos.Add(line);//adicionando na minha lista codigo linha por linha
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
            //List<MPrima> mprima = new List<MPrima>();
            //mprima = ler arquivo mprima
        }
    }
    
}
