using NUnit.Framework;
using ZaidimasProtmusis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAssert = NUnit.Framework.CollectionAssert;
using Assert = NUnit.Framework.Assert;

namespace ZaidimasProtmusis.Tests
{
    [TestFixture()]
    public class ProgramTests
    {
        [Test()]
        public void PirmaRaideUpperPirmaIsMazosiosTest()//2
        {
            String name = "test";


            string actual = Program.PirmaRaideUpper(name);

            Assert.AreEqual("Test", actual);
        }

        [Test()]
        public void PirmaRaideUpperPirmaIsDidziosiosTest()//2
        {
            String name = "Test";


            string actual = Program.PirmaRaideUpper(name);

            Assert.AreEqual("Test", actual);
        }

        [Test()]
        public void NuoAtrosRaidesLowerSuDidziosiomTest()//2
        {
            String name = "tEST";

            string actual = Program.NuoAtrosRaidesLower(name);

            Assert.AreEqual("test", actual);
        }

        [Test()]
        public void NuoAtrosRaidesLowerVisosMazosiosTest()//2
        {
            String name = "test";

            string actual = Program.NuoAtrosRaidesLower(name);

            Assert.AreEqual("test", actual);
        }

        [Test()]
        public void ArLeistinosRaidesSkaiciaiTest()//2
        {
            String name = "10";


            bool isValid = Program.ArLeistinosRaides(name);

            Assert.IsFalse(isValid);
        }

        [Test()]
        public void ArLeistinosRaidesSimboliaiTest()//2
        {
            String name = "ar!";


            bool isValid = Program.ArLeistinosRaides(name);

            Assert.IsFalse(isValid);
        }

        [Test()]
        public void ZaidimoDalyviuTop10SuZvaigzdutem3ZaidejaiTest()//3 ir 5 punktai
        {

            Dictionary<string, int> zaidejaiIrTaskai = new Dictionary<string, int>
        {
            {"Petras Petraitis", 5},
            {"Jonas Jonaitis", 10},
            {"Antanas Antanaitis", 3}

        };

            List<string> expected = new List<string> { "1 Jonas Jonaitis* 10", "2 Petras Petraitis** 5", "3 Antanas Antanaitis*** 3" };
            var surikuoti = Program.ZaidimoDalyviuRikiavimasPagalTaskus(zaidejaiIrTaskai);
            List<string> actual = Program.ZaidimoDalyviuTop10SuZvaigzdutem(surikuoti);

            CollectionAssert.AreEqual(expected, actual);


        }

        [Test()]
        public void ZaidimoDalyviuTop10SuZvaigzdutem10ZaidejuTest()//3 ir 5 punktai
        {

            Dictionary<string, int> zaidejaiIrTaskai = new Dictionary<string, int>
        {
            {"Petras Petraitis", 3},
            {"Jonas Jonaitis", 6},
            {"Antanas Antanaitis", 7},
            {"Mindaugas Arnaitis", 11},
            {"Gerda Arnaitis", 17},
            {"Jurgita Arnaitis", 20},
            {"Janina Arnaitis", 15},
            {"Aurimas Arnaitis", 18},
            {"Migle Arnaitis", 22},
            {"Kamile Arnaitis", 21}

        };
            List<string> expected = new List<string> { "1 Migle Arnaitis* 22", "2 Kamile Arnaitis** 21", "3 Jurgita Arnaitis*** 20", "4 Aurimas Arnaitis 18", "5 Gerda Arnaitis 17", "6 Janina Arnaitis 15", "7 Mindaugas Arnaitis 11", "8 Antanas Antanaitis 7", "9 Jonas Jonaitis 6", "10 Petras Petraitis 3" };
            var surikuoti = Program.ZaidimoDalyviuRikiavimasPagalTaskus(zaidejaiIrTaskai);
            List<string> actual = Program.ZaidimoDalyviuTop10SuZvaigzdutem(surikuoti);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test()]
        public void ZaidimoDalyviuTop10SuZvaigzdutem11ZaidejuTest()//3 ir 5 punktai
        {
            Dictionary<string, int> zaidejaiIrTaskai = new Dictionary<string, int>
        {
            {"Petras Petraitis", 3},
            {"Jonas Jonaitis", 6},
            {"Antanas Antanaitis", 7},
            {"Mindaugas Arnaitis", 11},
            {"Gerda Arnaitis", 17},
            {"Jurgita Arnaitis", 20},
            {"Janina Arnaitis", 15},
            {"Aurimas Arnaitis", 18},
            {"Migle Arnaitis", 22},
            {"Kamile Arnaitis", 21},
            {"Petras Jonaitis", 2 }

        };
            List<string> expected = new List<string> { "1 Migle Arnaitis* 22", "2 Kamile Arnaitis** 21", "3 Jurgita Arnaitis*** 20", "4 Aurimas Arnaitis 18", "5 Gerda Arnaitis 17", "6 Janina Arnaitis 15", "7 Mindaugas Arnaitis 11", "8 Antanas Antanaitis 7", "9 Jonas Jonaitis 6", "10 Petras Petraitis 3", "Petras Jonaitis 2" };
            var surikuoti = Program.ZaidimoDalyviuRikiavimasPagalTaskus(zaidejaiIrTaskai);// surikiuojam
            List<string> actual = Program.ZaidimoDalyviuTop10SuZvaigzdutem(surikuoti);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test()]
        public void ZaidimoDalyviuRikiavimasPagalTaskus2ZaidejaiSkirtingiTaskaiTest()//4
        {
            Dictionary<string, int> zaidejaiIrTaskai = new Dictionary<string, int>
        {
            {"Petras Petraitis", 5},
            {"Jonas Jonaitis", 10},

        };
            Dictionary<string, int> expected = new Dictionary<string, int>
        {
            {"Jonas Jonaitis", 10},
            {"Petras Petraitis", 5},

        };
            var actual = Program.ZaidimoDalyviuRikiavimasPagalTaskus(zaidejaiIrTaskai);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test()]
        public void ZaidimoDalyviuRikiavimasPagalTaskus3ZaidejaiVienodiTaskaiTest()//4
        {
            Dictionary<string, int> zaidejaiIrTaskai = new Dictionary<string, int>
        {
            {"Petras Petraitis", 3},
            {"Jonas Jonaitis", 3},
            {"Antanas Antanaitis", 3},


        };
            Dictionary<string, int> expected = new Dictionary<string, int>
        {
            {"Petras Petraitis", 3},
            {"Jonas Jonaitis", 3},
            {"Antanas Antanaitis", 3},


        };

            var actual = Program.ZaidimoDalyviuRikiavimasPagalTaskus(zaidejaiIrTaskai);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test()]
        public void ZaidimoDalyviuRikiavimasPagalTaskus15ZaidejuVienodiTaskaiTest()//4
        {
            Dictionary<string, int> zaidejaiIrTaskai = new Dictionary<string, int>
        {
            {"Jonas Jonaitis", 1},
            {"Antanas Antanaitis", 1},
            {"Mindaugas Arnaitis", 1},
            {"Gerda Arnaitis", 1},
            {"Jurgita Arnaitis", 1},
            {"Janina Arnaitis", 1},
            {"Aurimas Arnaitis", 1},
            {"Migle Arnaitis", 1},
            {"Kamile Arnaitis", 1},
            {"Raimondas Arnaitis", 1},
            {"Toma Arnaitis", 1},
            {"Tomas Arnaitis", 1},
            {"Gabija Arnaitis", 1},
            {"Robertas Arnaitis", 1},
            {"Rasa Arnaitis", 1},
            {"Petras Petraitis", 2},

        };
            Dictionary<string, int> expected = new Dictionary<string, int>
        {
            {"Petras Petraitis", 2},
            {"Jonas Jonaitis", 1},
            {"Antanas Antanaitis", 1},
            {"Mindaugas Arnaitis", 1},
            {"Gerda Arnaitis", 1},
            {"Jurgita Arnaitis", 1},
            {"Janina Arnaitis", 1},
            {"Aurimas Arnaitis", 1},
            {"Migle Arnaitis", 1},
            {"Kamile Arnaitis", 1},
            {"Raimondas Arnaitis", 1},
            {"Toma Arnaitis", 1},
            {"Tomas Arnaitis", 1},
            {"Gabija Arnaitis", 1},
            {"Robertas Arnaitis", 1},
            {"Rasa Arnaitis", 1},

        };
            var actual = Program.ZaidimoDalyviuRikiavimasPagalTaskus(zaidejaiIrTaskai);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test()]
        public void ZaidimoDalyviuRikiavimasPagalTaskus15ZaidejuSkirtingiTaskaiTest()//4
        {
            Dictionary<string, int> zaidejaiIrTaskai = new Dictionary<string, int>
        {
            {"Petras Petraitis", 15},//
            {"Jonas Jonaitis", 22},//
            {"Antanas Antanaitis", 33},//
            {"Mindaugas Arnaitis", 21},//
            {"Gerda Arnaitis", 24},//
            {"Jurgita Arnaitis", 27},//
            {"Janina Arnaitis", 14},//
            {"Aurimas Arnaitis", 13},
            {"Migle Arnaitis", 28},//
            {"Kamile Arnaitis", 29},//
            {"Raimondas Arnaitis", 30},//
            {"Toma Arnaitis", 25},//
            {"Tomas Arnaitis", 40},//
            {"Gabija Arnaitis", 45},//
            {"Robertas Arnaitis", 2},//

        };

            Dictionary<string, int> expected = new Dictionary<string, int>
        {
            {"Gabija Arnaitis", 45},
            {"Tomas Arnaitis", 40},
            {"Antanas Antanaitis", 33},
            {"Raimondas Arnaitis", 30},
            {"Kamile Arnaitis", 29},
            {"Migle Arnaitis", 28},
            {"Jurgita Arnaitis", 27},
            {"Toma Arnaitis", 25},
            {"Gerda Arnaitis", 24},
            {"Jonas Jonaitis", 22},
            {"Mindaugas Arnaitis", 21},
            {"Petras Petraitis", 15},
            {"Janina Arnaitis", 14},
            {"Aurimas Arnaitis", 13},
            {"Robertas Arnaitis", 2},

        };

            var actual = Program.ZaidimoDalyviuRikiavimasPagalTaskus(zaidejaiIrTaskai);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test()]
        public void SumaisytiKlausimaiTest()//6
        {
            Dictionary<string, List<string>> klausimaiMatematika = new Dictionary<string, List<String>>
        {
            {"Kiek yra 5 + 5", new List<string>{"1. 9", "2. 10", "3. 15", "4. 8",} },
            {"Kiek yra 10 + 5", new List<string>{"1. 15", "2. 20", "3. 10", "4. 25",} },
            {"Kiek yra 10 + 10", new List<string>{"1. 30", "2. 21", "3. 25", "4. 20",} },
            {"Kiek yra 15 + 3", new List<string>{"1. 20", "2. 18", "3. 19", "4. 17",} },
            {"Kiek yra 20 + 5", new List<string>{"1. 20", "2. 23", "3. 25", "4. 30",} },
        };

            var klausimai = Program.SumaisytiKlausimusKeys(klausimaiMatematika.Keys.ToArray()); //random
            bool arUnikalus = klausimai.Distinct().Count() == klausimai.Count(); //distinct grazina tik unikalias reiksmes, count patikrina ar saraso ilgis islieka toks pats
            Assert.IsTrue(arUnikalus);
        }

    }
}