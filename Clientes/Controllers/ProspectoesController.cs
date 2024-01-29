using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clientes.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Clientes.Controllers
{
    public class ProspectoesController : Controller
    {
        private readonly PROSPECTOSContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProspectoesController(PROSPECTOSContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Prospectoes
        public async Task<IActionResult> Index()
        {
              return _context.Prospectos != null ? 
                          View(await _context.Prospectos.ToListAsync()) :
                          Problem("Entity set 'PROSPECTOSContext.Prospectos'  is null.");
        }

        // GET: Prospectoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prospectos == null)
            {
                return NotFound();
            }

            var prospecto = await _context.Prospectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prospecto == null)
            {
                return NotFound();
            }

            return View(prospecto);
        }

        // GET: Prospectoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prospectoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,PrimerApellido,SegundoApellido,Calle,Numero,Colonia,CodigoPostal,Telefono,Rfc,Estatus,Activo,Fecha,Archivo")] Prospecto prospecto)
        {
            if (ModelState.IsValid)
            {
                if (prospecto.Archivo != null && prospecto.Archivo.Length > 0)
                {
                    try
                    {
                        // Guardar el archivo en el sistema de archivos
                        string directorioArchivos = Path.Combine(_hostEnvironment.ContentRootPath, "Archivos");
                        if (!Directory.Exists(directorioArchivos))
                        {
                            Directory.CreateDirectory(directorioArchivos);
                        }

                        string nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(prospecto.Archivo.FileName);
                        string rutaArchivo = Path.Combine(directorioArchivos, nombreArchivo);

                        using (var stream = new FileStream(rutaArchivo, FileMode.Create))
                        {
                            await prospecto.Archivo.CopyToAsync(stream);
                        }

                        // Almacena el nombre del archivo en la base de datos
                        prospecto.NombreArchivo = nombreArchivo;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = $"Error al guardar el archivo: {ex.Message}";
                        return View(prospecto);
                    }
                }

                _context.Add(prospecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { success = true });
            }
            return View(prospecto);
        }

        public IActionResult VerPDF(string nombreArchivo)
        {
            var rutaArchivo = Path.Combine(Directory.GetCurrentDirectory(), "Archivos", nombreArchivo);

            if (System.IO.File.Exists(rutaArchivo))
            {
                // Leer el contenido del archivo
                var contenidoArchivo = System.IO.File.ReadAllBytes(rutaArchivo);

                // Devolver el contenido del archivo como un archivo PDF
                return File(contenidoArchivo, "application/pdf");
            }
            else
            {
                // Devolver un resultado 404 si el archivo no existe
                return NotFound();
            }
        }


        // GET: Prospectoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prospectos == null)
            {
                return NotFound();
            }

            var prospecto = await _context.Prospectos.FindAsync(id);
            if (prospecto == null)
            {
                return NotFound();
            }
            return View(prospecto);
        }

        // POST: Prospectoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,PrimerApellido,SegundoApellido,Calle,Numero,Colonia,CodigoPostal,Telefono,Rfc,Estatus,Activo,Fecha,Observaciones,NombreArchivo")] Prospecto prospecto)
        {
            if (id != prospecto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prospecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProspectoExists(prospecto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { success = true });
            }
            return View(prospecto);
        }

        // GET: Prospectoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prospectos == null)
            {
                return NotFound();
            }

            var prospecto = await _context.Prospectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prospecto == null)
            {
                return NotFound();
            }

            return View(prospecto);
        }

        // POST: Prospectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prospectos == null)
            {
                return Problem("Entity set 'PROSPECTOSContext.Prospectos'  is null.");
            }
            var prospecto = await _context.Prospectos.FindAsync(id);
            if (prospecto != null)
            {
                _context.Prospectos.Remove(prospecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProspectoExists(int id)
        {
          return (_context.Prospectos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
