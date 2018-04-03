using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class IntroPage
    { 
        Interface myInterface = new Interface();
        Content myContent = new Content();
        Input myInput = new Input();
        CrimeScenePage myCrimeScene = new CrimeScenePage();

        private List<string> IntroText = new List<string>();
        private List<string> choiceList = new List<string>();

        private bool replay = false;

        public void StartIntro()
        {
            SetScreen();
            AddText1();
            myInterface.DrawScreen();
            AddText2();
            myInterface.DrawScreen();
            AddText3();

            while(replay)
            {
                myInterface.DrawScreen();
                myInput.playerInputToInt = 1;//set it to instruction choice
                AddText3();
            }

            myCrimeScene.StartCrimeScene();
        }

        private void AddText3()
        {
            Console.SetCursorPosition(1, 28);
            switch (myInput.playerInputToInt)
            {                
                case 1://answer the phone
                    IntroText.Add("It's your supervisor.");
                    IntroText.Add("\"Hello detective. I know it's been a while.\"");
                    IntroText.Add("\"Look. There's been a murder. It's a tricky one too.\"");
                    IntroText.Add("\"You're the only homicide detective we can afford for the job.\"");
                    IntroText.Add("\"No offense.\"");
                    IntroText.Add("\"I know you're not familiar with our procedure, so here's how it's gonna go down...\"");
                    GetEnterInput();
                    IntroText.Add("\"The murder happened at a dinner party hosted by a woman called Agatha Grestin\"");
                    IntroText.Add("\"This case is important because of the recent controversy surrounding her son and his fiancee.\"");
                    IntroText.Add("\"You see...Her son was murdered by one of her guests last night.\"");
                    IntroText.Add("\"We need to solve this case before the press finds out about this.\"");
                    IntroText.Add("");
                    IntroText.Add("\"The first thing you need to do is visit the scene of the crime.\"");
                    IntroText.Add("\"Once there, you can check the scene for clues.\"");
                    IntroText.Add("\"You should also talk to forensics about how he died.\"");
                    GetEnterInput();
                    IntroText.Add("\"We have local officers keeping all the suspects at the scene.\"");
                    IntroText.Add("\"I suggest that you interview all of them.\"");
                    IntroText.Add("\"Find out if they have an alibi.\"");
                    IntroText.Add("\"It's also good to know their relationship with the victim\"");
                    IntroText.Add("");
                    IntroText.Add("\"You should be keeping a page of notes.\"");
                    IntroText.Add("\"Be sure to check them for inconsistancies.\"");
                    IntroText.Add("\"Catching someone in a lie can force them to speak truthfully.\"");
                    IntroText.Add("\"As I understand, this family keeps a lot of secrets...\"");
                    GetEnterInput();
                    IntroText.Add("\"You might feel the need to bring a suspect to the station for questioning.\"");
                    IntroText.Add("\"Especially if you think someone has been lying to you.\"");
                    IntroText.Add("");
                    IntroText.Add("\"Once you think you know what happened, give me a call.\"");
                    IntroText.Add("\"Just make sure you have enough information to rightfully accuse someone.\"");
                    IntroText.Add("\"You're the only one who can do it!\"");
                    IntroText.Add("\"Good Luck!\"");
                    IntroText.Add("");
                    IntroText.Add("\"Did you understand everything I told you?\"");
                    IntroText.Add("");
                    myContent.AddContent(IntroText);
                    IntroText.Clear();
                    AddChoices3();                
                    break;
                case 2://ignore call
                    IntroText.Add("You decide not to answer the phone.");
                    IntroText.Add("A few moments later, your supervisor texts you some information and a location.");
                    IntroText.Add("");
                    myContent.AddContent(IntroText);
                    IntroText.Clear();
                    AddChoices4();
                    break;
            }            
        }

        private void AddText2()
        {
            switch (myInput.playerInputToInt)//check what you chose and change response based on it...
            {
                case 1://coffee
                    IntroText.Add("Coffee, huh? I thought so.");
                    IntroText.Add("You're gripping a mug of freshly brewed coffee.");
                    break;
                case 2://tea
                    IntroText.Add("Oh, so you're a tea person. Alright then.");
                    IntroText.Add("You've got a glass of homemade tea in one hand.");
                    break;
                case 3://soda
                    IntroText.Add("Ah, the calming taste of soda.");
                    IntroText.Add("You have a large fast food cup in your hands.");
                    break;
                case 4://hot chocolate
                    IntroText.Add("Ohhh! That's so cozy!");
                    IntroText.Add("You've got a mug of hot cocoa with marshmallows.");
                    break;
                case 5://other
                    IntroText.Add("What? You didn't like any of my options?");
                    IntroText.Add("Suit yourself.");
                    IntroText.Add("You're sipping your weird drink that I'm clearly not cool enough to know about.");
                    break;
            }
            IntroText.Add("");
            IntroText.Add("Just as you start to settle down, the phone begins to ring...");
            myContent.AddContent(IntroText);
            IntroText.Clear();
            AddChoices2();
        }

        private void AddChoices2()
        {
            choiceList.Add("Answer the phone");
            choiceList.Add("Let it ring (skip the tutorial/introduction)");
            myContent.ShowChoices(choiceList);//display choices
            myInput.GetChoiceInput(choiceList.Count());//get input about choices
            choiceList.Clear();
        }

        private void SetScreen()
        {
            Console.Title = "The Dinner Party : Intro";
            myContent.showNotes = false;
            Console.CursorVisible = true;
            myInterface.DrawScreen();
        }

        private void AddText1()
        {
            IntroText.Add("You are in your home, reclining in your most comfy chair.");
            IntroText.Add("In one hand is your favorite book. In your other hand, your favorite drink.");
            IntroText.Add("");
            IntroText.Add("What is your favorite drink, by the way?");
            IntroText.Add("");
            IntroText.Add("(type a number that matches your choice and then hit enter)");
            myContent.AddContent(IntroText);
            IntroText.Clear();
            AddChoices1();
        }

        private void AddChoices1()
        {
            choiceList.Add("Coffee");
            choiceList.Add("Tea");
            choiceList.Add("Soda");
            choiceList.Add("Hot chocolate");
            choiceList.Add("Some other drink");
            myContent.ShowChoices(choiceList);//display choices
            myInput.GetChoiceInput(choiceList.Count());//get input about choices
            choiceList.Clear();
        }

        void GetEnterInput()
        {
            IntroText.Add("");
            IntroText.Add("(press enter to continue)");
            Console.CursorVisible = false;
            myContent.AddContent(IntroText);
            Console.ReadLine();
            IntroText.Clear();
            myInterface.DrawScreen();
            Console.CursorVisible = true;
        }

        void AddChoices3()
        {
            choiceList.Add("Got it! (head to the crime scene)");
            choiceList.Add("Can you please repeat what you just said word for word?");
            myContent.ShowChoices(choiceList);//display choices
            myInput.GetChoiceInput(choiceList.Count());//get input about choices

            if (myInput.playerInputToInt == 2)
                replay = true;
            else
                replay = false;

            choiceList.Clear();
        }

        void AddChoices4()
        {
            choiceList.Add("Go to crime scene");
            myContent.ShowChoices(choiceList);
            myInput.GetChoiceInput(choiceList.Count());
            choiceList.Clear();
        }
    }
}
