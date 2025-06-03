using System.Text.RegularExpressions;
using ClubeDeLeitura.Compartilhado;
using ClubeDeLeitura.Enum;
using ClubeDeLeitura.ModuloCaixa;

namespace ClubeDeLeitura.Modulo_Revista;

public partial class Revista : EntidadeBase
{
    public int Edicao  { get; set; }
    public DateTime Data  { get; set; }
    public Status Status  { get; set; }
    public string Caixa  { get; set; }

    public Revista(string nome, int edicao, DateTime data, string caixa)
    {
        if (string.IsNullOrWhiteSpace(nome) || nome.Length < 2 || nome.Length > 100)
            throw new ArgumentException("O nome deve ter entre 2 e 100 caracteres");
        if (edicao <= 1)
            throw new ArgumentException("O numero da edição deve ser maior que 0");
        if (string.IsNullOrWhiteSpace(data.ToString()) || (data - DateTime.Now).Days < 0)
            throw new ArgumentException("A data ser valida");
            
        Nome = nome;
        Edicao = edicao;
        Data = data;
        Caixa = caixa;
        Status = Status.Disponivel;
    }

    public void Emprestar()
    {
        Status = Status.Emprestado;
    }
    public void Devolver()
    {
        Status = Status.Disponivel;
    }
    public void Reservar()
    {
        Status = Status.Reservado;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}\n" +
               $"Edição: {Edicao}\n" +
               $"Data: {Data}\n" +
               $"Status: {Status}\n:" +
               $"";  
    }

    [GeneratedRegex(@"^\([0-9]{2}\)[0-9]{4,5}\-[0-9]{4}$")]
    private static partial Regex MyRegex();
}