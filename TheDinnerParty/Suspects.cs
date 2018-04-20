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

        public static bool heardThatGabrielAsleepInLounge = false;
        public static bool heardThatPeterWasInTheDiningRoom = false;
        public static bool heardThatLarissaWasIntTheKitchen = false;//confirm with agatha

        public static bool heardThatLarissaWasGoingToMoveToParis = false;

        public static bool talkedToGabrielAboutLarissa = false;
        public static bool talkedToPeterAboutLarissa = false;
        public static bool gabrielDirectsAttentionToLarissa = false;
        public static bool talkedToLarissaAboutPeterButLarissasTheKiller = false;
   

        public static void AddSuspectsWithInitialClues()//eliminates suspects whose clues were not found
        {
            SuspectList.Add("Larissa");
            SuspectList.Add("Peter");
            ChooseRandomKiller();
        }

        private static void ChooseRandomKiller()
        {
            Random r = new Random();
            randomChooseKillerInt = r.Next(0, 2);
            Killer = SuspectList[randomChooseKillerInt];
        }
    }
}
