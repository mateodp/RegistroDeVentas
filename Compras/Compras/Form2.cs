using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;//sirve para acceder a las clases y metodos con ADO.NET para acceso a datos
using System.Data.SqlClient;//sirve para conectarse a base de datos sqlserver

namespace Compras
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
            textBox6.Text = id.ToString();
            consultas.Lista_categorias(comboBox2);

        }
        Conexcion conexcion = new Conexcion();
        SqlDataAdapter dataa = new SqlDataAdapter();
        DataSet datas = new DataSet();
        Consultas consultas = new Consultas();
        SqlCommand consultar_admi;
        SqlCommand consultar_compra;
        SqlCommand consultar_categoria;
        SqlCommand consultar_produc;
        SqlCommand idcatego;
        public int id;
        string idcate;
        string opcion;
        public int identificacion;
        public void consultar_Admins()
        {
            consultar_admi = new SqlCommand("select * from administrador", conexcion.conectar());
            consultar_admi.CommandType = CommandType.Text;
            consultar_admi.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(consultar_admi);
            da.Fill(datas, "administrador");
            try
            {
                dataGridView1.DataMember = ("administrador");
                dataGridView1.DataSource = datas;
            }
            catch (Exception e) //muestra posible error
            {

                MessageBox.Show("usuario NO esta registrado");

            }
        }
        public void consultar_comprad()
        {
            consultar_compra = new SqlCommand("select * from usuarios", conexcion.conectar());
            consultar_compra.CommandType = CommandType.Text;
            consultar_compra.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(consultar_compra);
            da.Fill(datas, "usuarios");
            try
            {
                dataGridView1.DataMember = ("usuarios");
                dataGridView1.DataSource = datas;
            }
            catch (Exception e) //muestra posible error
            {

                MessageBox.Show("usuario NO esta registrado");

            }
        }
        public void consultar_cat()
        {
            consultar_categoria = new SqlCommand("select * from categorias", conexcion.conectar());
            consultar_categoria.CommandType = CommandType.Text;
            consultar_categoria.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(consultar_categoria);
            da.Fill(datas, "categorias");
            try
            {
                dataGridView1.DataMember = ("categorias");
                dataGridView1.DataSource = datas;
            }
            catch (Exception e) //muestra posible error
            {
                MessageBox.Show("");
            }
        }
        public void consultar_pro()
        {
            consultar_produc = new SqlCommand("select * from productos", conexcion.conectar());
            consultar_produc.CommandType = CommandType.Text;
            consultar_produc.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(consultar_produc);
            da.Fill(datas, "productos");
            try
            {
                dataGridView1.DataMember = ("productos");
                dataGridView1.DataSource = datas;
            }
            catch (Exception e) //muestra posible error
            {
                MessageBox.Show("");
            }
        }
        public void Modificar_admin(string user, string pass, string nombre, string apellido)
        {
            SqlCommand actualizar = new SqlCommand("update administrador set pass=@pass, nombre=@nombre, apellido=@apellido where id_admin=@id_admin", conexcion.conectar());
            try
            {
                actualizar.Parameters.AddWithValue("@id_admin", user);
                actualizar.Parameters.AddWithValue("@pass", pass);
                actualizar.Parameters.AddWithValue("@nombre", nombre);
                actualizar.Parameters.AddWithValue("@apellido", apellido);
                actualizar.ExecuteNonQuery();
                datas.Clear();
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Modificar_user(string user, string pass, string nombre, string apellido)
        {
            SqlCommand actualizar = new SqlCommand("update usuarios set pass=@pass, nombre=@nombre, apellido=@apellido where id_user=@id_user", conexcion.conectar());
            try
            {
                actualizar.Parameters.AddWithValue("@id_user", user);
                actualizar.Parameters.AddWithValue("@pass", pass);
                actualizar.Parameters.AddWithValue("@nombre", nombre);
                actualizar.Parameters.AddWithValue("@apellido", apellido);
                actualizar.ExecuteNonQuery();
                datas.Clear();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Modificar_categorias(string user, string nombre_categoria, string id_admin)
        {
            SqlCommand actualizar = new SqlCommand("update categorias set nombre_categorias=@nombre_categorias, id_admin=@id_admin where id_categorias=@id_categorias", conexcion.conectar());
            try
            {
                actualizar.Parameters.AddWithValue("@id_categorias", user);
                actualizar.Parameters.AddWithValue("@nombre_categorias", nombre_categoria);
                actualizar.Parameters.AddWithValue("@id_admin", id_admin);
                actualizar.ExecuteNonQuery();
                datas.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Adminitrador")
            {
                consultas.registro_admin(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            }
            else if (comboBox1.Text == "Comprador")
            {
                consultas.registro_compra(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text);
            }
            groupBox3.Visible = false;
            button10.Enabled = true;
            button5.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = id.ToString();           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox5.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("llene los datos para el registro", "AVISO", MessageBoxButtons.OK);
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            button5.Enabled = false;
            button10.Enabled = false;
            id=int.Parse(textBox6.Text);
            label6.Visible = false;
            textBox6.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(24, 28);
            this.Size = new Size(720, 520);
            textBox6.Text = identificacion.ToString(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(24, 28);
            this.Size = new Size(720, 500);
            opcion = "Administrador";
            groupBox4.Visible = true;
            groupBox4.Size = new Size(455, groupBox4.Size.Height);
            dataGridView1.Size = new Size(440, dataGridView1.Size.Height);
            datas.Clear();
            consultar_Admins();
            groupBox3.Visible = false;
            button5.Enabled = true;
          /*button10.Enabled = false;
            textBox5.Visible = false;
            label5.Visible = false;     */    
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(70, 28);
           this.Size = new Size(825, 500);
            opcion = "Comprador";
            consultar_comprad();
            groupBox4.Visible = true;
            groupBox4.Size = new Size(560, groupBox4.Size.Height);
            dataGridView1.Size = new Size(543, dataGridView1.Size.Height);
            datas.Clear();
            consultar_comprad();
            groupBox3.Visible = false;
            button5.Enabled = true;
            button10.Enabled = true;
            textBox5.Visible = true;
            label5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (opcion == "Administrador")
            {
             Modificar_admin(dataGridView1.CurrentRow.Cells["id_admin"].Value.ToString(),dataGridView1.CurrentRow.Cells["pass"].Value.ToString(),dataGridView1.CurrentRow.Cells["nombre"].Value.ToString(),dataGridView1.CurrentRow.Cells["apellido"].Value.ToString());
             groupBox4.Visible = true;
             groupBox4.Size = new Size(550, groupBox4.Size.Height);
             dataGridView1.Size = new Size(600, dataGridView1.Size.Height);
            datas.Clear();
            consultar_Admins();
            }
            if (opcion == "Comprador")
            {
                Modificar_user(dataGridView1.CurrentRow.Cells["id_user"].Value.ToString(), dataGridView1.CurrentRow.Cells["pass"].Value.ToString(), dataGridView1.CurrentRow.Cells["nombre"].Value.ToString(), dataGridView1.CurrentRow.Cells["apellido"].Value.ToString());
                groupBox4.Visible = true;
                groupBox4.Size = new Size(550, groupBox4.Size.Height);
                dataGridView1.Size = new Size(600, dataGridView1.Size.Height);
                datas.Clear();
                consultar_comprad();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (opcion == "Administrador")
            {
                SqlCommand borrarctg = new SqlCommand("DELETE from categorias where id_admin=@id_admin", conexcion.conectar());
                borrarctg.Parameters.AddWithValue("@id_admin", textBox5.Text);
                borrarctg.ExecuteNonQuery();
                SqlCommand comando = new SqlCommand("DELETE from Administrador where id_admin=@id_admin", conexcion.conectar());
                comando.Parameters.AddWithValue("@id_admin", textBox5.Text);
                comando.ExecuteNonQuery();
                datas.Clear();
                consultar_Admins();
            }
            if (opcion == "Comprador")
            {
                SqlCommand comando = new SqlCommand("DELETE from usuarios where id_user=@id_user", conexcion.conectar());
                comando.Parameters.AddWithValue("@id_user", textBox5.Text);
                comando.ExecuteNonQuery();
                datas.Clear();
                consultar_comprad();
            }
            if (opcion == "categoria")
            {
                SqlCommand comando = new SqlCommand("DELETE from categorias where id_categorias=@id_categorias", conexcion.conectar());
                comando.Parameters.AddWithValue("@id_categorias", textBox5.Text);
                comando.ExecuteNonQuery();
                datas.Clear();
                consultar_cat();
            }
            textBox5.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Adminitrador")
            {
                label6.Visible = false;
                textBox6.Visible = false;
            }
            if(comboBox1.Text == "Comprador")
            {
                label6.Visible = true;
                textBox6.Visible = true;
                textBox6.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void consult_categoria_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox6.Visible = false;
            datas.Clear();
            consultar_cat();
            opcion = "categoria";
            button10.Enabled = true;
        }

        private void add_categoria_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            groupBox6.Visible = true;
            id = int.Parse(textBox6.Text);
            textBox9.Text = id.ToString();
            textBox9.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox9.Enabled = false;
           consultas.registro_categoria(textBox7.Text, textBox8.Text, textBox9.Text);
           id = int.Parse(textBox6.Text);
        }

        private void modif_categoria_Click(object sender, EventArgs e)
        {
            if (opcion == "categoria")
            {
                Modificar_categorias(dataGridView1.CurrentRow.Cells["id_categorias"].Value.ToString(), dataGridView1.CurrentRow.Cells["nombre_categorias"].Value.ToString(), dataGridView1.CurrentRow.Cells["id_admin"].Value.ToString());
                datas.Clear();
                consultar_cat();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox8.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox8.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            consultar_pro();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            groupBox8.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (comboBox2.Text=="lacteos")
            {
                idcatego = new SqlCommand("select id_categorias from categorias where nombre_categorias==lacteos", conexcion.conectar());
                idcatego.CommandType = CommandType.Text;
                idcatego.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(idcatego);
                da.Fill(datas, "categorias");

                idcate = ("categorias");
                    idcate = datas.ToString(); 
               */ 
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            consultas.registro_productos(textBox11.Text, idcate, textBox10.Text, textBox12.Text);
        }
    }
}
