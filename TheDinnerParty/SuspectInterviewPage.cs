using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class SuspectInterviewPage : Content
    {

        private List<string> InterviewText = new List<string>();
        private List<string> choiceList = new List<string>();

        static bool alreadySeenIntroduction = false;

        public void StartInterview()
        {
            Console.Title = "The Dinner Party : Suspect Interviews";
            location = "House";
            DrawScreen();
            Suspects.AddSuspectsWithInitialClues();//this is how the interface knows who the killer is
            IntroductionText1();
            IntroductionText2();
        }

        void DebugShowKiller()
        {
            InterviewText.Add("The killer is: " + Suspects.Killer);
        }

        #region Texts
        void IntroductionText1()
        {
            if (alreadySeenIntroduction)
            {
                InterviewText.Add("Who do you want to bring in for questioning?");
                InterviewText.Add("Here is what you know:");
                InterviewText.Add("");

                foreach (string i in Suspects.InterviewClueList)
                {
                    InterviewText.Add(i);
                }
            }
            else
            {
                InterviewText.Add("A cop ushers you into the living room in the house.");
                InterviewText.Add("All the suspects are sitting on a long couch, avoiding eye contact.");
                InterviewText.Add("You can bring anyone to the police station for questioning.");
                InterviewText.Add("");
                InterviewText.Add("There are 3 people. You have a list with their names on it.");
                InterviewText.Add("It should be noted that everyone except the mother is a suspect.");
                InterviewText.Add("The other officers have already cleared her, and she is unable to speak to anyone right now.");
                InterviewText.Add("");
                InterviewText.Add("Who are you going to talk to first?");

                DebugShowKiller();


                alreadySeenIntroduction = true;
            }
            AddAllText();
            IntroductionChoices1();
        }

        void IntroductionText2()
        {
            switch (playerInputToInt)
            {
                case 1://peter
                    PetersInterview petersInterview = new PetersInterview();
                    petersInterview.StartPeterInterview();
                    break;
                case 2://gabriel
                    GabrielsInterview gabrielsInterview = new GabrielsInterview();
                    gabrielsInterview.StartGabrielInterview();
                    break;
                case 3://larissa
                    LarissasInterview larissasInterview = new LarissasInterview();
                    larissasInterview.StartLarissaInterview();
                    break;
            }
        }

        #endregion



        #region choices
        void IntroductionChoices1()
        {
            choiceList.Add("Peter Zangara (uncle)");
            choiceList.Add("Gabriel Garrison (old friend)");
            choiceList.Add("Larissa McCarthy (fiancee)");
            AddChoicesForInput();
        }       
        #endregion

        #region userInterface Functions
        void AddAllText()
        {
            AddContent(InterviewText);
            InterviewText.Clear();
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
