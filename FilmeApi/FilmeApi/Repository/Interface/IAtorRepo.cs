using FilmeApi.Model;

namespace FilmeApi.Repository.Interface
{
    public interface IAtorRepo
    {
        Task<List<Atores>> BuscarAtores ();
        Task<Atores> BuscarId(int idAtor);
        Task<Atores> AddAtor(Atores atores);
        Task<Atores> UpAtores(Atores atores, int idAtor);
        Task<bool> DelAtores(int idAtor);
    }
}
