using System;

public class Goblin : Enemy
{
	private const int goblinHealth = 20;
	private const int goblinDamage = 5;

	public Goblin()
	{
		Health = goblinHealth;
		Damage = goblinDamage;
	}
}
