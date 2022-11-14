using System;
using WCZ6Y1_HFT_2022231.Client.Menu;

namespace WCZ6Y1_HFT_2022231.Client
{
    class Program
    {
        //35742 //http://localhost:35742"
        public static RestService REST_API = new RestService("http://localhost:35742");
        static void Main(string[] args)
        {
            try
            {
                MenuSystem.ConfigureMenu(args);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\nThe application will close now.");

            }
        }
    }
}
