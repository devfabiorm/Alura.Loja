using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class ProdutoDAOEntity : IProdutoDAO, IDisposable
    {
        private LojaContext _contexto;

        public ProdutoDAOEntity()
        {
            _contexto = new LojaContext();
        }

        public void Adicionar(Produto p)
        {
            this._contexto.Produtos.Add(p);
        }

        public void Atualizar(Produto p)
        {
            this._contexto.Produtos.Update(p);
        }

        public IList<Produto> Produtos()
        {
            return this._contexto.Produtos.ToList();
        }

        public void Remover(Produto p)
        {
            this._contexto.Produtos.Remove(p);
        }

        public void Dispose()
        {
            this._contexto.Dispose();
        }
    }
}
