using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class Suspects
    {
        public static List<string> SuspectList = new List<string>();
        public static List<string> InterviewClueList = new List<string>();

        public static string Killer;
        static int randomChooseKillerInt = 0;

        public static bool heardThatBruceWasDownstairsAt9 = false;//confirm with agatha

        public static bool heardThatGabrielAsleepInLounge = false;
        public static bool heardThatGabrielWasWatchingTheGame = false;
        public static bool heardThatLarissaWasIntTheKitchen = false;//confirm with agatha
        public static bool heardThatLarissaMadeHerMoneyAsAnAppraiser = false;
        public static bool heardThatLarissaWasGoingToMoveToParis = false;

        public static void AddSuspectsWithInitialClues()//eliminates suspects whose clues were not found
        {
            if (SearchCrimeScene.checkedDesk)
                SuspectList.Add("Peter");

            if (SearchCrimeScene.checkedFloorboards)
                SuspectList.Add("Larissa");

            if (SearchCrimeScene.checkedTrashCan)
                SuspectList.Add("Gabriel");

            ChooseRandomKiller();
        }

        private static void ChooseRandomKiller()
        {
            Random r = new Random();
            if (SuspectList.Count == 2)
            {
                randomChooseKillerInt = r.Next(0, 2);
            }

            Killer = SuspectList[randomChooseKillerInt];
        }
    }
}
