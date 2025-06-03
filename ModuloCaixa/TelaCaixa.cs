using ClubeDeLeitura.Compartilhado;

namespace ClubeDeLeitura.ModuloCaixa;

public class TelaCaixa : TelaBase<Caixa>
{
    private readonly ServicoCaixa Servico = new();
    
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
        Console.WriteLine("Digite a etiqueta da caixa: ");
        Console.Write("-> ");
        var nome = Console.ReadLine();
        Console.WriteLine("\nDigite o código hexadecimal da cor: ");
        Console.Write("-> ");
        var hex = Console.ReadLine();

        try
        {
            var entidade = new Caixa(nome, hex);
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
        Console.WriteLine("Digite o nome da caixa que deseja editar: ");
        Console.Write("-> ");
        var nomeAntigo = Console.ReadLine();
        
        
        Console.WriteLine("Digite o novo nome da caixa: ");
        Console.Write("-> ");
        var nome = Console.ReadLine();
        Console.WriteLine("\nDigite a nova cor: ");
        Console.Write("-> ");
        var hex = Console.ReadLine();

        try
        {
            var entidade = new Caixa(nome, hex);
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
        Console.WriteLine("Digite o nome da caixa que deseja excluir: ");
        Console.Write("-> ");
        var nome = Console.ReadLine();

        Servico.Remover(nome);
    }
}