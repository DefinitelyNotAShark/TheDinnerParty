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
        public static string Killer;
        static int randomChooseKillerInt = 0;

        public static bool heardThatBruceWasDownstairsAt9 = false;//confirm with agatha

      //  public static bool heardThatBruceWasDownstairsAt9 = false;//confirm with agatha
      //  public static bool heardThatBruceWasDownstairsAt9 = false;//confirm with agatha
      //  public static bool heardThatBruceWasDownstairsAt9 = false;//confirm with agatha
      //  public static bool heardThatBruceWasDownstairsAt9 = false;//confirm with agatha

        public static void AddSuspectsWithInitialClues()//eliminates suspects whose clues were not found
        {
            if (SearchCrimeScene.checkedBed)
                SuspectList.Add("Irene");

            if (SearchCrimeScene.checkedCloset)
                SuspectList.Add("Agatha");

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
            randomChooseKillerInt = r.Next(0, 3);

            Killer = SuspectList[randomChooseKillerInt];
        }
    }
}
