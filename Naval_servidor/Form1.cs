using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Data.SQLite﻿;

namespace Naval_servidor
{
    public partial class Form1 : Form
    {
        public static int PORT = 9500;
        public TcpListener ServerSocket = new TcpListener(IPAddress.Any, PORT);
        public Thread[] t;
        public Thread _principal;
        static TcpClient client;
        static List<Cliente> lista_clientes = new List<Cliente>();
        static string username;
        Cliente cliente;
        static List<int> lista_espera = new List<int>();


        public static int CONEX = 10;

        static readonly object _lock = new object();
        static Random rnd = new Random();


        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            ServerSocket.Start();
            t = new Thread[CONEX];


            _principal = new Thread(delegate ()//Start live acquisition
            {
                // thread logic 
                principal();
            });

            _principal.Start();

        }

        private void principal()
        {
            int count = 1;
            int pares = 0;
            int id_hilo = 0;

            Console.WriteLine("Se ha abierto un nuevo canal de conexión: " + id_hilo);


            //this.Show();

            while (true)
            {

                if (id_hilo >= CONEX)
                {
                    Console.WriteLine("Ha alcanzado el máximo de conexiones");
                }
                else
                {
                    //ver identificacion TcpClient
                    client = ServerSocket.AcceptTcpClient();

                    lock (_lock)
                    {
                        Cliente cliente = new Cliente();
                        cliente.id = count;
                        cliente.cliente_TCP = client;
                        cliente.estado = "esperando";
                        //cliente.hilo = id_hilo;
                        lista_clientes.Add(cliente);

                        //////////////////////

                        lista_espera.Add(count);

                        client = cliente.cliente_TCP;

                        //Recibe el nombre del usuario que se esta conectando
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = new byte[1024];
                        int byte_count = stream.Read(buffer, 0, buffer.Length);
                        username = Encoding.ASCII.GetString(buffer, 0, byte_count);
                        cliente.username = username;

                        chat_text.Text = chat_text.Text + username + "\r\n";

                        //Se agrega el usuario a la sala de espera
                        lista_jugadores.Rows.Add(cliente.username, "esperando rival...");
                    }
                    count++;
                    pares++;

                    if (pares == 2)
                    {
                        pares = 0;
                        id_hilo++;
                        //Console.WriteLine("Se ha abierto un nuevo canal de conexión: " + id_hilo);
                    }

                }
            }

        }


        //Envia el mensaje de un cliente a su rival
        static void envia_a_rival(string data, Cliente cliente_actual)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);

            //Bloquea una seccion critica
            lock (_lock)
            {
                //Busca al rival para enviarle el mensaje
                Cliente rival = lista_clientes.FirstOrDefault(x => x.cliente_TCP != cliente_actual.cliente_TCP && x.hilo == cliente_actual.hilo);
                
                NetworkStream stream = rival.cliente_TCP.GetStream();
                stream.Write(buffer, 0, buffer.Length);

            }
        }


        public void Controlador_clientes(object o)
        {

            int id = (int)o;

            TcpClient client;
            Cliente cliente = lista_clientes.FirstOrDefault(x => x.id == id);

            lock (_lock) client = cliente.cliente_TCP;

            //Recibe mensajes
            NetworkStream stream = client.GetStream();

            lock (_lock)
            {
                
                SQLiteConnection conexion = new SQLiteConnection("Data Source = C:/Users/DarkAsus/Documents/GitHub/NavalServidor/usuarios.sqlite");
                conexion.Open();

                string consulta = "select * from Jugadores where nombre = '" + cliente.username + "';";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                SQLiteDataReader datos = comando.ExecuteReader();

                //chat_text.Text = chat_text.Text + username + " conectado!! \r\n";
                //chat_text.Text = chat_text.Text + "\nLista clientes actuales: \r\n";

                if (datos.Read())
                {
                    //Si el usuario existe en la BD, obtiene los datos
                    cliente.victorias = Convert.ToInt32(datos[1]);
                    cliente.derrotas = Convert.ToInt32(datos[2]);
                    cliente.porc_victorias = Convert.ToInt32(datos[3]);
                }
                else
                {
               
                    //Sino inicializa todo en cero
                    cliente.victorias = 0;
                    cliente.derrotas = 0;
                    cliente.porc_victorias = 0;
                }
            }


            /*
            foreach (Cliente c in lista_clientes)
            {

                chat_text.Text = chat_text.Text + "id: " + c.id + "\r\n";
                chat_text.Text = chat_text.Text + "username: " + c.username + "\r\n";
                chat_text.Text = chat_text.Text + "hilo: " + c.hilo + "\r\n";
                chat_text.Text = chat_text.Text + "victorias: " + c.victorias + "\r\n";
                chat_text.Text = chat_text.Text + "derrotas: " + c.derrotas + "\r\n";
                chat_text.Text = chat_text.Text + "porc_victorias: " + c.porc_victorias + "\r\n";
                chat_text.Text = chat_text.Text + "\r\n";
            }
            chat_text.Text = chat_text.Text + "****************** \r\n";
            */

            while (true)
            {

                stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int byte_count = stream.Read(buffer, 0, buffer.Length);

                if (byte_count == 0)
                {
                    break;
                }

                Cliente rival = lista_clientes.FirstOrDefault(x => x.cliente_TCP != cliente.cliente_TCP && x.hilo == cliente.hilo);

                lock (_lock)
                {

                    SQLiteConnection conexion = new SQLiteConnection("Data Source = C:/Users/DarkAsus/Documents/GitHub/NavalServidor/usuarios.sqlite");
                    conexion.Open();

                    string consulta = "select * from Jugadores where nombre = '" + rival.username + "';";

                    SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                    SQLiteDataReader datos_consulta = comando.ExecuteReader();

                    //chat_text.Text = chat_text.Text + username + " conectado!! \r\n";
                    //chat_text.Text = chat_text.Text + "\nLista clientes actuales: \r\n";

                    if (datos_consulta.Read())
                    {
                        //Si el usuario existe en la BD, obtiene los datos
                        rival.victorias = Convert.ToInt32(datos_consulta[1]);
                        rival.derrotas = Convert.ToInt32(datos_consulta[2]);
                        rival.porc_victorias = Convert.ToInt32(datos_consulta[3]);
                    }
                    else
                    {

                        //Sino inicializa todo en cero
                        rival.victorias = 0;
                        rival.derrotas = 0;
                        rival.porc_victorias = 0;
                    }
                }


                string data = Encoding.ASCII.GetString(buffer, 0, byte_count);
                string[] datos = data.Split(':');

                if(datos[0] == "config")
                {
                    envia_a_rival(data, cliente);

                    cliente.estado = "listo";
                    
                    if (cliente.estado == "listo" && rival.estado == "listo")
                    {
                        int aleatorio = rnd.Next(0, 1);

                        if (aleatorio == 0)
                        {
                            envia_a_rival("ready:true", cliente);
                            envia_a_rival("ready:false", rival);
                        }
                        else
                        {
                            envia_a_rival("ready:false", cliente);
                            envia_a_rival("ready:true", rival);
                        }

                    }
                    
                }
                else if (datos[0] == "victoria")
                {
                    cliente.victorias++;
                    cliente.derrotas++;
                    cliente.porc_victorias++;

                    envia_a_rival("victoria:si,"+ cliente.victorias+","+ cliente.derrotas+","+ cliente.porc_victorias, cliente);
                    envia_a_rival("victoria:no," + rival.victorias + "," + rival.derrotas + "," + rival.porc_victorias, rival);
                }
                else
                {
                    envia_a_rival(data, cliente);
                }

                chat_text.Text = chat_text.Text + data + "\r\n";

            }
        }


        //PASAR ESTA FUNCION AL LADO DEL CLIENTE UNA VEZ QUE SE HAYA CREADO
        static string reconstruir_datos(string data)
        {
            string[] datos = data.Split(':');
            string salida = "";
            salida = salida + datos[1];

            for (int i = 2; i < datos.Length; i++)
            {
                salida = salida + ":" + datos[i];
            }

            return salida;
        }


        private void bd_btn_Click(object sender, EventArgs e)
        {
            BD_Form bd_form = new BD_Form();
            bd_form.Show();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            ServerSocket.Server.Shutdown(SocketShutdown.Receive);
            _principal.Join();
            ServerSocket.Stop();
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Desplazar el cursor del TextBox hasta el final
            chat_text.SelectionStart = chat_text.Text.Length;
            chat_text.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn colu1 = new DataGridViewTextBoxColumn();
            colu1.HeaderText = "Jugador";
            colu1.Width = 200;
            colu1.ReadOnly = true;

            DataGridViewTextBoxColumn colu2 = new DataGridViewTextBoxColumn();
            colu2.HeaderText = "Estado";
            colu2.Width = 300;
            colu2.ReadOnly = true;

            lista_jugadores.Columns.Add(colu1);
            lista_jugadores.Columns.Add(colu2);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public void emparejar_Click(object sender, EventArgs e)
        {
            lock (_lock)
            {
                /*
                foreach (Cliente c in lista_clientes)
                {
                    chat_text.Text = chat_text.Text + "id: " + c.username + "\r\n";
                }
                chat_text.Text = chat_text.Text + "****************** \r\n";
                
                */

                
                chat_text.Text = chat_text.Text + "Parejas: " + "\r\n";

                int id1 = -1, id2 = -1;
                int r1 = -1, r2 = -1;
                int id_hilo = 0;

                //comienza el emparejamiento
                while (lista_espera.Count >= 2)
                {
                    while (r1 == r2)
                    {
                        r1 = rnd.Next(lista_espera.Count);
                        id1 = lista_espera[r1];

                        r2 = rnd.Next(lista_espera.Count);
                        id2 = lista_espera[r2];
                    }

                    //se eliminan los indices de los jugadores ya emparejados
                    if (r1 > r2)
                    {
                        lista_espera.RemoveAt(r1);
                        lista_espera.RemoveAt(r2);
                    }
                    else
                    {
                        lista_espera.RemoveAt(r2);
                        lista_espera.RemoveAt(r1);
                    }

                    Cliente player1 = lista_clientes.FirstOrDefault(x => x.id == id1);
                    Cliente player2 = lista_clientes.FirstOrDefault(x => x.id == id2);

                    chat_text.Text = chat_text.Text + player1.username + " vs " + player2.username + "\r\n";

                    //establece un hilo en comun para conectar a dos jugadores
                    //Jugador 1
                    player1.hilo = id_hilo;
                    t[id_hilo] = new Thread(Controlador_clientes);
                    t[id_hilo].Start(player1.id);
                    //Jugador 2
                    player2.hilo = id_hilo;
                    t[id_hilo] = new Thread(Controlador_clientes);
                    t[id_hilo].Start(player2.id);

                    r1 = -1;
                    r2 = -1;
                    id_hilo++;
                }
            }
            
        }
    }

}
