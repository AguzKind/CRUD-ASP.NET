namespace CRUD_Empleados.Models.Domain
{
    public class Empleado
    {
        // Lo que se busca en la db
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public string Email { get; set;}

        public DateTime Nacimiento { get; set;}

        public long Sueldo { get; set;}

        public string Puesto { get; set;}
    }
}
