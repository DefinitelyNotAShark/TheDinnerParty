using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class GabrielsInterview : Content
    {
        //remember to set location in police station
        private List<string> GabrielText = new List<string>();
        private List<string> choiceList = new List<string>();

        bool loopBreak = false;

        public void StartGabrielInterview()
        {
            Console.Title = "The Dinner Party : Interview";
            location = "Police Station";
            DrawScreen();
            GabrielDescription();
            DrawScreen();
            GabrielQuestions();

            while (!loopBreak)
            {
                DrawScreen();
                GabrielQuestions();
            }

        }

        private void GabrielDescription()
        {
            GabrielText.Add("Gabriel is a tall man with a bit of a slouch.");
            GabrielText.Add("He looks tired and his clothes are stained.");
            GabrielText.Add("He folds his spindly fingers in his lap");
            GabrielText.Add("Here's what you know about Gabriel: ");
            GabrielText.Add("- He's the author of a bestselling book.");
            GabrielText.Add("- He's Bruce's best and oldest friend.");
            GabrielText.Add("");
            GabrielText.Add("\"How can I help,\" he asks.");
            AddAllText();
            GabrielQuestions();
        }


        //need another function here just for choices again

        void GabrielQuestions()
        {

            choiceList.Add("\"Where were you from 10 to 11?\" (alibi)");

            choiceList.Add("Interview someone else");

            if (SearchCrimeScene.checkedTrashCan)
                choiceList.Add("\"(Clue)We found a script for a sequal to your book in the trash.\"");


            AddChoicesForInput();
            //sub questions
            DrawScreen();

            switch (playerInputToInt)
            {
                case 1://where were you from 10 to 11
                
                        GabrielText.Add("\"It's hard to remember much of what happened last night.\"");
                        GabrielText.Add("\"But after Bruce went to bed around 10, we all kind of split up.\"");
                        GabrielText.Add("\"I went to the lounge to see if I could catch the game.\"");
                        GabrielText.Add("\"I passed out a couple minutes of flipping through channels.\"");
                        GabrielText.Add("");
                        GabrielText.Add("\"When I woke up, the cops were here.\"");


                    if (Suspects.Killer == "Peter")
                    {
                        GabrielText.Add("\"Before I fell asleep, Peter came in and told me the game was over.\"");
                        GabrielText.Add("\"That's all I remember about last night.\"");
                    }
                    
                    if (Suspects.heardThatGabrielAsleepInLounge == false)
                    {
                        Suspects.heardThatGabrielAsleepInLounge = true;
                        Suspects.InterviewClueList.Add("Gabriel claims he was alseep in the lounge when the murder took place.");
                        ClueAlert("Larissa claims he was asleep in the lounge.");
                    }

                    AddAllText();
                    choiceList.Add("Got it.");
                    AddChoicesForInput();
                    break;

                case 3://found story script
                    GabrielText.Add("Gabriel looks surprised.");
                    GabrielText.Add("You can't tell if he's surprised about the script's existance or that you found it.");
                    GabrielText.Add("");

                    if (Suspects.Killer == "Gabriel")
                    {
                        GabrielText.Add("\"Oh? Is it any good?.\"");
                        GabrielText.Add("\"I knew he liked my story, but I never thought he'd write about it.\"");
                        GabrielText.Add("\"Bruce and I have a lot in common.\"");
                        GabrielText.Add("\"We're both writers.\"");
                        GabrielText.Add("");
                        GabrielText.Add("\"I think after my first book got so popular, he became a bit jealous of me.\"");
                        GabrielText.Add("\"It didn't break up our friendship though, and I'm extremely grateful for that.\"");
                        GabrielText.Add("\"Even when Bruce and Larissa got engaged, he still made time to spend weekends with me.\"");
                        GabrielText.Add("");
                        GabrielText.Add("\"Larissa didn't approve of us spending time together.\"");
                        GabrielText.Add("\"I tried many times to make friends with her.\"");
                        GabrielText.Add("\"She was always cold, and distant with me.\"");

                        if (Suspects.talkedToGabrielAboutLarissa == false)
                        {
                            Suspects.talkedToGabrielAboutLarissa = true;
                            Suspects.InterviewClueList.Add("Gabriel and Larissa don't get along.");
                            ClueAlert("Gabriel claims Larissa has never liked him.");
                        }

                    }

                    else
                    {
                        GabrielText.Add("Gabriel looks away.");
                        GabrielText.Add("\"Oh. I didn't know he was working on that\"");
                        GabrielText.Add("AUTHORS NOTE: this part of the story hasn't been written yet.");

                        AddAllText();
                        choiceList.Add("\"Whatever\"");
                        AddChoicesForInput();

                    }
                    break;

                case 2:
                    //go back to interview menu!
                    SuspectInterviewPage suspectInterviewPage = new SuspectInterviewPage();
                    suspectInterviewPage.StartInterview();
                    break;
            }
        }


        #region userInterface Functions
        void AddAllText()
        {
            AddContent(GabrielText);
            GabrielText.Clear();
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
