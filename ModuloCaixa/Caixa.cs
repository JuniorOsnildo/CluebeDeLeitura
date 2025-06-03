using System.Text.RegularExpressions;
using ClubeDeLeitura.Compartilhado;

namespace ClubeDeLeitura.ModuloCaixa;

public partial class Caixa : EntidadeBase
{
    public string Responsavel { get; set; }
    private string Cor { get; set; }
    public int diasDeEmprestimo = 7;
    public List<Revista> Revistas { get; set; }

    public Caixa(string nome, string cor)
    {
        if (string.IsNullOrWhiteSpace(nome) || nome.Length > 50 || nome.Contains(' '))
            throw new ArgumentException("A etiqueta deve ser uma palavra unica com no máximo 50 caracteres");
        if (!MyRegex().IsMatch(cor))
            throw new ArgumentException("A cor deve estar em modelo hexadecimal");

        Nome = nome;
        Cor = cor;
        Revistas = [];
    }

    public override string ToString()
    {
        return $"Nome: {Nome}\n" +
               $"Cor {Cor}\n" +
               $"Emprestimo: 7 dias";
    }
    
    [GeneratedRegex(@"^\#[0-9A-Fa-f]{6}$")]
    private static partial Regex MyRegex();
}