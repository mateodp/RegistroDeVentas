using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Compras
{
    class Consultas
    {
        Conexcion conexcion = new Conexcion();
        SqlDataAdapter dataa = new SqlDataAdapter();
        DataSet datas = new DataSet();
        Boolean estado_conexcion = false;
        SqlCommand consulta3;
        SqlCommand registro;
        public SqlDataReader datos;
        SqlDataReader Lista;
        public int i;
        public SqlCommand actualizar(string user, string pass, string nombre, string apellido)
        {
            try
            {
                consulta3 = new SqlCommand("insert into administrador(id_admin,pass,nombre,apellido) values (@id_admin,@pass,@nombre,@apellido)", conexcion.conectar());
                consulta3.CommandType = CommandType.Text;
                consulta3.Parameters.AddWithValue("@id_admin", SqlDbType.VarChar).Value = user;
                consulta3.Parameters.AddWithValue("@pass", SqlDbType.VarChar).Value = pass;
                consulta3.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = nombre;
                consulta3.Parameters.AddWithValue("@apellido", SqlDbType.VarChar).Value = apellido;
                consulta3.ExecuteNonQuery();
                MessageBox.Show("Usuario registrado con excito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return registro;
        }
        public Boolean inicio_sesion(string user, string pass)
        {
            if (i == 0)
            {
                SqlCommand conectar;//SqlCommand → escribe la consulta que se quiere ejecutar
                conectar = new SqlCommand("select id_admin, pass from administrador where id_admin=@id_admin and pass=@pass", conexcion.conectar());//consulta SqlServer
                conectar.Parameters.AddWithValue("@id_admin", user);//especifica el tipo de comando
                conectar.Parameters.AddWithValue("@pass", pass);//pasa los valores que tiene el metodo,el de abajo tambien ↓
                conectar.ExecuteNonQuery();//ejecuta la consulta Sql
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(conectar);//asocia la consulta que se va a ejecutar
                    da.Fill(datas, "administrador");//especifica de que tabla se van a tomar(llenar) los datos. Fill → llenar
                    DataRow dr;//hace referencia a las filas de una tabla
                    dr = datas.Tables["administrador"].Rows[0];//asigna una fila a la variable
                    if (user == dr["id_admin"].ToString() & pass == dr["pass"].ToString())
                    {
                        Form2 frm = new Form2();
                        frm.identificacion = int.Parse(user);
                        frm.Show();
                        estado_conexcion = true;
                    }
                    else
                    {
                        i = 1;
                    }
                }
                catch (Exception ex)
                {
                    i = 1;
                    if (i == 0)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            } if (i == 1)
            {
                SqlCommand conectar;//SqlCommand → escribe la consulta que se quiere ejecutar
                conectar = new SqlCommand("select id_user, pass from usuarios where id_user=@id_user and pass=@pass", conexcion.conectar());//consulta SqlServer
                conectar.Parameters.AddWithValue("@id_user", user);//especifica el tipo de comando
                conectar.Parameters.AddWithValue("@pass", pass);//pasa los valores que tiene el metodo,el de abajo tambien ↓
                conectar.ExecuteNonQuery();//ejecuta la consulta Sql
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(conectar);//asocia la consulta que se va a ejecutar
                    da.Fill(datas, "usuarios");//especifica de que tabla se van a tomar(llenar) los datos. Fill → llenar
                    DataRow dr;//hace referencia a las filas de una tabla
                    dr = datas.Tables["usuarios"].Rows[0];//asigna una fila a la variable
                    if (user == dr["id_user"].ToString() & pass == dr["pass"].ToString())
                    {
                       /* Form3 frm = new Form3();
                        frm.Show();
                        estado_conexcion = true;*/
                    }
                    else
                    {
                        i = 1;
                    }
                }
                catch (Exception ex)
                {
                    i = 2;
                    if (i == 0)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (i == 2)
            {
                MessageBox.Show("no esta registrado", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return estado_conexcion;
        }
        public SqlCommand registro_admin(string user, string pass, string nombre, string apellido)
        {
            try
            {
                registro = new SqlCommand("insert into administrador(id_admin,pass,nombre,apellido) values (@id_admin,@pass,@nombre,@apellido)", conexcion.conectar());
                registro.CommandType = CommandType.Text;
                registro.Parameters.AddWithValue("@id_admin", SqlDbType.VarChar).Value = user;
                registro.Parameters.AddWithValue("@pass", SqlDbType.VarChar).Value = pass;
                registro.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = nombre;
                registro.Parameters.AddWithValue("@apellido", SqlDbType.VarChar).Value = apellido;
                registro.ExecuteNonQuery();
                MessageBox.Show("Usuario registrado con excito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return registro;
        }
        public SqlCommand registro_compra(string user, string pass, string nombre, string apellido, string admin)
        {
            try
            {
                registro = new SqlCommand("insert into usuarios(id_user,pass,nombre,apellido,id_admin) values (@id_user,@pass,@nombre,@apellido,@id_admin)", conexcion.conectar());
                registro.CommandType = CommandType.Text;
                registro.Parameters.AddWithValue("@id_user", SqlDbType.VarChar).Value = user;
                registro.Parameters.AddWithValue("@pass", SqlDbType.VarChar).Value = pass;
                registro.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = nombre;
                registro.Parameters.AddWithValue("@apellido", SqlDbType.VarChar).Value = apellido;
                registro.Parameters.AddWithValue("@id_admin", SqlDbType.VarChar).Value = admin;
                registro.ExecuteNonQuery();
                MessageBox.Show("Usuario registrado con excito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return registro;
        }
        public SqlCommand registro_categoria(string idcat,string nombcat, string admin)
        {
            try
            {
                registro = new SqlCommand("insert into categorias(id_categorias,nombre_categorias,id_admin) values (@id_categorias,@nombre_categorias,@id_admin)", conexcion.conectar());
                registro.CommandType = CommandType.Text;
                registro.Parameters.AddWithValue("@id_categorias", SqlDbType.VarChar).Value = idcat;
                registro.Parameters.AddWithValue("@nombre_categorias", SqlDbType.VarChar).Value = nombcat;
                registro.Parameters.AddWithValue("@id_admin", SqlDbType.VarChar).Value = admin;
                registro.ExecuteNonQuery();
                MessageBox.Show("Categoria registrada con excito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return registro;
        }
        public void Lista_categorias(ComboBox cb)
        {
            cb.Items.Clear();
            conexcion.conectar();
            SqlCommand cmd = new SqlCommand("select nombre_categorias from categorias", conexcion.conectar());
            Lista = cmd.ExecuteReader();
            while (Lista.Read())
            {
                cb.Items.Add(Lista[0].ToString());
            }
            cb.Items.Insert(0, "Categorias");
            cb.SelectedIndex = 0;
        }
        public SqlCommand registro_productos(string idprod, string idcat, string nombreprod, string precioprod)
        {

            try
            {
                registro = new SqlCommand("insert into categorias(id_productos,id_categoria,nombre_productos,precio_productos) values (@id_productos,@id_categoria,@nombre_productos,@precio_productos)", conexcion.conectar());
                registro.CommandType = CommandType.Text;
                registro.Parameters.AddWithValue("@id_productos", SqlDbType.VarChar).Value = idprod;
                registro.Parameters.AddWithValue("@id_categoria", SqlDbType.VarChar).Value = idcat;
                registro.Parameters.AddWithValue("@nombre_productos", SqlDbType.VarChar).Value = nombreprod;
                registro.Parameters.AddWithValue("@precio_productos", SqlDbType.VarChar).Value = precioprod;
                registro.ExecuteNonQuery();
                MessageBox.Show("Producto registrado con excito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return registro;
        }
    }
}
