using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite﻿;

namespace Naval_servidor
{
    public partial class BD_Form : Form
    {
        public BD_Form()
        {
            InitializeComponent();
        }

        private void crear_bd_btn_Click(object sender, EventArgs e)
        {

        }

        private void consultar_btn_Click(object sender, EventArgs e)
        {
            SQLiteConnection conexion = new SQLiteConnection("Data Source = D:/usuarios.sqlite");
            conexion.Open();

            string consulta = "select * from Usuarios";
            SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
            SQLiteDataReader datos = comando.ExecuteReader();

            while (datos.Read())
            {
                //string nombre = Convert.ToString(datos[0]);
                string nombre = datos.GetString(0);
                textBox1.Text = textBox1.Text + nombre;
                textBox1.Text = textBox1.Text + "\n";

            }
            conexion.Close();

        }

        private void BD_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
