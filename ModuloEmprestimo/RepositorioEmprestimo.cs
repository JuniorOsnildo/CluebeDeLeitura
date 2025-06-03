using ClubeDeLeitura.Compartilhado;

namespace ClubeDeLeitura.Emprestimo;

public class RepositorioEmprestimo : RepositorioBase<ModuloEmprestimo.Emprestimo>
{
    public virtual ModuloEmprestimo.Emprestimo ObterPorNome(string nome)
    {
        return Registro.FirstOrDefault(e => e.Amigo.Nome == nome);
    }
}