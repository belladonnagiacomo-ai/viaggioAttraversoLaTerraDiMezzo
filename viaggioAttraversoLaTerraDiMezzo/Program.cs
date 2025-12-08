namespace viaggioAttraversoLaTerraDiMezzo
{
    internal class Program
    {
        static void Merry(string personaggio, string[] mappa)
        {
            bool i = false;
            int j = 0, puntiS = 100;
            
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
                    Console.WriteLine("hai incontrato un mostro");
                    int random = rand.Next(1,2);
                   
                }

               


            }
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuti nel viaggio attraverso la terra di mezzo selezionate il vostro personaggio: 1)Frodo 2)Sam 3)Merry");
            int nome = Convert.ToInt32(Console.ReadLine());
            string[] mappa = { "Contea", "Brea", "Gran Burrone", "Moria", "Bosco Atro", "Minas Tirith", "Minas Morgul", "Monte Fato" };
           

        }
    }
}
