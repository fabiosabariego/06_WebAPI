using Fiap.Api.AspNet5.Data;
using Fiap.Api.AspNet5.Models;
using Fiap.Api.AspNet5.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet5.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly DataContext _dataContext;

        public MarcaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IList<MarcaModel> FindAll()
        {
            return _dataContext.Marcas.AsNoTracking().ToList();
        }

        public MarcaModel FindById(int id)
        {
            return _dataContext.Marcas.FirstOrDefault(x => x.MarcaId == id);
        }

        public int Insert(MarcaModel marcaModel)
        {
            _dataContext.Marcas.Add(marcaModel);
            _dataContext.SaveChanges();
            return marcaModel.MarcaId;
        }

        public void Update(MarcaModel marcaModel)
        {
            _dataContext.Marcas.Update(marcaModel);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var marca = new MarcaModel  { MarcaId = id };
            _dataContext.Marcas.Remove(marca);
            _dataContext.SaveChanges();
        }
    }
}
