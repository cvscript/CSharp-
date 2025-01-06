using System.Collections.Generic;

namespace GameTans.Lec03_CmdGame
{
    public class RenderInfos {
        private List<RenderInfo> infos = new List<RenderInfo>();
        private List<object> extraInfos = new List<object>();
        public void AddInfo(RenderInfo info)
        {
            infos.Add(info);
        }
        // IEnumerable 是一个泛型接口，它表示一个可以通过 IEnumerator 迭代器进行枚举的集合。
        public void AddExtInfos<T>(IEnumerable<T> objs)
        {
            foreach (var item in objs)
            {
                extraInfos.Add(item);
            }
        }
        public List<RenderInfo> GetInfos()
        {
            return infos;
        }
        public List<object> GetExtInfos()
        {
            return extraInfos;
        }
    }
    
}
