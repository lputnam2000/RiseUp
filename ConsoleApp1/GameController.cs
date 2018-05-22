using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;
using System.Threading;

namespace ConsoleApp1
{
    class GameController 
    {
        Controller controller1;
        RobotRxTx rxtxObj;
        public GameController()
        {
            controller1 = new Controller(UserIndex.One);
            rxtxObj = new RobotRxTx();
            State previousState = controller1.GetState();
            while (controller1.IsConnected)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == (ConsoleKey.Escape))
                {
                    break;
                }
                var state = controller1.GetState();
                if (previousState.PacketNumber != state.PacketNumber)
                {
                    Console.WriteLine(state.Gamepad);
                    rxtxObj.update(state.Gamepad);
                }
                Thread.Sleep(10);
                previousState = state;
            }
        }
        static void Main()
        {
            new GameController();
        }

    }
}
