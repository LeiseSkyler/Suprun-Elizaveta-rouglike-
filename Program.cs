using System;

namespace rogalik__2
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            bool Game_Over = false; 

            Map_Generator();

            while (!Game_Over)
            {
                Console.Clear();

                Map_Risovator();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        Dvigatel_Persika(0, -1);
                        break;
                    case ConsoleKey.S:
                        Dvigatel_Persika(0, 1);
                        break;
                    case ConsoleKey.A:
                        Dvigatel_Persika(-1, 0);
                        break;
                    case ConsoleKey.D:
                        Dvigatel_Persika(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Game_Over = true;
                        break;

                }

                Dvigatel_Nekto_rina(avoska, random);
            }

            
        }

        static int width = 60;
        static int height = 40;

        static string[,] massiv = new string[height, width];

        static Random random = new Random();

        static Persik persik;

        static Nekto_rin[] avoska;

        static Bublik bublik;

        static void Map_Generator()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    massiv[i, j] = "##";
                }
            }

            int room_num = random.Next(4, 10);

            avoska = new Nekto_rin[room_num];

            Room[] komnatki = new Room[room_num];

            for (int i = 0; i < room_num; i++)
            {
                int razmer_width = random.Next(4, 12);
                int razmer_height = random.Next(4, 12);

                int position_x = random.Next(1, width - razmer_width - 1);
                int position_y = random.Next(1, height - razmer_height - 1);

                Room new_room = new Room
                {
                    room_width = razmer_width,
                    room_height = razmer_height,
                    room_x = position_x,
                    room_y = position_y

                };

                bool Overlay = false;
                
                for (int j = 0; j < i; j++)
                {
                    Room diff_room = komnatki[j];

                    if (diff_room != null && 
                        new_room.room_x < diff_room.room_x + diff_room.room_width &&
                        new_room.room_x + new_room.room_width > diff_room.room_x &&
                        new_room.room_y < diff_room.room_y + diff_room.room_height &&
                        new_room.room_y + new_room.room_height > diff_room.room_y)
                    {
                        Overlay = true; break;
                    }
                }
                if (Overlay)
                {
                    i--; continue;
                }

                int nekt_x = random.Next(position_x, position_x + razmer_width);
                int nekt_y = random.Next(position_y, position_y + razmer_height);

                Nekto_rin nekto_rin = new Nekto_rin(nekt_y, nekt_x);
                avoska[i] = nekto_rin;

                Room_Risovator(new_room, nekt_x, nekt_y);
                komnatki[i] = new_room;
            }

            int pers_room = random.Next(0, room_num);

            Room start_persik = komnatki[pers_room];

            int X = random.Next(start_persik.room_x, start_persik.room_width + start_persik.room_x);
            int Y = random.Next(start_persik.room_y, start_persik.room_height + start_persik.room_y);

            persik = new Persik(Y, X);

            for (int i = 0; i < komnatki.Length - 1; i++)
            {
                if (komnatki[i] != null && komnatki[i + 1] != null)
                {
                    Room start_room = komnatki[i];
                    Room end_room = komnatki[i + 1];
                    int start_x = random.Next(start_room.room_x, start_room.room_x + start_room.room_width);
                    int start_y = random.Next(start_room.room_y, start_room.room_y + start_room.room_height);
                    int end_x = random.Next(end_room.room_x, end_room.room_x + end_room.room_width);
                    int end_y = random.Next(end_room.room_y, end_room.room_y + end_room.room_height);

                    Colidor(start_x, start_y, end_x, end_y);
                }
            }

            int bublik_room_num = random.Next(0, room_num);

            Room bublik_room = komnatki[bublik_room_num];

            int bub_room_x = random.Next(bublik_room.room_x + 1, bublik_room.room_x + bublik_room.room_width - 1);
            int bub_room_y = random.Next(bublik_room.room_y + 1, bublik_room.room_y + bublik_room.room_height - 1);

            bublik = new Bublik(bub_room_x, bub_room_y);

            massiv[bub_room_y, bub_room_x] = "O ";
        }

        static void Dvigatel_Persika(int dvig_x, int dvig_y)
        {
            int x_new = persik.pers_x + dvig_x;
            int y_new = persik.pers_y + dvig_y;

            if (massiv[y_new, x_new] == "  ")
            {
                persik.pers_x = x_new;
                persik.pers_y = y_new;
            }

            if (y_new == bublik.bub_y && x_new == bublik.bub_x)
            {
                Map_Generator();
            }
        }
        static void Room_Risovator(Room room, int nekt_x, int nekt_y)
        {
            for (int i = room.room_x; i < room.room_x + room.room_width; i++)
            {
                for (int j = room.room_y; j < room.room_y + room.room_height; j++)
                {
                    massiv[j, i] = "  ";
                    massiv[nekt_y, nekt_x] = "N ";
                }
            }
        }
        static void Colidor(int start_x, int start_y, int end_x, int end_y)
        {
            for (int x = Math.Min(start_x, end_x); x <= Math.Max(start_x, end_x); x++)
            {
                massiv[start_y, x] = "  ";
            }
            for (int y = Math.Min(start_y, end_y); y <= Math.Max(start_y, end_y); y++)
            {
                massiv[y, end_x] = "  ";
            }
        }

        static void Map_Risovator()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    
                    if (i == persik.pers_y && j == persik.pers_x)
                    {
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write(massiv[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        static void Dvigatel_Nekto_rina(Nekto_rin[] avoska, Random random)
        {
            foreach (var nekto_rin in avoska)
            {
                massiv[nekto_rin.pers_y, nekto_rin.pers_x] = "  ";

                int position = random.Next(0, 4);

                switch (position)
                {
                    case 0:
                        if (nekto_rin.pers_x > 0 && massiv[nekto_rin.pers_y, nekto_rin.pers_x - 1] == "  ")
                        {
                            nekto_rin.pers_x--;
                        }
                        break;
                    case 1:
                        if (nekto_rin.pers_x < width && massiv[nekto_rin.pers_y, nekto_rin.pers_x + 1] == "  ")
                        {
                            nekto_rin.pers_x++;
                        }
                        break;
                    case 2:
                        if (nekto_rin.pers_y > 0 && massiv[nekto_rin.pers_y, nekto_rin.pers_y - 1] == "  ")
                        {
                            nekto_rin.pers_y--;
                        }
                        break;
                    case 3:
                        if (nekto_rin.pers_y < height && massiv[nekto_rin.pers_y, nekto_rin.pers_y + 1] == "  ")
                        {
                            nekto_rin.pers_y++;
                        }
                        break;
                }

                massiv[nekto_rin.pers_y, nekto_rin.pers_x] = "N ";
            }

        }


    }

}

