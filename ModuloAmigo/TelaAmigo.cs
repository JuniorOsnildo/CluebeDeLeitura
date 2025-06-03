using ClubeDeLeitura.Compartilhado;

namespace ClubeDeLeitura.ModeloAmigo;

public class TelaAmigo : TelaBase<Amigo>
{
    private readonly ServicoAmigo Servico = new();

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
        Console.WriteLine("Digite o nome do amigo: ");
        Console.Write("-> ");
        var nome = Console.ReadLine();
        Console.WriteLine("\nDigite o nome do responsavel");
        Console.Write("-> ");
        var responsavel = Console.ReadLine();
        Console.WriteLine("\nDigite um telefone para contato ex: (xx)xxxx-xxxx ou (xx)xxxxx-xxxx");
        Console.Write("-> ");
        var telefone = Console.ReadLine();

        try
        {
            var entidade = new Amigo(nome, responsavel, telefone);
            Servico.Adicionar(entidade);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override void Listar()
    {
        Servico.ObterTodos();
    }

    public override void Editar()
    {
        Console.WriteLine("Digite o nome do amigo que deseja editar: ");
        Console.Write("-> ");
        var nomeAntigo = Console.ReadLine();
        
        
        Console.WriteLine("Digite o novo nome do amigo: ");
        Console.Write("-> ");
        var nome = Console.ReadLine();
        Console.WriteLine("\nDigite o nome do novo responsavel");
        Console.Write("-> ");
        var responsavel = Console.ReadLine();
        Console.WriteLine("\nDigite um telefone para contato ex: (xx)xxxx-xxxx ou (xx)xxxxx-xxxx");
        Console.Write("-> ");
        var telefone = Console.ReadLine();

        try
        {
            var entidade = new Amigo(nome, responsavel, telefone);
            Servico.Atualizar(nome,entidade);
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

        Servico.Remover(nome);
    }
}