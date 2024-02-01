// See https://aka.ms/new-console-template for more information

using E3DCIntegration.Base;

var connector = new E3DCConnector("192.168.188.30");

while (true) {
    Console.Clear();
    
    Console.WriteLine($"SolarPower: {await connector.SolarPower}");
    Console.WriteLine($"BatteryPower: {await connector.BatteryPower}");
    Console.WriteLine($"HouseConsumption: {await connector.HouseConsumption}");
    Console.WriteLine($"GridPower: {await connector.GridPower}");
    Console.WriteLine($"ExternalPower: {await connector.ExternalPower}");
    Console.WriteLine($"Autarky: {await connector.Autarky}");
    Console.WriteLine($"BatteryPercentage: {await connector.BatteryPercentage}");
    Console.WriteLine($"EmergencyPowerState: {await connector.EmergencyPowerState}");
    Console.WriteLine($"String1Power: {await connector.String1Power}");
    Console.WriteLine($"String2Power: {await connector.String2Power}");
    Console.WriteLine($"PowermeterL1: {await connector.PowermeterL1}");
    Console.WriteLine($"PowermeterL2: {await connector.PowermeterL2}");
    Console.WriteLine($"PowermeterL3: {await connector.PowermeterL3}");

    await Task.Delay(2000);
}

