using System.Net.Sockets;
using NModbus;

namespace E3DCIntegration.Base; 

public sealed class ModbusClient {
    public string Address { get; init; }
    public short Port { get; set; }

    private TcpClient Client { get; set; }
    private IModbusMaster Modbus { get; set; }

    public void Connect() {
        Client = new TcpClient(Address, Port);
        Modbus = new ModbusFactory().CreateMaster(Client);
    }

    public async Task<int> ReadInt(ushort address) {
        var data = await ReadBytes(address, 2);
        return BitConverter.ToInt32(data);
    }
    
    public async Task<short> ReadShort(ushort address) {
        var data = await ReadBytes(address, 1);
        return BitConverter.ToInt16(data);
    }
    
    public async Task<ushort> ReadUShort(ushort address) {
        var data = await ReadBytes(address, 1);
        return BitConverter.ToUInt16(data);
    }

    private async Task<byte[]> ReadBytes(ushort address, byte length) {
        var data = await Modbus.ReadHoldingRegistersAsync(0, address, length);
        var bytes = new byte[data.Length * sizeof(ushort)];
        for (int i = 0; i < data.Length; i++) {
            var raw = BitConverter.GetBytes(data[i]);
            bytes[i * 2] = raw[0];
            bytes[i * 2 + 1] = raw[1];
        }

        return bytes;
    }
}