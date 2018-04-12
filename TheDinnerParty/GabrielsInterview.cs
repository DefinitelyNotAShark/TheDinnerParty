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
    

        public void StartGabrielInterview()
        {
            Console.Title = "The Dinner Party : Interview";
            location = "Police Station";
            DrawScreen();
            GabrielDescription();
            DrawScreen();
            GabrielDescriptionResponse();
            DrawScreen();
            GabrielQuestions();
        }

        private void GabrielDescription()
        {
            //text
            if (Suspects.Killer == "Gabriel")
            {
                GabrielText.Add("THIS DUDE TOTALLY MURDERY!");
            }

            else
            {
                GabrielText.Add("Yo THIS DUDE INNNO");
            }
            GabrielText.Add("Gabriel Garrison is a thin man with large eyes.");
            GabrielText.Add("When he sits down in the room for questioning, you notice how much he slouches.");
            GabrielText.Add("He folds his spindly fingers in his lap.");
            AddAllText();
            //choices
            choiceList.Add("\"How are you feeling, Mr.Garrison ?\"");
            choiceList.Add("\"I'm sorry about your loss, Mr Garrison.\"");
            AddChoicesForInput();
        }

        private void GabrielDescriptionResponse()
        {
            switch (playerInputToInt)
            {
                case 1:
                    if (Suspects.Killer == "Gabriel")
                    {
                        GabrielText.Add("\"I- Well, obviously I'm not doing too good!\"");
                        GabrielText.Add("\"It's been a long, confusing day.\"");
                        GabrielText.Add("\"I just want to help in any way I can.\"");
                    }
                    else
                    {
                        GabrielText.Add("\"My best friend was just murdered!\"");
                        GabrielText.Add("\"How do you think I'm feeling?\"");
                        GabrielText.Add("\"...\"");
                        GabrielText.Add("\"Sorry officer. I think I'm going to be sick.\"");
                        GabrielText.Add("\"Just ask your quesitons already!\"");
                    }
                    break;
                case 2:
                    GabrielText.Add("\"Thank you.\"");
                    GabrielText.Add("\"What do you need to know?\"");;
                    break;
            }
            AddAllText();
            //choices
            choiceList.Add("Questions about the murder");
            choiceList.Add("Questions about Gabriel's relationship with Bruce");
            AddChoicesForInput();
        }


        void GabrielQuestions()
        {
            switch (playerInputToInt)
            {
                case 1://questions about murder
                    GabrielText.Add("\"I want to know about what happened last night,\" you say.");
                    GabrielText.Add("");
                    GabrielText.Add("\"What a coincidence,\" he says. \"So do I\"");
                    AddAllText();
                    //choices
                    choiceList.Add("When was the last time you saw Bruce alive?");
                    choiceList.Add("Where were you from 10 to 11? (alibi)");
                    choiceList.Add("Did you notice anything out of place?");
                    AddChoicesForInput();
                    //sub questions
                        DrawScreen();
                    switch (playerInputToInt)
                    { 
                        case 1:
                            if (Suspects.Killer == "Gabriel")
                            {//killer text
                                GabrielText.Add("Gabriel rubs his face and pauses before answering.");
                                GabrielText.Add("");
                                GabrielText.Add("\"Ummm...I think I last saw him downstairs talking to his mother and Peter.\"");
                                GabrielText.Add("\"That was maybe 9, or 9:30.\"");
                                GabrielText.Add("\"I was drinking last night, so it's hard to remember.\"");
                            }
                            else
                            {//inno text
                                GabrielText.Add("Gabriel looks away for a second before answering.");
                                GabrielText.Add("");
                                GabrielText.Add("\"Ah, I saw him downstairs laughing with Agatha and Peter.\"");
                                GabrielText.Add("\"That was around 9:30 or maybe...9.\"");
                                GabrielText.Add("\"After that, he went to his room to bed early.\"");
                            }
                            AddAllText();

                            if (Suspects.heardThatBruceWasDownstairsAt9 == false)
                            {
                                Suspects.heardThatBruceWasDownstairsAt9 = true;
                                ClueAlert("Gabriel claims Bruce was downstairs with his mother and uncle");
                            }

                            AddChoicesForInput();
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }

                    break;
                case 2://questions about relationship with bruce
                    GabrielText.Add("\"I want to know about your relationship with the deceased,\" you say.");
                    GabrielText.Add("");
                    GabrielText.Add("\"I'm an open book,\" he says grimly.");
                    GabrielText.Add("\"What do you want to know?\"");
                    AddAllText();
                    //choices
                    choiceList.Add("");
                    choiceList.Add("");
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
