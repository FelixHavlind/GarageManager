using GarageManager.Garage;
using GarageManager.Garage.Vehicles;

namespace GarageManager.Tests;

public class GarageTest
{
    [Fact]
    public void AddVehicle_WithVehicle_Success()
    {
        // ARRANGE
        var gm = new Garage<Car>(3);
        var car = new Car("ABC123", "Green", 250);
        var expectedResult = 1;
        
        // ACT
        gm.AddVehicle(car);
        
        // ASSERT
        Assert.Equal(expectedResult, gm.VehicleCount);
    }

    [Fact]
    public void AddVehicle_WithVehicle_InvalidOperationException()
    {
        // ARRANGE
        var gm = new Garage<Car>(0);
        var car = new Car("ABC123", "Green", 250);
        var expectedResult = "Garage is full";
        
        // ASSERT
        var exception = Assert.Throws<InvalidOperationException>(() => gm.AddVehicle(car));
        Assert.Equal(expectedResult, exception.Message);
    }
}