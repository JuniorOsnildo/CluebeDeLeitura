using ClubeDeLeitura.Compartilhado;
using ClubeDeLeitura.ModeloAmigo;
using ClubeDeLeitura.ModuloRevista;

namespace ClubeDeLeitura.Emprestimo;

public class TelaEmprestimo : TelaBase<ModuloEmprestimo.Emprestimo>
{
    private readonly ServicoEmprestimo Servico = new();
    private readonly ServicoAmigo ServicoAmigo = new();
    private readonly ServicoRevista ServicoRevista = new();
    
    public void ExibirMenu()
    {
        ExibirMenuBase();

        switch (Console.ReadLine())
        {
            case "1": Cadastrar(); break;
            case "2": Listar(); break;
            case "3": Devolver(); break;
            case "4": Excluir(); break;
            case "0": return;
            default: Console.WriteLine("Opção inválida."); break;
        }
    }
    
    public new void ExibirMenuBase()
    {
        Console.WriteLine($"\n--- Gestão de {nameof(Emprestimo)} ---");
        Console.WriteLine("1. Cadastrar");
        Console.WriteLine("2. Listar");
        Console.WriteLine("3. Devolver");
        Console.WriteLine("4. Excluir");
        Console.WriteLine("0. Voltar");

        Console.Write("Escolha uma opção: ");
    }

    private void Devolver()
    {
        Console.WriteLine("Digite o nome do amigo: ");
        Console.Write("-> ");
        var nome = Console.ReadLine();

        ServicoAmigo.ObterPorNome(nome).Emprestimo = null;
        Servico.Remover(nome);
    }
    
    public override void Cadastrar()
    {
        Console.WriteLine("Digite o nome do amigo: ");
        Console.Write("-> ");
        var amigo = Console.ReadLine();
        Console.WriteLine("\nDigite o nome da Revista: ");
        Console.Write("-> ");
        var revista = Console.ReadLine();

        try
        {
            var entidade = new ModuloEmprestimo.Emprestimo(ServicoAmigo.ObterPorNome(amigo)
                                            ,ServicoRevista.ObterPorNome(revista));
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
        Console.WriteLine(Servico.ObterTodos());
    }

    public override void Editar()
    {
    }

    public override void Excluir()
    {
        Console.WriteLine("Digite o nome do aluno com emprestimo que deseja excluir: ");
        Console.Write("-> ");
        var nome = Console.ReadLine();

        Servico.Remover(nome);
    }
}