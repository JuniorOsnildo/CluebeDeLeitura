using ClubeDeLeitura.Compartilhado;

namespace ClubeDeLeitura.Modulo_Revista;

public class RepositorioRevista : RepositorioBase<Revista>
{
    public override void Inserir(Revista entidade)
    {
        if (Registro.Any(e => e.Edicao == entidade.Edicao && e.Nome == entidade.Nome))
        {
            return;
        }

        Registro.Add(entidade);
    }
    
    public override void Editar(string nome, Revista entidade)
    {
        if (Registro.Any(e => e.Edicao == entidade.Edicao && e.Nome == entidade.Nome))
        {
            return;
        }
        
        var existente = ObterPorNome(nome);
        var index = Registro.IndexOf(existente);
        entidade.Nome = nome;
        Registro[index] = entidade;
    }
}