using System;

namespace GameTans.Lec03_CmdGame
{
    public class RenderEngine : IAwake
    {
        public int RowCount;
        public int ColCount;
        public virtual void SetMapSize(int RowCount, int ColCount)
        {
            this.RowCount = RowCount;
            this.ColCount = ColCount;
        }
        public virtual void Awake()
        {
            Debug.Log($"{GetType().Name} Awake");
        }
        public virtual void Render(RenderInfos info)
        {
            Debug.Log($"{GetType().Name} Render");
        }
    }

}
