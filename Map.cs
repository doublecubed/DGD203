using System;
using System.Numerics;
using System.ComponentModel;

public class Map
{
	private int[] _coordinates;

	private int[] _widthBoundaries;
	private int[] _heightBoundaries;

	private Location[] _locations;


	public Map(int width, int height)
	{
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
        _coordinates = new int[2];
        _coordinates[0] = 0;
        _coordinates[1] = 0;

		GenerateLocations();

		// Display result message
		Console.WriteLine($"Created map with size {width}x{height}");
    }

    #region Coordinates

    public int[] GetCoordinates()
	{
		return _coordinates;
	}

	public void SetCoordinates(int[] newCoordinates)
	{
		if (newCoordinates.Length != 2)
		{
			Console.WriteLine("ERROR: Coordinates must be fed in an int[2] format");
			return;
		}

		_coordinates = newCoordinates;
	}

	#endregion

	#region Movement

	public void MovePlayer(int x, int y)
	{
		int newXCoordinate = _coordinates[0] + x;
        int newYCoordinate = _coordinates[1] + y;

		if (!CanMoveTo(newXCoordinate, newYCoordinate)) 
		{
            Console.WriteLine("You can't go that way");
            return;
        }

		_coordinates[0] = newXCoordinate;
		_coordinates[1] = newYCoordinate;

		if (IsOnLocation(_coordinates))

        Console.WriteLine($"You are now standing on {_coordinates[0]},{_coordinates[1]}");
    }

	private bool CanMoveTo(int x, int y)
	{
		return !(x < _widthBoundaries[0] || x > _widthBoundaries[1] || y < _heightBoundaries[0] || y > _heightBoundaries[1]);
	}

	#endregion

	#region Locations

	private void GenerateLocations()
	{
        _locations = new Location[4];

        Vector2 gristolLocation = new Vector2(0, 0);
        Location gristol = new Location("Gristol", gristolLocation);
        _locations[0] = gristol;

        Vector2 tyviaLocation = new Vector2(-1, 1);
        Location tyvia = new Location("Tyvia", tyviaLocation);
        _locations[1] = tyvia;

        Vector2 serkonosLocation = new Vector2(1, -1);
        Location serkonos = new Location("Serkonos", serkonosLocation);
        _locations[2] = serkonos;

        Vector2 morleyLocation = new Vector2(0, 1);
        Location morley = new Location("Morley", morleyLocation);
        _locations[3] = morley;
    }

	private bool IsOnLocation(int[] coords)
	{
		// Convert int[] to Vector2

		// ADAPTER OR TOTAL CONVERSION?

		// IT DEPENDS


		return false;
	}

	#endregion
}