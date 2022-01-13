using AppSeriesDio;
using AppSeriesDio.Classes;
using AppSeriesDio.Interfaces;


FilmesRepositorio repositorio = new FilmesRepositorio();

string opcaoUsuario = ObterOpcaoUsuario();

while (opcaoUsuario.ToUpper() != "X")
{
     switch (opcaoUsuario)
     {
         case "1":
         ListarFilmes(repositorio);
         break;
         case "2":
         InserirFilme(repositorio);
         break;
         case "3":
         AtualizarFilme(repositorio);
         break;
         case "4":
         ExcluirFilme(repositorio);
         break;
         case "5":
         VisualizarFilme(repositorio);
         break;
         case "C":
         Console.Clear();
         break;

         default:
            throw new ArgumentOutOfRangeException();
     }
     opcaoUsuario = ObterOpcaoUsuario();
}

static void VisualizarFilme(FilmesRepositorio repositorio)
{
    Console.Write("Digite o id do filme: ");
	int indiceFilme = int.Parse(Console.ReadLine());

	var filme = repositorio.RetornaPorId(indiceFilme);

	Console.WriteLine(filme);
}

Console.WriteLine("Obrigado por utilizar nossos serviços.");
Console.ReadLine();

static void ExcluirFilme(FilmesRepositorio repositorio)
	{
		Console.Write("Digite o id da série: ");
		int indiceFilme = int.Parse(Console.ReadLine());
        System.Console.WriteLine($"Tem certeza que deseja excluir o filme de id #{indiceFilme}? S/N");
        string confirmaexclusao = Console.ReadLine();

        if (confirmaexclusao.ToUpper() == "S")
        {
		    repositorio.Exclui(indiceFilme);
        }

	}

static void AtualizarFilme(FilmesRepositorio repositorio)
    {
        Console.Write("Digite o id do filme: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título do Filme: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano do Filme: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição do Filme: ");
        string entradaDescricao = Console.ReadLine();

        Filme atualizaFilme = new Filme(id: indiceFilme,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Atualiza(indiceFilme, atualizaFilme);
    }


static string ObterOpcaoUsuario()
{
System.Console.WriteLine();
System.Console.WriteLine("Filmes do Tim Burton para assistir:");
System.Console.WriteLine("Infome a opção desejada:");

System.Console.WriteLine("1 - Listar filmes");
System.Console.WriteLine("2 - Inserir novo filme");
System.Console.WriteLine("3 - Atualizar filme");
System.Console.WriteLine("4 - Excluir filme");
System.Console.WriteLine("5 - Visualizar filme");
System.Console.WriteLine("C - Limpar tela");
System.Console.WriteLine("X - Sair");
System.Console.WriteLine();

string opcaoUsuario = Console.ReadLine().ToUpper();
System.Console.WriteLine();
return opcaoUsuario;
}

static void ListarFilmes(FilmesRepositorio repositorio)
{
    System.Console.WriteLine("Listar filmes do Tim Burton");

    var lista = repositorio.Lista();

    if (lista.Count == 0)
    {
        System.Console.WriteLine("Nenhuma filme cadastrado:");
        return;
    }
    foreach (var filme in lista)
    {
        var excluido = filme.retornaExcluido();
        
        String foiExcluido = (excluido ? " - !!Excluído!!" : "");
        System.Console.WriteLine($"#ID {filme.retornaId()}: - {filme.retornaTitulo()}{foiExcluido}");

    }
}


static void InserirFilme(FilmesRepositorio repositorio)
    {
        Console.WriteLine("Inserir novo filme do Tim Burton");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título do Filme: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano do Filme: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição do Filme: ");
        string entradaDescricao = Console.ReadLine();

        Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Insere(novoFilme);
    }

