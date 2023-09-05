using FilmeApi.Model;

namespace FilmeApi.Repository.Interface
{
    public interface IFilmeRepo
    {
        Task<List<Filmes>> BuscarFilmes ();
        Task<Filmes> BuscarId(int idFilme);
        Task<Filmes> AddFilme(Filmes filmes);
        Task<Filmes> UpFilmes(Filmes filmes, int idFilme);
        Task<bool> DelFilmes(int idFilme);
    }
}
