using System;

public class Player
{
	private const int playerMaxHealth = 100;

	public string Name { get; private set; }
	public int Health { get; private set; }

    public Player(string name)
	{
		Name = name;
		Health = playerMaxHealth;
	}
}
