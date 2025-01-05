using System;

namespace GameTans.Lec03_CmdGame
{
    public class CmdRenderEngine : RenderEngine
    {
        int[,] mapData; // [,] 二维数组
        public override void SetMapSize(int rowCount, int colCount)
        {
            base.SetMapSize(rowCount, colCount);
           
            mapData = new int[rowCount, colCount];

        }
        public override void Render(RenderInfos info)
        {
            Console.Clear();
            Debug.Log($"{GetType().Name} Render");
            for (int row = 0; row < RowCount; row++)
            {
                for (int col = 0; col < ColCount; col++)
                {
                    mapData[row, col] = 0;
                }
            }
            var infos = info.GetInfos();
            foreach (var item in infos)
            {
                // ColCount = 21
                // -10    0    10   // 玩家位置x
                //  0     10   20   // 显示列
         
                var helfColCount = (ColCount - 1) / 2;
                var row = item.pos.x + helfColCount;
                var helfRowCount = (RowCount - 1) / 2;
                var col = item.pos.y + helfRowCount;
                // item.color 值 受伤为负数 isHurt = -1;
                mapData[row, col] = item.color * item.type;
            }
            const int CharSpaceCount = 2;//两个字符为一格
            for (int row = 0; row < RowCount; row++)
            {
                int lastIdx = -1;
                for (int col = 0; col < ColCount; col++)
                {
                    var val = mapData[RowCount -row -1, col];
                    //为0时 进入下一次循环，不执行下面的逻辑；
                    if (val == 0) continue; 
                    // 计算前方有多少个空格
                    var spaceCount = col - lastIdx - 1;
                    //记录空格结束的位置，用于计算下次前方空格数量
                    lastIdx = col;
                    var spaceStr = new string(' ', spaceCount * CharSpaceCount);
                    Console.Write(spaceStr);
                    //判断颜色
                    var color = val < 0 ? ConsoleColor.Red : ConsoleColor.White;
                    // 指定控制台的前景色,也就是字符的颜色
                    Console.ForegroundColor = color; 
                    //判断是怪物还是角色 一个格子两个字符，加一个空格为了沾满格子
                    var ch = (Math.Abs(val) == 1 ? "M" : "P") + new string(' ', CharSpaceCount - 1);
                    Console.Write(ch);
                    //重置控制台前景色
                    Console.ForegroundColor = ConsoleColor.White;


                }
                //行的渲染收尾
                var endSpaceStr = new string(' ', (ColCount - lastIdx - 1) * CharSpaceCount);
                Console.Write(endSpaceStr);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('|');
                Console.WriteLine();

            }
            var endLineStr = new string('-', ColCount * CharSpaceCount);
            Console.WriteLine(endLineStr);
            var extraInfos = info.GetExtInfos();
            foreach (var item in extraInfos)
            {
                Console.WriteLine(item);
            }

        }
    }

}
