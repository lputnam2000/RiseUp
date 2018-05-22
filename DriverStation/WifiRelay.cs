using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DriverStation
{
    public class WifiRelay
    {
        //private static SerialPort port;
        //private int baud;
        //private string name;

        // statistics
        private const int statLength = 15;
        private int statIndex = 0, statReady = 0;
        private int[] statCount = new int[statLength];
        private SerialPort comm = new SerialPort();
        private int detectorType = 0;
        private bool signal = false;
        private int intervalsToSave = 0;
        private bool saveOnMotion = false;
        static IPAddress ips;
        static IPEndPoint ipe;
        static Socket socket = null;
        string CameraIp = "";
        private String ROUTER_CONTROL_URL = "www.wifi_robots.com_ray_yi00B5D4";
        string ControlIp = "192.168.1.1";
        int Port = 2001;
        string CMD_Forward = "", CMD_Backward = "", CMD_TurnLeft = "", CMD_TurnRight = "", CMD_Stop = "", CMD_EngineUp = "", CMD_EngineDown = "";
        private int controlType = 3;
        private string btCom;
        private string btBaudrate;

        TcpClient tcpClient;

        public WifiRelay()
        {
            InitWIFISocket(ControlIp, Port);
            //Console.WriteLine("Attempting to connect to " + ControlIp);
        }

        private void InitWIFISocket(String controlIp, int port)
        {
            try
            {
                tcpClient = new TcpClient(controlIp, port);

                //ips = IPAddress.Parse(controlIp);
                //ipe = new IPEndPoint(ips, port);
                //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //socket.Connect(ipe);
                Console.WriteLine("Connected to " + controlIp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        public void WriteToPort(byte[] command)
        {
            if (tcpClient.Connected)
            {
                //tcpClient.Client.Send(command);
                Console.WriteLine("SENDING COMMAND");
                NetworkStream stream = tcpClient.GetStream();
                stream.Write(command, 0, command.Length);
                //stream.Close();
            }

            else
            {
                Console.WriteLine("NOT CONNECTED");
            }

            //if (socket.Connected)
            //{
            //    socket.Send(command);
            //}
        }

        //public static void port_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        //{
        //    for (int i = 0; i < (10000 * port.BytesToRead) / port.BaudRate; i++) ;
        //    Console.WriteLine(port.ReadExisting());
        //}

        //private void BeginSerial(string name, int baud)
        //{
        //    port = new SerialPort(name, baud);
        //    string[] names = SerialPort.GetPortNames();
        //    foreach(string portName in names)
        //    {
        //        Console.WriteLine(portName);
        //    }
        //    port.Open();

        //}

        //public void WriteToPort(string value)
        //{
        //    port.Write(value);
        //}

    }
}
