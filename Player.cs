using System;

public class Player
{
	private const int playerMaxHealth = 100;

	public string Name { get; private set; }
	public int Health { get; private set; }

	public Inventory Inventory { get; private set; }

    public Player(string name, List<Item> inventoryItems)
	{
		Name = name;
		Health = playerMaxHealth;
		Inventory = new Inventory();

		for (int i = 0; i < inventoryItems.Count; i++)
		{
			Inventory.AddItem(inventoryItems[i]);
		}
	}

	public void TakeItem(Item item)
	{
		Inventory.AddItem(item);
	}

	
	public void DropItem(Item item)
	{
		// This will be implemented in the future!
	}

	public void CheckInventory()
	{
		for (int i = 0; i < Inventory.Items.Count; i++)
		{
			Console.WriteLine($"You have a {Inventory.Items[i]}");
		}
	}
}
