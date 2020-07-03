using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace arduino.Helper
{

    public static class ArduinoEventSender
    {


        public  static TcpListener server = new TcpListener(8090);
        public static TcpClient client;

      public static  void  StartArduinoEventSender()
        {
            server.Start();
            client = server.AcceptTcpClient();
        }

        public static void sentEvent(String data)
        {
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);


            sw.Write(data);
            sw.Flush();


        }


    }
}
