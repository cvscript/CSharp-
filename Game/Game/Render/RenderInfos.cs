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
