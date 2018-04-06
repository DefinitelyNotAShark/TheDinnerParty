using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class CrimeScenePage : Content
    {

        private List<string> CrimeText = new List<string>();
        private List<string> choiceList = new List<string>();
        private List<string> placestextList = new List<string>();

        private int cluesFound = 0;

        public void StartCrimeScene()
        {
            SetScreen();
            DetectiveBanterText1();
            DrawScreen();
            DetectiveBanterText2();
            DrawScreen();
            CheckChoiceForCrimeSceneOrME();

            Console.Read();
        }

        void SetScreen()
        {

            Console.Title = "The Dinner Party : Crime Scene";
            location = "Crime Scene";           
            Console.CursorVisible = true;
            DrawScreen();
            placestextList.Add("There's a large bed that's neatly made.");
            placestextList.Add("There's a desk next to the bed.");
            placestextList.Add("There's a trash can next to the desk full of papers.");
            placestextList.Add("You see some loose floorboards in the corner.");
            placestextList.Add("There's a closet on the far wall.");
        }

        #region TextFunctions
        void DetectiveBanterText1()
        {
            CrimeText.Add("You're at the scene of the crime.");
            CrimeText.Add("The body is still lying on the ground.");
            CrimeText.Add("There are a couple of cops hanging around.");
            CrimeText.Add("");
            CrimeText.Add("One of the officers grabs you by the arm.");
            CrimeText.Add("\"So you're that bigshot detective I've been hearing so much about, huh?\"");
            AddAllText();
            DetectiveBanterChoices1();
        }

        void DetectiveBanterText2()
        {
            switch (playerInputToInt)
            {
                case 1:
                    CrimeText.Add("\"Well it's good to know you're not getting a big head about it.\"");
                    CrimeText.Add("\"You know how detectives can get these days.\"");
                    CrimeText.Add("He coughs importantly, which is quite a difficult thing to do.");
                    CrimeText.Add("It requires a lot of pretentious facial work.");
                    break;
                case 2:
                    CrimeText.Add("The cop frowns, looking for a second like he's trying to swallow a lemon.");
                    CrimeText.Add("\"Well don't expect any special treatment because of it!\"");
                    CrimeText.Add("He mutters something about detectives having no respect for honest policework.");                   
                    break;
            }
            CrimeText.Add("");
            CrimeText.Add("\"Anyways,\" he says, \"We made sure not to move anything until you arrived.\"");
            CrimeText.Add("\"You should search the scene for any clues.\"");
            CrimeText.Add("\"Make a note of anything strange.\"");
            CrimeText.Add("");
            CrimeText.Add("\"Or, if you prefer,\" he jabs a thumb at a man with rubber gloves, \"you can talk to the medical examiner.\"");
            CrimeText.Add("\"He can tell you what we know about the murder and the body.\"");
            AddAllText();
            DetectiveBanterChoices2();
        }

        void CheckChoiceForCrimeSceneOrME()
        {
            switch (playerInputToInt)
            {
                case 1://search crime scene
                    CrimeSceneSearchText1();//give 5 options for clue searching
                    DrawScreen();
                    CrimeSceneSearchText2();
                    DrawScreen();
                    CrimeSceneSearchText2();
                    DrawScreen();
                    CrimeSceneSearchText2();
                    break;

                case 2://talk to medical examiner
                    MedicalExaminerText1();
                    break;
            }
        }


        void CrimeSceneSearchText1()
        {
            CrimeText.Add("At first glance, the room looks like an ordinary bedroom.");
            CrimeText.Add("");
            foreach (string a in placestextList)
            {
                CrimeText.Add(a);
            }
            AddAllText();
            CrimeSceneChoices1();
        }

        private void CrimeSceneSearchText2()
        {
            switch (playerInputToInt)
            {
                case 1://bed
                    CrimeText.Add("Nothing in the bed seems unusual.");
                    CrimeText.Add("There's a couple of unsuspicious old shirts under the bed.");
                    CrimeText.Add("Right next to the shirts, you spot a couple of pink fake nails.");
                    ClueAlert("Fake fingernails");
                    placestextList.Remove("There's a large bed that's neatly made.");
                    CheckIfYouHave2Clues();
                    AddAllText();
                    CrimeSceneChoices1();
                    cluesFound++;
                    break;
                case 2://desk
                    CrimeText.Add("The papers on the desk are mostly old bills and letters.");
                    CrimeText.Add("The first drawer contains a jumble of office supplies.");
                    CrimeText.Add("The second drawer has a half empty bottle of some strong smelling liquid.");
                    CrimeText.Add("One of the officers identifies it as a mix of opiates and alcohol.");
                    ClueAlert("Bottle of laudanum");
                    placestextList.Remove("There's a desk next to the bed.");
                    CheckIfYouHave2Clues();
                    AddAllText();
                    CrimeSceneChoices1();
                    cluesFound++;
                    break;
                case 3://trash can
                    CrimeText.Add("It doesn't take a lot of digging around in the trash can to find a bunch of");
                    CrimeText.Add("papers crumpled up at the bottom of the bin.");
                    CrimeText.Add("Straightening out the papers reveals a typed script that seems to be the first draft of a story.");
                    ClueAlert("Story script");
                    placestextList.Remove("There's a trash can next to the desk full of papers.");
                    CheckIfYouHave2Clues();
                    AddAllText();
                    CrimeSceneChoices1();
                    cluesFound++;
                    break;
                case 4://floor boards
                    CrimeText.Add("You pry up the loose floorboards, effectively ruining the manicure you got just a couple days ago.");
                    CrimeText.Add("Under the boards, you find an old police badge.");
                    CrimeText.Add("");
                    CrimeText.Add("You have the police dust it for prints and run the badge number.");
                    CrimeText.Add("Seems it belongs to the victim's uncle, a retired police officer, though the badge was never reported missing.");
                    CrimeText.Add("Strangely, the fingerprints match those of the victim's fiancee, Larissa.");
                    ClueAlert("Police badge with fingerprints");
                    placestextList.Remove("You see some loose floorboards in the corner.");
                    CheckIfYouHave2Clues();
                    AddAllText();
                    CrimeSceneChoices1();
                    cluesFound++;
                    break;
                case 5://closet
                    CrimeText.Add("Surprisingly enough, there's a bunch of clothes in the closet.");
                    CrimeText.Add("Upon closer inspection, ");
                    CrimeText.Add("");
                    CrimeText.Add("You have the police dust it for prints and run the badge number.");
                    CrimeText.Add("Seems it belongs to the victim's uncle, a retired police officer, though the badge was never reported missing.");
                    CrimeText.Add("Strangely, the fingerprints match those of the victim's fiancee, Larissa.");
                    ClueAlert("Police badge with fingerprints");
                    placestextList.Remove("There's a closet on the far wall.");
                    CheckIfYouHave2Clues();
                    AddAllText();
                    CrimeSceneChoices1();
                    cluesFound++;
                    break;
            }
        }

        void MedicalExaminerText1()
        {

        }
        #endregion

        #region Choices
        void DetectiveBanterChoices1()
        {
            choiceList.Add("Yes, sir");
            choiceList.Add("You could call me that.");
            AddChoicesForInput();
        }
        void DetectiveBanterChoices2()
        {
            choiceList.Add("Search the crime scene first");
            choiceList.Add("Talk to the medical examiner first");
            AddChoicesForInput();            
        }
        void CrimeSceneChoices1()
        {
            showNotes = true;
            if (placestextList.Contains("There's a large bed that's neatly made."))
                choiceList.Add("Search bed");

            if (placestextList.Contains("There's a desk next to the bed."))
                choiceList.Add("Search desk");

            if (placestextList.Contains("There's a trash can next to the desk full of papers."))
                choiceList.Add("Search trash can");

            if (placestextList.Contains("You see some loose floorboards in the corner."))
                choiceList.Add("Search floorboards");

            if (placestextList.Contains("There's a closet on the far wall."))
                choiceList.Add("Search closet");

            AddChoicesForInput();
        }
        void MedicalExaminerChoices1()
        {
            showNotes = true;
        }
        #endregion


        void AddAllText()
        {
            AddContent(CrimeText);
            CrimeText.Clear();
        }
        void AddChoicesForInput()
        {
            ShowChoices(choiceList);//display choices
            GetChoiceInput(choiceList.Count());//get input about choices
            choiceList.Clear();
        }

        private void CheckIfYouHave2Clues()
        {
            if (cluesFound >= 2)
            {
                CrimeText.Add("");
                CrimeText.Add("A nearby cop catches your eye and taps his watch.");
                CrimeText.Add("Seems you only have time to check one more place.");
            }
        }
    }
}
