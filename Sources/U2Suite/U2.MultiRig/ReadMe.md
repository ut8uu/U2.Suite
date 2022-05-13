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

Being based on the OmniRig, the U2.MultiRig software can use INI files
from the OmniRig without any change. If for some reason you cannot see your device
in the dropdown list of supported rigs, but OmniRig has it listed, please report this
on the GitHub ([link to issue tracker](https://github.com/ut8uu/U2.Suite/issues)).

## The protocol

The used protocol is adopted from the WSJT-X, where the similar UDP-based exchange 
is used. The UDP datagramm consists of the following parts

| Title       | Size    | Description |
| ----------- | ------- | ----------- |
| MagicNumber | 4 bytes | Indicates this is an U2.MultiRig-related datagram. Always equals 0xABBA1105. |
| Timestamp   | 8 bytes | A 64-bit integer value representing the DateTime in binary format. |
