using System.IO;

namespace UITests.Utilities
{
    public static class CommonConstants
    {
        public static class DriverSettings
        {
            // running tests on chrome
            public static string filepath = Path.GetFullPath("Driver"); 
            public static string BinaryLocationChrome = filepath;

            // running tests on edge

            public static string BinaryLocationEdge = filepath;

            // running tests on edge

            public static string BinaryLocationFireFox = filepath;

            public static string ChromeBrowser = "Chrome";
            public static string EdgeBrowser = "Edge";
            public static string HeadlessBrowser = "Headless";
            public static string FireFoxBrowser = "FireFox";
            public static int DefaultWaitTime = 3000;
        }
    }
}