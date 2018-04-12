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

        public void StartInterview()
        {
            Console.Title = "The Dinner Party : Suspect Interviews";
            location = "House";
            DrawScreen();
            Suspects.AddSuspectsWithInitialClues();//this is how the interface knows who the killer is
            IntroductionText1();
            IntroductionText2();
        }

        #region Texts
        void IntroductionText1()
        {
            InterviewText.Add("\"A cop ushers you into the living room in the house.\"");
            InterviewText.Add("\"All the suspects are sitting on a long couch, avoiding eye contact.\"");
            InterviewText.Add("");
            InterviewText.Add("There are 5 people. You have a list with their names on it.");
            InterviewText.Add("Who are you going to talk to first?");
            AddAllText();
            IntroductionChoices1();
        }

        void IntroductionText2()
        {
            switch (playerInputToInt)
            {
                case 1://agatha
                    
                    break;
                case 2://peter
                    break;
                case 3://gabriel
                    GabrielsInterview gabrielsInterview = new GabrielsInterview();
                    gabrielsInterview.StartGabrielInterview();
                    break;
                case 4://irene
                    break;
                case 5://larissa
                    break;
            }
        }

        #endregion



        #region choices
        void IntroductionChoices1()
        {
            choiceList.Add("Agatha Grestin (mother)");
            choiceList.Add("Peter Zangara (uncle)");
            choiceList.Add("Gabriel Garrison (old friend)");
            choiceList.Add("Irene Payne (mother's friend)");
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
