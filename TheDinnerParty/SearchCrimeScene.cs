using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class SearchCrimeScene : Content
    {
        private List<string> CrimeText = new List<string>();
        private List<string> choiceList = new List<string>();
        private List<string> placestextList = new List<string>();

        private int cluesFound = 0;

        public static bool checkedBed;
        public static bool checkedDesk;
        public static bool checkedTrashCan;
        public static bool checkedFloorboards;
        public static bool checkedCloset;

        public static bool checkedTheCrimeScene;

        public void Start()
        {
            DrawScreen();
            Console.Title = "The Dinner Party : Search Crime Scene";
            location = "Crime Scene";

            CrimeSceneDescription();//only use once

            while (cluesFound < 3)
            {               
                choiceList.Add("Search bed");//add all choices regardless of what player has already seen
                choiceList.Add("Search desk");
                choiceList.Add("Search trash can");
                choiceList.Add("Search floorboards");
                choiceList.Add("Search closet");

                AddChoicesForInput();
                AllSearchDescriptions();
            }

            checkedTheCrimeScene = true;

            if (TalkToME.talkedToTheME == true)
            {
                IntroToInterview();
                DrawScreen();
                SuspectInterviewPage suspectInterviewPage = new SuspectInterviewPage();
                suspectInterviewPage.StartInterview();
            }

            else if (TalkToME.talkedToTheME == false)
            {
                CrimeText.Add("");
                CrimeText.Add("");
                CrimeText.Add("");
                CrimeText.Add("");
                CrimeText.Add("");
                CrimeText.Add("");
                CrimeText.Add("");
                CrimeText.Add("");

                CrimeText.Add("\"Time's up.\" says one of the cops, steering you toward the Medical Examiner.");
                CrimeText.Add("\"He hasn't got all day, you know.\"");
                AddAllText();

                choiceList.Add("Talk to the Medical Examiner.");
                AddChoicesForInput();

                TalkToME talkToME = new TalkToME();
                talkToME.Start();
            }
        }
    
        void CrimeSceneDescription()
        {
            CrimeText.Add("At first glance, the room looks like an ordinary bedroom.");
            CrimeText.Add("");
            CrimeText.Add("There's a very ordinary bed.");
            CrimeText.Add("There's a desk with papers on it.");
            CrimeText.Add("There's a trash can filled to the brim with papers.");
            CrimeText.Add("There are a couple of floorboards that look a bit loose.");
            CrimeText.Add("There's a closet in the corner.");
            AddAllText();           
        }

        private void AllSearchDescriptions()
        {
            DrawScreen();

            switch (playerInputToInt)
            {
                case 1://bed
                    if (checkedBed)
                        AlreadyCheckedAlert();

                    else
                    {
                        CrimeText.Add("Nothing in the bed seems unusual.");
                        CrimeText.Add("There's a couple of unsuspicious old shirts under the bed.");
                        CrimeText.Add("Right next to the shirts, you spot a couple of pink fake nails.");
                        ClueAlert("Fake fingernails");
                        checkedBed = true;

                        if (cluesFound == 1)
                        {
                            CrimeText.Add("");
                            CrimeText.Add("A nearby cop catches your eye and taps his watch.");
                            CrimeText.Add("Seems you only have time to check one more place.");
                        }
                        cluesFound++;
                        AddAllText();
                    }
                    break;
                case 2://desk
                    if (checkedDesk)
                        AlreadyCheckedAlert();

                    else
                    {
                        CrimeText.Add("The papers on the desk are mostly old bills and letters.");
                        CrimeText.Add("The first drawer contains a jumble of office supplies.");
                        CrimeText.Add("The second drawer has a half empty bottle of some strong smelling liquid.");
                        CrimeText.Add("One of the officers identifies it as a mix of opiates and alcohol.");
                        ClueAlert("Bottle of laudanum");
                        checkedDesk = true;

                        if (cluesFound == 1)
                        {
                            CrimeText.Add("");
                            CrimeText.Add("A nearby cop catches your eye and taps his watch.");
                            CrimeText.Add("Seems you only have time to check one more place.");
                        }
                        cluesFound++;
                        AddAllText();
                    }
                    break;
                case 3://trash can
                    if (checkedTrashCan)
                        AlreadyCheckedAlert();

                    else
                    {
                        CrimeText.Add("It doesn't take a lot of digging around in the trash can to find a bunch of");
                        CrimeText.Add("papers crumpled up at the bottom of the bin.");
                        CrimeText.Add("Straightening out the papers reveals a typed script that seems to be the first draft of a story.");
                        CrimeText.Add("");
                        CrimeText.Add("You think you recognize the title.");
                        CrimeText.Add("One of the officers identifies it as a sequal to a bestseller book.");
                        CrimeText.Add("The first book was written by Gabriel Garrison, one of the guests.");
                        ClueAlert("Story script");
                        checkedTrashCan = true;

                        if (cluesFound == 1)
                        {
                            CrimeText.Add("");
                            CrimeText.Add("A nearby cop catches your eye and taps his watch.");
                            CrimeText.Add("Seems you only have time to check one more place.");
                        }
                        cluesFound++;
                        AddAllText();
                    }
                    break;
                case 4://floor boards
                    if (checkedFloorboards)
                        AlreadyCheckedAlert();

                    else
                    {
                        CrimeText.Add("You pry up the loose floorboards, effectively ruining the manicure you got just a couple days ago.");
                        CrimeText.Add("Under the boards, you find an old police badge.");
                        CrimeText.Add("");
                        CrimeText.Add("You have the police dust it for prints and run the badge number.");
                        CrimeText.Add("Seems it belongs to the victim's uncle, a retired police officer, though the badge was never reported missing.");
                        CrimeText.Add("Strangely, the fingerprints match those of the victim's fiancee, Larissa.");
                        ClueAlert("Police badge with fingerprints");
                        checkedFloorboards = true;

                        if (cluesFound == 1)
                        {
                            CrimeText.Add("");
                            CrimeText.Add("A nearby cop catches your eye and taps his watch.");
                            CrimeText.Add("Seems you only have time to check one more place.");
                        }

                        cluesFound++;
                        AddAllText();
                    }
                    break;
                case 5://closet
                    if (checkedCloset)
                        AlreadyCheckedAlert();

                    else
                    {
                        CrimeText.Add("Surprisingly enough, there's a bunch of clothes in the closet.");
                        CrimeText.Add("You push aside the clothes to find...");
                        CrimeText.Add("");
                        CrimeText.Add("More clothes. How surprising.");
                        CrimeText.Add("Seems like there's nothing of note in the closet.");
                        checkedCloset = true;

                        if (cluesFound == 1)
                        {
                            CrimeText.Add("");
                            CrimeText.Add("A nearby cop catches your eye and taps his watch.");
                            CrimeText.Add("Seems you only have time to check one more place.");
                        }
                        cluesFound++;
                        AddAllText();
                    }
                    break;
            }//end switch
        }
        private void IntroToInterview()
        {
            DrawScreen();
            CrimeText.Add("\"Sir,\" says one of the cops,");
            CrimeText.Add("\"I think it's time to interview the suspects...\"");
            CrimeText.Add("He shows you to the door, and you feel as if you've overstayed your welcome.");
            AddAllText();
            choiceList.Add("Go interview suspects");
            AddChoicesForInput();
        }


        private void AlreadyCheckedAlert()
        {
            CrimeText.Add("You've already checked that place out, remember?");
            CrimeText.Add("Choose another place.");
            AddAllText();
        }

        #region userInterface Functions
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
        #endregion
    }
}
