# Protocol

An U2.Suite communication protocol is based on the UDP datagrams.
It can be used to connect all the U2.Suite applications to each other.
Moreover, all third-party applications supporting this protocol can communicate
to U2.Suite software and to each other.

## Datagrams

The UDP datagram is a sequence of bytes formed in some particular order.
The order of chunks is always the same for the same command, request, and response.
The datagram consists of the following parts.

| Title       | Size    | Description |
| ----------- | ------- | ----------- |
| MagicNumber | 4 bytes | Indicates this is a U2.Suite-related datagram. Always equals 0xABBA1105. |
| Timestamp   | 8 bytes | A 64-bit integer value representing the DateTime in binary format. |
| MessageId   | 1 byte  | A 8-bit unsigned integer, specifying the message identifier. |
| SenderId    | 2 bytes | A 16-bit unsigned integer representing the sender of the datagram. |
| ReceiverId  | 2 bytes | A 16-bit unsigned integer representing the receiver of the datagram. |
| MessageType | 1 byte  | A character, specifying the type of the message. Can be either 'R', 'A', 'I', OR 'S'. |
| Checksum	  | 4 bytes | A 32-bit unsigned integer used to check if the arrived data are consistent. |
| CommandId   | 2 bytes | A 16-bit unsigned integer representing the command. |
| DataLength  | 2 bytes | A 16-bit unsigned integer specifying the length of the following data. |
| Data		  | ??      | A content of the datagram. |

All values are being sent using the big-endian order when the first 
(or most significant) byte of the sequence comes first.

### Magic Number

Always must equal 0xABBA1105. When differs, the datagram is ignored.

### Timestamp

The number of 100-ns periods since 01.01.0000 00:00:00, which is equal to 0.
Positive values are AD times, negative values are BC times.
A timestamp 01.01.0000 00:00:01 is encoded as 10.000.000 (10M).

### MessageId

An internal identifier of the message. As far as datagrams can arrive in the 
wrong order, the field can be used to map requests and responses. 
It is recommended to increment the message identifier every time after sending 
the message requiring the reply.

### SenderId

An unsigned 16-bit integer value (0-65534 range) representing the origin 
of the datagram. 

There are two groups of senders: registered and not registered.
A U2.Suite representative assigns SenderId and stores these values in the 
dedicated table, that is stored in the text file in the U2.Suite repository 
on GitHub.

All values in the range 0-32767 (inclusive) are considered registered and cannot be 
freely assigned. 
All values in the range 32768-65534 (inclusive) can be self-assigned. You can use 
these values in your software for testing purposes or private use.

Although you can choose the identifier from the entire range 0-65535, 
it is advised to avoid the registered range in your software.

Also, the identifier 65535 is for multicast datagrams and cannot be used to identify 
the sender.

### ReceiverId

The same as SenderId, but for receivers. Can be any value in the range 0-65535.
Please refer to the list of the registered software identifiers to specify
the receiver explicitly. Use the `65535` to send the multicast message.
Please note, by sending the multicast message expecting the answer, you can flood
the network with a lot of responses from all the software accepting the multicast
messages and knowing how to process the request message.

### MessageType

A one-char long representation of the type of the message.
Can be either 'R' (a request), 'A' (answer to the request), 'I' (general info),
'S' (some status).

An 'R' message is sent hoping to get some information. The 'A' message is expected to be received.

An 'A' message can be sent as a reply to 'R' or 'A' messages.

An 'I' and 'S' can be sent as broadcast messages with or without specifying the concrete receiver.

The messages having unrecognized types should be ignored.

### CommandId

A two-byte long identifier of the command. Being an unsigned short integer can 
handle up to 65536 commands. Commands in the range 0-32767 are predefined commands 
and should not be used to handle the custom commands, not known to the U2.Suite 
ecosystem. Commands in the range 32768-65535 can be used for sending custom commands.

All predefined commands from the range 0-32767 are described in the 
[separate file](UdpCommandIds.md).

### DataLength

A two-byte long unsigned integer. Specifies the length of the data in the datagram.

### Data

Actual data. All bytes exceeding the `DataLength` will be ignored.
A datagram having less data will be ignored.
