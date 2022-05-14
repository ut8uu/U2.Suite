# Introduction

The U2.MultiRig project is aimed on ability to control the different kind 
of radio equipment via the CAT interface.

## The source codes

The idea to control the radio equipment via the CAT interface is quite old.
One of the mature solutions is OmniRig, the open source software by Alex
Shovkoplyas, VE3NEA. Inspired by the simplicity of the solution and using the 
source codes of the OmniRig, released under the terms of the Mozilla Public
License, v. 2.0. You can find the full text of the License in this repository
([LInk to the License](mpl.me)) or directly on the 
[Mozilla.org site](http://mozilla.org/MPL/2.0/).

The OmniRig is written in Object Pascal, which makes impossible to use them directly.
It took some quite long time to port them to C#. To make the software to be
crossplatform, the original inter-application approach was rejected. The more
modern approach based on the exchange of the UDP messages was used.

## Supported rigs

Being based on the OmniRig, the U2.MultiRig software can use the INI files
from the OmniRig without any change. If, for some reason, you cannot see your device
in the dropdown list of the supported rigs, but OmniRig has it listed, please 
report this using the GitHub ([link to the issue tracker](https://github.com/ut8uu/U2.Suite/issues)).

## The protocol

The UDP datagramm consists of the following parts.

| Title       | Size    | Description |
| ----------- | ------- | ----------- |
| MagicNumber | 4 bytes | Indicates this is an U2.MultiRig-related datagram. Always equals 0xABBA1105. |
| Timestamp   | 8 bytes | A 64-bit integer value representing the DateTime in binary format. |
| SenderId    | 2 bytes | A 16-bit unsigned integer representing the sender of the datagram. |
| ReceiverId  | 2 bytes | A 16-bit unsigned integer representing the receiver of the datagram. |

All values are stored and sent using the big-endian order, when the first 
(or most significant) byte of the sequence is being sent first.

### Magic Number

Always must equal to 0xABBA1105. When differs, the datagram is ignored.

### Timestamp

The number of 100-ns periods since 01.01.0000 00:00:00, which is equal to 0.
Negative values represents time before the timestamp above.
A timestamp 01.01.0000 00:00:01 is encoded as 10.000.000 (10M).

### SenderId

An unsigned 16-bit integer value (0-65534 range) representing the origin 
of the datagram. 

There are two groups of senders: registered and not registered.
A registered sender has a number, that was assigned by U2.Suite representative.
All identifiers are stored in the text file in the U2.Suite repository on GitHub.
All numbers in range 0-32767 (inclusive) are considered registered and cannot be 
freely assigned. 
All numbers in range 32768-65534 (inclusive) can be self-assigned. You can use 
these values in your software for testing purposes of for private use.

Although you can use any identifier from the range 0-65535, it is advised to avoid the
registered range in your software.

An identifier 65535 is for multicast datagrams and cannot be used to identify the sender.

### ReceiverId

The same as SenderId, but for receivers. Can be any value in the range 0-65535.
Please refer to the list of the registered software identifiers to specify
the receiver explicitly. Use the `65535` to send the multicast message.
Please note, sending the multicast message expecting the answer, you can flood
the network with a lot of responses from all the sowtware accepting the multicast
messages and knowing how to process the request message.

