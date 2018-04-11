using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class Suspects
    {
        public static bool AgathaDidIt = false;
        public static bool IreneDidIt = false;
        public static bool GabrielDidIt = false;
        public static bool LarissaDidIt = false;
        public static bool PeterDidIt = false;

        public static void EliminateSuspectsWithInitialClues()//eliminates suspects whose clues were not found
        {
            if (SearchCrimeScene.checkedBed)
                IreneDidIt = true;

            if (SearchCrimeScene.checkedCloset)
                AgathaDidIt = true;

            if (SearchCrimeScene.checkedDesk)
                PeterDidIt = true;

            if (SearchCrimeScene.checkedFloorboards)
                LarissaDidIt = true;

            if (SearchCrimeScene.checkedTrashCan)
                GabrielDidIt = true;
        }

        public static void EliminateSuspectsWhoseCluesWerentFollowedUpOn()
        {

        }
    }
}
