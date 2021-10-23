using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Consultas consultas = new Consultas();
       Form2 f = new Form2();
        private void button1_Click(object sender, EventArgs e)
        {
            consultas.i = 0;
           
            consultas.inicio_sesion(textBox1.Text, textBox2.Text);
            f.id = int.Parse(textBox1.Text);
        }
    }
}
