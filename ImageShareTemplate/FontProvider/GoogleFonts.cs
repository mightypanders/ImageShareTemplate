using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.Webfonts;
using ImageShareTemplate;
using SixLabors;
using System.IO;

namespace ImageShareTemplate.FontProvider
{
    public class GoogleFont
    {
        Google.Apis.Webfonts.v1.WebfontsService list;
        public GoogleFont()
        {
            initService(getAPIKeyFromFile());
        }

        private string getAPIKeyFromFile()
        {
            return System.IO.File.ReadAllText("apikey.txt");
        }
        private void initService(string Key)
        {
            list = new Google.Apis.Webfonts.v1.WebfontsService(
                   new BaseClientService.Initializer()
                   {
                       ApiKey = Key,
                       ApplicationName = "ImageSharer"
                   });
        }
        public async Task getStuff()
        {

            Console.WriteLine("Fetch googlefonts");
            var result = await list.Webfonts.List().ExecuteAsync();
            if (result.Items != null)
            {
                foreach (var item in result.Items)
                {

                }
            }
        }
    }
}
