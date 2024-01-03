using System.IO;
using System.Numerics;

namespace DGD203_2
{
    internal class Game
    {
        #region VARIABLES

        #region Game Constants

        private const int _defaultMapWidth = 5;
        private const int _defaultMapHeight = 5;

        #endregion

        #region Game Variables

        #region Player Variables

        private string _playerName;
        private int _playerAge;

        #endregion

        #region World Variables

        private Location[] _locations;

        #endregion

        private bool _gameRunning;
        private Map _gameMap;
        private string _playerInput;

        #endregion

        #endregion

        #region METHODS

        #region Initialization

        public void StartGame(Game gameInstanceReference)
        {
            // Generate game environment
            CreateNewMap();

            // Load game
            LoadGame();

            // Deal with player generation
            if (_playerName == null)
            {
                CreatePlayer();
            }

            InitializeGameConditions();

            _gameRunning = true;
            StartGameLoop();
            
        }

        private void CreateNewMap()
        {
            _gameMap = new Map(_defaultMapWidth, _defaultMapHeight);
        }


        private void CreatePlayer()
        {
            GetPlayerName();
            GetPlayerAge();
        }

        private void GetPlayerName()
        {
            Console.WriteLine("Welcome to the most awesomest RPG game of all time!");
            Console.WriteLine("Would you be kind enough to provide us with your name?");
            _playerName = Console.ReadLine();

            if (_playerName == "Johnny")
            {
                Console.WriteLine($"Here comes {_playerName}!!");
            }
            else if (_playerName == "")
            {
                Console.WriteLine("Player name not entered, giving the name John Doe");
                _playerName = "John Doe";
            }
            else
            {
                Console.WriteLine($"Pleased to meet you {_playerName}, we will have a great adventure together!");
            }
        }

        private void GetPlayerAge()
        {
            Console.WriteLine($"Okay then, what is your age {_playerName}?");

            string playerAgeInString = Console.ReadLine();

            if (Int32.TryParse(playerAgeInString, out int x))
            {
                _playerAge = x;
                Console.WriteLine($"Wow, what a wonderful age, {_playerAge} is");
            }
            else
            {
                _playerAge = 2;
                Console.WriteLine("Ha ha ha, so mature. I think it's appropriate that I record your age as 2");
            }
        }

        private void InitializeGameConditions()
        {
            _gameMap.CheckForLocation(_gameMap.GetCoordinates());
        }


        #endregion

        #region Game Loop

        private void StartGameLoop()
        {
            while (_gameRunning)
            {
                GetInput();
                ProcessInput();
            }
        }

        private void GetInput()
        {
            _playerInput = Console.ReadLine();
        }

        private void ProcessInput()
        {
            if (_playerInput == "" || _playerInput == null)
            {
                Console.WriteLine("Give me a command!");
                return;
            }

            switch (_playerInput)
            {
                case ("N"):
                    _gameMap.MovePlayer(0, 1);
                    break;
                case "S":
                    _gameMap.MovePlayer(0, -1);
                    break;
                case "E":
                    _gameMap.MovePlayer(1, 0);
                    break;
                case "W":
                    _gameMap.MovePlayer(-1, 0);
                    break;
                case "exit":
                    Console.WriteLine("We hope you enjoyed our game!");
                    _gameRunning = false;
                    break;
                case "save":
                    SaveGame();
                    Console.WriteLine("Game saved");
                    break;
                case "load":
                    LoadGame();
                    Console.WriteLine("Game loaded");
                    break;
                case "help":
                    Console.WriteLine(HelpMessage());
                    break;
                case "where":
                    _gameMap.CheckForLocation(_gameMap.GetCoordinates());
                    break;
                case "clear":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Command not recognized. Please type 'help' for a list of available commands");
                    break;
            }
        }

        #endregion

        #region Save Management

        private void LoadGame()
        {
            string path = SaveFilePath();

            if (!File.Exists(path)) return;
            
            // Reading the file contents
            string[] saveContent = File.ReadAllLines(path);
            _playerName = saveContent[0];
            _playerAge = Int32.Parse(saveContent[1]);

            List<int> coords = saveContent[2].Split(',').Select(int.Parse).ToList();
            Vector2 coordArray = new Vector2(coords[0], coords[1]);

            _gameMap.SetCoordinates(coordArray);

        }

        private void SaveGame()
        {
            // Player Coordinates
            string xCoord = _gameMap.GetCoordinates()[0].ToString();
            string yCoord = _gameMap.GetCoordinates()[1].ToString();
            string playerCoords = $"{xCoord},{yCoord}";

            string saveContent = $"{_playerName}{Environment.NewLine}{_playerAge}{Environment.NewLine}{playerCoords}";

            string path = SaveFilePath();

            File.WriteAllText(path, saveContent);
        }

        private string SaveFilePath()
        {
            // Get the save file path
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string path = projectDirectory + @"\save.txt";

            return path;
        }

        #endregion

        #region Miscellaneous

        private string HelpMessage()
        {
            return @"Here are the current commands:
N: go north
S: go south
W: go west
E: go east
load: Load saved game
save: save current game
exit: exit the game";

        }

        #endregion

        #endregion
    }
}