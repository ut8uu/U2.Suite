using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.MultiRig.Code
{
	public static class ByteFunctions
	{
		public static bool ByteArraysEqual(byte[] arr1, byte[] arr2)
        {
            return arr1.SequenceEqual(arr2);
		}

		public static byte[] BytesAnd(byte[] arr1, byte[] arr2)
		{
			byte[] bytesAnd_result = new byte[] { };
			int i = 0;
			Array.Resize(ref bytesAnd_result, Math.Min(arr1.Length, arr2.Length));

			for (i = 0; i <= arr1.Length - 1; i++)
			{
				bytesAnd_result[i] = (byte)(arr1[i] & arr2[i]);
			}

			return bytesAnd_result;
		}

        public static void BytesReverse(byte[] arr)
        {
            var arrReversed = arr.Reverse().ToArray();
            for (var index = 0; index < arrReversed.Length; index++)
            {
				arr[index] = arrReversed[index];
            }
		}

        public static string BytesToStr(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
		}

        public static byte[] StrToBytes(string s)
        {
            return Encoding.UTF8.GetBytes(s);
		}

        public static string BytesToHex(byte[] bytes)
		{
			var stringBuilder = new StringBuilder();
            foreach (var b in bytes)
            {
                stringBuilder.Append($"{b:X}");
            }
			return stringBuilder.ToString();
		}

        public static string StrToHex(string s)
		{
			return BytesToHex(StrToBytes(s));
		}
	}
}
