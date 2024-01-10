using System;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics;
using DGD203_2;

public class Map
{
	private Game _theGame;

	private Vector2 _coordinates;

	private int[] _widthBoundaries;
	private int[] _heightBoundaries;

	private Location[] _locations;


	public Map(Game game, int width, int height)
	{
		_theGame = game;

		// Setting the width boundaries
		int widthBoundary = (width - 1) / 2;

        _widthBoundaries = new int[2];
        _widthBoundaries[0] = -widthBoundary;
		_widthBoundaries[1] = widthBoundary;

		// Setting the height boundaries
        int heightBoundary = (height - 1) / 2;

        _heightBoundaries = new int[2];
		_heightBoundaries[0] = -heightBoundary;
		_heightBoundaries[1] = heightBoundary;

		// Setting starting coordinates
        _coordinates = new Vector2(0,0);

		GenerateLocations();

		// Display result message
		Console.WriteLine($"Created map with size {width}x{height}");
    }

    #region Coordinates

    public Vector2 GetCoordinates()
	{
		return _coordinates;
	}

	public void SetCoordinates(Vector2 newCoordinates)
	{
		_coordinates = newCoordinates;
	}

	#endregion

	#region Movement

	public void MovePlayer(int x, int y)
	{
		int newXCoordinate = (int)_coordinates[0] + x;
        int newYCoordinate = (int)_coordinates[1] + y;

		if (!CanMoveTo(newXCoordinate, newYCoordinate)) 
		{
            Console.WriteLine("You can't go that way");
            return;
        }

		_coordinates[0] = newXCoordinate;
		_coordinates[1] = newYCoordinate;

		CheckForLocation(_coordinates);
    }

	private bool CanMoveTo(int x, int y)
	{
		return !(x < _widthBoundaries[0] || x > _widthBoundaries[1] || y < _heightBoundaries[0] || y > _heightBoundaries[1]);
	}

	#endregion

	#region Locations

	private void GenerateLocations()
	{
        _locations = new Location[6];

        Vector2 gristolLocation = new Vector2(0, 0);
        Location gristol = new Location("Gristol", LocationType.City, gristolLocation);
        _locations[0] = gristol;

        Vector2 tyviaLocation = new Vector2(-2, 2);
        Location tyvia = new Location("Tyvia", LocationType.City, tyviaLocation);
        _locations[1] = tyvia;

        Vector2 serkonosLocation = new Vector2(1, -2);
        Location serkonos = new Location("Serkonos", LocationType.City, serkonosLocation);
        _locations[2] = serkonos;

        Vector2 morleyLocation = new Vector2(1, 1);
        Location morley = new Location("Morley", LocationType.City, morleyLocation);
        _locations[3] = morley;

		Vector2 firstCombatLocation = new Vector2(-2, 1);
		Location firstCombat = new Location("First Combat", LocationType.Combat, firstCombatLocation);
		_locations[4] = firstCombat;

        Vector2 secondCombatLocation = new Vector2(-1, -1);
        Location secondCombat = new Location("Second Combat", LocationType.Combat, secondCombatLocation);
        _locations[5] = secondCombat;

    }

	public void CheckForLocation(Vector2 coordinates)
	{
        Console.WriteLine($"You are now standing on {_coordinates[0]},{_coordinates[1]}");

        if (IsOnLocation(_coordinates, out Location location))
        {
            if (location.Type == LocationType.Combat)
			{
				Console.WriteLine("Prepare to fight!");
				Combat combat = new Combat(_theGame);
			} else
			{
				Console.WriteLine($"You are in {location.Name} {location.Type}");
			}
        }
    }

	private bool IsOnLocation(Vector2 coords, out Location foundLocation)
	{
		for (int i = 0; i < _locations.Length; i++)
		{
			if (_locations[i].Coordinates == coords)
			{
				foundLocation = _locations[i];
				return true;
			}
		}

		foundLocation = null;
		return false;
	}

	#endregion
}