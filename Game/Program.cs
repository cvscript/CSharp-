using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTans.Lec03_CmdGame
{
    partial class Program
    {
        static void Main(string[] args)
        {
            
            var game = new Game();
            game.Awake();
          
            Driver.FrameIntervalMS = 100;
            Driver.Start(game.OnGetInput, game.OnUpdate);


            Console.ReadLine();
        }
    }
}
 