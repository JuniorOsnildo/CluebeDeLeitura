using ClubeDeLeitura.ModeloAmigo;

namespace ClubeDeLeitura.Compartilhado;

public class ServicoBase<T, TRepossitorio> 
    where T : EntidadeBase 
    where TRepossitorio : RepositorioBase<T>, new()
{
    private readonly TRepossitorio Repositorio = new();

    public void Adicionar(T entidade)
    {
        Repositorio.Inserir(entidade);
    }

    public void ObterTodos() => Repositorio.ListarTodos();

    public T? ObterPorNome(string nome) => Repositorio.ObterPorNome(nome);

    public bool Atualizar(string nome, T atualizado)
    {
        var existente = Repositorio.ObterPorNome(nome);
        atualizado.Nome = nome;
        Repositorio.Editar(nome, atualizado);
        return true;
    }

    public bool Remover(string nome)
    {
        Repositorio.Excluir(nome);
        return true;
    }

}