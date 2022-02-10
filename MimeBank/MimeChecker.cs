/*
* Programmed by Umut Celenli umut@celenli.com
*/

using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MimeBank
{
	/// <summary>
	/// This is the main class to check the file mime type
	/// Header list is loaded once
	/// </summary>
	public class MimeChecker
	{

		public async Task<FileHeader> GetFileHeaderAsync(string file)
		{
			using var stream = File.OpenRead(file);
			return await GetFileHeaderAsync(stream);
		}

		public async Task<FileHeader> GetFileHeaderAsync(Stream stream)
		{
			var buffer = new byte[HeaderData.MaxBufferSize];
			await stream.ReadAsync(buffer, 0, HeaderData.MaxBufferSize);

			return HeaderData.Items.FirstOrDefault(mime => mime.Check(buffer));
		}

		public FileHeader GetFileHeader(string file)
		{
			using var stream = File.OpenRead(file);
			return GetFileHeader(stream);
		}

		public FileHeader GetFileHeader(Stream stream)
		{
			var buffer = new byte[HeaderData.MaxBufferSize];
			stream.Read(buffer, 0, HeaderData.MaxBufferSize);

			return HeaderData.Items.FirstOrDefault(mime => mime.Check(buffer));
		}

		/// <summary>
		/// A simple static method for simpler checks.
		/// </summary>
		/// <param name="file">The path to the file to check.</param>
		/// <param name="expectedType">The file type to compare againt.</param>
		/// <returns></returns>
		public static async Task<bool> CheckAsync(string file, FileType expectedType)
		{
			var checker = new MimeChecker();
			var header = await checker.GetFileHeaderAsync(file);
			return header.Type == expectedType;
		}

		/// <summary>
		/// A simple static method for simpler checks.
		/// </summary>
		/// <param name="file">The path to the file to check.</param>
		/// <param name="expectedType">The file type to compare againt.</param>
		/// <returns></returns>
		public static bool Check(string file, FileType expectedType)
		{
			var checker = new MimeChecker();
			var header = checker.GetFileHeader(file);
			return header.Type == expectedType;
		}
	}
}
