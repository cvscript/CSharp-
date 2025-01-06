namespace GameTans.Lec03_CmdGame
{
    public class PlaerAI : AI
    {
        public override void Update(float dt)
        {
            Debug.Log($"\t\t {GetType().Name} Update");
            //var pos = actor.pos;
            //pos.y += 1;
            //actor.pos = pos;
        }
    }

}
