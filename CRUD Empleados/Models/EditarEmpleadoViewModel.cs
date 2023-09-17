namespace CRUD_Empleados.Models
{
    public class EditarEmpleadoViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public string Email { get; set; }

        public DateTime Nacimiento { get; set; }

        public long Sueldo { get; set; }

        public string Puesto { get; set; }
    }
}
