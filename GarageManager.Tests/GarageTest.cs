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
        const int expectedResult = 1;
        
        // ACT
        gm.AddVehicle(car);
        
        // ASSERT
        Assert.Equal(expectedResult, gm.VehicleCount);
    }

    [Fact]
    public void AddVehicle_WithVehicle_GarageFullException()
    {
        // ARRANGE
        var gm = new Garage<Car>(0);
        var c1 = new Car("ABC123", "Green", 250);
        const string expectedResult = "Garage is full";
        
        // ASSERT
        var exception = Assert.Throws<InvalidOperationException>(() => gm.AddVehicle(c1));
        Assert.Equal(expectedResult, exception.Message);
    }

    [Fact]
    public void AddVehicle_WithVehicle_DuplicateVehicleException()
    {
        // ARRANGE
        var gm = new Garage<Car>(10);
        var c1 = new Car("ABC123", "Green", 250);
        var c2 = new Car("ABC123", "Red", 400);
        const string expectedResult = "Vehicle with registration number: 'ABC123', already exist in garage";
        
        // ACT
        gm.AddVehicle(c1);
        
        // ASSERT
        var exception = Assert.Throws<InvalidOperationException>(() => gm.AddVehicle(c2));
        Assert.Equal(expectedResult, exception.Message);
    }

    [Fact]
    public void RemoveVehicle_WithRegistrationNumber_Success()
    {
        // ARRANGE
        var gm = new Garage<Car>(3);
        var c1 = new Car("ABC123", "Green", 250);
        var c2 = new Car("BCD234", "Green", 300);
        gm.AddVehicle(c1);
        gm.AddVehicle(c2);
        
        // ACT
        gm.RemoveVehicle("ABC123");
        
        // ASSERT
        Assert.Single(gm);
    }
    
    [Fact]
    public void RemoveVehicle_WithVehicle_DoesNotExistException()
    {
        // ARRANGE
        var gm = new Garage<Car>(3);
        var c1 = new Car("ABC123", "Green", 250);
        var c2 = new Car("BCD234", "Green", 300);
        const string expectedResult = $"Vehicle with registration number: 'BCD234', does not exist in garage";
        gm.AddVehicle(c1);
        
        // ASSERT
        var exception = Assert.Throws<ArgumentException>(() => gm.RemoveVehicle(c2));
        Assert.Equal(expectedResult, exception.Message);
    }

    [Fact]
    public void RemoveVehicle_WithVehicle_InvalidIndexException()
    {
        // ARRANGE
        var gm = new Garage<Car>(3);
        var c1 = new Car("ABC123", "Green", 250);
        const string expectedResult = "Vehicle with registration number: 'CBA321', does not exist in garage";
        gm.AddVehicle(c1);
        
        // ASSERT
        var exception = Assert.Throws<ArgumentException>(() => gm.RemoveVehicle("CBA321"));
        Assert.Equal(expectedResult, exception.Message);
        
        // ASSERT
        Assert.Single(gm);
    }
}