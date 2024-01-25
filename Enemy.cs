using System;

public abstract class Enemy
{
	public int Health { get; protected set; }
	public int Damage { get; protected set; }

	public void TakeDamage(int amount)
	{
		Health -= amount;
		if (Health < 0) Health = 0;
	}

}

