using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static Random random = new Random();
        static int GenRandomInt()
        {
            var number = random.Next(0, 100);
            return number;
        }
        static int totalCount = 1;
        static void Main(string[] args)
        {
            int sysNum = GenRandomInt();
            Console.WriteLine(sysNum);
            Console.WriteLine("请输入一个0-99的数字，按回车键结束。");
            while (true)
            {
                var intputStr = Console.ReadLine();
                int intputNumber = int.Parse(intputStr);
                if (intputNumber == sysNum)
                {
                    sysNum = Resets();
                }
                else if (intputNumber > sysNum)
                {
                    totalCount++;
                    Console.WriteLine("太大了");
                }
                else
                {
                    totalCount++;
                    Console.WriteLine("太小了");
                }
            }
            Console.ReadLine();
        }

        private static int Resets()
        {
            int sysNum;
            Console.WriteLine($"太厉害了，你只猜了{totalCount}次，就答对了！");
            sysNum = GenRandomInt();
            Console.WriteLine(sysNum);
            Console.WriteLine("已重新生成随机数，请猜测是多少！");
            totalCount = 1;
            return sysNum;
        }
    }
}
