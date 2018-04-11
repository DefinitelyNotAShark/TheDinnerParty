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
            IntroductionText1();
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
                    InterviewText.Add("You decide to speak to the party's host first.");
                    InterviewText.Add("It does make sense.");
                    InterviewText.Add("");
                    InterviewText.Add("The woman you are sitting with is in her late 60s.");
                    InterviewText.Add("She's got quite a lot of jewelry hanging from her neck and ears.");
                    InterviewText.Add("She stares off into the distance, refusing to make eye contact with you.");
                    InterviewText.Add("");
                    InterviewText.Add("What are you going to ask her about?");
                    break;
                case 2://peter
                    break;
                case 3://gabriel
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

        void AgathaChoices()
        {
            choiceList.Add("How do you know all your guests?");
            choiceList.Add("Where were you from 10:00 to 11:00?");
            choiceList.Add("");
        }

        void IreneChoices()
        {
            choiceList.Add("");
            choiceList.Add("Where were you from 10:00 to 11:00?");
            choiceList.Add("");
        }

        void GabrielChoices()
        {
            choiceList.Add("");
            choiceList.Add("Where were you from 10:00 to 11:00?");
            choiceList.Add("");
        }

        void LarissaChoices()
        {
            choiceList.Add("");
            choiceList.Add("Where were you from 10:00 to 11:00?");
            choiceList.Add("");
        }

        void PeterChoices()
        {
            choiceList.Add("");
            choiceList.Add("Where were you from 10:00 to 11:00?");
            choiceList.Add("");
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
