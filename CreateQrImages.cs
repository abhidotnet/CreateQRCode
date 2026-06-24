using System;
using System.Drawing;
using System.IO;
using QRCoder;

namespace MakeQrCodes
{
    public class CreateQrImages
    {
        public void MakeQRImage(string url, string outputPath, string logoPath = null)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage;
            if (!string.IsNullOrWhiteSpace(logoPath) && File.Exists(logoPath))
            {
                using (var logo = (Bitmap)Bitmap.FromFile(logoPath))
                {
                    qrCodeImage = qrCode.GetGraphic(20, Color.Aqua, Color.Navy, logo);
                }
            }
            else
            {
                qrCodeImage = qrCode.GetGraphic(20, Color.Aqua, Color.Black, false);
            }

            try
            {
                var directory = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                qrCodeImage.Save(outputPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                qrCodeImage.Dispose();
            }
        }
    }
}
