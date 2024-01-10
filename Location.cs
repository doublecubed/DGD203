using System;
using System.Numerics;

public class Location
{
    #region VARIABLES

    public string Name { get; private set; }
    public Vector2 Coordinates { get; private set; }
    public LocationType Type { get; private set; }

    #endregion

    #region CONSTRUCTOR

    public Location(string locationName, LocationType type, Vector2 coordinates)
    {
        Name = locationName;
        Type = type;
        Coordinates = coordinates;
    }

    #endregion

    #region METHODS

    #endregion
}

public enum LocationType
{
    City,
    Combat,
    Cave
}