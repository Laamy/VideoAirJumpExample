#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace AirJumpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MCM.openGame(); // Open the minecraft process
            MCM.openWindowHost(); // Open the window host for mcbe

            ulong clientInstance = MCM.baseEvaluatePointer(0x04120F18, new ulong[] { 0x0, 0x18 });

            while (true) // Loop this code rapidly
            {
                Thread.Sleep(1); // Wait 1ms so this loop doesnt try to eat all the CPU!

                ulong localPlayer = MCM.evaluatePointer(clientInstance, new ulong[] { 0xB8, 0x0 });
                ulong ongroundAddr = localPlayer + 0x1D8;

                MCM.writeInt(ongroundAddr, 16777473); // 0x1D8 onground offset
            }
        }
    } // okay sorry fixed first define the client instance up here before you rapidly loop because it wont change until a game restart
    // next define local player and then the onground address which is local player + 0x1D8 (*1.17.30)
    // then write to it via write int
}
