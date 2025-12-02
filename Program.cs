
public class Program
{
    
    public class Produto
    {
        public List<Produto> listaProduto = new();
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCadastro { get; private set; }

       

        public void adicionarProduto(Guid id, string nomeProduto, string descricaoProduto,DateTime datacadastro)
        {
          listaProduto.Add(
              new Produto {Id = id,Nome = nomeProduto, Descricao = descricaoProduto,DataCadastro = datacadastro});
        }

        public  void listarProduto()
        {
            if (listaProduto.Count() <= 0)
            {
                Console.WriteLine("Lista de produtos vázia");
                Console.WriteLine("");
            }

            else
            {
                foreach (var produto in listaProduto)
                {
                    Console.WriteLine($"""
                        ID : {produto.Id}
                        Nome do produto : {produto.Nome}
                        Descrição do produto : {produto.Descricao}
                        Data de cadastro do produto : {produto.DataCadastro}
                        """);

                    Console.WriteLine("---------------------");
                    Console.WriteLine("");

                }
            }
        }
        public void excluirProduto(string nomeProduto)
        {
            var produto = listaProduto.FirstOrDefault(p => p.Nome.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase));
        
        }

    }

    public static void Main(string[] args)
    {
        Produto p =  new Produto();
        exibirMenuDeOpcao();
        while (true) {
            string opcao = Console.ReadLine().Trim();

            switch (opcao)
            {
                case "0":
                    Environment.Exit(0);
                    break;

                case "1":
                    Guid guid = Guid.NewGuid();
                    DateTime dateTime = DateTime.Now;

                    Console.WriteLine("Nome do produto : ");
                    string nomeProduto = Console.ReadLine().Trim();

                    if (p.listaProduto.Exists(prod => prod.Nome == nomeProduto))
                    {
                        Console.WriteLine("Produto já cadastrado");
                        Console.WriteLine("");
                        continue;
                    }

                    else
                    {
                        Console.WriteLine("Descrição do produto : ");
                        string descricaoProduto = Console.ReadLine().Trim();

                        p.adicionarProduto(guid, nomeProduto, descricaoProduto, dateTime);
                        Console.WriteLine("Produto cadastrado com sucesso");
                        Console.WriteLine("");

                        Task.Delay(2000).Wait();
                        Console.Clear();
                        exibirMenuDeOpcao();
                    }

                        break;
                case "2":
                    p.listarProduto();
                    Console.WriteLine("");
                    Console.WriteLine("Limpando a tela em: ");
                    for(int i = 10; i >= 0; i--)
                    {
                        Console.Write(i.ToString());
                        Task.Delay(1000).Wait();
                    }
                    
                    Console.Clear();
                    exibirMenuDeOpcao();
                    break;

               case "3":
                    Console.WriteLine("Nome do produto para exclusão : ");
                    string nomeProdutoExcluir = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(nomeProdutoExcluir))
                    {
                        if(p.listaProduto.Exists(prod => prod.Nome == nomeProdutoExcluir))
                        {
                            p.excluirProduto(nomeProdutoExcluir);
                            Console.WriteLine("Produto excluido com sucesso.");
                            Task.Delay(2000).Wait();
                            Console.Clear();
                            exibirMenuDeOpcao();
                        }

                        else
                        {
                            Console.WriteLine($"Produto {nomeProdutoExcluir} não existe na lista.");
                            Task.Delay(2000).Wait();
                            Console.Clear();
                            exibirMenuDeOpcao();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Nome do produto vázio.");
                        Task.Delay(2000).Wait();
                        Console.Clear();
                        exibirMenuDeOpcao();
                    }
                        break;

                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("");
                    Task.Delay(1000).Wait();
                    Console.Clear();
                    exibirMenuDeOpcao();
                    break;


            }

        }


    }

    public static void exibirMenuDeOpcao()
    {
        
        Console.WriteLine("Sistema de cadastro");
        Console.WriteLine("");
        Console.WriteLine("0 - Sair");
        Console.WriteLine("1 - Cadastrar novo produto");
        Console.WriteLine("2 - Listar produtos");
        Console.WriteLine("3 - Excluir produto");
        Console.WriteLine("");
        Console.WriteLine("Opção: ");
       
    }
}