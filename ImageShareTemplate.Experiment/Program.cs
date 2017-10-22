using ImageShareTemplate.ImageProvider;
using ImageShareTemplate.FontProvider;
using SixLabors.ImageSharp;
using System;

namespace ImageShareTemplate.Experiment
{
    class Program
    {

        static void Main(string[] args)
        {
            GoogleFonts gFont = new GoogleFonts();
            gFont.getFontList().Wait();
        }
        static void Sub()
        {
            byte[] bytes = FileHelpers.LoadImageFormPath("main-image.jpeg");

            var textBlockItem = new BlockText("Test the first line\r\nTest the second line\r\nTest the third line...")
            {
                PointX = 100,
                PointY = 100
            };

            var imageBlockItem = new BlockImage("imagesharp-logo-256.png")
            {
                PointX = 100,
                PointY = 10
            };

            var options = new ShareOption
            {
                ImageProvider = new FacebookImageProvider(ImageSize.Large),
                Block1 = textBlockItem,
                Block3 = imageBlockItem,
                RatioX = 0.6, // 60%
                RatioY = 0.6, // 60%
                Font = "Hack",
                FontSize = 24,
                FontStyle = SixLabors.Fonts.FontStyle.Italic,
                ImageSource = bytes
            };

            var result = Convert.FromBase64String(
                ShareTemplate.CreateAsBase64String(options).Split(',')[1]
            );

            using (var image = Image.Load(result))
            {
                image.Save("output.jpeg");
            }
        }
    }
}
