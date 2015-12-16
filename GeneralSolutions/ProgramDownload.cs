using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    class ProgramDownload
    {
        const string someUrl = "http://r5---sn-aigllnzd.googlevideo.com/videoplayback?signature=96950B56C5DA608EF4E5AC21EE23AEB3854D340F.0597D4EDCE5B258E2079EEEA4AE91D46E684E369&itag=22&upn=DX_tfpBkjZM&expire=1450307757&fexp=9408509%2C9408940%2C9412755%2C9413209%2C9416126%2C9416484%2C9417488%2C9418199%2C9420452%2C9422596%2C9423642%2C9423662%2C9424114%2C9424151%2C9425938%2C9425944%2C9426410&nh=IgpwcjAzLmxocjE0KgkxMjcuMC4wLjE&dur=1740.196&source=youtube&initcwndbps=5668750&key=yt6&lmt=1450251576172133&ratebypass=yes&ipbits=0&mm=31&ip=2a02%3A2498%3Ae003%3A46%3A3%3A3%3A0%3A2&mn=sn-aigllnzd&sver=3&mime=video%2Fmp4&id=o-ALbdM9RAiw5RiHvas-cIlEJIc-ehtsr633iMeaoLRQ8j&pl=33&sparams=dur%2Cid%2Cinitcwndbps%2Cip%2Cipbits%2Citag%2Clmt%2Cmime%2Cmm%2Cmn%2Cms%2Cmv%2Cnh%2Cpl%2Cratebypass%2Csource%2Cupn%2Cexpire&mt=1450285966&mv=m&ms=au&title=MongoDB+Tutorial+2+-+Insert%2C+Update%2C+Remove%2C+Query";
        const string someFileName = "somefile.mp4";        
        
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Downlaod file from: {0}", someUrl);

            HTTPGetModule getModule = new HTTPGetModule();
            byte[] video = getModule.GetBinary(someUrl);

            if(getModule.IsSuccess)
            {
                Console.Out.WriteLine("Downloaded {0} bytes", video.Length);
                TextFileWriterModule fileWriter = new TextFileWriterModule(someFileName);
                fileWriter.Write(video);
            }
            else
            {
                Console.Out.WriteLine("{0} - {1}", getModule.Status.HttpStatusCode, getModule.Status.Description);
            }
        }
    }
}
