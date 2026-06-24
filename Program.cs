using System;
using System.Configuration;

namespace MakeQrCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = ConfigurationManager.AppSettings["QrUrl"];
            var logoPath = ConfigurationManager.AppSettings["LogoPath"];
            var outputPath = ConfigurationManager.AppSettings["OutputPath"] ?? @"c:\temp\qrcode.jpg";

            if (string.IsNullOrWhiteSpace(url))
            {
                Console.WriteLine("QrUrl is required in App.config.");
                return;
            }

            CreateQrCodeFromUrl(url, outputPath, logoPath);
            Console.WriteLine($"QR code saved to {outputPath}");
        }

        static void CreateQrCodeFromUrl(string url, string outputPath, string logoPath = null)
        {
            var generator = new CreateQrImages();
            generator.MakeQRImage(url, outputPath, logoPath);
        }
    }
}
