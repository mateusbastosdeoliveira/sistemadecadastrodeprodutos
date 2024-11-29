using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SisteDeCadastroDeProdutos
{
    internal class Produto
    {   
        private String? _nome;
        //private double _preco;
        private String? _quantidade;




        private int _totalProduto = 0;
        List<string> _listaprodutos = new List<string> { };
        Dictionary<string, int> _dicionario = new Dictionary<string, int>();


        public Produto(String nome, String quantidade) {
        this._nome = nome;
        // this._preco = preco;
        this._quantidade = quantidade;
        
        
        }

        public void adicionarProduto(String produto, String quantidade) {
            if (produto != null && produto != "" && quantidade != null && quantidade != "")
            {
                if (_dicionario.ContainsKey(produto)) {
                     
                    try
                    {
                        int quantidadeC = Convert.ToInt32(quantidade);
                        _dicionario[produto] += quantidadeC; // Incrementa a quantidade do produto
                        Console.WriteLine($"Produto '{produto}' atualizado. Total: {_dicionario[produto]}.");



                    }
                    catch(FormatException){ 
                        Console.WriteLine("Digite um valor válido");
                        Console.WriteLine();
                    }
                


                }
                else{
                    try
                    {
                        int quantidadeC = Convert.ToInt32(quantidade);
                        _dicionario.Add(produto, quantidadeC); 
                        Console.WriteLine($"Produto {produto} com a quantidade de {quantidade} adiconado na lista ");
                        Console.WriteLine();



                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Digite um valor válido");
                        Console.WriteLine();
                    }
                    
                }


            }
            else
            {
                Console.WriteLine("Produto ou quantidade não podem ser vázio");
                Console.WriteLine();
            }


        
        }

        public void listarProdutos()
        {
            if(_dicionario.Count == 0) { Console.WriteLine("Lista vázia");
                Console.WriteLine();
            }
            else { 
            Console.WriteLine("Listando produtos...");
            foreach (var p in _dicionario) {
                
                Console.WriteLine($"{p}");
                Console.WriteLine();
                
                }
            }
        }


        public void removerProduto(String produto, String? quantidade) {

            if (produto != null && _dicionario.ContainsKey(produto)) {
                    try
                    {
                        int quantidadeC = Convert.ToInt32(quantidade);

                    

                    if (_dicionario[produto] < quantidadeC)
                    {
                        Console.WriteLine("Quantidade de produto zerada, ou valor digitado  para remoção era maior que a quantidade que continha");
                        Console.WriteLine();
                    }
                    else
                    {
                        _dicionario[produto] -= quantidadeC;
                        Console.WriteLine($"Produto {produto} removido da lista, restam {_dicionario[produto]}");
                        Console.WriteLine();
                    }



                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Digite um valor válido para remoção");
                        Console.WriteLine();
                    }
   
            }

            else
            {
                Console.WriteLine("Produto não foi localizado ou você digitou um valor em branco.");
                Console.WriteLine();
              
            }


        }



        public bool ExisteProduto(string produto)
        {
            return _dicionario.ContainsKey(produto);
        }


        public void consultarProduto(String produto) {
            if (_dicionario.ContainsKey(produto)) { Console.WriteLine($"Produto {produto} existe na lista");
                Console.WriteLine();
            }
            else { Console.WriteLine($"Produto {produto} não existe na lista");
                Console.WriteLine();
            }
        }
        
    }
}
