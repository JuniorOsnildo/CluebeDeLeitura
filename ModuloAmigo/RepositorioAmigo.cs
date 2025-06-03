using ClubeDeLeitura.Compartilhado;

namespace ClubeDeLeitura.ModeloAmigo;

public class RepositorioAmigo : RepositorioBase<Amigo>
{
    public override void Inserir(Amigo entidade)
    {
        if (Registro.Any(e => e.Telefone == entidade.Telefone || e.Nome == entidade.Nome))
        {
            return;
        }

        Registro.Add(entidade);
    }
    
    public override void Editar(string nome, Amigo entidade)
    {
        if (Registro.Any(e => e.Telefone == entidade.Telefone || e.Nome == entidade.Nome))
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
        var existente = ObterPorNome(nome);
        if (existente.Emprestimo ==  null)
            throw new ArgumentException("O amigo não pode ser removido pois tem um emprestimo pendente");
        Registro.Remove(existente);
    }
}
