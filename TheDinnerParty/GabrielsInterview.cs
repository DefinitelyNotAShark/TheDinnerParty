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
        bool scriptStoryTold = false;

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
                AddQuestionTypes();
                GabrielQuestions();
            }

        }

        private void GabrielDescription()
        {
            GabrielText.Add("Gabriel Garrison is a thin man with large eyes.");
            GabrielText.Add("When he sits down in the room for questioning, you notice how much he slouches.");
            GabrielText.Add("He folds his spindly fingers in his lap.");
            GabrielText.Add("\"What do you want to know?\" He asks.");
            AddAllText();
            AddQuestionTypes();
        }

        void AddQuestionTypes()
        {
            choiceList.Add("Questions about the murder");
            choiceList.Add("Questions about Gabriel's relationship with Bruce");
            choiceList.Add("Interview someone else");
            AddChoicesForInput();
            DrawScreen();
        }

        //need another function here just for choices again

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
                    AddChoicesForInput();
                    //sub questions
                    DrawScreen();
                    switch (playerInputToInt)
                    {
                        case 1://last time you saw bruce alive
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
                                GabrielText.Add("\"Ah, I saw him downstairs laughing with Ms. Grestin and Peter.\"");
                                GabrielText.Add("\"That was around 9:30 or maybe...9.\"");
                                GabrielText.Add("\"After that, he went to his room to bed early.\"");
                            }
                            AddAllText();

                            if (Suspects.heardThatBruceWasDownstairsAt9 == false)
                            {
                                Suspects.heardThatBruceWasDownstairsAt9 = true;
                                Suspects.InterviewClueList.Add("Gabriel claims Bruce was downstairs with his mom and uncle");
                                ClueAlert("Gabriel claims Bruce was downstairs with his mother and uncle");
                            }

                            choiceList.Add("Got it.");
                            AddChoicesForInput();
                            break;
                        case 2://where were you at time of the murder?
                            if (Suspects.Killer == "Gabriel")
                            {//killer text
                                GabrielText.Add("\"We were having a pretty good time last night.\"");
                                GabrielText.Add("\"You know...before...all of this happened.\"");
                                GabrielText.Add("");
                                GabrielText.Add("\"Peter got his good brandy out, and we all had a bit much to drink.\"");
                                GabrielText.Add("\"I don't actually drink very often, and if you didn't notice,\" he gestures to his skinny body.");
                                GabrielText.Add("\"I'm a bit of a lightweight. I'm afraid I didn't know when to stop.\"");
                                GabrielText.Add("\"I fell asleep in the lounge. Maybe around 10.\"");

                                if (Suspects.heardThatGabrielAsleepInLounge == false)
                                {
                                    Suspects.heardThatGabrielAsleepInLounge = true;
                                    Suspects.InterviewClueList.Add("Gabriel claims that he was asleep in the lounge when the murder took place.");
                                    ClueAlert("Gabriel claims he was asleep in the lounge at the time of the murder.");
                                }
                            }
                            else
                            {//inno text
                                GabrielText.Add("\"After we were done chatting, we all kind of seperated.\"");
                                GabrielText.Add("\"I didn't really keep track of where everyone else went.\"");
                                GabrielText.Add("");
                                GabrielText.Add("\"I had been looking forward to watching the match that was on that night.\"");
                                GabrielText.Add("\"So I was in the lounge the whole time watching the game.\"");
                                GabrielText.Add("\"It was on until about 11.\"");
                                if (Suspects.heardThatGabrielWasWatchingTheGame == false)
                                {
                                    Suspects.heardThatGabrielWasWatchingTheGame = true;
                                    Suspects.InterviewClueList.Add("Gabriel claims that he was watching the game at the time of the murder.");
                                    ClueAlert("Gabriel claims he was watching a game in the lounge.");
                                }
                            }                          
                            AddAllText();
                            //choices
                            choiceList.Add("Is there anyone that can confirm that you were there?");
                            choiceList.Add("So none of the guests saw you past 10?");//both choices link to the same dialogue                           
                            AddChoicesForInput();
                            DrawScreen();
                            //response text
                            GabrielText.Add("\"Fraid not,\" he shrugs.");
                            GabrielText.Add("\"I feel a bit useless, not knowing where everyone else was.\"");
                            GabrielText.Add("\"I can't imagine anyone here wanting to hurt Bruce.\"");
                            if (Suspects.Killer != "Gabriel")
                            {//killer text
                                GabrielText.Add("");
                                GabrielText.Add("\"I can tell you that the Giants won the game.\"");
                                GabrielText.Add("\"But I suppose that I could have just looked it up later,\"");
                                GabrielText.Add("\"So I guess I'm not that much help.\"");
                                AddAllText();
                                choiceList.Add("That does help. Thank you.");
                                AddChoicesForInput();
                            }
                            else
                            {
                                AddAllText();
                                choiceList.Add("Okay.");
                                AddChoicesForInput();
                            }
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
                    choiceList.Add("\"I hear you guys were old friends?\"");

                    if(SearchCrimeScene.checkedTrashCan && scriptStoryTold ==false)
                    choiceList.Add("CLUE: (story script) \"Why would he have a sequal to your story in his trash?\"");

                    AddChoicesForInput();
                    DrawScreen();
                    switch (playerInputToInt)
                    {
                        case 1://you were friends?
                            GabrielText.Add("\"We've known each other a pretty long time.\"");
                            GabrielText.Add("\"We went to the same high school.\"");
                            GabrielText.Add("\"We bonded over our love for writing and football and camping.\"");
                            GabrielText.Add("\"We just had a lot in common.\"");
                            break;

                        case 2://story script???
                                GabrielText.Add("\"He did?\"");
                                GabrielText.Add("Gabriel looks surprised.");
                                GabrielText.Add("");
                                GabrielText.Add("\"I... was it any good?\"");

                            if (Suspects.Killer == "Gabriel")
                            {
                                GabrielText.Add("\"That doesn't really matter now, I guess.\"");
                                GabrielText.Add("\"You know, I did get a call from him about a week ago.\"");
                                GabrielText.Add("");
                                GabrielText.Add("\"We're both writers, you see.\"");
                                GabrielText.Add("\"Bruce was never as successful as me, but he was still pretty good.\"");
                                GabrielText.Add("\"He could never work up the nerve to ask anyone to read his writing.\"");
                                GabrielText.Add("\"Thats probably why it was in the trash.\"");
                                GabrielText.Add("");
                                GabrielText.Add("\"I guess he had some ideas about a sequal for my book.\"");
                                GabrielText.Add("\"Is there a chance I'd get to read it?\"");
                                GabrielText.Add("\"Maybe I could get it published in his honor or something.\"");
                            }
                            else
                            {
                                GabrielText.Add("\"Bruce...would probably want me to come clean about that...\"");
                                AddAllText();
                                //choices
                                choiceList.Add("Come clean about what?");
                                AddChoicesForInput();
                                DrawScreen();
                                GabrielText.Add("Gabriel leans back in his chair, and looks at the ground.");
                                GabrielText.Add("");
                                GabrielText.Add("\"We were writers, Bruce and I. He was always better than me.\"");
                                GabrielText.Add("\"When we were in college, Bruce showed me a story he had written.\"");
                                GabrielText.Add("\"It was good. Like really good.\"");
                                GabrielText.Add("\"I tried to convince him to publish it, but he was too self-concious.\"");
                                GabrielText.Add("\"He didn't think anyone would read it.\"");
                                GabrielText.Add("");
                                GabrielText.Add("\"But I sent it to a publisher. Just to get a professional opinion, you see.\"");
                                GabrielText.Add("\"The publisher loved it. Wanted to get it made into a book. An actual book!\"");
                                GabrielText.Add("\"But...the thing is...\"");
                                GabrielText.Add("\"I published it under my name.\"");
                                GabrielText.Add("\"I didn't try to steal the story from him! I just knew he didn't want his name out in the open.\"");
                                GabrielText.Add("\"I had no idea it would be so popular.\"");
                                AddAllText();
                                //choices
                                choiceList.Add("I see...");
                                AddChoicesForInput();
                                DrawScreen();
                                GabrielText.Add("Gabriel fidgets in his seat.");
                                GabrielText.Add("\"Bruce was not happy when he found out.\"");
                                GabrielText.Add("\"Even though everyone loved his book, he didn't like that I'd gone behind his back.\"");
                                GabrielText.Add("\"He didn't even want any of the money I'd made from selling the book.\"");
                                GabrielText.Add("");
                                GabrielText.Add("\"But...after a while...I guess he got tired of holding a grudge.\"");
                                GabrielText.Add("\"I had no idea he was working on a sequal.\"");
                            }
                            break;
                    }
                    AddAllText();
                    choiceList.Add("Thanks for telling me that.");
                    AddChoicesForInput();
                    break;
                case 3:
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
