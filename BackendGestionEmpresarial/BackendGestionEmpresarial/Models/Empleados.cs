namespace BackendGestionEmpresarial.Models
{
    //Modelo para el Empleado
    public class Empleados
    {
        public int EmpleadoID { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public string DepartamentoID { get; set; }
        public DateTime FechaContratacion { get; set; }
        public double Salario {  get; set; }

    }
}
