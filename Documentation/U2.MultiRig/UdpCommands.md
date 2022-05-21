# UDP Commands

The table below contains all the commands known to the U2.Suite ecosystem.
The predefined set takes the range 0-32767 (0x7FFF).
Explanations of the commands are given under the table.

| CommandId | Meaning       | 
| --------- | ------------- | 
| 0x0000    | A broadcast informational message. |
| 0x0001	| A result of the command execution. |
| 0x0002	| A broadcast message about multiple changed parameters. |
| 0x0003    | A broadcast message about a single changed parameter. |
| 0x0009	| A result of the command execution, if expected. |
| 0x0010    | Get parameter | 
| 0x0011	| Set parameter | 

## 0x0000 - A broadcast message

Used to send some information as a broadcast message.
The MessageType should be 'S' or 'I'.
The message is sent in the DATA section of the message.

An example of the 5-bytes-long broadcast message containing the word `Start`:
`0000`.`0005`.`5374617274`

## 0x0001 - A command execution result

Used to report the result of the Set command in the format of the datagram.
The MessageType should be 'A'.
Below are examples of responses.

Operation successful: `0001`.`0001`.`00`
Operation failed: `0001`.`0002`.`01`.`XX`, where `XX` is a code of the failure [TBD].

## 0x0010 - A broadcast message about multiple changed parameters

Used to report changes of several parameters without specifying the value.
For example, it is possible to simultaneously report the FreqA and mode.
Each application willing to know the exact value of the parameter (e.g. FreqA),
should perform a separate call for this value.

Example of reporting of the FreqA and CW-L:
`0002`.`0004`.`00800002`

## 0x0011 - A broadcast message about a single changed parameter

Used to report a single changed parameter and its value.
For example, the FreqA is the only parameter that has been changed.
To minimize the amount of requests to the MultiRig, the extended broadcast 
message is being sent.

Please note, all values are sent using big endian order.

Examples:

FreqA is changed to 14.200: `0003`.`0008`.`00000002`.`00D8ACC0`
Rig switched to `CW_U`: `0003`.`0004`.`00400000`

## 0x0100 - Get parameter

Used to request the value of some specific parameter.
The MessageType should be 'R'.
The parameter is a 64-bit value following the command.
A list of parameters can be found in the [list of parameters](UdpParameters.md).

An example of requesting the FreqA:
`0100`.`0004`.`0000002`

An answer will be sent with MessageType='A' as the following:
`0100`.`0008`.`0000002`.`XXXXXXXX`
where XXXXXXXX is a hexadecimal representation of the frequency in hertz 
(using the big endian order).

## 0x0101 - Set parameter

Used to set the value into the specified parameter.
The parameterId is a 8-bit (one byte, 256 different parameters) value following the command.
The MessageType should be 'R', all bytes are passed using the big endian order.

A list of parameters can be found in the [list of parameters](UdpParameters.md).
The value of the parameter to be set is provided in the *DATA* section of the datagram
(see the [protocol](Protocol.md)).

An example of setting the FreqA to 14.200 MHz:
`0101`.`0008`.`00000002`.`00D8ACC0`
