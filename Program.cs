namespace SistemaDeCadastroDeProdutos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Cadastro");
            Console.WriteLine();

            bool emExecucao = true;
            SisteDeCadastroDeProdutos.Produto p = new SisteDeCadastroDeProdutos.Produto("", "" );

            while (emExecucao)
            {
                Console.WriteLine("""
                    Selecione uma opção
                    0 - Sair
                    1 - Adicionar produto
                    2 - Listar produtos
                    3 - Remover produto
                    4 - Consultar produto
                    """);
                Console.WriteLine();
                String opcao = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();

                switch (opcao)
                {

                    case "0":
                        Console.WriteLine("Saindo..");
                        emExecucao = false;
                        break;

                    case "1":
                        Console.WriteLine("Descreva o produto");
                        String produto = Console.ReadLine().ToUpper();
                        Console.Clear();
                        Console.WriteLine("Descreva a quantidade do produto");
                        String quantidade = Console.ReadLine();
                        Console.Clear();
                        p.adicionarProduto(produto, quantidade);
                        break;

                    case "2":
                        Console.Clear();
                        p.listarProdutos();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Digite o produto para ser removido");
                        String produtoRemover = Console.ReadLine().ToUpper();
                        if (!p.ExisteProduto(produtoRemover))
                        {
                            Console.Clear();
                            Console.WriteLine($"Produto {produtoRemover} não encontrado na lista.");
                            Console.WriteLine();
                            continue;
                            
                        }

                        Console.Clear();
                        Console.WriteLine("Digite a quantidade do produto a ser removido");
                        String quantidadeRemover = Console.ReadLine();
                        p.removerProduto(produtoRemover, quantidadeRemover);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Digite o produto para consulta");
                        String produtoConsultar = Console.ReadLine().ToUpper();
                        p.consultarProduto(produtoConsultar);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }



            }




        }
    }
}
