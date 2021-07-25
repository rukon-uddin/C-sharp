using System;

namespace Hangman_game
{
    class Program
    {
        static void game(string[] arr)
        {
            Random rnd = new Random();
            int random_idx = rnd.Next(arr.Length);
            string challenge_word = arr[random_idx];
            int cw_length = challenge_word.Length;
            int life = 6;
            int life_copy = life;
            int correct = cw_length;
            char[] wrong_answer = new char[life];

            Console.WriteLine("Please guess the correct characters of the word to win.");
            Console.WriteLine("You have " + life + " life's.");

            char[] guesses = new char[cw_length];
            for (int i = 0; i < life; i++)
            {
                wrong_answer[i] = '-';
            }

            for (int i = 0; i < cw_length; i++)
            {
                guesses[i] = '-';
            }
            int track_WA = 0;

            while (true)
            {
                for (int i = 0; i < cw_length; i++)
                {
                    Console.Write(guesses[i] + " ");
                }

                Console.Write("\nPlease enter a character: ");

                char character = Convert.ToChar(Console.ReadLine());
                int flag = 0;

                for (int i = 0; i < cw_length; i++)
                {
                    if (character == challenge_word[i] && guesses[i] == '-')
                    {
                        flag = 1;
                        guesses[i] = character;
                        break;

                    }
                }
                if (flag == 1)
                {
                    correct--;
                }
                else
                {
                    int wa_flag = 0;

                    for (int i = 0; i < life_copy; i++)
                    {
                        if (wrong_answer[i] == character)
                        {
                            wa_flag = 1;
                            break;
                        }
                    }
                    if (wa_flag == 0)
                    {
                        wrong_answer[track_WA] = character;
                        track_WA++;
                        life--;
                        Console.WriteLine("\nYou have " + life + " life's left.");
                    }
                    else
                    {
                        Console.WriteLine("You have already selected " + character + ", please select different character");
                        Console.WriteLine("\nYou have " + life + " life's left.");
                    }


                }

                if (correct == 0 || life == 0)
                {
                    break;
                }


            }
            if (correct == 0)
            {
                Console.Write("Congratulation!! you have guessed the word correct. its -> ");
                for (int i = 0; i < cw_length; i++)
                {
                    Console.Write(guesses[i] + " ");
                }
                Console.WriteLine("\n\n");

            }
            else
            {
                Console.WriteLine("You are hanged the correct word is: " + challenge_word+ "\nplease try again.");
            }



            /*Console.WriteLine(challenge_word.Length);*/
        }

        static void Main(string[] args)
        {
            string[] flowers = { "jasmine", "daisy", "poppy", "rose", "alyssum", "violet", "iris", "ivy", "sunflower" };
            string[] animals = { "cat", "dog", "giraff", "tiger", "lion", "bear", "monkey", "gorilla", "stag", "kangaroo" };
            string[] country = { "oman", "bangladesh", "australia", "japan", "canada", "hungary", "brazil", "argentina", "france","germany" };
            string[] person = { "bilgates", "steve", "nelson", "teresa", "ghandi", "einstein", "newton", "Galileo", "darwin", "tesla" };
            string[] color = {"red", "indigo", "blue", "violet", "pink", "orrange", "green", "black", "yellow", "white" };

            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("------------------------");
            Console.WriteLine("1) Flowers");
            Console.WriteLine("2) Animals");
            Console.WriteLine("3) Country");
            Console.WriteLine("4) Person");
            Console.WriteLine("5) Color");
            Console.Write("\nPlease choose any one of the above category: ");

            int cat_selection = Convert.ToInt32(Console.ReadLine());
               
            if (cat_selection == 5)
            {
                game(color);
            }else if(cat_selection == 1)
            {
                game(flowers);
            }
            else if (cat_selection == 2)
            {
                game(animals);
            }
            else if (cat_selection == 3)
            {
                game(country);
            }
            else
            {
                game(person);
            }

        }
    }
}
