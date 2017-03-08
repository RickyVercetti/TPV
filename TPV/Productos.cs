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
        String cat;
      
        public Productos(Form categoria,String nombre_categoria)
        {
            InitializeComponent();
            mostrarbotones();
            cat = nombre_categoria;
        }

        private void mostrarbotones()
        {
            String myConex = "Server=localhost;Database=tpv;Uid=root;Pwd=1234;";
            MySqlConnection conex = new MySqlConnection(myConex);

            MySqlCommand cmd;
            conex.Open();

            cmd = conex.CreateCommand();
            cmd.CommandText = "SELECT * FROM tpv.productos WHERE categoria='"+cat+"'";

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                   
                    Button boton = new Button();
                    boton.Text = data.GetString(0);
                    //boton.Click += new EventHandler(onClick_Boton);
                    flowLayoutPanelProductos.Controls.Add(boton);
                }
            }
        }
    }
}
