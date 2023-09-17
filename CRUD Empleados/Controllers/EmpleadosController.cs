using CRUD_Empleados.Data;
using CRUD_Empleados.Models;
using CRUD_Empleados.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Empleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public EmpleadosController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        // Metodo GET para leer todos los empleados de la Db
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var empleados = await mvcDemoDbContext.Empleados.ToListAsync();
            return View(empleados);

        }


        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        // Metodo Post para Agregar un nuevo empleado en la Db
        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarEmpleadoViewModel agregarEmpleadoRequest)
        {
            var empleado = new Empleado()
            {
                Id = Guid.NewGuid(),
                Nombre = agregarEmpleadoRequest.Nombre,
                Email = agregarEmpleadoRequest.Email,
                Nacimiento = agregarEmpleadoRequest.Nacimiento,
                Puesto = agregarEmpleadoRequest.Puesto,
                Sueldo = agregarEmpleadoRequest.Sueldo,
            };
            await mvcDemoDbContext.Empleados.AddAsync(empleado);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Agregar");
        }
    }
}
