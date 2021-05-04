using Application.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OpenApp
{
    public class AppProduct : InterfaceProductApp
    {
        IProduct _IProduct;
        IServiceProduct _IServiceProduct;
        public AppProduct(IProduct IProduct, IServiceProduct IServiceProduct)
        {
            _IProduct = IProduct;
            _IServiceProduct = IServiceProduct;
        }

        public async Task AddProduct(Produto produto)
        {
            await _IServiceProduct.AddProduct(produto);
        }
        public async Task UpdateProduct(Produto produto)
        {
            await _IServiceProduct.UpdateProduct(produto);
        }

        public async Task Add(Produto Objecto)
        {
            await _IProduct.Add(Objecto);
        }
        public async Task Delete(Produto Objecto)
        {
            await _IProduct.Delete(Objecto);
        }

        public async Task<Produto> GetTEntityById(int Id)
        {
           return await _IProduct.GetTEntityById(Id);
        }

        public async Task<List<Produto>> List()
        {
            return await _IProduct.List();
        }

        public async Task Update(Produto Objecto)
        {
            await _IProduct.Update(Objecto);
        }

       
    }
}
