namespace verificaFile
{
    internal class Program
    {
        static void es3(string file)
        {
            List<string> messaggiSospetti = new List<string>();

            using(StreamReader sr = new StreamReader(file))
            {
                string riga = sr.ReadLine();
                riga = sr.ReadLine();

                while(riga != null)
                {
                    if(riga.Contains("Vinci") == true || riga.Contains("Offerta") == true || riga.Contains("Compra") == true)
                    {
                        messaggiSospetti.Add(riga);
                    }

                    riga = sr.ReadLine();
                }
                
            }

            using (StreamWriter sw = new StreamWriter("messaggi_sospetti.csv"))
            {
                sw.WriteLine("mittente,testo");

                for(int i = 0; i < messaggiSospetti.Count; i++)
                {
                    sw.WriteLine(messaggiSospetti[i]);
                }
            }

        }
        static int[] es1(string[] ruote)
        {
            
            int[] numeri = new int[5];
            int num = 0;
            Random rnd = new Random();

            using(StreamWriter sw = new StreamWriter("estrazioni.csv"))
            {
                sw.WriteLine("ruota,n1,n2,n3,n4,n5");

                for(int i = 0; i < ruote.Length; i++)
                {
                    for(int j = 0; j < numeri.Length; j++)
                    {
                        num = rnd.Next(1, 91);

                        while(numeri.Contains(num) == true)
                        {
                            num = rnd.Next(1, 91);
                        }

                        numeri[j] = num;
                    }

                    sw.Write(ruote[i] + ",");

                    for(int k = 0;  k < numeri.Length; k++)
                    {
                        sw.Write(",");
                        sw.Write(numeri[k]);
                    }

                    sw.WriteLine();
                }

            }

            return numeri;
        }
        static void es2(string[] ruote)
        {
            string[] rigaSplit;

            List<string> nome = new List<string>();
            List<string> cittaVincente = new List<string>();
            List<int> numVincente = new List<int>();

            using (StreamReader sr = new StreamReader("giocateLotto.csv"))
            {
                string riga = sr.ReadLine();
                riga = sr.ReadLine();

                while(riga != null)
                {
                    rigaSplit = riga.Split(",");

                    nome.Add(rigaSplit[0]);
                    cittaVincente.Add(rigaSplit[1]);
                    numVincente.Add(Convert.ToInt32(rigaSplit[2]));

                    riga = sr.ReadLine();
                }
            }

            string[] rigaSplit2;

            List<string> citta = new List<string>();
            List<int> num = new List<int>();

            using(StreamReader sr = new StreamReader("estrazioni.csv"))
            {
                string riga = sr.ReadLine();
                riga = sr.ReadLine();

                while(riga != null)
                {
                    rigaSplit2 = riga.Split(",");

                    citta.Add(rigaSplit2[0]);

                    riga = sr.ReadLine();
                }
            }

            List<string> nomeVincente = new List<string>();

            foreach(string s in citta)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            foreach (string s in cittaVincente)
            {
                Console.WriteLine(s);
            }
        }
        static void Main(string[] args)
        {
            string file = "messaggi.csv";

            string[] ruote = { "Bari", "Cagliari", "Firenze", "Genova", "Milano", "Napoli", "Palermo", "Roma", "Torino", "Venezia", "Nazionale" };

            es3(file);
            es1(ruote);
            es2(ruote);
        }
    }
}
