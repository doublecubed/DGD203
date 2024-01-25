using DGD203_2;
using System;

public class Combat
{
    #region REFERENCES

    private Game _theGame;
    public Player Player { get; private set; }

    public List<Enemy> Enemies { get; private set; }

	private Location _location;

    #endregion

    #region VARIABLES

    private const int maxNumberOfEnemies = 3;

    private bool _isOngoing;


    private string _playerInput;

    #endregion

    #region CONSTRUCTOR

    public Combat(Game game, Location location)
	{
		_theGame = game;
		Player = game.Player;

		_isOngoing = false;

		_location = location;

		Random rand = new Random();
		int numberOfEnemies = rand.Next(1, maxNumberOfEnemies + 1);

		Enemies = new List<Enemy>();
		for (int i = 0; i < numberOfEnemies; i++)
		{
			Enemy nextEnemy = new Goblin();
			Enemies.Add(nextEnemy);
		}
	}

    #endregion


    #region METHODS

    #region Initialization & Loop

    public void StartCombat()
	{
		_isOngoing = true;

		while (_isOngoing)
		{
			GetInput();
			ProcessInput();

			if (!_isOngoing) break;

			ProcessEnemyActions();
			CheckPlayerPulse();
		}
	}

	private void GetInput()
	{
		Console.WriteLine($"There are {Enemies.Count} goblin(s) in front of you. What do you want to do?");
		for (int i = 0; i < Enemies.Count; i++)
		{
			Console.WriteLine($"[{i + 1}]: Attack goblin {i + 1}");
		}
		Console.WriteLine($"[{Enemies.Count + 1}]: Try to flee (50% chance)");
		_playerInput = Console.ReadLine();
	}

	private void ProcessInput()
	{
        if (_playerInput == "" || _playerInput == null)
        {
            Console.WriteLine("You can't just stand still, they will attack you!");
            return;
        }

		ProcessChoice(_playerInput);
    }


	private void ProcessChoice(string choice)
	{
		if (Int32.TryParse(choice, out int value)) // When the command is an integer
		{
			if (value > Enemies.Count + 1)
			{
				Console.WriteLine("That is not a valid choice");
			} else
			{
				if (value == Enemies.Count + 1) 
				{
					TryToFlee();
				} else
				{
					HitEnemy(value);
				}
			}
		} else // When the command is not an integer
		{
			Console.WriteLine("You don't make any sense. Quit babbling, they are going to kill you!");
		}
	}

	private void CheckPlayerPulse()
	{
		if (Player.Health <= 0)
		{
			EndCombat();
		}
	}

    private void EndCombat()
    {
        _isOngoing = false;
		_location.CombatHappened();
    }

    #endregion

    #region Combat

    private void TryToFlee()
	{
		Random rand = new Random();
		double randomNumber = rand.NextDouble();

		if (randomNumber >= 0.5f)
		{
			Console.WriteLine("You flee! You are a coward maybe, but a live one!");
			EndCombat();
		} else
		{
			Console.WriteLine("You cannot flee because a goblin is in your way");
		}
	}

    private void HitEnemy(int index)
	{
		int enemyIndex = index - 1;
		int playerDamage = Player.Damage();

		Enemies[enemyIndex].TakeDamage(playerDamage);
		Console.WriteLine($"The goblin takes {playerDamage} damage!");

		if (Enemies[enemyIndex].Health <= 0)
		{
			Console.WriteLine("This goblin is toast!");
			Enemies.RemoveAt(enemyIndex);
		}
	}

	private void ProcessEnemyActions()
	{
		if (Enemies.Count == 0)
		{
			Console.WriteLine("You defeated all your enemies!");
			EndCombat();
		}

		for (int i = 0; i < Enemies.Count; i++)
		{
			int goblinDamage = Enemies[i].Damage;
			Player.TakeDamage(goblinDamage);
		}
	}



	#endregion

	#endregion

}
