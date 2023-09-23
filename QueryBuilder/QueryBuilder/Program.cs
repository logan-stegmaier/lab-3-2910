using System.Security.Cryptography;

namespace QueryBuilder
{
    public class Program
    {
        static string root = FileRoot.Root;
        static string dbPath = root + "\\data\\data.db";

        static void Main(string[] args)
        {
            // driver 
            // * visual confirmation that all records are cleared (DeleteAll)
            // * write all objects back into the database (Create)
            // * write single object to database using Create

            QueryBuilder query = new QueryBuilder(dbPath); // establishes connection w/ SQL - QueryBuilder active

            Menu.MainMenu();

            char main = Console.ReadLine().ToLower()[0];

            while (main == 'a' || main == 'b')
            {
                if (main == 'a') // SEQUENCE FOR POKEMON
                {
                    Pokemon pokemon = new Pokemon();

                    Menu.ErasedRecords();

                    query.DeleteAll(pokemon); // deletes all pokemon records cus it knows its pokemon object

                    Console.Write("All data entries for pokemon have been ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("erased.");
                    Console.ResetColor();
                    Console.Write(" Press any key to continue to load the CSV.\n");

                    Console.ReadKey();

                    List<Pokemon> pokemonFromFile = new List<Pokemon>(); // borrowing from code example
                    
                    var filePath = root + "\\data\\AllPokemon.csv"; // changed file path name stuff
                    using (var sr = new StreamReader(filePath))
                    {
                        while (!sr.EndOfStream) // creating all the pokemon instances based on csv
                        {
                            var line = sr.ReadLine();
                            var data = line.Split(',');

                            var p = new Pokemon()
                            {
                                DexNumber = Convert.ToInt32(data[0]),
                                Name = data[1],
                                Form = data[2],
                                Type1 = data[3],
                                Type2 = data[4],
                                Total = Convert.ToInt32(data[5]),
                                HP = Convert.ToInt32(data[6]),
                                Attack = Convert.ToInt32(data[7]),
                                Defense = Convert.ToInt32(data[8]),
                                SpecialAttack = Convert.ToInt32(data[9]),
                                SpecialDefense = Convert.ToInt32(data[10]),
                                Speed = Convert.ToInt32(data[11]),
                                Generation = Convert.ToInt32(data[12]),
                            };

                            pokemonFromFile.Add(p);
                        }
                    }

                    foreach (var p in pokemonFromFile)
                    {
                        query.Create(p); // for each item, add this to the database in the pokemon table
                    }

                    Menu.LoadCSV(pokemon); //grabbing pokemon obj
                    Console.WriteLine($"All {pokemonFromFile.Count()} pokemon have successfully been added to the database.\n"); // shows count
                    Console.Write("Press any key to continue to "); Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("write "); Console.ResetColor();
                    Console.Write("your pokemon to the database\n");

                    Console.ReadKey();

                    Menu.LoadOwn(); 

                    
                    Console.WriteLine("What is the dex number for your pokemon?");
                    int dexnum = Int32.Parse(Console.ReadLine()); // some user input stuff

                    while (dexnum == null) // a quick check
                    {
                        Console.WriteLine("What is the dex number for your pokemon?");
                        dexnum = Int32.Parse(Console.ReadLine());
                    }

                    pokemon.DexNumber = dexnum;

                    Console.WriteLine("\nWhat is the name of your Pokemon?");

                    string pokename = Console.ReadLine();

                    pokemon.Name = pokename;

                    // didn't want to make user inputs for all of these lol 

                    pokemon.Form = "";

                    pokemon.Type1 = "Poison";
                    pokemon.Type2 = "Fairy";
                    pokemon.Total = 200;
                    pokemon.HP = 50;
                    pokemon.Attack = 100;
                    pokemon.Generation = 1; 

                    query.Create(pokemon); // using create method to make ONE pokemon 

                    Console.WriteLine($"\nPokemon {pokename} Successfully Added to the Database.\n");

                    Console.WriteLine("\nType b to continue to banned game or anything else to terminate");
                    main = Console.ReadLine().ToLower()[0]; 

                }
                else if (main == 'b') // SEQUENCE FOR BANNED
                {

                    BannedGame bannedGame = new BannedGame();

                    Menu.ErasedRecords();

                    query.DeleteAll(bannedGame);

                    Console.Write("All data entries for Banned Games have been ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("erased.");
                    Console.ResetColor();
                    Console.Write(" Press any key to continue to load the CSV.\n");
                    Console.ReadKey();

                    List<BannedGame> bannedGameFromFile = new List<BannedGame>(); // same as for pokemon

                    var filePath = root + "\\data\\BannedGames.csv";
                    using (var sr = new StreamReader(filePath))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            var data = line.Split(',');

                            var b = new BannedGame()
                            {
                                Title = data[0],
                                Series = data[1], 
                                Country = data[2], 
                                Details = data[3]
                            };

                            bannedGameFromFile.Add(b);
                        }
                    }

                    foreach (var b in bannedGameFromFile) // same as for pokemon
                    {
                        query.Create(b);
                    }

                    Menu.LoadCSV(bannedGame); //grabbing bannedGame obj name
                    Console.WriteLine($"All {bannedGameFromFile.Count} banned games have successfully been added to the database.\n");
                    Console.Write("Press any key to continue to "); Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("write "); Console.ResetColor();
                    Console.Write("your banned game to the database\n");

                    Console.ReadKey();

                    Menu.LoadOwn();


                    Console.WriteLine("What is the title of your game?");
                    string title = Console.ReadLine(); 


                    bannedGame.Title = title;

                    Console.WriteLine("\nWhat is the series of your game?");
                    string series = Console.ReadLine();

                    bannedGame.Series = series;

                    Console.WriteLine("What country is your game from?");
                    string country = Console.ReadLine();

                    bannedGame.Country = country;

                    Console.WriteLine("Why was your game banned?");
                    string details = Console.ReadLine();

                    bannedGame.Details = details; 


                    query.Create(bannedGame); // same as for pokemon

                    Console.WriteLine($"\nBanned Game: {title} Successfully Added to the Database.\n");

                    Console.WriteLine("\nType a to continue to pokemon or type any other letter to terminate");
                    main = Console.ReadLine().ToLower()[0];


                }

            }
                if (main != 'a' || main != 'b') // if anything is put in besides a or b, program will end
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ending Program. Thank you.");
                    Console.ResetColor();
                }

        }

    }
}