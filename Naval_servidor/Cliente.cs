using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Naval_servidor
{
    class Cliente
    {
        public int id { get; set; }
        public TcpClient cliente_TCP { get; set; }
        public int hilo { get; set; }
        public string username { get; set; }
        public int victorias { get; set; }
        public int derrotas { get; set; }
        public int porc_victorias { get; set; }
        public string estado { get; set; }
    }
}
