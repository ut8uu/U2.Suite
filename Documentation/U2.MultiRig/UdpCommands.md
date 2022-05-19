# UDP Commands

The table below contains all the commands known to the U2.Suite ecosystem.
The predefined set takes the range 0-32767 (0x7FFF).
Explanations of the commands are given under the table.

| CommandId | Meaning       | 
| --------- | ------------- | 
| 0x0000    | A broadcast informational message. |
| 0x0001	| A broadcast message about multiple changed parameters. |
| 0x0002    | A broadcast message about a single changed parameter. |
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
Operation failed: `0001`.`0001`.`01`.`XX`, where `XX` is a code of the failure [TBD].

## 0x0010 - Get parameter

Used to request the value of some specific parameter.
The MessageType should be 'R'.
The parameterId is a 8-bit (one byte) value following the command.
A list of parameters can be found in the [list of parameters](UdpParameters.md).

An example:
`0010`.`0001`.`00`

## 0x0011 - Set parameter

Used to set the value into the specified parameter.
The parameterId is a 8-bit (one byte, 256 different parameters) value following the command.
The MessageType should be 'R'.
A list of parameters can be found in the [list of parameters](UdpParameters.md).
The value of the parameter to be set is provided in the *DATA* section of the datagram
(see the [protocol](Protocol.md)).
