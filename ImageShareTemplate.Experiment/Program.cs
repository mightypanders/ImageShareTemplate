using ImageShareTemplate.ImageProvider;
using ImageShareTemplate.FontProvider;
using SixLabors.ImageSharp;
using System;
using System.Net;
using System.IO;

namespace ImageShareTemplate.Experiment
{
    class Program
    {

        static void Main(string[] args)
        {
            GoogleFonts gFont = new GoogleFonts();
            SixLabors.Fonts.FontFamily family = null;
            SixLabors.Fonts.FontCollection fonts = null;

            gFont.getFontList().Wait();
            var font = gFont.getFontFromList("Architects Daughter");
            string fontlink = font.Files["regular"];
            if (fontlink != null && fontlink != "")
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(fontlink, "googlefont.ttf");
                };
                fonts = new SixLabors.Fonts.FontCollection();
                family = fonts.Install("googlefont.ttf");
            }
            if (family != null)
                Sub(family);
        
            File.Delete("googlefont.ttf");
        }
        static void Sub(SixLabors.Fonts.FontFamily family)
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
                FontFile = family,
                FontSize = 56,
                FontStyle = SixLabors.Fonts.FontStyle.Italic,
                ImageSource = bytes
            };

            var result = Convert.FromBase64String(
                ShareTemplate.CreateAsBase64String(options).Split(',')[1]
            );

            using (var image = Image.Load(result))
            {
                image.Save("output-"+options.FontFile.Name+".jpeg");
            }
        }
    }
}
