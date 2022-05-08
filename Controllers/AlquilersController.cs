using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlquilerGSS.Models;
using AlquilerGSS.PocoClass;

namespace AlquilerGSS.Controllers
{
    public class AlquilersController : Controller
    {
        private readonly GSSContext _context;

        public AlquilersController(GSSContext context)
        {
            _context = context;
        }


        // Listar cedula, nombre ,fecha alquiler, tiempo alquilado , saldo , placa , marca
        public async Task<IActionResult> Index(DateTime? finicio, DateTime? ffin)
        {
            try 
            {

                if (!finicio.HasValue && !ffin.HasValue)
                {

                    var query = await (from a in _context.Alquilers
                                       join c in _context.Clientes on a.Idcliente equals c.Idcliente
                                       join ca in _context.Carros on a.Idcarro equals ca.Idcarro
                                       select new DetalleAlquiler
                                       {
                                           Cedulacliente = c.Cedula,
                                           Nombrecliente = c.Nombre,
                                           Fecha = a.Fecha,
                                           Dias = a.Dias,
                                           Saldo = a.Saldo,
                                           Placacarro = ca.Placa,
                                           Marcacarro = ca.Marca
                                       }).ToListAsync();


                    return View(query);


                }
                else 
                {
                    ViewData["finicio"] = finicio;
                    ViewData["ffin"] = ffin;

                    var query = await (from a in _context.Alquilers
                                       join c in _context.Clientes on a.Idcliente equals c.Idcliente
                                       join ca in _context.Carros on a.Idcarro equals ca.Idcarro
                                       where a.Fecha >= finicio && a.Fecha <= ffin
                                       select new DetalleAlquiler
                                       {
                                           Cedulacliente = c.Cedula,
                                           Nombrecliente = c.Nombre,
                                           Fecha = a.Fecha,
                                           Dias = a.Dias,
                                           Saldo = a.Saldo,
                                           Placacarro = ca.Placa,
                                           Marcacarro = ca.Marca
                                       }).ToListAsync();


                    return View(query);

                }

                

            }            
            catch (Exception ex)
            {            
                Console.WriteLine("Exception Message: " + ex.Message);
                return null;
            }

        }



        //GET: Alquilers
        // public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Alquilers.ToListAsync());
        //}

        // GET: Alquilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquilers
                .FirstOrDefaultAsync(m => m.Idalquiler == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // GET: Alquilers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alquilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Idalquiler,Idcarro,Idcliente,Fecha,Dias,Total,Saldo,Abonoinicial,Devuelto")] Alquiler alquiler)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(alquiler);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(alquiler);
        //}

        // GET: Alquilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquilers.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }
            return View(alquiler);
        }

        // POST: Alquilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Idalquiler,Idcarro,Idcliente,Fecha,Dias,Total,Saldo,Abonoinicial,Devuelto")] Alquiler alquiler)
        //{
        //    if (id != alquiler.Idalquiler)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(alquiler);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AlquilerExists(alquiler.Idalquiler))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(alquiler);
        //}

        // GET: Alquilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquilers
                .FirstOrDefaultAsync(m => m.Idalquiler == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // POST: Alquilers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var alquiler = await _context.Alquilers.FindAsync(id);
        //    _context.Alquilers.Remove(alquiler);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AlquilerExists(int id)
        {
            return _context.Alquilers.Any(e => e.Idalquiler == id);
        }
    }
}
