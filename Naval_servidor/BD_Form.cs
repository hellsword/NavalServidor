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
            SQLiteConnection conexion = new SQLiteConnection("Data Source = C:/Users/DarkAsus/Documents/GitHub/NavalServidor/usuarios.sqlite");
            conexion.Open();

            string consulta = "select * from Jugadores;";

            SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
            SQLiteDataReader datos = comando.ExecuteReader();

            //textBox1.Text = textBox1.Text + "datos:" + datos.Read() + "\r\n";

            while (datos.Read())
            {
                //string nombre = Convert.ToString(datos[0]);
                string nombre = datos.GetString(0);
                string victorias = Convert.ToString(datos[1]);
                string derrotas = Convert.ToString(datos[2]);
                string porc_victorias = Convert.ToString(datos[3]);

                textBox1.Text = textBox1.Text + "Nombre: " + nombre + "\r\n";
                textBox1.Text = textBox1.Text + "victorias: " + victorias + "\r\n";
                textBox1.Text = textBox1.Text + "derrotas: " + derrotas + "\r\n";
                textBox1.Text = textBox1.Text + "% victorias: " + porc_victorias + "\r\n";
                textBox1.Text = textBox1.Text + "\r\n";

            }
            conexion.Close();

        }

        private void BD_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
