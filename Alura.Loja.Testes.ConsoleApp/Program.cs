using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            AtualizarProduto();
        }

        private static void AtualizarProduto()
        {
            //Incluir produto
            GravarUsandoEntity();
            RecuperarProdutos();

            //Atualizar Produto
            using(var repo = new LojaContext())
            {
                Produto produto = repo.Produtos.First();
                produto.Nome = "Harry Potter e o Cálice de Fogo";
                repo.Produtos.Update(produto);
                repo.SaveChanges();
            }
            RecuperarProdutos();

        }

        private static void ExcluirProdutos()
        {
            using(var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();
                foreach(var item in produtos)
                {
                    repo.Produtos.Remove(item);
                }
                repo.SaveChanges();
            }
        }

        private static void RecuperarProdutos()
        {
            using(var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();
                Console.WriteLine("Foram encontrados {0} produtos", produtos.Count);

                foreach(var produto in produtos)
                {
                    Console.WriteLine(produto.Nome);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
