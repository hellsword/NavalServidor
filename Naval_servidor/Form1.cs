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
        
        public static int CONEX = 10;

        static readonly object _lock = new object();
        

        public Form1()
        {
            InitializeComponent();

            
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


            while (true)
            {
                //this.Show();

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
                        Cliente ocliente = new Cliente();
                        ocliente.id = count;
                        ocliente.cliente_TCP = client;
                        ocliente.hilo = id_hilo;
                        lista_clientes.Add(ocliente);
                    }

                    t[id_hilo] = new Thread(controlador_clientes);
                    t[id_hilo].Start(count);

                    count++;
                    pares++;

                    if (pares == 2)
                    {
                        pares = 0;
                        id_hilo++;
                        Console.WriteLine("Se ha abierto un nuevo canal de conexión: " + id_hilo);
                    }
                }
            }

        }


        //Envia el mensaje de un cliente a todos los demas que esten conectados
        static void envia_a_todos(string data, TcpClient cliente_actual, int hilo)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);

            //Bloquea una seccion critica
            lock (_lock)
            {
                foreach (Cliente c in lista_clientes)
                {
                    //Comprueba que no se envie el mensaje al cliente que lo generó
                    if (cliente_actual != c.cliente_TCP && c.hilo == hilo)
                    {
                        NetworkStream stream = c.cliente_TCP.GetStream();

                        stream.Write(buffer, 0, buffer.Length);
                    }

                }
            }
        }


        //Se reciben los mensajes 
        public void controlador_clientes(object o)
        {
            CheckForIllegalCrossThreadCalls = false;

            int id = (int)o;
            Cliente cliente = lista_clientes.FirstOrDefault(x => x.id == id);

            lock (_lock) client = cliente.cliente_TCP;

            //Recibe mensajes
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int byte_count = stream.Read(buffer, 0, buffer.Length);

            username = Encoding.ASCII.GetString(buffer, 0, byte_count);
            cliente.username = username;
            Console.WriteLine(username + " conectado!!");
            textBox1.Text = textBox1.Text + username + " conectado!! \r\n";

            Console.WriteLine("\nLista clientes actuales: ");
            textBox1.Text = textBox1.Text + "\nLista clientes actuales: \r\n";
            foreach (Cliente c in lista_clientes)
            {
                Console.WriteLine("id: " + c.id);
                Console.WriteLine("username: " + c.username);
                Console.WriteLine("hilo: " + c.hilo);
                Console.WriteLine("\n");

                textBox1.Text = textBox1.Text + "id: " + c.id + "\r\n";
                textBox1.Text = textBox1.Text + "username: " + c.username + "\r\n";
                textBox1.Text = textBox1.Text + "hilo: " + c.hilo + "\r\n";
                textBox1.Text = textBox1.Text + "\r\n";
            }
            Console.WriteLine("****************** ");
            textBox1.Text = textBox1.Text + "****************** \r\n";

            while (true)
            {

                stream = client.GetStream();
                buffer = new byte[1024];
                byte_count = stream.Read(buffer, 0, buffer.Length);

                if (byte_count == 0)
                {
                    break;
                }

                string data = Encoding.ASCII.GetString(buffer, 0, byte_count);

                string[] datos = data.Split(':');
                if (datos[0] == "mensaje")
                {
                    data = reconstruir_datos(data);
                }
                else if (datos[0] == "mov")
                {
                    data = reconstruir_datos(data);
                }

                envia_a_todos(data, client, cliente.hilo);

                //data = Encoding.ASCII.GetString(buffer, 0, byte_count);
                Console.WriteLine(data);
                textBox1.Text = textBox1.Text + data + "\r\n";
            }

            lock (_lock) lista_clientes.RemoveAll(x => x.id == id);
            client.Client.Shutdown(SocketShutdown.Both);
            client.Close();
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

    }

}
