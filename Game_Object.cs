namespace rogalik__2
{
    partial class Program
    {
        public class Game_Object
        {
            public Vector2 Position 
            { 
                get
                {
                    return _position;
                } 
              
                set
                {
                    Previous_Position = _position;
                    _position = value;
                } 
            }
            public Game_Object(Vector2 position, char symbol, bool passable)
            {
                Position = position;
                Symbol = symbol;
                Passable = passable;
                Previous_Position = new Vector2(_position.X, _position.Y);
            }

            public Vector2 _position;
            public Vector2 Previous_Position { get; set; }
            public char Symbol { get; set; }
            public bool Passable { get; set; }

            public virtual void Update()
            {

            }

            public event Action<Game_Object> On_Destroy;
            public event Action<Game_Object, Vector2> Move;

            public virtual void Destroy_Action()
            {
               
            }

            public void Destroy()
            {
                Destroy_Action();
                if (On_Destroy != null) On_Destroy(this);

            }
        }

    }


}

