namespace E3DCIntegration.Base; 

public sealed class E3DCConnector {
    public ModbusClient Client { get; set; }

    public E3DCConnector(string address, short port = 502) {
        Client = new ModbusClient {
            Address = address,
            Port = port
        };
        
        Client.Connect();
    }

    private async Task<PowerState> GetPowerState() {
        var data = await Client.ReadShort(40083);
        return (PowerState)BitConverter.GetBytes(data)[0];
    }

    #region PowerData
        public Task<int> SolarPower => Client.ReadInt(40067);
        public Task<int> BatteryPower => Client.ReadInt(40069);
        public Task<int> HouseConsumption => Client.ReadInt(40071);
        public Task<int> GridPower => Client.ReadInt(40073);
        public Task<int> ExternalPower => Client.ReadInt(40075);

        public Task<short> Autarky => Client.ReadShort(40081);
        public Task<short> BatteryPercentage => Client.ReadShort(40082);
        public Task<PowerState> EmergencyPowerState => GetPowerState();
    #endregion

    #region PowerMeter
        public Task<ushort> String1Power => Client.ReadUShort(40101);
        public Task<ushort> String2Power => Client.ReadUShort(40102);
        
        public Task<short> PowermeterL1 => Client.ReadShort(40105);
        public Task<short> PowermeterL2 => Client.ReadShort(40106);
        public Task<short> PowermeterL3 => Client.ReadShort(40107);
    #endregion
}