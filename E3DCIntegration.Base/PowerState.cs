namespace E3DCIntegration.Base; 

public enum PowerState : byte {
    NotSupported = 0x00,
    Active = 0x01,
    Inactive = 0x02,
    NotAvailable = 0x03,
    NotConfigured = 0x04
}