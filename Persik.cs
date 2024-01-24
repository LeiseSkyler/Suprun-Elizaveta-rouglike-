namespace rogalik__2
{
    partial class Program
    {
        public class Persik
        {
            public int pers_x;
            public int pers_y;
            public int pers_hp;

            public void Persik_Generator(int y_pers, int x_pers)
            {
                massiv[y_pers, x_pers] = " > ";
            }

            public Persik(int y, int x)
            {
                pers_x = x; pers_y = y;
            }


        }

        public class Nekto_rin : Persik
        {
            public Nekto_rin(int y_nekto, int x_nekto) : base(y_nekto, x_nekto)
            {

            }
        }

        public class Bublik
        {
            public int bub_x;
            public int bub_y;

            public Bublik(int bub_x, int bub_y)
            {
                this.bub_x = bub_x;
                this.bub_y = bub_y;
            }
        }
    }


}

