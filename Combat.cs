using DGD203_2;
using System;

public class Combat
{
	private Game _theGame;

	private const int maxNumberOfEnemies = 3;

	public List<Enemy> Enemies {  get; private set; }
	public Player Player { get; private set; }

    public Combat(Game game)
	{
		_theGame = game;
		Player = game.Player;

		Random rand = new Random();
		int numberOfEnemies = rand.Next(1, maxNumberOfEnemies + 1);

		Enemies = new List<Enemy>();
		for (int i = 0; i < numberOfEnemies; i++)
		{
			Enemy nextEnemy = new Goblin();
			Enemies.Add(nextEnemy);
		}
	}
}
