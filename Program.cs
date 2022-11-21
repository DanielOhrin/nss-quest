using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge howOld = new Challenge("How old am I?", 1000, 50);
            Challenge howManyKids = new Challenge("How many children do I have?", 21, 25);
            Challenge whatYear = new Challenge("What year was I born?", DateTime.Now.Year - 1000, 50);

            List<Challenge> allChallenges = new List<Challenge> { twoPlusTwo, theAnswer, whatSecond, guessRandom, favoriteBeatle, howOld, howManyKids, whatYear };
            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible

            // Populated if user REPEATS a quest
            int initialAwesomeness = 0;


            //! Add option to repeat adventure
            bool isDone = false;
            while (!isDone)
            {
                Console.Clear();
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                // Make a new "Adventurer" object using the "Adventurer" class
                Robe theRobe = new Robe()
                {
                    Colors = new List<string> { "red", "blue", "purple", "green", "yellow", "white", "black" },
                    Length = 12
                };
                Hat theHat = new Hat()
                {
                    ShininessLevel = 7
                };

                Prize thePrize = new Prize();

                Console.Write("What is your name, noble adventurer? ");
                Adventurer theAdventurer = new Adventurer(Console.ReadLine(), theRobe, theHat);
                theAdventurer.Awesomeness += initialAwesomeness;
                Console.WriteLine(theAdventurer.GetDescription());

                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.

                // Get 5 random challenges
                Random r = new Random();
                List<byte> challengeIndexes = new List<byte>();

                while (challengeIndexes.Count < 5)
                {
                    byte randomByte = Convert.ToByte(r.Next(0, allChallenges.Count - 1));

                    if (challengeIndexes.IndexOf(randomByte) == -1)
                    {
                        challengeIndexes.Add(randomByte);
                    }
                }

                // Execute those challenges
                List<Challenge> challenges = new List<Challenge>();
                foreach (byte index in challengeIndexes)
                {
                    challenges.Add(allChallenges[index]);
                }

                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in challenges)
                {
                    Console.WriteLine();
                    initialAwesomeness += challenge.RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                Console.WriteLine(thePrize.ShowPrize(theAdventurer));

                Console.WriteLine();
                Console.Write("Would you like to partake in another adventure? (Y | N): ");
                isDone = Console.ReadLine().ToLower() == "y" ? false : true;
            }
        }
    }
}