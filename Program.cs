using System;
using System.Threading;

namespace clase_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                Console.SetWindowSize(130, 40);
                Console.WriteLine(String.Format("{0,30}", "Wumpus"));
                Console.WriteLine(String.Format("{0,30}", "------"));
                Console.WriteLine();

                Console.WriteLine("Encuentra el tesoro! Pero cuidado con el Wumpus...");
                Console.WriteLine();
                Console.WriteLine("Instrucciones:");
                Console.WriteLine("Para desplazarse, use la tecla \"a\" para ir a la izquierda. \"d\" para ir a la derecha.");
                Console.WriteLine("\"w\" para ir así arriba y \"s\" para abajo. Ademas, tienes 3 flechas para matar al Gumpus.");
                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();

                Random rand = new Random();
                Fin Fin = new Fin();
                Wumpus Wump = new Wumpus();
                Inicio Inicio = new Inicio();
                Aire Aire = new Aire();
                Peste Peste = new Peste();
                Hueco Foso = new Hueco();
                Casilla espacio = new Casilla();
                You Tu = new You();

                String[,] arreglo = new String[,] { { Fin.Espacio(), espacio.Espacio(), Aire.Espacio(), Foso.Espacio() },
                                  { Wump.Espacio(), Peste.Espacio(), espacio.Espacio(), Aire.Espacio() },
                                  { Peste.Espacio(), espacio.Espacio(), Aire.Espacio(), espacio.Espacio() },
                                  { Inicio.Espacio(), Aire.Espacio(), Foso.Espacio(), Aire.Espacio()} };

                String[,] arr = new String[,] { { " ___________", " ___________", " ___________"," ____________ "},
                              { "|           |", "           |", "           |", "           |" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|" + arreglo[0,0] + "|", "" + arreglo[0,1] + "|", "" + arreglo[0,2] + "|", "" + arreglo[0,3] + "|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|___________|", "___________|", "___________|", "___________|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|" + arreglo[1,0] + "|", "" + arreglo[1,1] + "|", "" + arreglo[1,2] + "|", "" + arreglo[1,3] + "|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|___________|", "___________|", "___________|", "___________|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|" + arreglo[2,0] + "|", "" + arreglo[2,1] + "|", "" + arreglo[2,2] + "|", "" + arreglo[2,3] + "|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|___________|", "___________|", "___________|", "___________|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|" + arreglo[3,0] + "|", arreglo[3,1] + "|", arreglo[3,2] + "|", arreglo[3,3] + "|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|___________|", "___________|", "___________|", "___________|" }};


                for (int i = 0; i < 21; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(arr[i, j] + "");
                    }
                    Console.WriteLine();
                }

                int y = 3;
                int x = 0;
                int balas = 3;
                String salir = "1";
                String lugar = Inicio.Espacio();
                String tiro;
                
                while (true) //while de teclados
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione las teclas para moverse o cualquier tecla para salir:");
                    String newPos = Console.ReadLine();
                    Console.WriteLine();

                    if ( (newPos != "a" || newPos != "A") & (newPos != "d" || newPos != "D") & (newPos != "w" || newPos != "W") & (newPos != "s" || newPos != "S") )
                    {
                        ;
                    }
                    else
                    {
                        break;
                    }

                    if (balas > 0 || arreglo[1, 0]== Wump.Espacio())
                    {
                        Console.WriteLine("¿Desea lanzar una flecha? s/n");
                        tiro = Console.ReadLine();
                        if (tiro == "s")
                        {
                            if (arreglo[rand.Next(0, 4), rand.Next(0, 4)] == arreglo[1, 0])
                            {
                                Console.WriteLine();
                                balas -= 1;
                                Console.WriteLine("Ha muerto el Gumpus!");
                                arreglo[1, 0] = espacio.Espacio();
                                Console.WriteLine();
                                Console.WriteLine(arreglo[1, 0]);
                                Console.WriteLine("Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine();
                                balas -= 1;
                                Console.WriteLine("No le has dado a nada.");
                                Console.WriteLine();
                                Console.WriteLine("Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                            }

                            

                        }
                    }
                    
                    

                   
                    Console.Clear();
                    //Bug de Inicio. 
                    //You tiene que aparecer en (18,0) y inicio en (17,0). 
                    for (int i = 0; i < 21; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write(arr[i, j] + "");
                        }
                        Console.WriteLine();
                    }

                    if (newPos == "a" || newPos == "A")
                    {

                        if (x - 1 >= 0)
                        {
                            if (arreglo[y, x - 1] == Wump.Espacio() || arreglo[y, x - 1] == Foso.Espacio())
                            {
                                if (arreglo[y, x - 1] == Foso.Espacio())
                                {
                                    Console.Clear();
                                    MuerteFoso();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                    salir = Console.ReadLine();
                                    Console.Clear();
                                    break;
                                }
                                Console.Clear();
                                MuerteWumpus();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                salir = Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if (arreglo[y, x - 1] == Fin.Espacio())
                            {
                                Console.Clear();
                                Final();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                salir = Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if (arreglo[y, x - 1] == Aire.Espacio() || arreglo[y, x - 1] == Peste.Espacio() || arreglo[y, x - 1] == espacio.Espacio())
                            {
                                arreglo[y, x] = lugar;
                                x -= 1;
                                lugar = arreglo[y, x];
                                arreglo[y, x] = Tu.Espacio();
                            }
                        }


                    }
                    else if (newPos == "d" || newPos == "D")
                    {
                        if (x + 1 <= 3)
                        {
                            if (arreglo[y, x + 1] == Wump.Espacio() || arreglo[y, x + 1] == Foso.Espacio())
                            {
                                if (arreglo[y, x + 1] == Foso.Espacio())
                                {
                                    Console.Clear();
                                    MuerteFoso();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                    salir = Console.ReadLine();
                                    Console.Clear();
                                    break;
                                }
                                Console.Clear();
                                MuerteWumpus();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                salir = Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if (arreglo[y, x + 1] == Fin.Espacio())
                            {
                                Console.Clear();
                                Final();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                salir = Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if (arreglo[y, x + 1] == Aire.Espacio() || arreglo[y, x + 1] == Peste.Espacio() || arreglo[y, x + 1] == espacio.Espacio())
                            {
                                arreglo[y, x] = lugar;
                                x += 1;
                                lugar = arreglo[y, x];
                                arreglo[y, x] = Tu.Espacio();
                            }
                        }


                    }
                    else if (newPos == "w" || newPos == "W")
                    {
                        if (y - 1 >= 0)
                        {
                            if (arreglo[y - 1, x] == Wump.Espacio() || arreglo[y - 1, x] == Foso.Espacio())
                            {
                                if (arreglo[y - 1, x] == Foso.Espacio())
                                {
                                    Console.Clear();
                                    MuerteFoso();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                    salir = Console.ReadLine();
                                    Console.Clear();
                                    break;
                                }
                                Console.Clear();
                                MuerteWumpus();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                salir = Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if (arreglo[y - 1, x] == Fin.Espacio())
                            {
                                Console.Clear();
                                Final();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                salir = Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if (arreglo[y - 1, x] == Aire.Espacio() || arreglo[y - 1, x] == Peste.Espacio() || arreglo[y - 1, x] == espacio.Espacio())
                            {
                                arreglo[y, x] = lugar;
                                y -= 1;
                                lugar = arreglo[y, x];
                                arreglo[y, x] = Tu.Espacio();
                            }
                        }



                    }
                    else if (newPos == "s" || newPos == "S")
                    {
                        if (y + 1 <= 3)
                        {
                            if (arreglo[y + 1, x] == Wump.Espacio() || arreglo[y + 1, x] == Foso.Espacio())
                            {
                                if (arreglo[y + 1, x] == Foso.Espacio())
                                {
                                    Console.Clear();
                                    MuerteFoso();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                    salir = Console.ReadLine();
                                    Console.Clear();
                                    break;
                                }
                                Console.Clear();
                                MuerteWumpus();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                salir = Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if (arreglo[y + 1, x] == Fin.Espacio())
                            {
                                Console.Clear();
                                Final();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Presione \"0\" para salir o \"1\" para continuar:");
                                salir = Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if (arreglo[y + 1, x] == Aire.Espacio() || arreglo[y + 1, x] == Peste.Espacio() || arreglo[y + 1, x] == espacio.Espacio())
                            {
                                arreglo[y, x] = lugar;
                                y += 1;
                                lugar = arreglo[y, x];
                                arreglo[y, x] = Tu.Espacio();
                            }
                        }

                    }
                    else
                    {
                        salir = "0";
                        Console.Clear();
                        break;
                    }

                    Console.Clear();
                    arr = new String[,] { { " ___________", " ___________", " ___________"," ____________ "},
                              { "|           |", "           |", "           |", "           |" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|" + arreglo[0,0] + "|", "" + arreglo[0,1] + "|", "" + arreglo[0,2] + "|", "" + arreglo[0,3] + "|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|___________|", "___________|", "___________|", "___________|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|" + arreglo[1,0] + "|", "" + arreglo[1,1] + "|", "" + arreglo[1,2] + "|", "" + arreglo[1,3] + "|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|___________|", "___________|", "___________|", "___________|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|" + arreglo[2,0] + "|", "" + arreglo[2,1] + "|", "" + arreglo[2,2] + "|", "" + arreglo[2,3] + "|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|___________|", "___________|", "___________|", "___________|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|" + arreglo[3,0] + "|", arreglo[3,1] + "|", arreglo[3,2] + "|", arreglo[3,3] + "|" },
                              { "|           |", "           |", "           |", "           |" },
                              { "|___________|", "___________|", "___________|", "___________|" }};

                    for (int i = 0; i < 21; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write(arr[i, j] + "");
                        }
                        Console.WriteLine();
                    }

                }

                if (salir == "0")
                {
                    break;
                }






            }






        }

        static void MuerteWumpus()
        {
            Console.WriteLine();
            Console.WriteLine("Has sido capturado por el Wumpus...");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,40}", "-------------          -------------"));
            Console.WriteLine(String.Format("{0,40}", "---        --          ---        --"));
            Console.WriteLine(String.Format("{0,40}", "---                    ---          "));
            Console.WriteLine(String.Format("{0,40}", "---                    ---          "));
            Console.WriteLine(String.Format("{0,40}", "---    ------          ---    ------"));
            Console.WriteLine(String.Format("{0,40}", "---        --          ---        --"));
            Console.WriteLine(String.Format("{0,40}", "---        --          ---        --"));
            Console.WriteLine(String.Format("{0,40}", "-------------          -------------"));


        }
        static void MuerteFoso()
        {
            Console.WriteLine();
            Console.WriteLine("Encontraste la muerte en el foso...");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,40}", "-------------          -------------"));
            Console.WriteLine(String.Format("{0,40}", "---        --          ---        --"));
            Console.WriteLine(String.Format("{0,40}", "---                    ---          "));
            Console.WriteLine(String.Format("{0,40}", "---                    ---          "));
            Console.WriteLine(String.Format("{0,40}", "---    ------          ---    ------"));
            Console.WriteLine(String.Format("{0,40}", "---        --          ---        --"));
            Console.WriteLine(String.Format("{0,40}", "---        --          ---        --"));
            Console.WriteLine(String.Format("{0,40}", "-------------          -------------"));


        }


        static void Final()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,20}", "-------------          -------------          ---       ---"));
            Console.WriteLine(String.Format("{0,20}", "---                         ---               --- -     ---"));
            Console.WriteLine(String.Format("{0,20}", "---                         ---               ---  -    ---"));
            Console.WriteLine(String.Format("{0,20}", "---                         ---               ---   -   ---"));
            Console.WriteLine(String.Format("{0,20}", "-------------               ---               ---    -  ---"));
            Console.WriteLine(String.Format("{0,20}", "---                         ---               ---     - ---"));
            Console.WriteLine(String.Format("{0,20}", "---                         ---               ---      ----"));
            Console.WriteLine(String.Format("{0,20}", "---                    -------------          ---       ---"));

        }

        //Bonus mapa aleatorio 

    }
    

    

    class Casilla 
    {
        public virtual String Espacio()
        {
            return "           "; //niebla de guerra para el mapa
        }
        
    }

    class Wumpus : Casilla 
    {
        public override String Espacio()
        {
            return "  Wumpus   ";
        }
    }

    class Hueco : Casilla 
    {
        public override String Espacio()
        {
            return "   Foso    ";
        }
    }

    class Aire : Casilla  
    {
        public override String Espacio()
        {
            return "  Viento   ";
        }
    }

    class Peste : Casilla 
    {
        public override String Espacio()
        {
            return "   Hedor   ";
        }
    }

    class Inicio : Casilla 
    {
        public override String Espacio()
        {
           return "  Inicio   ";
        }
    }

    class Fin : Casilla  
    {
        public override String Espacio()
        {
            return "  Tesoro   ";
        }
    }

    class You : Casilla
    {

        public override String Espacio()
        {
            return "    You    ";
        }
    }




}
