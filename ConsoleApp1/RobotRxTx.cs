using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriverStation;
using SharpDX.XInput;

namespace ConsoleApp1
{
    class RobotRxTx
    {
        WifiRelay relay;
        private byte[] COMM_FORWARD = { (byte)0xFF, (byte)0x00, (byte)0x01, (byte)0x00, (byte)0xFF };
        private byte[] COMM_BACKWARD = { (byte)0xFF, 0x00, 0x02, 0x00, (byte)0xFF };
        private byte[] COMM_STOP = { (byte)0xFF, 0x00, 0x00, 0x00, (byte)0xFF };
        private byte[] COMM_LEFT = { (byte)0xFF, 0x00, 0x03, 0x00, (byte)0xFF };
        private byte[] COMM_RIGHT = { (byte)0xFF, 0x00, 0x04, 0x00, (byte)0xFF };
        private byte[] COMM_FASTER = { (byte)0xFF, 0x00, 0x05, 0x00, (byte)0xFF };
        private byte[] COMM_SLOWER = { (byte)0xFF, 0x00, 0x06, 0x00, (byte)0xFF };


        public RobotRxTx()
        {
            relay = new WifiRelay();
            //axWindowsMediaPlayer1.URL = "192.168.1.1:8080";
        }

        public void update(Gamepad gamePad)
        {
            stopClick();
            if (gamePad.RightThumbY > 16000)
            {
                forwardClick();
            }
            else if (gamePad.RightThumbY < -16000)
            {
                backClick();
            }
            else if (gamePad.RightThumbX < -16000)
            {
                leftClick();
            }
            else if (gamePad.RightThumbX > 16000)
            {
                rightClick();
            }
            else
            {
                stopClick();
            }
        }

        public void forwardClick()
        {
            relay.WriteToPort(COMM_FORWARD);
        }

        public void backClick()
        {
            relay.WriteToPort(COMM_BACKWARD);
        }

        public void leftClick()
        {
            relay.WriteToPort(COMM_LEFT);
        }

        public void rightClick()
        {
            relay.WriteToPort(COMM_RIGHT);
        }

        public void stopClick()
        {
            relay.WriteToPort(COMM_STOP);
        }

        public void button5_Click()
        {
            relay.WriteToPort(COMM_FASTER);
        }

        public void button6_Click()
        {
            relay.WriteToPort(COMM_SLOWER);
        }

    }
}
