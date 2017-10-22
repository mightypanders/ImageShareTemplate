using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.Webfonts;
using ImageShareTemplate;
using SixLabors;
using System.IO;
using System.Linq;

namespace ImageShareTemplate.FontProvider
{
    public class GoogleFonts
    {
        private Google.Apis.Webfonts.v1.WebfontsService service;
        public Google.Apis.Webfonts.v1.Data.WebfontList FontList;
        public GoogleFonts()
        {
            initService(getAPIKeyFromFile());
        }

        private string getAPIKeyFromFile()
        {
            return System.IO.File.ReadAllText("apikey.txt");
        }
        private void initService(string Key)
        {
            service = new Google.Apis.Webfonts.v1.WebfontsService(
                   new BaseClientService.Initializer()
                   {
                       ApiKey = Key,
                       ApplicationName = "ImageSharer"
                   });
        }
        public async Task getFontList()
        {

            Console.WriteLine("Fetch googlefonts");
            FontList = await service.Webfonts.List().ExecuteAsync();
            if (FontList.Items != null)
            {
                foreach (var item in FontList.Items)
                {
                    System.Console.WriteLine(item.Subsets[0] + " " + item.Category + " " + item.Kind + " " + item.Subsets.Count);
                }
            }
        }
        public Google.Apis.Webfonts.v1.Data.Webfont getFontFromList(string fontname)
        {
            IEnumerable<Google.Apis.Webfonts.v1.Data.Webfont> font = FontList.Items.Where(x=>x.Family.Equals(fontname));
            return font.First();

        }
    }
}
