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

        private bool _gameRunning;
        private Map _gameMap;
        private string _playerInput;

        #endregion

        #endregion

        #region METHODS

        #region Initialization

        public void StartGame(Game gameInstanceReference)
        {
            _gameRunning = true;

            CreateNewMap();
            CreatePlayer();
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
                default:
                    Console.WriteLine("We can currently only accept map movement commands. Please provide a direction, indicated by its initial letter (N, S, W or E");
                    break;
            }


        }

        #endregion

        #endregion
    }
}