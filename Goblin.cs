using System;

public class Goblin : Enemy
{

	private const int goblinHealth = 20;

	private const int goblinMinDamage = 3;
	private const int goblinMaxDamage = 10;

	/*
	public int Damage
	{
		get
		{
			return goblinMaxDamage;
			//Random newRandom = new Random();
			//return newRandom.Next(goblinMinDamage, goblinMaxDamage + 1);
		} protected set
		{
			Damage = value;
		}
	}
	*/

	public Goblin()
	{
		Health = goblinHealth;
		Damage = goblinMaxDamage;
	}


}
