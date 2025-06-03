using System.Text.RegularExpressions;
using ClubeDeLeitura.Compartilhado;
using ClubeDeLeitura.ModuloRevista;

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

    public void AdicionarRevista(Revista revista)
    {
        Revistas.Add(revista);
    }

    public void RemoverRevista(Revista revista)
    {
        foreach (var r in Revistas.Where(r => r.Nome == revista.Nome && r.Edicao == revista.Edicao))
        {
            Revistas.Remove(r);
        }
    }

    public override string ToString()
    {
        return $"Nome: {Nome}\n" +
               $"Cor {Cor}\n" +
               $"ModuloEmprestimo: 7 dias";
    }
    
    [GeneratedRegex(@"^\#[0-9A-Fa-f]{6}$")]
    private static partial Regex MyRegex();
}