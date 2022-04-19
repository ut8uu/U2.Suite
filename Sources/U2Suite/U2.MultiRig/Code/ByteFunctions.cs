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

		public static byte[] BytesAnd(byte[] Arr1, byte[] Arr2)
		{
			byte[] bytesAnd_result = new byte[] { };
			int i = 0;
			Array.Resize(ref bytesAnd_result, Math.Min(Arr1.Length, Arr2.Length));

			for (i = 0; i <= Arr1.Length - 1; i++)
			{
				bytesAnd_result[i] = (byte)(Arr1[i] & Arr2[i]);
			}

			return bytesAnd_result;
		}

        public static void BytesReverse(byte[] Arr)
		{
			byte B = 0;
			int i = 0;

			if (Arr.Length < 2)
			{
				return;
			}

			for (i = 0; i <= (Arr.Length / 2) - 1; i++)
			{
				B = Arr[i];
				Arr[i] = Arr[Arr.Length - 1 - i];
				Arr[Arr.Length - 1 - i] = B;
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

        public static string StrToHex(string S)
		{
			return BytesToHex(StrToBytes(S));
		}
	}
}
