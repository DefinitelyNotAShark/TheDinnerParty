using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class TalkToME : Content
    {
        private List<string> CrimeText = new List<string>();
        private List<string> choiceList = new List<string>();

        public static bool talkedToTheME;

        public void Start()
        {
            DrawScreen();
            MedicalExaminerText1();
            DrawScreen();
            MedicalExaminerText2();

            if (SearchCrimeScene.checkedTheCrimeScene == false)
            {
                SearchCrimeScene searchCrimeScene = new SearchCrimeScene();
                searchCrimeScene.Start();
            }

            else if (SearchCrimeScene.checkedTheCrimeScene == true)
            {
                SuspectInterviewPage suspectInterviewPage = new SuspectInterviewPage();
                suspectInterviewPage.StartInterview();
            }
        }


        void MedicalExaminerText1()
        {
            //text
            CrimeText.Add("You decide to talk to the medical examiner.");
            CrimeText.Add("He's able to tell you a couple facts about the victim.");
            CrimeText.Add("");
            CrimeText.Add("He tells you that the victim was Bruce Grestin.");
            CrimeText.Add("");
            CrimeText.Add("Bruce was killed in his room between 10 and 11 last night.");
            CrimeText.Add("He was killed during a dinner party his mother was hosting.");
            AddAllText();
            //choices
            showNotes = true;
            choiceList.Add("Is there anything else important I should know?");
            AddChoicesForInput();

        }

        void MedicalExaminerText2()
        {
            //text
            CrimeText.Add("\"Glad you asked!\"");
            CrimeText.Add("");
            CrimeText.Add("You also find out that he was strangled from behind.");
            CrimeText.Add("The rope that he was strangled with hasn't been found yet.");
            CrimeText.Add("");
            CrimeText.Add("\"Based on the position he died in,");
            CrimeText.Add("It was likely someone he trusted who killed him.\"");
            AddAllText();
            //choices
            choiceList.Add("See if you can find out anything else...");
            AddChoicesForInput();

            talkedToTheME = true;
            DrawScreen();

            if (SearchCrimeScene.checkedTheCrimeScene == false)
            {
                CrimeText.Add("He shakes his head.");
                CrimeText.Add("That's all I got for ya.");
                CrimeText.Add("");
                CrimeText.Add("You decide that you should probably look for clues now.");
                AddAllText();
                choiceList.Add("Go check the crime scene");
                AddChoicesForInput();
            }

            else if (SearchCrimeScene.checkedTheCrimeScene == true)
            {
                CrimeText.Add("He shakes his head.");
                CrimeText.Add("That's all I got for ya.");
                CrimeText.Add("");
                CrimeText.Add("You decide that you should probably go interview the suspects");
                AddAllText();
                choiceList.Add("Interview suspects");
                AddChoicesForInput();
            }
        }

        //interface helpers
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

    }
}
