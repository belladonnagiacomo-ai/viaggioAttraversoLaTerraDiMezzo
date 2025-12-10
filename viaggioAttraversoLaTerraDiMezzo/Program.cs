namespace viaggioAttraversoLaTerraDiMezzo
{
    internal class Program
    {
        static string Merry(string personaggio, string[] mappa)
        {
            bool i = false;
            int j = 0, puntiS = 10, z = 0;
            string[] inventario = { };
            
            Console.WriteLine("partirai dalla Contea");
            Console.WriteLine("hai" + puntiS + " punti salute e un buff personaggio(+1 probabilita di fuga)");
            while (i == false)
            {
               
                Random rand = new Random();
                int danno = rand.Next(6);
                int casella = rand.Next(4);
                int evento = rand.Next(9);
               
                mappa[j] = mappa[j + casella];
                j++;
                Console.WriteLine("la tua posizione attuale e: " + mappa);
                Console.WriteLine("hai" + puntiS + " punti salute");
                if(evento <= 3)
                {
                     int vitaM = 10;
                    Console.WriteLine("hai incontrato un mostro, vuoi provare a scappare?(s/n)");
                    string risposta = Console.ReadLine();
                    int fuga = rand.Next(2);
                    if (risposta == "s" && fuga >= 1)
                    {
                        Console.WriteLine("il buff personaggio è stato applicato, e sei riuscito a fuggire dal mostro");

                    }
                    else if(risposta == "s" && fuga < 1)
                    {
                        Console.WriteLine("Il mostro ti ha impedito di fuggire, ora combatti!");
                        if (danno >= 3)
                        {
                            while (vitaM > 0)
                            {
                                vitaM = vitaM - danno;
                            }
                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggere il mostro, ecco la tua ricompenza");
                            inventario[z] = "+5 di danno(utilizzabile una sola volta)";
                            z++;
                        }
                        else
                        {
                            puntiS = puntiS - danno;
                            Console.WriteLine("sei stato colpito dal mostro e sei scappato ma la tua salute ora e:" + puntiS);
                        }
                    }
                    else if (risposta == "n")
                    {
                        Console.WriteLine("Hai scelto di non fuggire, sei coraggioso!");
                        if (danno >= 3)
                        {
                            while (vitaM > 0)
                            {
                                vitaM = vitaM - danno;
                            }
                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggere il mostro, ecco la tua ricompenza");
                            inventario[z] = "+5 di danno(utilizzabile una sola volta)";
                            z++;
                        }
                        else
                        {
                            puntiS = puntiS - danno;
                            Console.WriteLine("sei stato colpito dal mostro e sei scappato ma la tua salute ora e:" + puntiS);
                        }

                    }
                    
                   
                }

               


            }
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuti nel viaggio attraverso la terra di mezzo selezionate il vostro personaggio: 1)Frodo 2)Sam 3)Merry");
            int nome = Convert.ToInt32(Console.ReadLine());
            string[] mappa = { "Contea", "I colli di brea" , "Il puledro impennato","Bosco vecchio", "Tumulilande", "Gran Burrone", "Lothlórien", "Fiume Morgul", "Moria", "La Cripta di Balin", "Le Cascate di Rauros", "Cirith Ungol", "Emyn Muil", "Le Paludi Morte", "Piana di Gorgoroth", "Bosco Atro", "Valle dell'Ombra", "Minas Tirith", "Minas Morgul", "Monte Fato" };
          

        }
    }
}
