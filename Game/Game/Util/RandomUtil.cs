using System;

namespace GameTans.Lec03_CmdGame
{
    public class RandomUtil
    {
        public static Random random = new Random();
        public static int Range(int minVal, int maxVal)
        {
            return random.Next(minVal, maxVal + 1);
        }
    }

}
