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

The U2.Suite protocol is described in the [Protocol](../../../Documentation/protocol.md) file.
Also, there you can find all the [command identifiers](../../../Documentation/UdpCommandIds.md)
and [parameter identifiers](../../../Documentation/UdpParameterIds.md)