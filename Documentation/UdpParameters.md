# UDP Command Parameters

All parameters are the powers of 2.
Therefore, you can mix parameters with each other by adding their codes.
This can be useful when sending a broadcast message about the multiple
changed parameters. For excemple, the value `0x00000006` indicates changes 
in both FreqA and FreqB parameters.

However, some parameters requires the value to be specified, for example the `FreqA`.
To get or set thiese parameters, a separate message should be issued.

| Code		  | Name	    |
| ----------- | ----------- |
| 0x00000001  | Freq		|
| 0x00000002  | FreqA		|
| 0x00000004  | FreqB		|
| 0x00000008  | Pitch		|
| 0x00000010  | RitOffset	|
| 0x00000020  | Rit0		|
| 0x00000040  | VfoAA		|
| 0x00000080  | VfoAB		|
| 0x00000100  | VfoBA		|
| 0x00000200  | VfoBB		|
| 0x00000400  | VfoA		|
| 0x00000800  | VfoB		|
| 0x00001000  | VfoEqual	|
| 0x00002000  | VfoSwap		|
| 0x00004000  | SplitOn		|
| 0x00008000  | SplitOff	|
| 0x00010000  | RitOn		|
| 0x00020000  | RitOff		|
| 0x00040000  | XitOn		|
| 0x00080000  | XitOff		|
| 0x00100000  | Rx			|
| 0x00200000  | Tx			|
| 0x00400000  | CW_U		|
| 0x00800000  | CW_L		|
| 0x01000000  | SSB_U		|
| 0x02000000  | SSB_L		|
| 0x04000000  | DIG_U		|
| 0x08000000  | DIG_L		|
| 0x10000000  | AM			|
| 0x20000000  | FM			|
