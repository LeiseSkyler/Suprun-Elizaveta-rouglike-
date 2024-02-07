namespace rogalik__2
{
    partial class Program
    {
        public class Game_Entity : Game_Object
        {
            private int hp;
            public int HP
            {
                get { return hp; }
                set
                {
                    hp = value;
                    if (hp <= 0)
                    {
                        Destroy();
                    }
                }
            }
            
            public Game_Entity(int hp, Vector2 position, char symbol, bool passable = false) 
                : base(position, symbol, passable)
            {
                HP = hp;
            }
            
            public void Get_Damage(int damage)
            {
                HP -= damage;
            }

            public override void Update()
            {
                base.Update();
            }
        } 

    }


}

