using ClubeDeLeitura.Compartilhado;
using ClubeDeLeitura.ModuloCaixa;
namespace ClubeDeLeitura.ModuloRevista;

public class TelaRevista : TelaBase<Revista>
{
    private readonly ServicoRevista SerRevistas = new();
    private readonly ServicoCaixa SerCaixas = new();
    
    public void ExibirMenu()
    {
        ExibirMenuBase();

        switch (Console.ReadLine())
        {
            case "1": Cadastrar(); break;
            case "2": Listar(); break;
            case "3": Editar(); break;
            case "4": Excluir(); break;
            case "0": return;
            default: Console.WriteLine("Opção inválida."); break;
        }
    }
    
    public override void Cadastrar()
    {
        Console.WriteLine("Digite o nome da revista: ");
        Console.Write("-> ");
        var nome = Console.ReadLine();
        Console.WriteLine("\nDigite o numero da edição");
        Console.Write("-> ");
        var edicao = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a data da revista: ");
        Console.Write("-> ");
        var data = DateTime.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine(SerCaixas.ObterTodos());
        Console.WriteLine();
        
        Console.WriteLine("Digite a nome da caixa: ");
        Console.Write("-> ");
        var caixa = Console.ReadLine();
        
        
        try
        {
            var entidade = new Revista(nome, edicao, data, caixa);
            SerRevistas.Adicionar(entidade);
            SerCaixas.ObterPorNome(caixa).AdicionarRevista(entidade);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override void Listar()
    {
        Console.WriteLine(SerRevistas.ObterTodos());
    }

    public override void Editar()
    {
        Console.WriteLine("Digite o nome da revista que deseja editar: ");
        Console.Write("-> ");
        var nomeAntigo = Console.ReadLine();
        
        
        Console.WriteLine("Digite o nome da revista: ");
        Console.Write("-> ");
        var nome = Console.ReadLine();
        Console.WriteLine("\nDigite o numero da edição");
        Console.Write("-> ");
        var edicao = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a data da revista: ");
        Console.Write("-> ");
        var data = DateTime.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine(SerCaixas.ObterTodos());
        Console.WriteLine();
        
        Console.WriteLine("Digite a nome da caixa: ");
        Console.Write("-> ");
        var caixa = Console.ReadLine();

        try
        {
            var entidade = new Revista(nome, edicao, data, caixa);
            SerRevistas.Atualizar(nomeAntigo,entidade);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override void Excluir()
    {
        Console.WriteLine("Digite o nome do amigo que deseja excluir: ");
        Console.Write("-> ");
        var nome = Console.ReadLine();

        SerRevistas.Remover(nome);
    }
}