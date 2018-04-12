using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class AgathasInterview : Content
    {
        //remember to set location in police station
        private List<string> AgathaText = new List<string>();
        private List<string> choiceList = new List<string>();

        public void StartAgathaInterview()
        {
            Console.Title = "The Dinner Party : Interview";
            location = "Police Station";
            DrawScreen();

        }

        void AgathaIntroText()
        {
            AgathaText.Add("You decide to speak to the party's host first.");
            AgathaText.Add("It does make sense.");
            AgathaText.Add("");
            AgathaText.Add("The woman you are sitting with is in her late 60s.");
            AgathaText.Add("She's got quite a lot of jewelry hanging from her neck and ears.");
            AgathaText.Add("She stares off into the distance, refusing to make eye contact with you.");
            AgathaText.Add("");
            AgathaText.Add("What are you going to ask her about?");
        }

        void AgathaQuestionGenres()
        {

        }







        #region userInterface Functions
        void AddAllText()
        {
            AddContent(AgathaText);
            AgathaText.Clear();
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
