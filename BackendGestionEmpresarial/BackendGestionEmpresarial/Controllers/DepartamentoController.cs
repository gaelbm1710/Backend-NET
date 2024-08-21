using BackendGestionEmpresarial.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace BackendGestionEmpresarial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartamentoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Departamentos";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpresaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Departamentos dep)
        {
            string query = @"insert into Departamentos values (@Nombre, @Descripcion)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpresaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Nombre", dep.Nombre);
                    myCommand.Parameters.AddWithValue("@Descripcion", dep.Descripcion);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Se Agrego el Departamento Exitosamente");
        }
        [HttpPut]
        public JsonResult Put(Departamentos dep)
        {
            string query = @"update Departamentos set Nombre= @Nombre, Descripcion = @Descripcion where DepartamentoID = @DepartamentoID ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpresaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartamentoID", dep.DepartamentoID);
                    myCommand.Parameters.AddWithValue("@Nombre", dep.Nombre);
                    myCommand.Parameters.AddWithValue("@Descripcion", dep.Descripcion);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Se actualizo Correctamente el Departamento");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from Departamentos where DepartamentoID = @DepartamentoID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpresaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartamentoID", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Se elimino de forma correcta el Departamento");
        }
    }
}
