using System;

public class Thermostat
{
    // Fields
    private string _roomName;
    private int _currentTemperature;
    private int _targetTemperature;

    // Constructor
    public Thermostat(string roomName, int currentTemperature, int targetTemperature)
    {
        _roomName = roomName;
        _currentTemperature = currentTemperature;
        _targetTemperature = targetTemperature;
    }

    // Properties
    public string RoomName => _roomName;
    public int CurrentTemperature => _currentTemperature;
    public int TargetTemperature => _targetTemperature;

    // Methods
    public bool SetTarget(int temperature)
    {
        if (temperature < 16 || temperature > 30)
        {
            return false;
        }

        _targetTemperature = temperature;
        return true;
    }

    public void AdjustOneDegree()
    {
        if (_currentTemperature < _targetTemperature)
        {
            _currentTemperature++;
        }
        else if (_currentTemperature > _targetTemperature)
        {
            _currentTemperature--;
        }
    }

    public string GetStatus()
    {
        if (_currentTemperature < _targetTemperature)
        {
            return "Heating";
        }
        else if (_currentTemperature > _targetTemperature)
        {
            return "Cooling";
        }
        else
        {
            return "At target";
        }
    }
}

class Program
{
    static void Main()
    {
        Thermostat livingRoom = new("Living room", 20, 23);
        Thermostat bedroom = new("Bedroom", 24, 21);
        Thermostat office = new("Office", 19, 19);

        livingRoom.AdjustOneDegree();
        livingRoom.AdjustOneDegree();

        bedroom.AdjustOneDegree();

        Console.WriteLine("SetTarget(31): " + livingRoom.SetTarget(31));

        Console.WriteLine("\nTHERMOSTAT RESULTS");

        Console.WriteLine($"{livingRoom.RoomName}: Current = {livingRoom.CurrentTemperature}, Target = {livingRoom.TargetTemperature}, Status = {livingRoom.GetStatus()}");

        Console.WriteLine($"{bedroom.RoomName}: Current = {bedroom.CurrentTemperature}, Target = {bedroom.TargetTemperature}, Status = {bedroom.GetStatus()}");

        Console.WriteLine($"{office.RoomName}: Current = {office.CurrentTemperature}, Target = {office.TargetTemperature}, Status = {office.GetStatus()}");
    }
}