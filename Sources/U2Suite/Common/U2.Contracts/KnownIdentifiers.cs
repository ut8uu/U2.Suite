namespace U2.Contracts;

public static class KnownIdentifiers
{
    /// <summary>
    /// A generic MultiRig object
    /// </summary>
    public const ushort U2MultiRig = 0;
    /// <summary>
    /// A MultiRig demo application
    /// </summary>
    public const ushort U2MultiRigDemo = 1;
    /// <summary>
    /// An instance of the MultiRig emulator implementing
    /// the <see cref="IRigEmulator"/> interface.
    /// For example, <see cref="IC707Emulator"/>.
    /// </summary>
    public const ushort U2MultiRigEmulatorInstance = 2;
    /// <summary>
    /// A GUI application to manage the EmulatorInstance.
    /// Used to display the current state of the emulator
    /// and manage it.
    /// </summary>
    public const ushort U2MultiRigEmulatorGui = 3;
    /// <summary>
    /// An instance of the U2.Logger application.
    /// </summary>
    public const ushort U2Logger = 10;
    /// <summary>
    /// An instance of the U2.QslManager application
    /// </summary>
    public const ushort U2QslManager = 20;
    
    /// <summary>
    /// A multicast message. Can be used as an identifier
    /// of the receiver only.
    /// </summary>
    public const ushort MultiCast = 32768;
}
