namespace viaggioAttraversoLaTerraDiMezzo
{
    internal class Program
    {
        static void Merry( string[] mappa)
        {
           
            int puntiS = 10, posizioneG = 0;
            Random rand = new Random();

            Console.WriteLine("partirai dalla Contea");
            Console.WriteLine("hai " + puntiS + " punti salute e un buff personaggio(+1 probabilita di fuga)");
            while (puntiS > 0 && posizioneG < mappa.Length)
            {
                
                    
                    int danno = rand.Next(1,6);
                    int casella = rand.Next(1,4);
                    int evento = rand.Next(1,9);

                    posizioneG = posizioneG + casella;

                    if (posizioneG >= mappa.Length)
                    {
                        posizioneG = mappa.Length - 1;
                    }

                    Console.WriteLine("Ti sei mosso di " + casella + " passi.");
                    Console.WriteLine("Ti trovi sulla casella: " + mappa[posizioneG]);
                    Console.WriteLine("hai " + puntiS + " punti salute");
                    if (evento <= 3)
                    {

                        Console.WriteLine("hai incontrato un mostro, vuoi provare a scappare?(s/n)");
                        string risposta = Console.ReadLine();
                        int fuga = rand.Next(2);

                        if (risposta == "s" && fuga >= 1)
                        {
                            Console.WriteLine("il buff personaggio è stato applicato, e sei riuscito a fuggire dal mostro");

                        }
                        else if (risposta == "s" && fuga < 1)
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
                                
                            }

                        }


                    }
                    else if (evento <= 6)
                    {
                        Console.WriteLine("Hai incontrato una creatura magica, vuoi provare a interagirci?(s/n)");
                        string risposta = Console.ReadLine();
                        int probabilitaP = rand.Next(1, 2);
                        if (risposta == "s" && probabilitaP == 1)
                        {
                            posizioneG = posizioneG + 2;
                            Console.WriteLine("Hai incontrato una creatura abbastanza socievole che ti aiutera mandandoti avanti di 2 caselle nel tuo percorso e perciò la tua posizione attuale e: " + mappa[posizioneG]);
                        }
                        else if (risposta == "s" && probabilitaP == 2)
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
                                   
                                }
                            }
                        }
                        else if (risposta == "n")
                        {
                            Console.WriteLine("Hai deciso di non interagire con la creatura magica e quindi hai continuato il tuo lungo cammino");
                        }
                    }


                

            }
            Console.WriteLine("Per tua sfortuna, il fato ha deciso di farti decadere ma non disperarti, osru rigioca un'altra partita");
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuti nel viaggio attraverso la terra di mezzo selezionate il vostro personaggio: 1)Frodo 2)Sam 3)Merry");
            int nome = Convert.ToInt32(Console.ReadLine());
            string[] mappa = { "Contea", "I colli di brea" , "Il puledro impennato","Bosco vecchio", "Tumulilande", "Gran Burrone", "Lothlórien", "Fiume Morgul", "Moria", "La Cripta di Balin", "Le Cascate di Rauros", "Cirith Ungol", "Emyn Muil", "Le Paludi Morte", "Piana di Gorgoroth", "Bosco Atro", "Valle dell'Ombra", "Minas Tirith", "Minas Morgul", "Monte Fato" };
            if(nome == 1)
            {
                Merry(mappa);
            }
            

        }
    }
}
