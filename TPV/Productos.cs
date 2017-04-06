using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPV
{
    public partial class Productos : Form
    {
        String nombre_categoria;
        Categorias cat;
      
        public Productos(Form categoria,String nombre)
        {
            InitializeComponent();
            mostrarbotones();
            nombre_categoria = nombre;
            cat = (Categorias) categoria;
        }

        private void mostrarbotones()
        {
            String myConex = "Server=localhost;Database=tpv;Uid=root;Pwd=root;";

            MySqlConnection conex = new MySqlConnection();
            conex.ConnectionString = myConex;
            conex.Open();
            //MessageBox.Show(nombre_categoria);




            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT nombre,precio FROM productos WHERE categoria=('"+nombre_categoria+"');";
            cmd.Connection = conex;
            

          
            

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Button boton = new Button();
                    boton.Text = data.GetString(0);
                    boton.Click += new EventHandler(onClick_Boton);
                    flowLayoutPanelProductos.Controls.Add(boton);
                }
            }
        }

        private void onClick_Boton(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
