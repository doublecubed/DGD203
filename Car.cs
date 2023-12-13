using System;

public class Car
{
	private string _make;   //
	private string _model;

	private float _maxSpeed;  // 0f
	private int _numberOfSeats; // 0
	private float _amountOfGas;
	private float _maximumGas;


	private bool _isRunning;  // false

	// Constructor
	public Car(string make, string model, int noOfSeats)
	{
		_make = make;
		_model = model;

		_maxSpeed = 180f;
		_numberOfSeats = noOfSeats;
		_maximumGas = 60f;
		_amountOfGas = 60f;

		_isRunning = false;
	}

	public void StartCar()
	{
		_isRunning = true;
	}

	public int GetNumberOfSeats()
	{
		return _numberOfSeats;
	}

	public float GetGasPercentage()
	{
		float percentage = _amountOfGas / _maximumGas;  // 0.0 0.45 0.75 1.0
		return percentage;
	}
}
