using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//sirve para acceder a las clases y metodos con ADO.NET para acceso a datos
using System.Data.SqlClient;//sirve para conectarse a base de datos sqlserver
using System.Windows.Forms;//para utilizar MessagerBox

namespace Compras
{
    class Conexcion
    {
        SqlConnection con;//tipo de dato = nombre_variable. → crea cadena de conexion
        public SqlConnection conectar()// parametros de cadena de conexoion y abrir la conexion
        {
            try//exepciones
            {
                con = new SqlConnection("data Source= DESKTOP-9255TFQ\\SQLEXPRESS; Initial Catalog= admin-user;Integrated Security= true");//datos para la conexion
                con.Open();//abre conexion
            }
            catch (Exception e) //muestra posible error
            {
                //MessageBox.Show(e.Message);//error
                MessageBox.Show("los datos no coinciden");
            }
            return con;//contiene los paremetros de conexion
        }
        public void cerrar()
        {
            con.Close();//cierra la conexion
        }
    }
}
