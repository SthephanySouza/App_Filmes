using FilmeApi.Model;

namespace FilmeApi.Repository.Interface
{
    public interface IGeneroRepo
    {
        Task<List<Generos>> BuscarGeneros ();
        Task<Generos> BuscarId(int idGenero);
        Task<Generos> AddGenero(Generos generos);
        Task<Generos> UpGeneros(Generos generos, int idGenero);
        Task<bool> DelGeneros(int idGenro);
    }
}
