using ClubeDeLeitura.Compartilhado;
using ClubeDeLeitura.Enum;
using ClubeDeLeitura.ModeloAmigo;
using ClubeDeLeitura.ModuloRevista;

namespace ClubeDeLeitura.ModuloEmprestimo;

public class Emprestimo : EntidadeBase
{
    public Amigo Amigo { get; set; }
    public DateTime DataDeLocacao { get; set; }
    public Locacao Status { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataDeDevolucao { get; set; }

    public Emprestimo(Amigo amigo, Revista revista)
    {
        Amigo = amigo;
        Revista = revista;
        DataDeLocacao = DateTime.Now;
        DataDeDevolucao = DataDeLocacao.AddDays(7);
        Status = Locacao.Aberto;
    }

    public override string ToString()
    {
        const string red = "\e[31m";
        const string reset = "\e[0m";
    
        var baseString = $"Amigo: {Amigo.Nome}\n" +
                            $"Revista: {Revista.Nome}\n" +
                            $"Data de locacao: {DataDeLocacao}\n" +
                            $"Data de devolucao: {DataDeDevolucao}\n" +
                            $"Status: ";

        if (Status == Locacao.Atrasado)
        {
            return baseString + $"{red}{Status.ToString().ToUpper()}{reset}";
        }

        return baseString + $"{Status}";
    }
}