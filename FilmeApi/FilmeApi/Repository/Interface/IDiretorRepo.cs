using FilmeApi.Model;

namespace FilmeApi.Repository.Interface
{
    public interface IDiretorRepo
    {
        Task<List<Diretores>> BuscarDiretores ();
        Task<Diretores> BuscarId(int idDiretor);
        Task<Diretores> AddDiretor(Diretores diretores);
        Task<Diretores> UpDiretores(Diretores diretores, int idDiretor);
        Task<bool> DelDiretores(int idDiretor);
    }
}
