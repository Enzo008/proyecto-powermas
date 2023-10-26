using Microsoft.Data.SqlClient;
namespace PROYECTO.Modulos
{
    public class conexionDAO
    {
        //atributo de conexion de alcance local
        private SqlConnection cn = new SqlConnection(@"server=DESKTOP-7G09PKQ; Database=BdProductos;" +
        "Trusted_Connection=true; MultipleActiveResultSets=true; TrustServerCertificate=false; Encrypt=false");

        //propiedad donde retorna la conexion
        public SqlConnection getcn { get { return cn; } }
    }
}
