using System;

namespace GameTans.Lec03_CmdGame
{
    public class Component
    {
        // virtual 关键字用于修改方法、属性、索引器或事件声明，并使它们可以在派生类中被重写。
        public virtual void Awake() {
            Debug.Log($"{GetType().Name} Awake");
        }
        public virtual void Update(float dt) {
            Debug.Log($"\t\t {GetType().Name} Update");
        }
    }
    
}
