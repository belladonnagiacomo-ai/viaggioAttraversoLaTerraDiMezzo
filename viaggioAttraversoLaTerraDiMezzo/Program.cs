namespace viaggioAttraversoLaTerraDiMezzo
{
    internal class Program
    {
        static void Merry( string[] mappa)
        {
            bool i = false;
            int j = 0, puntiS = 10, z = 0;
            
            
            Console.WriteLine("partirai dalla Contea");
            Console.WriteLine("hai " + puntiS + " punti salute e un buff personaggio(+1 probabilita di fuga)");
            while (i == false)
            {
               
                Random rand = new Random();
                int danno = rand.Next(6);
                int casella = rand.Next(4);
                int evento = rand.Next(9);
               
                mappa[j] = mappa[j + casella];
                j++;
                Console.WriteLine("la tua posizione attuale e: " + mappa);
                Console.WriteLine("hai " + puntiS + " punti salute");
                if(evento <= 3)
                {
                    
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
                           
                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggere il mostro");
                            
                        }
                        else
                        {
                            puntiS = puntiS - danno;
                            Console.WriteLine("sei stato colpito dal mostro e sei scappato ma la tua salute ora e:" + puntiS);
                            if(puntiS == 0)
                            {
                                i = true;
                            }
                        }
                    }
                    else if (risposta == "n")
                    {
                        Console.WriteLine("Hai scelto di non fuggire, sei coraggioso!");
                        if (danno >= 3)
                        {
                            
                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggere il mostro");
                            
                        }
                        else
                        {
                            puntiS = puntiS - danno;
                            Console.WriteLine("sei stato colpito dal mostro e sei scappato ma la tua salute ora e:" + puntiS);
                            if (puntiS == 0)
                            {
                                i = true;
                            }
                        }

                    }
                    
                   
                }
                else if(evento <= 6)
                {
                    Console.WriteLine("Hai incontrato una creatura magica, vuoi provare a interagirci?(s/n)");
                    string risposta = Console.ReadLine();
                    int probabilitaP = rand.Next(1,2);
                    if (risposta == "s" && probabilitaP == 1)
                    {
                        mappa[j] = mappa[j + 2];
                        Console.WriteLine("Hai incontrato una creatura abbastanza socievole che ti aiutera mandandoti avanti di 2 caselle nel tuo percorso e perciò la tua posizione attuale e: " + mappa);
                    }
                    else if(risposta == "s" && probabilitaP == 2)
                    {
                        Console.WriteLine("Per tua sfortuna questa creatura non e molto socievole con te e perciò ti ostacolera");

                        Console.WriteLine("vuoi provare a scappare?(s/n)");
                        string risp = Console.ReadLine();
                        int fuga = rand.Next(2);

                        if (risp == "s" && fuga >= 1)
                        {
                            Console.WriteLine("il buff personaggio è stato applicato, e sei riuscito a fuggire dal mostro");

                        }
                        else if (risp == "s" && fuga < 1)
                        {
                            Console.WriteLine("La creatura ti ha impedito di fuggire, ora combatti!");
                            if (danno >= 3)
                            {

                                Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggerla");

                            }
                            else
                            {
                                puntiS = puntiS - danno;
                                Console.WriteLine("sei stato colpito e sei scappato ma la tua salute ora e:" + puntiS);
                                if (puntiS == 0)
                                {
                                    i = true;
                                }
                            }
                        }
                    }
                    else if(risposta == "n")
                    {
                        Console.WriteLine("Hai deciso di non interagire con la creatura magiche e quindi hai continuato il tuo lungo cammino");
                    }
                }

               


            }
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuti nel viaggio attraverso la terra di mezzo selezionate il vostro personaggio: 1)Frodo 2)Sam 3)Merry");
            int nome = Convert.ToInt32(Console.ReadLine());
            string[] mappa = { "Contea", "I colli di brea" , "Il puledro impennato","Bosco vecchio", "Tumulilande", "Gran Burrone", "Lothlórien", "Fiume Morgul", "Moria", "La Cripta di Balin", "Le Cascate di Rauros", "Cirith Ungol", "Emyn Muil", "Le Paludi Morte", "Piana di Gorgoroth", "Bosco Atro", "Valle dell'Ombra", "Minas Tirith", "Minas Morgul", "Monte Fato" };
            Merry( mappa);

        }
    }
}
