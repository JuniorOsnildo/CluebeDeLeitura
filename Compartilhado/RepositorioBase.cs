namespace ClubeDeLeitura.Compartilhado;

public class RepositorioBase<T> where T : EntidadeBase
{
    protected static readonly List<T> Registro = [];
    
    public virtual void Inserir(T entidade)
    {
        Registro.Add(entidade);
    }
    
    public virtual void Editar(string nome, T novaEntidade)
    {
        var existente = ObterPorNome(nome);
        var index = Registro.IndexOf(existente);
        novaEntidade.Nome = nome;
        Registro[index] = novaEntidade;
    }
    
    public virtual void Excluir(string nome)
    {
        var entidade = ObterPorNome(nome);
        Registro.Remove(entidade);
    }

    public virtual T ObterPorNome(string nome)
    {
        return Registro.FirstOrDefault(e => e.Nome == nome);
    }

    public virtual List<T> ListarTodos()
    {
        return [..Registro];
    }
    
    

}