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

        public Produto(String nome, String quantidade) {
        this._nome = nome;
        // this._preco = preco;
        this._quantidade = quantidade;
        
        
        }

        public void adicionarProduto(String produto, String quantidade) {
            if (produto != null && produto != "" && quantidade != null && quantidade != "")
            {
                if (_listaprodutos.Contains(produto)) {
                     
                    try
                    {
                        int quantidadeC = Convert.ToInt32(quantidade);
                        _totalProduto += quantidadeC;
                            Console.WriteLine($"Produto {produto} adiconado na lista, contém o total de {_totalProduto}.");
                            Console.WriteLine();
                        
                   
                           
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
                        _totalProduto += quantidadeC;
                        _listaprodutos.Add(produto);
                        Console.WriteLine($"Produto {produto} com a quantidade de {_totalProduto} adiconado na lista ");
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
            if(_listaprodutos.Count == 0) { Console.WriteLine("Lista vázia");
                Console.WriteLine();
            }
            else { 
            Console.WriteLine("Listando produtos...");
            foreach (String p in _listaprodutos) {
                
                Console.WriteLine($"{p}");
                Console.WriteLine();
                
                }
            }
        }


        public void removerProduto(String produto, String? quantidade) {

            if (produto != null && _listaprodutos.Contains(produto)) {
                    try
                    {
                        int quantidadeC = Convert.ToInt32(quantidade);
                
                            _totalProduto -= quantidadeC;

                    if (_totalProduto <= 0)
                    {
                        Console.WriteLine("Quantidade de produto zerada, ou valor digitado  para remoção era maior que a quantidade que continha");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"Produto {produto} removido da lista, restam {_totalProduto}");
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
            return _listaprodutos.Contains(produto);
        }


        public void consultarProduto(String produto) {
            if (_listaprodutos.Contains(produto)) { Console.WriteLine($"Produto {produto} existe na lista");
                Console.WriteLine();
            }
            else { Console.WriteLine($"Produto {produto} não existe na lista");
                Console.WriteLine();
            }
        }
        
    }
}
