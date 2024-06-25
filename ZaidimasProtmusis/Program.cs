using System.Text;

namespace ZaidimasProtmusis
{
    public class Program
    {
        static Dictionary<string, int> zaidejaiIrTaskai = new Dictionary<string, int> //Zaidejai ir taskai
        {
            {"Petras Petraitis", 0},
            {"Jonas Jonaitis", 0},
            {"Antanas Antanaitis", 0},
            {"Mindaugas Arnaitis", 0},
            {"Gerda Arnaitis", 0},
            {"Jurgita Arnaitis", 0},
            {"Janina Arnaitis", 0},
            {"Aurimas Arnaitis", 0},
            {"Migle Arnaitis", 0},
            {"Kamile Arnaitis", 0},
            {"Raimondas Arnaitis", 0},
            {"Toma Arnaitis", 0},
            {"Tomas Arnaitis", 0},
            {"Gabija Arnaitis", 0},
            {"Robertas Arnaitis", 0},
            {"Rasa Arnaitis", 0},
        };
        static List<string> klausimuKategorijos = new List<string>  //Klausimu kategorijos
        {
            "Matematika",
            "Geografija",
        };

        static Dictionary<string, List<string>> klausimaiMatematika = new Dictionary<string, List<String>>  //Matematikos klausimai
        {
            {"Kiek yra 5 + 5", new List<string>{"1. 9", "2. 10", "3. 15", "4. 8",} },
            {"Kiek yra 10 + 5", new List<string>{"1. 15", "2. 20", "3. 10", "4. 25",} },
            {"Kiek yra 10 + 10", new List<string>{"1. 30", "2. 21", "3. 25", "4. 20",} },
            {"Kiek yra 15 + 3", new List<string>{"1. 20", "2. 18", "3. 19", "4. 17",} },
            {"Kiek yra 20 + 5", new List<string>{"1. 20", "2. 23", "3. 25", "4. 30",} },
        };

        static Dictionary<string, int> matematikosKlausimuAtsakymai = new Dictionary<string, int>  //Matematikos klausimu atsakymai
        {
            {"Kiek yra 5 + 5", 2 },
            {"Kiek yra 10 + 5", 1 },
            {"Kiek yra 10 + 10", 4 },
            {"Kiek yra 15 + 3", 2 },
            {"Kiek yra 20 + 5", 3 },
        };

        static Dictionary<string, List<string>> klausimaiGeografijos = new Dictionary<string, List<String>>
        {
            {"Kas yra Lietuvos sostine", new List<string>{"1. Vilnius", "2. Kaunas", "3. Klaipeda", "4. Šiauliai",} }, //Geografijos klausimai
            {"Iš kiek valstijų sudaro JAV", new List<string>{"1. 45", "2. 50", "3. 55", "4. 60",} }
        };

        static Dictionary<string, int> geografijosKlausimuAtsakymai = new Dictionary<string, int>  //Geografijos klausimu atsakymai
        {
            {"Kas yra Lietuvos sostine", 1 },
            {"Iš kiek valstijų sudaro JAV", 2 },
        };

        static string prisijungesVartotojas = String.Empty; // String.Empty tas pats kas = "", globalus kintamasis galima atnaujinti iš bet kur ir visada matyti kas prisijungęs

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //lietuviskos raides
            Console.InputEncoding = Encoding.UTF8;
            Prisijungimas(); //Prisijungimas
            MeniuPasirinkimas(); // Po prisijungimo kvieciame i meniu

        }

        public static string PirmaRaideUpper(string text) //Metodas kuris turi viena parametra teksta ir teksto pirmą raidę padaro didžiaja ir gražina tekstą
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }
            var temp = text.ToCharArray(); //Paverčiame tekstą į char masyvą
            temp[0] = char.ToUpper(temp[0]);//Masyvo pirmą raidę padarome didžiają
            return new string(temp);//Gražiname nauja string su pakeista pirma raide
        }

        public static string NuoAtrosRaidesLower(string text) //Metodas kuris turi viena parametra teksta ir teksto nuo antros raides padaro iš mažosios ir gražina tekstą
        {
            if (text.Length > 1)
            {
                return text.Substring(0, 1) + text.Substring(1).ToLower(); //Paimama teksto pirma raide ir prijungiamas likusis su mažosiomis raidėmis
            }
            return text;
        }

        public static bool ArLeistinosRaides(string text) //Metodas kuris turi viena parametra teksta ir patikrina jame yra tik leistinos raides jei taip grazina true jei yra neleistina grazina false
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }
            string leistinosRaides = "aąbcčdeęėfghiįyjklmnoprsštuųūvzžqwx";
            var sarasas = leistinosRaides.ToCharArray();
            var charArray = text.ToLower().ToCharArray();// Tekstą paverčiame mažosiomis raidėmis ir į char masyvą kad galėtume lyginti neatsižvelgiant į tai ar didžioji ar mažoji raidė
            bool valid = true;
            foreach (char c in charArray)
            { //Einame teksto raides ir tikriname ar yra tokia raide leistinosRaides sarase
                if (!sarasas.Contains(c))
                {
                    valid = false; break; //Rasta netinkamas simbolis todėl valid false ir break iš ciklo
                }
            }
            return valid;
        }

        private static void Prisijungimas() //Prisijungimo metodas
        {
            Console.Clear();// Išvalo konsole
            Console.WriteLine("Sveiki atvykę į protmūšį");
            string vardas = String.Empty;
            string pavarde = String.Empty;
            while (string.IsNullOrWhiteSpace(vardas) || !ArLeistinosRaides(vardas)) //sukame while cikla kol vartotojas ives ne null arba tarpus (apsauga)
            {
                Console.WriteLine("Įveskite vardą, galimos raidės [aąbcčdeęėfghiįyjklmnoprsštuųūvzžqwx]");
                vardas = Console.ReadLine().Trim(); //nuskaitome ir dar išvalome tarpus
                vardas = PirmaRaideUpper(vardas);
                vardas = NuoAtrosRaidesLower(vardas);
            }
            while (string.IsNullOrWhiteSpace(pavarde) || !ArLeistinosRaides(pavarde))
            {
                Console.WriteLine("Įveskite pavardę, galimos raidės [aąbcčdeęėfghiįyjklmnoprsštuųūvzžqwx]");
                pavarde = Console.ReadLine().Trim(); //nuskaitome ir dar išvalome tarpus
                pavarde = PirmaRaideUpper(pavarde);
                pavarde = NuoAtrosRaidesLower(pavarde);
            }
            string zaidejas = vardas + " " + pavarde;
            if (zaidejaiIrTaskai.ContainsKey(zaidejas))  //ar zaidejas yra sarase, jeigu yra tai pranešame kad jau egzistuoja
            {
                Console.WriteLine("Prisijungėte su paskyra, kuri jau egzistuoja, paspauskite bet kurį mygtuką kad tęstumėte");
                Console.ReadKey();
                prisijungesVartotojas = zaidejas;
            }
            else
            {
                zaidejaiIrTaskai.Add(zaidejas, 0); //jei nera, zaidejas sukuriamas ir pasisveikinama
                Console.WriteLine("Sveikiname prisijungus ir susikūrus naują paskyrą, paspauskite bet kurį mygtuką kad tęstumėte");
                Console.ReadKey();
                prisijungesVartotojas = zaidejas;
            }
        }

        private static void MeniuPasirinkimas()//meniu metodas
        {
            int pasirinkimasInt = 0;
            while (pasirinkimasInt != 5) //While ciklas vyksta kol nepasirenkama 5 iš meniu tuomet ciklas nutruksta ir užbaigiama programa
            {
                Console.Clear();
                PrisijungesVartotojas();
                Console.WriteLine("|-----------------------------------------------|");
                Console.WriteLine("| Pasirinkite meniu punktą                      |");
                Console.WriteLine("|-----------------------------------------------|");
                Console.WriteLine("| 1. Atsijungimas                               |");
                Console.WriteLine("| 2. Žaidimo taisyklės                          |");
                Console.WriteLine("| 3. Žaidimo rezultatų ir dalyvių peržiūra      |");
                Console.WriteLine("| 4. Dalyvavimas (Start game)                   |");
                Console.WriteLine("| 5. Išėjimas iš žaidimo                        |");
                Console.WriteLine("|-----------------------------------------------|");
                do
                {
                    Console.WriteLine("Pasirinkite meniu punktą 1-5");
                } while (!int.TryParse(Console.ReadLine(), out pasirinkimasInt) || pasirinkimasInt < 1 || pasirinkimasInt > 5);
                switch (pasirinkimasInt)
                {
                    case 1:
                        Atsijungimas();
                        Prisijungimas();
                        break;
                    case 2:
                        ZaidimoTaisykles();
                        break;
                    case 3:
                        ZaidimoRezultataiIrDalyviuPerziura(zaidejaiIrTaskai);
                        break;
                    case 4:
                        Dalyvavimas();
                        break;
                    case 5:
                        pasirinkimasInt = 5; //Uzsibaigs ciklas ir išeisime iš žaidimo
                        break;
                }
            }
        }

        private static void Atsijungimas() //Atsijungimo metodas
        {
            prisijungesVartotojas = String.Empty; //Globalu kintamaji prisijungesVartotojas išvalome
        }

        private static void ZaidimoTaisykles() //Žaidimo taiksyklės metodas
        {
            Console.Clear();
            Console.WriteLine(@"Sveikiname prisijungus prie 'Platininio proto' protmūšio žaidimo programos.
            Protmūšio žaidimas leidžia pasirinkti klausimus net iš dviejų kategorijų. Pasirinkus kategoriją pradedate žaidimą.
            Kiekvienas klausimas turi 4 galimus atsakymus, iš kurių tik vienas yra teisingas.
            Kiekvienas teisingai atsakytas klausimas žaidėjui prideda 1 tašką. Sėkmės šioje proto kovoje!");
            Console.WriteLine();
            QIMeniu();
        }

        private static void QIMeniu()  //Išėjimas i meniu metodas
        {
            string pasirinkimas = String.Empty;
            while (pasirinkimas != "q") //Sukame ciklą kol neivedama q raidė
            {
                Console.WriteLine();
                Console.WriteLine("Įveskite \"q\" jeigu norite išeiti į meniu");
                pasirinkimas = Console.ReadLine();
            }
        }

        public static Dictionary<string, int> ZaidimoDalyviuRikiavimasPagalTaskus(Dictionary<string, int> zaidejaiIrTaskai) //Metodas surikuoja perduodamą parametrą dictionary pagal reikšmės(values)
        {
            return zaidejaiIrTaskai.OrderByDescending(x => x.Value).ToDictionary();
        }

        public static List<string> ZaidimoDalyviuTop10SuZvaigzdutem(Dictionary<string, int> zaidejaiIrTaskai) //Metodas kuris prirašo poziciją prie top 10 žaidėjų ir top 3 žaidėjams pridedamos žvaigždutės
        {
            List<string> zaidejai = new List<string>();// sarasas zaideju i kuri sudesime po kiekvieno ciklo suformuota zaidejo teksta
            int position = 1;
            foreach (var zaidejas in zaidejaiIrTaskai)
            {
                StringBuilder zaidejaiSb = new StringBuilder();
                if (position <= 10)
                {
                    zaidejaiSb.Append(position).Append(" ").Append(zaidejas.Key);
                }
                else
                {
                    zaidejaiSb.Append(zaidejas.Key);
                }
                if (position <= 3)
                {
                    for (int i = 0; i < position; i++)
                    {
                        zaidejaiSb.Append("*");
                    }
                }
                zaidejaiSb.Append(" ").Append(zaidejas.Value);
                zaidejai.Add(zaidejaiSb.ToString());
                position++;
            }
            return zaidejai;
        }

        private static void AtvaizduotiZaidejus(List<string> zaidejai) //Metodas, kuris atvaizduoja žaidėjų sarašą
        {
            foreach (var zaidejas in zaidejai)
            {
                Console.WriteLine(zaidejas);
            }
        }

        public static void ZaidimoRezultataiIrDalyviuPerziura(Dictionary<string, int> zaidejaiIrTaskai) //Metodas kuris atvaizduoja rezultatus ir dalyvių lentelę
        {
            Console.Clear();
            PrisijungesVartotojas();
            Console.WriteLine("-> Žaidimo rezultatų ir dalyvių peržiūra");
            Console.WriteLine();
            var surikiuotiZaidejaiPagalTaskus = ZaidimoDalyviuRikiavimasPagalTaskus(zaidejaiIrTaskai);
            var top10SuZvaigzdutem = ZaidimoDalyviuTop10SuZvaigzdutem(surikiuotiZaidejaiPagalTaskus);
            AtvaizduotiZaidejus(top10SuZvaigzdutem);
            QIMeniu();
        }

        private static void PrisijungesVartotojas()
        {
            Console.WriteLine();
            if (!string.IsNullOrWhiteSpace(prisijungesVartotojas))
            {
                Console.WriteLine($"Žaidėjas: {prisijungesVartotojas}");
                Console.WriteLine();
            }
        }

        private static void Dalyvavimas()
        {
            KlausimuKategorijosSwitch(KlausimuKategorijos());
        }

        private static int KlausimuKategorijos()
        {
            Console.Clear();
            PrisijungesVartotojas();
            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("| Klausimų kategorijos");
            Console.WriteLine("|------------------------------------------|");
            int numeracija = 1;
            foreach (var kategorija in klausimuKategorijos)
            {
                Console.WriteLine($"| {numeracija}. {kategorija}");
                numeracija++;
            }
            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine();
            string pranesimas = $"Pasirinkite Kategorija nuo 1 iki {klausimuKategorijos.Count} arba \"q\" jei norite grįžti į meniu";
            int kategorijosPasirinkimas = 0;
            kategorijosPasirinkimas = PasirinkimasArbaQ(pranesimas, klausimuKategorijos.Count);

            return kategorijosPasirinkimas;
        }

        private static void KlausimuKategorijosSwitch(int pasirinkimas)
        {
            switch (pasirinkimas)
            {
                case 1:
                    ZaistiMatematika("Matematika");
                    break;
                case 2:
                    ZaistiGeografija("Geografija");
                    break;
            }
        }

        private static int PasirinkimasArbaQ(string pranesimas, int atsakymuSkaicius) //Metodas, kuris žaidėjui leidžia pasirinkti ataskymą iš pateiktų galimų arba parašyti q raidę, kad išeitų iš meniu
        {
            int pasirinkimasInt = 0;
            string pasirinkimas = String.Empty;
            do
            {
                Console.WriteLine(pranesimas);
                pasirinkimas = Console.ReadLine();
                if (pasirinkimas == "q") //jeigu ivedama q raide issoka is while ciklo su break;
                {
                    pasirinkimasInt = 0; //Priskiriamas 0 kintamajam ir kadangi swtich case neturi su 0 užbaigiamas metodas ir meniu ciklas vėl iš naujo
                    break;
                }
            } while (!int.TryParse(pasirinkimas, out pasirinkimasInt) || pasirinkimasInt < 1 || pasirinkimasInt > atsakymuSkaicius); //kartosime kol vartotojas neives skaiciaus arba skaicius bus maziau uz 1 arba pasirinkimas bus didesnis uz pasirinkimu skaiciu iš klausimo atsakymų
            return pasirinkimasInt;
        }

        public static string[] SumaisytiKlausimusKeys(string[] klausimai)
        {
            Random.Shared.Shuffle(klausimai); //Sumaišo klausimų masyvą
            return klausimai;// metodas gražina sumaišytus klausimus
        }

        private static void ZaistiMatematika(string kategorija) //Matematikos žaidimo metodas, per parametrus perduodamas kategorijos pavadinimas
        {
            int klausimoSkaicius = 1;
            var matematikaKeysArray = SumaisytiKlausimusKeys(klausimaiMatematika.Keys.ToArray()); //Matematikos klausimų sumaišytas sąrašas
            StringBuilder stringBuilder = new StringBuilder(); //StringBuilder suformuoti tekstą su teisingais ir neteisingais atsakytais klausimais
            foreach (var key in matematikaKeysArray) // Matematikos klausimų ciklas
            {
                Console.Clear();
                PrisijungesVartotojas();
                Console.WriteLine($"Klausimas {klausimoSkaicius} / {matematikaKeysArray.Length}");
                Console.WriteLine();
                Console.WriteLine(key);
                foreach (var klausimas in klausimaiMatematika[key])
                {
                    Console.WriteLine(klausimas);//Atspausdina klausimų atsakymų pasirinkimus
                }
                string pranesimas = $"Įveskite atsakyma nuo 1 iki {klausimaiMatematika[key].Count} arba \"q\" jei norite grįžti į meniu";
                int klausimoAtsakymas = 0;

                klausimoAtsakymas = PasirinkimasArbaQ(pranesimas, klausimaiMatematika[key].Count);
                if (klausimoAtsakymas == 0)
                {
                    return;
                }

                bool arTeisingas = PatikrintiAtsakyma(kategorija, key, klausimoAtsakymas);
                stringBuilder.Append(klausimoSkaicius).Append(" ");
                if (arTeisingas)
                {
                    stringBuilder.Append("Teisingas");
                }
                else
                {
                    stringBuilder.Append("Neteisingas");
                }
                stringBuilder.Append(" ");
                klausimoSkaicius++;
            }
            Console.Clear();
            SpausdintiRezultatus(stringBuilder.ToString()); //Spausdinti kategorijos teisingai ir neteisingai atsakytus klausimus ir zaideju sarasa su rezultatais
        }

        private static void ZaistiGeografija(string kategorija)
        {
            int klausimoSkaicius = 1;
            var geografijaKeysArray = SumaisytiKlausimusKeys(klausimaiGeografijos.Keys.ToArray());
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var key in geografijaKeysArray)
            {
                Console.Clear();
                PrisijungesVartotojas();
                Console.WriteLine($"Klausimas {klausimoSkaicius} / {geografijaKeysArray.Length}");
                Console.WriteLine();
                Console.WriteLine(key);
                foreach (var item in klausimaiGeografijos[key])
                {
                    Console.WriteLine(item);
                }
                string pranesimas = $"Įveskite atsakyma nuo 1 iki {klausimaiGeografijos[key].Count} arba \"q\" jei norite grįžti į meniu";
                int klausimoAtsakymas = 0;

                klausimoAtsakymas = PasirinkimasArbaQ(pranesimas, klausimaiGeografijos[key].Count);
                if (klausimoAtsakymas == 0)
                {
                    return;
                }

                bool arTeisingas = PatikrintiAtsakyma(kategorija, key, klausimoAtsakymas);
                stringBuilder.Append(klausimoSkaicius).Append(" ");
                if (arTeisingas)
                {
                    stringBuilder.Append("Teisingas");
                }
                else
                {
                    stringBuilder.Append("Neteisingas");
                }
                stringBuilder.Append(" ");
                klausimoSkaicius++;
            }
            Console.Clear();
            SpausdintiRezultatus(stringBuilder.ToString());//Spausdinti kategorijos teisingai ir neteisingai atsakytus klausimus ir zaideju sarasa su rezultatais
        }

        private static void SpausdintiRezultatus(string atsakymai) //Metodas skirtas atspausdinti kategorijos zaidejo teisingai ir neteisingai atsakytus klausimus ir zaideju lentele su taskais
        {
            PrisijungesVartotojas();
            Console.WriteLine($"Klausimų rezultatai: {atsakymai}");
            var surikiuotiZaidejaiPagalTaskus = ZaidimoDalyviuRikiavimasPagalTaskus(zaidejaiIrTaskai);
            var top10SuZvaigzdutem = ZaidimoDalyviuTop10SuZvaigzdutem(surikiuotiZaidejaiPagalTaskus);
            AtvaizduotiZaidejus(top10SuZvaigzdutem);
            QIMeniu();
        }

        private static bool PatikrintiAtsakyma(string kategorija, string klausimas, int atsakymas)
        {
            bool arTeisignas;
            if (kategorija == "Matematika")
            {
                if (matematikosKlausimuAtsakymai[klausimas] == atsakymas)
                {
                    Console.WriteLine("Teisingai gaunate +1 tašką");
                    zaidejaiIrTaskai[prisijungesVartotojas] = zaidejaiIrTaskai[prisijungesVartotojas] + 1;
                    Console.WriteLine("Turimi taškai: " + zaidejaiIrTaskai[prisijungesVartotojas]); // is viso zaidejo taskai
                    arTeisignas = true;
                }
                else
                {
                    Console.WriteLine("Neteisingai");
                    Console.WriteLine("Turimi taškai: " + zaidejaiIrTaskai[prisijungesVartotojas]);
                    arTeisignas = false;
                }
                SekantisKlausimasPaspaudusMygtuka();
                return arTeisignas;
            }
            if (kategorija == "Geografija")
            {
                if (geografijosKlausimuAtsakymai[klausimas] == atsakymas)
                {
                    Console.WriteLine("Teisingai gaunate +1 tašką");
                    zaidejaiIrTaskai[prisijungesVartotojas] = zaidejaiIrTaskai[prisijungesVartotojas] + 1;
                    Console.WriteLine("Turimi taškai: " + zaidejaiIrTaskai[prisijungesVartotojas]);
                    arTeisignas = true;
                }
                else
                {
                    Console.WriteLine("Neteisingai");
                    Console.WriteLine("Turimi taškai: " + zaidejaiIrTaskai[prisijungesVartotojas]);
                    arTeisignas = false;
                }
                SekantisKlausimasPaspaudusMygtuka();
                return arTeisignas;
            }
            return false;
        }

        private static void SekantisKlausimasPaspaudusMygtuka()
        {
            Console.WriteLine("Paspauskite bet kurį mygtuką, kad pereitumėte prie sekančio klausimo");
            Console.ReadKey();
        }
    }
}



