using Fiap.Api.AspNet5.Data;
using Fiap.Api.AspNet5.Models;
using Fiap.Api.AspNet5.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet5.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _dataContext;

        public ProdutoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IList<ProdutoModel> FindAll()
        {
            return _dataContext.Produtos.AsNoTracking().ToList();
        }

        public ProdutoModel FindById(int id)
        {
            return _dataContext.Produtos.Include(c => c.Categoria).Include(m => m.Marca).FirstOrDefault(x => x.ProdutoId == id);
        }

        public int Insert(ProdutoModel produtoModel)
        {
            _dataContext.Produtos.Add(produtoModel);
            _dataContext.SaveChanges();
            return produtoModel.ProdutoId;
        }

        public void Update(ProdutoModel produtoModel)
        {
            _dataContext.Produtos.Update(produtoModel);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var produto = new ProdutoModel { ProdutoId = id };

            _dataContext.Produtos.Remove(produto);
            _dataContext.SaveChanges();
        }

        public int Count()
        {
            return _dataContext.Produtos.Count();
        }

        public IList<ProdutoModel> FindAll(int pagina, int tamanho)
        {
            var lista = _dataContext.Produtos.Skip(tamanho * pagina).Take(tamanho).ToList();
            return lista;
        }
    }
}
