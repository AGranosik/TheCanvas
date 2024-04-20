using Microsoft.SemanticKernel;
using SkiaSharp;

namespace llm_sandbox
{
    public static class PictureProvider
    {
        public static ImageContent GetImageContent(string path)
        {
           return GetImageContent(LoadImageToMemoryStream(path));
        }

        private static MemoryStream LoadImageToMemoryStream(string imagePath)
        {
            // Open the file stream from the image file
            using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                SKBitmap bitmap = SKBitmap.Decode(fileStream);
                MemoryStream memoryStream = new MemoryStream();
                using (SKImage image = SKImage.FromBitmap(bitmap))
                {
                    image.Encode(SKEncodedImageFormat.Jpeg, 100).SaveTo(memoryStream);
                }
                memoryStream.Position = 0;
                return memoryStream;
            }
        }

        private static ImageContent GetImageContent(MemoryStream stream)
        {
            var readOnly = new ReadOnlyMemory<byte>(stream.ToArray());
            return new ImageContent(readOnly);
        }
    }
}
