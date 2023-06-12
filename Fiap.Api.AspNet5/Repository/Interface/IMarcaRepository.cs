using Fiap.Api.AspNet5.Models;

namespace Fiap.Api.AspNet5.Repository.Interface
{
    public interface IMarcaRepository
    {
        public IList<MarcaModel> FindAll();
        public MarcaModel FindById(int id);
        public int Insert(MarcaModel marcaModel);
        public void Update(MarcaModel marcaModel);
        public void Delete(int id);

    }
}
