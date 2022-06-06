# Introduction

The purpose of the *U2.MultiRig.Emulators* project is to 
make the live of developers easy by substituting the real
equipment by its program analog.

# How To Use

To use the emulator you should perform several simple steps.

1. Create an `EmulatorBase` descendant class. Pass a desired 
resource file to base class' constructor. All the INI files
are already placed into the project's resources. Please refer to the
`IC705Emulator.cs` file to see how to do this properly. 

2. Create a `RigSerialPortEmulatorBase` descendant class. Please
refer to the `IC705SerialPortEmulator.cs` file to see how to do 
this properly.

3. Assign an instance of the serial port emulator to the 
`SerialPortEmulator` property.

4. Create an instance of the created class. 

5. Execute the following code: 
`MultiRigApplicationContext.Instance.BuildContainer();`
The magic is in the use of the IoC - it builds a container,
knowing how to create all the required objects when this is
required.

6. Change all the RIG-related properties of the newly
created emulator.

If you have done everything properly, the an attempt to 
launch the `HostRig` should lead to a successful reporting of
the changed values.

Please refer to the `U2.MultiRig.Tests` project to see
how it is already implemented.
