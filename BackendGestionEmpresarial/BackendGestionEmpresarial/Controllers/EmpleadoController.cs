using BackendGestionEmpresarial.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;

namespace BackendGestionEmpresarial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmpleadoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Empleados";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpresaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, myConn))
                {
                    myReader = sqlCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Empleados emp)
        {
            string query = @"insert into Empleados values (@Nombre, @Apellido, @DepartamentoID, @FechaContratacion, @Salario)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpresaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommad = new SqlCommand(query, myCon))
                {
                    myCommad.Parameters.AddWithValue("@Nombre", emp.Nombre);
                    myCommad.Parameters.AddWithValue("@Apellido", emp.Apellido);
                    myCommad.Parameters.AddWithValue("@DepartamentoID", emp.DepartamentoID);
                    myCommad.Parameters.AddWithValue("@FechaContratacion", emp.FechaContratacion);
                    myCommad.Parameters.AddWithValue("@Salario", emp.Salario);
                    myReader = myCommad.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Se Agrego el Empleado Exitosamente");
        }
        /*
         *  myCommad.Parameters.AddWithValue("@Nombre", emp.Nombre);
                    myCommad.Parameters.AddWithValue("@Apellido", emp.Apellido);
                    myCommad.Parameters.AddWithValue("@DepartamentoID", emp.DepartamentoID);
                    myCommad.Parameters.AddWithValue("@FechaContratacion", emp.FechaContratacion);
                    myCommad.Parameters.AddWithValue("@Salario", emp.Salario);
          */
        [HttpPut]
        public JsonResult Put(Empleados emp)
        {
            string query = @"update Empleados set Nombre = @Nombre, Apellido = @Apellido, DepartamentoID = @DepartamentoID, FechaContratacion = @FechaContratacion, Salario = @Salario where EmpleadoID = @EmpleadoID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpresaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmpleadoID", emp.EmpleadoID);
                    myCommand.Parameters.AddWithValue("@Nombre", emp.Nombre);
                    myCommand.Parameters.AddWithValue("@Apellido", emp.Apellido);
                    myCommand.Parameters.AddWithValue("@DepartamentoID", emp.DepartamentoID);
                    myCommand.Parameters.AddWithValue("@FechaContratacion", emp.FechaContratacion);
                    myCommand.Parameters.AddWithValue("@Salario", emp.Salario);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Se actualizo el Empleado de forma correcta");

        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from Empleados where EmpleadoID = @EmpleadoID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpresaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommad = new SqlCommand(query, myCon))
                {
                    myCommad.Parameters.AddWithValue("@EmpleadoID", id);
                    myReader=myCommad.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Se elimino el empleado exitosamente");
        }
    }
}
