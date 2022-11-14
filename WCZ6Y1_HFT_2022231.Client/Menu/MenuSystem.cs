using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCZ6Y1_HFT_2022231.Client.Menu
{
    public static class MenuSystem
    {
        public static void ConfigureMenu(string[] args)
        {
            var menu = new ConsoleMenu(args, 0)
              .Add("Authors", SubMenus.SetupAuthorSub().Show)
              .Add("Publishers", SubMenus.SetupPublisherSub().Show)
              .Add("Books", SubMenus.SetupBookSub().Show)
              .Add("Query Selection", SubMenus.SetupQuerySub().Show)
              .Add("Exit", () => Environment.Exit(0))
              .Configure(config =>
              {
                  config.Selector = "->";
                  config.EnableWriteTitle = true;
                  config.Title = "Main menu";
              });

            menu.Show();
        }
    }
}
