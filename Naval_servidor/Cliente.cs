﻿using System;
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
        public string victorias { get; set; }
        public string derrotas { get; set; }
        public string porc_victorias { get; set; }
        public string estado { get; set; }
    }
}
