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
        Button boton;
        public Categorias()
        {
            InitializeComponent();
            mostrarBotones();
        }

        private void mostrarBotones()
        {
            String myConex = "Server=localhost;Database=tpv;Uid=root;Pwd=1234;";
            MySqlConnection conex = new MySqlConnection(myConex);

            MySqlCommand cmd;
            conex.Open();

            cmd = conex.CreateCommand();
            cmd.CommandText = "Select distinct(categoria) from productos";

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    boton = new Button();
                    boton.Text = data.GetString(0);
                    boton.Click += new EventHandler(onClick_Boton);
                    panel.Controls.Add(boton);
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
            Productos produc = new Productos(this);
            produc.ShowDialog();
        }
    }
}
