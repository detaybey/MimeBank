﻿using System;
using System.Linq;

namespace MimeBank
{
	/// <summary>
	/// This is a data structure for holding the header byte sequences of each file format.
	/// </summary>
	public class FileHeader
	{
		private const int SkipValue = -1;
		private const char SkipChar = '?';
		private const string SkipMarker = "??";

		/// <summary>
		/// The enum type of the file.
		/// </summary>
		public FileType Type { get; private set; }

		/// <summary>
		/// Extension of the file.
		/// </summary>
		public string Extension { get; private set; }

		/// <summary>
		/// Byte sequence in hex string delimited with space.
		/// If there are unpredicted bytes in the sequence, they can be defined using ??.
		/// For example - WAV files have their 5th to 8th bytes different for each file
		/// so in it's definition, the header bytes are as follows
		/// "52 49 46 46 ?? ?? ?? ?? 57 41 56 45 66 6D 74 20"
		/// </summary>
		protected int[] Header { get; private set; }

		/// <summary>
		/// Header length of the file.
		/// </summary>
		public int HeaderLength => Header.Length;

		public FileHeader(FileType type, string extension, string header)
		{
			Type = type;
			Extension = extension;
			Header = ParsePattern(header);
		}

		private static int[] ParsePattern(string header) =>
			header.Split(' ')
				.Select(part =>
					part == SkipMarker
						? SkipValue
						: part[0] == SkipChar || part[1] == SkipChar
							? -1 * Convert.ToInt32(part.Replace(SkipChar, '0'), 16)
							: Convert.ToInt32(part, 16))
				.ToArray();

		/// <summary>
		/// Checks the byte array against the sent file buffer
		/// </summary>
		/// <param name="buffer">the first 256 bytes sent from file</param>
		/// <returns>true if the type is correct</returns>
		public bool Check(byte[] buffer)
		{
			var headerLength = Header.Length;
			if (headerLength > buffer.Length)
			{
				return false;
			}

			for (var i = 0; i < headerLength; i++)
			{
				var headerValue = Header[i];
				if (headerValue == SkipValue)
				{
					continue;
				}

				if (headerValue < 0)
				{
					var b = (byte)(-1 * headerValue);
					if ((buffer[i] & b) != b)
					{
						return false;
					}
				}
				else if (buffer[i] != headerValue)
				{
					return false;
				}
			}

			return true;
		}
	}
}
