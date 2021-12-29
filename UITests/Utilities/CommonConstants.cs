using System.IO;

namespace UITests.Utilities
{
    public static class CommonConstants
    {
        public static class DriverSettings
        {
            // running tests on chrome
            public static string filepathchrome = Path.GetFullPath("Driver"); // Create a folder called "chromedriver" under "C:\Users\yourusername\AppData\Local\Temp" & add the chrome driver version supported by your browser in this folder for the web browser to initiate. Make sure you name it as chromedriver.exe
            public static string BinaryLocationChrome = filepathchrome;

            // running tests on edge
            public static string filepathedge = Path.GetFullPath("Driver"); // Create a folder called "MicrosoftWebDriver" under "C:\Users\yourusername\AppData\Local\Temp" & add the chrome driver version supported by your browser in this folder for the web browser to initiate. Make sure you name it as MicrosoftWebDriver.exe
            public static string BinaryLocationEdge = filepathedge;

            public static string ChromeBrowser = "Chrome";
            public static string EdgeBrowser = "Edge";
            public static string HeadlessBrowser = "Headless";
            public static int DefaultWaitTime = 3000;
        }
    }
}