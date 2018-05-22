using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverStation
{
    public partial class Form1 : Form
    {

        WifiRelay relay;
        private byte[] COMM_FORWARD = { (byte)0xFF, (byte)0x00, (byte)0x01, (byte)0x00, (byte)0xFF };
        private byte[] COMM_BACKWARD = { (byte)0xFF, 0x00, 0x02, 0x00, (byte)0xFF };
        private byte[] COMM_STOP = { (byte)0xFF, 0x00, 0x00, 0x00, (byte)0xFF };
        private byte[] COMM_LEFT = { (byte)0xFF, 0x00, 0x03, 0x00, (byte)0xFF };
        private byte[] COMM_RIGHT = { (byte)0xFF, 0x00, 0x04, 0x00, (byte)0xFF };
        private byte[] COMM_FASTER = { (byte)0xFF, 0x00, 0x05, 0x00, (byte)0xFF };
        private byte[] COMM_SLOWER = { (byte)0xFF, 0x00, 0x06, 0x00, (byte)0xFF };


        public Form1()
        {
            relay = new WifiRelay();
            InitializeComponent();
            //axWindowsMediaPlayer1.URL = "192.168.1.1:8080";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void forwardClick(object sender, EventArgs e)
        {
            relay.WriteToPort(COMM_FORWARD);
        }

        private void backClick(object sender, EventArgs e)
        {
            relay.WriteToPort(COMM_BACKWARD);
        }

        private void leftClick(object sender, EventArgs e)
        {
            relay.WriteToPort(COMM_LEFT);
        }

        private void rightClick(object sender, EventArgs e)
        {
            relay.WriteToPort(COMM_RIGHT);
        }

        private void stopClick(object sender, EventArgs e)
        {
            relay.WriteToPort(COMM_STOP);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            relay.WriteToPort(COMM_FASTER);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            relay.WriteToPort(COMM_SLOWER);
        }
    }
}
