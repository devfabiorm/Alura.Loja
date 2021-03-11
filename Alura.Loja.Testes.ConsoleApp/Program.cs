using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();
                ExibeEntries(contexto.ChangeTracker.Entries());

                var novoProduto = new Produto
                {
                    Nome = "Sabão em pó",
                    Categoria = "Limpeza",
                    Preco = 2.99
                };

                contexto.Produtos.Add(novoProduto);
                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.Produtos.Remove(novoProduto);
                ExibeEntries(contexto.ChangeTracker.Entries());

                var entity = contexto.Entry(novoProduto);
                Console.WriteLine("\n\n" + entity.Entity.ToString() + "-" + entity.State);
            }
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("==========================================");
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + "-" + e.State);
            }
        }
    }
}
