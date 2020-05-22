using System.Collections.Generic;
using BackendApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BackendApplication.Data;
using System;

namespace BackendApplication.Controllers
{
    /* http://localhost:51170/api/produtos */
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IList<Produto> GetProdutos()
        {
            using (var context = new DatabaseContext())
            {
                return context.Produtos.ToList();
            }
        }

        [HttpPost]
        public IList<Produto> CreateProduto([FromBody]Produto produto)
        {
            using(var context = new DatabaseContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var ultimoCodigo = context.Produtos.Max(p => p.Codigo);
                        var codigo = ultimoCodigo == null ? 1 : ultimoCodigo + 1;

                        produto.Codigo = codigo;
                        context.Produtos.Add(produto);

                        context.SaveChanges();

                        transaction.Commit();
                    } 
                    catch(Exception)
                    {
                        transaction.Rollback();
                    }
                }

                return context.Produtos.ToList();
            }
        }

        [HttpDelete("{codigoProduto}")]
        public IList<Produto> DeleteProduto([FromRoute]int codigoProduto)
        {
            using (var context = new DatabaseContext())
            {
                var produto = context.Produtos.FirstOrDefault(p => p.Codigo == codigoProduto);
                context.Produtos.Remove(produto);
                context.SaveChanges();
                return context.Produtos.ToList();
            }
        }
    }
}