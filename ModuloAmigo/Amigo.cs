using System.Text.RegularExpressions;
using ClubeDeLeitura.Compartilhado;

namespace ClubeDeLeitura.ModeloAmigo;

public partial class Amigo : EntidadeBase
{
    public string Responsavel { get; set; }
    public string Telefone  { get; set; }
    public Revista? Emprestimo { get; set; }

    public Amigo(string nome, string telefone, string responsavel)
    {
        if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3)
            throw new ArgumentException("O nome deve ter ao menos 3 caracteres");
        if (string.IsNullOrWhiteSpace(telefone))
            throw new ArgumentException("O numero de telefone não pode ser vazio");
        if (string.IsNullOrWhiteSpace(responsavel))
            throw new ArgumentException("O nome do responsavel não pode ser vazio");
        if (!MyRegex().IsMatch(telefone))
            throw new ArgumentException("Fromato de telefone invalido");
            
        Nome = nome;
        Responsavel = responsavel;
        Telefone = telefone;
        Emprestimo = null;
    }

    public void ObterEmprestimo()
    {
        
    }

    public override string ToString()
    {
        return $"Nome: {Nome}\n" +
               $"Responsavel: {Responsavel}\n" +
               $"Telefone {Telefone}\n" +
               $"Emprestimo: "Emprestimo == null ? " -- " : $"{Emprestimo.nome}";  
    }

    [GeneratedRegex(@"^\([0-9]{2}\)[0-9]{4,5}\-[0-9]{4}$")]
    private static partial Regex MyRegex();
}