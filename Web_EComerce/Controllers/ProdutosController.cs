using Application.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Web_EComerce.Controllers
{

    [Authorize]
    public class ProdutosController : Controller
    {

        
        public readonly InterfaceProductApp _InterfaceProductApp;

        public ProdutosController(InterfaceProductApp InterfaceProductApp)
        {
            _InterfaceProductApp = InterfaceProductApp;
        }

        //// GET: ProdutosController
        public async Task<IActionResult> Index()
        {
            return View(await _InterfaceProductApp.List());
        }

        // GET: ProdutosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _InterfaceProductApp.GetTEntityById(id));
        }

        // GET: ProdutosController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            try
            {
                await _InterfaceProductApp.AddProduct(produto);
                if (produto.Notitycoes.Any()) 
                {
                    foreach(var item in produto.Notitycoes) 
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                    return View("Edit", produto);
                }
             
            }
            catch
            {
                return View("Edit", produto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _InterfaceProductApp.GetTEntityById(id));
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            try
            {
                await _InterfaceProductApp.UpdateProduct(produto);
                if (produto.Notitycoes.Any())
                {
                    foreach (var item in produto.Notitycoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Edit", produto);
                }
            }
            catch
            {
                return View("Edit", produto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _InterfaceProductApp.GetTEntityById(id));
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Produto produto)
        {
            try
            {
                var produtoDeletar = await _InterfaceProductApp.GetTEntityById(id);
                await _InterfaceProductApp.Delete(produtoDeletar);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
