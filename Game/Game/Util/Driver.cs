using System;
using System.Threading;

namespace GameTans.Lec03_CmdGame
{
    partial class Driver
    {
        public static int FrameIntervalMS = 300;
        private static bool isNeedStop;
        public static void Start(Action<char> onGetInput, Func<double, double, bool> onUpdate)
        {
            var thread = new Thread(() => {
                while (true)
                {
                    var info = Console.ReadKey();
                    var inputCh = info.KeyChar;
                    onGetInput(inputCh);
                }
            });
            thread.Start();
            RepeatInvoke(( timeSinceStart,  deltaTime) =>
            {
                isNeedStop = onUpdate(timeSinceStart, deltaTime);
            }, FrameIntervalMS);
        }
        static void RepeatInvoke(Action<double,double> func,int callIntervalMs)
        {
            var initTime = DateTime.Now;
            var lastTimestamp = DateTime.Now;
            while (true)
            {
                try
                {
                    // 下面程序暂时挂起 {callIntervalMs}毫秒
                    Thread.Sleep(Math.Max(1, callIntervalMs));
                    // 程序已经运行多长时间
                    var totalElipse = DateTime.Now - initTime; 
                    //程序运行多少秒了； 
                    var totalSec = totalElipse.TotalSeconds;
                    //距离上一次更新多久了
                    var elipse = DateTime.Now - lastTimestamp;
                    // 更新间隔为多少秒
                    var dtSec = elipse.TotalSeconds;
                    //记录最后更新时间
                    lastTimestamp = DateTime.Now;
                    //委托 储存更新间隔 
                    func(totalSec, dtSec);
                    if (isNeedStop) return;


                }
                // ThreadAbortException 是一个可以被捕获的特殊异常，但会在块的末尾再次自动引发 catch
                catch (ThreadAbortException e)
                {
                    return;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
        }
        
    }
}
 