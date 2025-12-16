using System.ComponentModel.Design;

namespace viaggioAttraversoLaTerraDiMezzo
{
    internal class Program
    {
        //inizio prima funzione
        static void Merry(string[] mappa)
        {
            //dichiarazione variabili
            int puntiS = 10, posizioneG = 0, pozioniCura = 0, invisibilità = 0;
            int[] inventario = { pozioniCura, invisibilità };
            string[] nomiOggetti = { "pozioni di cura", "invisibilità" };
            Random rand = new Random();
            //Commenti iniziali
            Console.WriteLine("Ciao  Merry, hai scelto di intraprendere un viaggio molto pericoloso alla distruzione dell'anello del male");
            Console.WriteLine("                                      ");
            Console.WriteLine("partirai dalla Contea");
            Console.WriteLine("hai " + puntiS + " punti salute e un buff personaggio(+1 probabilita di fuga)");
            //inizio while
            while (puntiS > 0 && posizioneG < mappa.Length - 1)
            {


                int danno = rand.Next(1, 6);
                int casella = rand.Next(1, 4);
                int evento = rand.Next(1, 6);
                int oggetto = rand.Next(1, 2);

                posizioneG = posizioneG + casella;

                if (posizioneG >= mappa.Length)
                {
                    posizioneG = mappa.Length - 1;
                }




                Console.WriteLine("Ti sei mosso di " + casella + " passi.");
                Console.WriteLine("Ti trovi sulla casella: " + mappa[posizioneG]);
                Console.WriteLine("hai " + puntiS + " punti salute");
                for (int z = 0; z < inventario.Length; z++)
                {
                    Console.WriteLine("              ");
                    Console.WriteLine(nomiOggetti[z]);
                    Console.WriteLine("Il tuo inventario al momento e: " + inventario[z]);
                    Console.WriteLine("              ");

                }
                Console.WriteLine("vuoi uscire dal gioco?(s/n)");
                string Scelta = Console.ReadLine();
                if (puntiS <= 5 && pozioniCura >= 1)
                {
                    Console.WriteLine("La tua salute attuale ora e di: " + puntiS + " vuoi utilizzare la pozione di cura(ti darà 2 punti vita)? s/n");
                    string dec = Console.ReadLine();
                    if (dec == "s")
                    {
                        puntiS = puntiS + 2;
                        inventario[pozioniCura] = pozioniCura - 1;
                        Console.WriteLine("Buona scelta, hai deciso di utilizzare la pozione di cura");
                    }
                    else
                    {
                        Console.WriteLine("non hai deciso di utilizzare la pozione di cura, ora combatti!");
                    }
                }
                if (Scelta == "s")
                {
                    Console.WriteLine("Hai scelto di uscire dal gioco");
                    Environment.Exit(0);
                }  
                //primo evento
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

                           

                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggere il mostro e ti droppera un'oggetto");
                            inventario[invisibilità] = invisibilità + 1;

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

                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggere il mostro e ti droppera un'oggetto");
                            inventario[invisibilità] = invisibilità + 1;

                        }
                        else
                        {
                            puntiS = puntiS - danno;
                            Console.WriteLine("sei stato colpito dal mostro e sei scappato ma la tua salute ora e:" + puntiS);

                        }

                    }


                }
                //secondo evento
                else if (evento <= 6)
                {
                    Console.WriteLine("Hai incontrato una creatura magica, vuoi provare a interagirci?(s/n)");
                    string risposta = Console.ReadLine();
                    int probabilitaP = rand.Next(1, 2);
                    if (risposta == "s" && probabilitaP == 1)
                    {

                        Console.WriteLine("Hai incontrato una creatura abbastanza socievole che ti aiutera dandoti un'oggetto");
                        inventario[pozioniCura] = pozioniCura++;


                    }
                    else if (risposta == "s" && probabilitaP == 2)
                    {
                        Console.WriteLine("Per tua sfortuna questa creatura non e molto socievole con te e perciò ti ostacolera");
                        if (puntiS <= 5)
                        {
                            if (pozioniCura >= 1)
                            {
                                Console.WriteLine("La tua salute attuale ora e di: " + puntiS + " vuoi utilizzare la pozione di cura(ti darà 2 punti vita)? s/n");
                                string dec = Console.ReadLine();
                                if (dec == "s")
                                {
                                    puntiS = puntiS + 2;
                                    inventario[pozioniCura] = pozioniCura - 1;
                                    Console.WriteLine("Buona scelta, hai deciso di utilizzare la pozione di cura");
                                }
                                else
                                {
                                    Console.WriteLine("non hai deciso di utilizzare la pozione di cura, ora combatti!");
                                }
                            }
                            else if (invisibilità >= 1)
                            {
                                Console.WriteLine("Hai una pozione di invisibilità, se la usi riuscirai a fuggire dal mostro s/n");
                                string decis = Console.ReadLine();
                                if (decis == "s")
                                {
                                    Console.WriteLine("Utilizzando la pozione di invisibiltà sei riuscito a scappare dal mostro");
                                    inventario[invisibilità] = invisibilità - 1;
                                }
                                else
                                {
                                    Console.WriteLine("vuoi provare a scappare?(s/n)");
                                    string risp = Console.ReadLine();
                                    int fuga = rand.Next(1, 2);

                                    if (risp == "s" && fuga >= 1)
                                    {
                                        Console.WriteLine("il buff personaggio è stato applicato, e sei riuscito a fuggire dalla creatura");

                                    }
                                    else if (risp == "s" && fuga < 1)
                                    {
                                        Console.WriteLine("La creatura ti ha impedito di fuggire, ora combatti!");
                                        if (danno >= 3)
                                        {

                                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggerla");
                                            Console.WriteLine("La creatura ti ha droppato un oggetto: ");
                                            if (oggetto == 1)
                                            {
                                                inventario[pozioniCura] = pozioniCura + 1;
                                                Console.WriteLine("Ottimo, hai trovato una pozione di cura che verra aggiunta al tuo inventario e che potrai utilizzare per curarti");
                                            }

                                            else if (oggetto == 2)
                                            {
                                                inventario[invisibilità] = invisibilità + 1;
                                                Console.WriteLine("Grandioso, hai trovato una pozione di invisibilità che potrai utilizzare per evitare combattimenti, verra aggiunta al tuo inventario");
                                            }
                                        }
                                        else
                                        {
                                            puntiS = puntiS - danno;
                                            Console.WriteLine("sei stato colpito e sei scappato ma la tua salute ora e:" + puntiS);

                                        }
                                    }
                                    else if (risposta == "n")
                                    {
                                        Console.WriteLine("Hai deciso di non interagire con la creatura magica e quindi hai continuato il tuo lungo cammino");
                                    }
                                }
                            }


                        }

                    }




                }
                //sconfitta
                if (puntiS <= 0)
                {
                    Console.WriteLine("sei stato sconfitto, ma non preoccuparti potrai ritentare la tua fortuna");
                    return;
                }
                //destinazione finale
                else if (mappa[posizioneG] == "Monte Fato")
                {
                    int dannoF = rand.Next(1, 3);

                    Console.WriteLine("Complimenti, sei arrivato al " + mappa[posizioneG] + " il grande Sauron e li che ti aspetta pronto a ucciderti, cosa fai: 1)Sconfiggi Sauron e ditsuggi l'anello 2) Indossi l'anello e ti unisci a Sauron");
                    int decisione = Convert.ToInt32(Console.ReadLine());
                    if (decisione == 1)
                    {
                        Console.WriteLine("Coraggioso e ora sconfiggi Sauron per proclamare la supremazia del bene sul male!");
                        if (dannoF <= 2)
                        {
                            Console.WriteLine("Il grande Sauron ti ha sconfitto, ma la tua morte non sara vana");
                        }
                        else if (dannoF == 3)
                        {
                            Console.WriteLine("Incredibile! Un dono divino! Hai sconfitto Sauron ora distruggi quell'anello e diventerai il grande eroe del regno!(distruggi l'anello? s/n)");
                            string sceltaF = Console.ReadLine();
                            if (sceltaF == "s")
                            {
                                Console.WriteLine("Hai distrutto l'anello e nel regno sei diventato il nuovo eroe");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("No! ti sei fatto trasportare dal potere dell'anello e ora sei diventato il nuovo re oscuro");
                                return;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hai deciso di unirti dal lato di Sauron e ora andrai con lui alla conquista dei mondi");
                        return;
                    }
                }

            }
        }
        //seconda funzione
        static void Frodo(string[] mappa)
        {
            //dichiarazione variabili
            int puntiS = 15, posizioneG = 0, pozioniCura = 0, invisibilità = 0;
            int[] inventario = { pozioniCura, invisibilità };
            string[] nomiOggetti = { "pozioni di cura", "invisibilità" };
            Random rand = new Random();
            //primi commenti
            Console.WriteLine("Ciao  Frodo, hai scelto di intraprendere un viaggio molto pericoloso alla distruzione dell'anello del male");
            Console.WriteLine("                                      ");
            Console.WriteLine("partirai dalla Contea");
            Console.WriteLine("hai " + puntiS + " punti salute e un buff personaggio(+5 punti vita)");
            //inizio while
            while (puntiS > 0 && posizioneG < mappa.Length - 1)
            {


                int danno = rand.Next(1, 6);
                int casella = rand.Next(1, 4);
                int evento = rand.Next(1, 6);
                int oggetto = rand.Next(1, 2);

                posizioneG = posizioneG + casella;

                if (posizioneG >= mappa.Length)
                {
                    posizioneG = mappa.Length - 1;
                }
             




                Console.WriteLine("Ti sei mosso di " + casella + " passi.");
                Console.WriteLine("Ti trovi sulla casella: " + mappa[posizioneG]);
                Console.WriteLine("hai " + puntiS + " punti salute");
                for (int z = 0; z < inventario.Length; z++)
                {
                    Console.WriteLine("              ");
                    Console.WriteLine(nomiOggetti[z]);
                    Console.WriteLine("Il tuo inventario al momento e: " + inventario[z]);
                    Console.WriteLine("              ");

                }
                Console.WriteLine("vuoi uscire dal gioco?(s/n)");
                string Scelta = Console.ReadLine();
                if (puntiS <= 5 && pozioniCura >= 1)
                {
                    Console.WriteLine("La tua salute attuale ora e di: " + puntiS + " vuoi utilizzare la pozione di cura(ti darà 2 punti vita)? s/n");
                    string dec = Console.ReadLine();
                    if (dec == "s")
                    {
                        puntiS = puntiS + 2;
                        inventario[pozioniCura] = pozioniCura - 1;
                        Console.WriteLine("Buona scelta, hai deciso di utilizzare la pozione di cura");
                    }
                    else
                    {
                        Console.WriteLine("non hai deciso di utilizzare la pozione di cura, ora combatti!");
                    }
                }
                if (Scelta == "s")
                {
                    Console.WriteLine("Hai scelto di uscire dal gioco");
                    Environment.Exit(0);
                }
                //primo evento
                if (evento <= 3)
                {

                    Console.WriteLine("hai incontrato un mostro, vuoi provare a scappare?(s/n)");
                    string risposta = Console.ReadLine();
                    int fuga = rand.Next(2);

                    if (risposta == "s" && fuga >= 1)
                    {
                        Console.WriteLine("sei riuscito a fuggire dal mostro");

                    }
                    else if (risposta == "s" && fuga < 1)
                    {
                        Console.WriteLine("Il mostro ti ha impedito di fuggire, ora combatti!");

                        if (danno >= 3)
                        {

                            

                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggere il mostro e ti droppera un'oggetto");
                            inventario[invisibilità] = invisibilità + 1;

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


                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggere il mostro e ti droppera un'oggetto");
                            inventario[invisibilità] = invisibilità + 1;

                        }
                        else
                        {
                            puntiS = puntiS - danno;
                            Console.WriteLine("sei stato colpito dal mostro e sei scappato ma la tua salute ora e:" + puntiS);

                        }

                    }


                }
                //secondo evento
                else if (evento <= 6)
                {
                    Console.WriteLine("Hai incontrato una creatura magica, vuoi provare a interagirci?(s/n)");
                    string risposta = Console.ReadLine();
                    int probabilitaP = rand.Next(1, 2);
                    if (risposta == "s" && probabilitaP == 1)
                    {

                        Console.WriteLine("Hai incontrato una creatura abbastanza socievole che ti aiutera dandoti un'oggetto");
                        inventario[pozioniCura] = pozioniCura + 1;
                    }
                    else if (risposta == "s" && probabilitaP == 2)
                    {
                        Console.WriteLine("Per tua sfortuna questa creatura non e molto socievole con te e perciò ti ostacolera");
                        if (puntiS <= 5)
                        {
                            if (pozioniCura >= 1)
                            {
                                Console.WriteLine("La tua salute attuale ora e di: " + puntiS + " vuoi utilizzare la pozione di cura(ti darà 2 punti vita)? s/n");
                                string dec = Console.ReadLine();
                                if (dec == "s")
                                {
                                    puntiS = puntiS + 2;
                                    inventario[pozioniCura] = pozioniCura - 1;
                                    Console.WriteLine("Buona scelta, hai deciso di utilizzare la pozione di cura");
                                }
                                else
                                {
                                    Console.WriteLine("non hai deciso di utilizzare la pozione di cura, ora combatti!");
                                }
                            }
                            else if (invisibilità >= 1)
                            {
                                Console.WriteLine("Hai una pozione di invisibilità, se la usi riuscirai a fuggire dal mostro s/n");
                                string decis = Console.ReadLine();
                                if (decis == "s")
                                {
                                    Console.WriteLine("Utilizzando la pozione di invisibiltà sei riuscito a scappare dal mostro");
                                    inventario[invisibilità] = invisibilità - 1;
                                }
                                else
                                {
                                    Console.WriteLine("vuoi provare a scappare?(s/n)");
                                    string risp = Console.ReadLine();
                                    int fuga = rand.Next(1, 2);

                                    if (risp == "s" && fuga >= 1)
                                    {
                                        Console.WriteLine("il buff personaggio è stato applicato, e sei riuscito a fuggire dalla creatura");

                                    }
                                    else if (risp == "s" && fuga < 1)
                                    {
                                        Console.WriteLine("La creatura ti ha impedito di fuggire, ora combatti!");
                                        if (danno >= 3)
                                        {

                                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggerla");
                                            Console.WriteLine("La creatura ti ha droppato un oggetto: ");
                                            if (oggetto == 1)
                                            {
                                                inventario[pozioniCura] = pozioniCura + 1;
                                                Console.WriteLine("Ottimo, hai trovato una pozione di cura che verra aggiunta al tuo inventario e che potrai utilizzare per curarti");
                                            }

                                            else if (oggetto == 2)
                                            {
                                                inventario[invisibilità] = invisibilità + 1;
                                                Console.WriteLine("Grandioso, hai trovato una pozione di invisibilità che potrai utilizzare per evitare combattimenti, verra aggiunta al tuo inventario");
                                            }
                                        }
                                        else
                                        {
                                            puntiS = puntiS - danno;
                                            Console.WriteLine("sei stato colpito e sei scappato ma la tua salute ora e:" + puntiS);

                                        }
                                    }
                                    else if (risposta == "n")
                                    {
                                        Console.WriteLine("Hai deciso di non interagire con la creatura magica e quindi hai continuato il tuo lungo cammino");
                                    }
                                }
                            }


                        }
                    }
                    else if (risposta == "n")
                    {
                        Console.WriteLine("Hai deciso di non interagire con la creatura magica e quindi hai continuato il tuo lungo cammino");
                    }
                }




            }
            //sconfitta
            if (puntiS <= 0)
            {
                Console.WriteLine("sei stato sconfitto, ma non preoccuparti potrai ritentare la tua fortuna");
                return;
            }
            //arrivo a destinazione
            else if (mappa[posizioneG] == "Monte Fato")
            {
                int dannoF = rand.Next(1, 3);

                Console.WriteLine("Complimenti, sei arrivato al " + mappa[posizioneG] + " il grande Sauron e li che ti aspetta pronto a ucciderti, cosa fai: 1)Sconfiggi Sauron e ditsuggi l'anello 2) Indossi l'anello e ti unisci a Sauron");
                int decisione = Convert.ToInt32(Console.ReadLine());
                if (decisione == 1)
                {
                    Console.WriteLine("Coraggioso e ora sconfiggi Sauron per proclamare la supremazia del bene sul male!");
                    if (dannoF <= 2)
                    {
                        Console.WriteLine("Il grande Sauron ti ha sconfitto, ma la tua morte non sara vana");
                    }
                    else if (dannoF == 3)
                    {
                        Console.WriteLine("Incredibile! Un dono divino! Hai sconfitto Sauron ora distruggi quell'anello e diventerai il grande eroe del regno!(distruggi l'anello? s/n)");
                        string sceltaF = Console.ReadLine();
                        if (sceltaF == "s")
                        {
                            Console.WriteLine("Hai distrutto l'anello e nel regno sei diventato il nuovo eroe");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("No! ti sei fatto trasportare dal potere dell'anello e ora sei diventato il nuovo re oscuro");
                            return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Hai deciso di unirti dal lato di Sauron e ora andrai con lui alla conquista dei mondi");
                    return;
                }
            }

        }
        //terza funzione
        static void Sam(string[] mappa)
        {
            //dichiarazione variabili
            int puntiS = 10, posizioneG = 0, pozioniCura = 0, invisibilità = 0;
            int[] inventario = { pozioniCura, invisibilità };
            string[] nomiOggetti = { "pozioni di cura", "invisibilità" };
            Random rand = new Random();
            //primi commenti
            Console.WriteLine("Ciao  Sam, hai scelto di intraprendere un viaggio molto pericoloso alla distruzione dell'anello del male");
            Console.WriteLine("                                      ");
            Console.WriteLine("partirai dalla Contea");
            Console.WriteLine("hai " + puntiS + " punti salute e un buff personaggio(+1 di danno ai nemici)");
            //inizio while
            while (puntiS > 0 && posizioneG < mappa.Length - 1)
            {


                int danno = rand.Next(1, 6);
                int casella = rand.Next(1, 4);
                int evento = rand.Next(1, 6);
                int oggetto = rand.Next(1, 3);

                posizioneG = posizioneG + casella;

                if (posizioneG >= mappa.Length)
                {
                    posizioneG = mappa.Length - 1;
                }

               



                Console.WriteLine("Ti sei mosso di " + casella + " passi.");
                Console.WriteLine("Ti trovi sulla casella: " + mappa[posizioneG]);
                Console.WriteLine("hai " + puntiS + " punti salute");
                for (int z = 0; z < inventario.Length; z++)
                {
                    Console.WriteLine("              ");
                    Console.WriteLine(nomiOggetti[z]);
                    Console.WriteLine("Il tuo inventario al momento e: " + inventario[z]);
                    Console.WriteLine("              ");

                }
                Console.WriteLine("vuoi uscire dal gioco?(s/n)");
                string Scelta = Console.ReadLine();
                if (puntiS <= 5 && pozioniCura >= 1)
                {
                    Console.WriteLine("La tua salute attuale ora e di: " + puntiS + " vuoi utilizzare la pozione di cura(ti darà 2 punti vita)? s/n");
                    string dec = Console.ReadLine();
                    if (dec == "s")
                    {
                        puntiS = puntiS + 2;
                        inventario[pozioniCura] = pozioniCura - 1;
                        Console.WriteLine("Buona scelta, hai deciso di utilizzare la pozione di cura");
                    }
                    else
                    {
                        Console.WriteLine("non hai deciso di utilizzare la pozione di cura, ora combatti!");
                    }
                }
                if (Scelta == "s")
                {
                    Console.WriteLine("Hai scelto di uscire dal gioco");
                    Environment.Exit(0);
                }
                //primo evento
                if (evento <= 3)
                {

                    Console.WriteLine("hai incontrato un mostro, vuoi provare a scappare?(s/n)");
                    string risposta = Console.ReadLine();
                    int fuga = rand.Next(2);

                    if (risposta == "s" && fuga >= 1)
                    {
                        Console.WriteLine("sei riuscito a fuggire dal mostro");

                    }
                    else if (risposta == "s" && fuga < 1)
                    {
                        Console.WriteLine("Il mostro ti ha impedito di fuggire, ora combatti!");

                        if (danno >= 3)
                        {


                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggere il mostro e ti droppera un'oggetto");
                            inventario[invisibilità] = invisibilità + 1;

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
                        if (danno >= 4)
                        {


                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggere il mostro e ti droppera un'oggetto");
                            inventario[invisibilità] = invisibilità + 1;

                        }
                        else
                        {
                            puntiS = puntiS - danno;
                            Console.WriteLine("sei stato colpito dal mostro e sei scappato ma la tua salute ora e:" + puntiS);

                        }

                    }


                }
                //secondo evento
                else if (evento <= 6)
                {
                    Console.WriteLine("Hai incontrato una creatura magica, vuoi provare a interagirci?(s/n)");
                    string risposta = Console.ReadLine();
                    int probabilitaP = rand.Next(1, 2);
                    if (risposta == "s" && probabilitaP == 1)
                    {
                        Console.WriteLine("Hai incontrato una creatura abbastanza socievole che ti aiutera dandoti un'oggetto");
                        inventario[pozioniCura] = pozioniCura + 1;
                    }
                    else if (risposta == "s" && probabilitaP == 2)
                    {
                        Console.WriteLine("Per tua sfortuna questa creatura non e molto socievole con te e perciò ti ostacolera");

                        if (puntiS <= 5)
                        {
                            if (pozioniCura >= 1)
                            {
                                Console.WriteLine("La tua salute attuale ora e di: " + puntiS + " vuoi utilizzare la pozione di cura(ti darà 2 punti vita)? s/n");
                                string dec = Console.ReadLine();
                                if (dec == "s")
                                {
                                    puntiS = puntiS + 2;
                                    inventario[pozioniCura] = pozioniCura - 1;
                                    Console.WriteLine("Buona scelta, hai deciso di utilizzare la pozione di cura");
                                }
                                else
                                {
                                    Console.WriteLine("non hai deciso di utilizzare la pozione di cura, ora combatti!");
                                }
                            }
                            else if (invisibilità >= 1)
                            {
                                Console.WriteLine("Hai una pozione di invisibilità, se la usi riuscirai a fuggire dal mostro s/n");
                                string decis = Console.ReadLine();
                                if (decis == "s")
                                {
                                    Console.WriteLine("Utilizzando la pozione di invisibiltà sei riuscito a scappare dal mostro");
                                    inventario[invisibilità] = invisibilità - 1;
                                }
                                else
                                {
                                    Console.WriteLine("vuoi provare a scappare?(s/n)");
                                    string risp = Console.ReadLine();
                                    int fuga = rand.Next(1, 2);

                                    if (risp == "s" && fuga >= 1)
                                    {
                                        Console.WriteLine("il buff personaggio è stato applicato, e sei riuscito a fuggire dalla creatura");

                                    }
                                    else if (risp == "s" && fuga < 1)
                                    {
                                        Console.WriteLine("La creatura ti ha impedito di fuggire, ora combatti!");
                                        if (danno >= 3)
                                        {

                                            Console.WriteLine("Congratulazioni!, sei riuscito ha sconfiggerla");
                                            Console.WriteLine("La creatura ti ha droppato un oggetto: ");
                                            if (oggetto == 1)
                                            {
                                                inventario[pozioniCura] = pozioniCura + 1;
                                                Console.WriteLine("Ottimo, hai trovato una pozione di cura che verra aggiunta al tuo inventario e che potrai utilizzare per curarti");
                                            }

                                            else if (oggetto == 2)
                                            {
                                                inventario[invisibilità] = invisibilità + 1;
                                                Console.WriteLine("Grandioso, hai trovato una pozione di invisibilità che potrai utilizzare per evitare combattimenti, verra aggiunta al tuo inventario");
                                            }
                                        }
                                        else
                                        {
                                            puntiS = puntiS - danno;
                                            Console.WriteLine("sei stato colpito e sei scappato ma la tua salute ora e:" + puntiS);

                                        }
                                    }
                                    else if (risposta == "n")
                                    {
                                        Console.WriteLine("Hai deciso di non interagire con la creatura magica e quindi hai continuato il tuo lungo cammino");
                                    }
                                }
                            }


                        }
                    }
                    else if (risposta == "n")
                    {
                        Console.WriteLine("Hai deciso di non interagire con la creatura magica e quindi hai continuato il tuo lungo cammino");
                    }
                }




            }
            //sconfitta
            if (puntiS <= 0)
            {
                Console.WriteLine("sei stato sconfitto, ma non preoccuparti potrai ritentare la tua fortuna");
                return;
            }
            //arrivo a destinazione
            else if (mappa[posizioneG] == "Monte Fato")
            {
                int dannoF = rand.Next(1, 3);

                Console.WriteLine("Complimenti, sei arrivato al " + mappa[posizioneG] + " il grande Sauron e li che ti aspetta pronto a ucciderti, cosa fai: 1)Sconfiggi Sauron e ditsuggi l'anello 2) Indossi l'anello e ti unisci a Sauron");
                int decisione = Convert.ToInt32(Console.ReadLine());
                if (decisione == 1)
                {
                    Console.WriteLine("Coraggioso e ora sconfiggi Sauron per proclamare la supremazia del bene sul male!");
                    if (dannoF <= 2)
                    {
                        Console.WriteLine("Il grande Sauron ti ha sconfitto, ma la tua morte non sara vana");
                    }
                    else if (dannoF == 3)
                    {
                        Console.WriteLine("Incredibile! Un dono divino! Hai sconfitto Sauron ora distruggi quell'anello e diventerai il grande eroe del regno!(distruggi l'anello? s/n)");
                        string sceltaF = Console.ReadLine();
                        if (sceltaF == "s")
                        {
                            Console.WriteLine("Hai distrutto l'anello e nel regno sei diventato il nuovo eroe");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("No! ti sei fatto trasportare dal potere dell'anello e ora sei diventato il nuovo re oscuro");
                            return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Hai deciso di unirti dal lato di Sauron e ora andrai con lui alla conquista dei mondi");
                    return;
                }
            }

        }
        static void Main(string[] args)
        {
            //scelta personaggi
            Console.WriteLine("Benvenuti nel viaggio attraverso la terra di mezzo selezionate il vostro personaggio: 1)Frodo 2)Sam 3)Merry");
            int nome = Convert.ToInt32(Console.ReadLine());
            //tappe della mappa
            string[] mappa = { "Contea", "I colli di brea", "Il puledro impennato", "Bosco vecchio", "Tumulilande", "Gran Burrone", "Lothlórien", "Fiume Morgul", "Moria", "La Cripta di Balin", "Le Cascate di Rauros", "Cirith Ungol", "Emyn Muil", "Le Paludi Morte", "Piana di Gorgoroth", "Bosco Atro", "Valle dell'Ombra", "Minas Tirith", "Minas Morgul", "Monte Fato" };
            if (nome == 1)
            {
                Frodo(mappa);
            }
            else if (nome == 2)
            {
                Sam(mappa);
            }
            else
            {
                Merry(mappa);
            }


        }

    }
}
