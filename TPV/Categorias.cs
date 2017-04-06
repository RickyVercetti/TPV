using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPV
{
    public partial class Categorias : Form
    {
        
        public Categorias()
        {
            InitializeComponent();
            mostrarBotones();
        }

        private void mostrarBotones()
        {
            String myConex = "Server=localhost;Database=tpv;Uid=root;Pwd=root;";
            MySqlConnection conex = new MySqlConnection(myConex);

            MySqlCommand cmd;
            conex.Open();

            cmd = conex.CreateCommand();
            cmd.CommandText = "SELECT distinct(categoria) FROM tpv.productos";

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Button boton = new Button();
                    boton.Text = data.GetString(0);
                    boton.Name = data.GetString(0);
                    boton.BackColor = Color.Transparent;
                    boton.Size  = new Size(150,100);
                    boton.Click += new EventHandler(onClick_Boton);
                    flowLayoutPanel1.Controls.Add(boton);
                }
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Realizado por: Ricardo Campos");
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void onClick_Boton(object sender, EventArgs e)
        {
            String categoria = ((Button)sender).Text;
            Productos produc = new Productos(this,categoria);
            MessageBox.Show(categoria);
            produc.ShowDialog();
        }
    }
}
