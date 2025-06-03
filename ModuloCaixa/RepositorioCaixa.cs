using System.IO.Enumeration;
using ClubeDeLeitura.Compartilhado;

namespace ClubeDeLeitura.ModuloCaixa;

public class RepositorioCaixa :  RepositorioBase<Caixa>
{

    public override void Inserir(Caixa entidade)
    {
        if (Registro.Any(e => e.Nome == entidade.Nome))
        {
            return;
        }
        base.Inserir(entidade);
    }

    public override void Editar(string nome, Caixa entidade)
    {
        if (Registro.Any(e => e.Nome == entidade.Nome))
        {
            return;
        }
        
        var existente = ObterPorNome(nome);
        var index = Registro.IndexOf(existente);
        entidade.Nome = nome;
        Registro[index] = entidade;
    }

    public override void Excluir(string nome)
    {
        foreach (var e in Registro.Where(e => e.Nome == nome).Where(e => e.Revistas.Count == 0))
        {
            Registro.Remove(e);
        }
    }
}