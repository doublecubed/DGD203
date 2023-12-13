using System;
using System.Numerics;

public class Location
{
    #region VARIABLES

    public string Name { get; private set; }
    public Vector2 Coordinates { get; private set; }

    #endregion

    #region CONSTRUCTOR

    public Location(string locationName, Vector2 coordinates)
    {
        Name = locationName;
        Coordinates = coordinates;
    }

    #endregion

    #region METHODS

    #endregion

}
