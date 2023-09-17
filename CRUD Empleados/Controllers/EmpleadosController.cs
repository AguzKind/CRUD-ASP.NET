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
            return RedirectToAction("Index");
        }

        // Metodo Get para tomar un id de la lista y editarlo
        [HttpGet]
        public async Task<IActionResult> Editar(Guid id)
        {
            var empleado = await mvcDemoDbContext.Empleados.FirstOrDefaultAsync(x => x.Id == id);

            if (empleado != null)
            {
                var viewModel = new EditarEmpleadoViewModel()
                {
                    Id = empleado.Id,
                    Nombre = empleado.Nombre,
                    Email = empleado.Email,
                    Nacimiento = empleado.Nacimiento,
                    Puesto = empleado.Puesto,
                    Sueldo = empleado.Sueldo,
                };
                return await Task.Run(() => View("Editar", viewModel));
            }

            

            return RedirectToAction("Index");
        }

        // Metodo Post para aceptar los cambios en el empleado
        [HttpPost]
        public async Task<IActionResult> Editar(EditarEmpleadoViewModel model)
        {
            var empleado = await mvcDemoDbContext.Empleados.FindAsync(model.Id);

            if (empleado != null)
            {
                empleado.Nombre = model.Nombre;
                empleado.Email = model.Email;
                empleado.Nacimiento = model.Nacimiento;
                empleado.Puesto = model.Puesto;
                empleado.Sueldo = model.Sueldo;

                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // Metodo Post para eliminar el empleado segun el id
        [HttpPost]
        public async Task<IActionResult> Borrar(EditarEmpleadoViewModel model)
        {
            var empleado = await mvcDemoDbContext.Empleados.FindAsync(model.Id);
            if (empleado != null) 
            {
                mvcDemoDbContext.Empleados.Remove(empleado);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
