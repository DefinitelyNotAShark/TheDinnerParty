using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class CrimeScenePage
    {
        Content myContent = new Content();
        Input myInput = new Input();
        Interface myInterface = new Interface();

        private List<string> CrimeText = new List<string>();
        private List<string> choiceList = new List<string>();

        public void StartCrimeScene()
        {
            SetScreen();
            DetectiveBanterText1();
            myInterface.DrawScreen();
            DetectiveBanterText2();
            myInterface.DrawScreen();

            Console.Read();
        }

        void SetScreen()
        {

            Console.Title = "The Dinner Party : Crime Scene";
            myInterface.location = "Crime Scene";           
            Console.CursorVisible = true;
            myInterface.DrawScreen();

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
            switch (myInput.playerInputToInt)
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

        void CrimeSceneSearchText1()
        {
            CrimeText.Add("At first glance, the room looks like an ordinary bedroom.");
            CrimeText.Add("")lllllll
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
            myContent.showNotes = true;

        }
        void MedicalExaminerChoices1()
        {
            myContent.showNotes = true;
        }
        #endregion


        void AddAllText()
        {
            myContent.AddContent(CrimeText);
            CrimeText.Clear();
        }
        void AddChoicesForInput()
        {
            myContent.ShowChoices(choiceList);//display choices
            myInput.GetChoiceInput(choiceList.Count());//get input about choices
            choiceList.Clear();
        }

    }
}
