using System;

namespace GameTans.Lec03_CmdGame
{
    public class Game : ILifeCycle
    {
        public static World world = new World();
        public EGamesState state;
        public void Awake()
        {
            Debug.Log($"{GetType().Name} Awake");
            world.Awake();


            world.AddActor(CreatePlayer(1000, 40));
            world.AddActor(CreateEnemy(300, 10));
            world.AddActor(CreateEnemy(300, 10));
            world.AddActor(CreateEnemy(300, 10));
        }
        Actor CreatePlayer(int health, int damage)
        {
            var player = new Player();
            InitActor(health, damage, player);
            player.AddComponent(new PlaerAI());
            return player;
        }
        Actor CreateEnemy(int health, int damage)
        {
            var enemy = new Enemy();
            InitActor(health, damage, enemy);
            enemy.AddComponent(new EnemyAI());
            return enemy;
        }

        private static void InitActor(int health, int damage, Actor actor)
        {
            actor.world = world;
            actor.damage = health;
            actor.health = damage;
            actor.pos = world.GetRandomPos();

            actor.AddComponent(new HurtEffect());
            actor.AddComponent(new Skill());

        }

        public void Update()
        {

            Debug.Log($"{GetType().Name} Update FrameCount:{Time.frameCount}");
            world.Update();
            Time.frameCount++;
        }
        public bool OnUpdate(double timeSinceStart, double deltaTime)
        {
            Time.deltaTime = (float)deltaTime;
            Update();
            return false;
        }
      
        public void OnGetInput(char inputCh)
        {
            switch (inputCh)
            {
                case 'w':
                    InputManager.inputVec = new Vector2(0, 1); 
                    break;
                case 's':
                    InputManager.inputVec = new Vector2(0, -1);
                    break;
                case 'a':
                    InputManager.inputVec = new Vector2(0 ,-1);
                    break;
                case 'd':
                    InputManager.inputVec = new Vector2(1, 0);
                    break;
            }
        }
    }

}
