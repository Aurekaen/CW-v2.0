using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShockAPI;

namespace Class_Wars_2._0
{
    class CSCommand
    {
        public static void DetailedCSHelp(CommandArgs args)
        {
            TSPlayer player = args.Player;
            if (args.Parameters.Count > 1)
            {
                if (args.Parameters[1] == "admin" && player.HasPermission("CS.admin"))
                {
                    player.SendErrorMessage("/class add [name]");
                    player.SendErrorMessage("/class set [name] <inv|stats>");
                    player.SendErrorMessage("/class del [name]");
                    player.SendErrorMessage("/class buff <add|del> [name] [buff] [duration]");
                    player.SendErrorMessage("/class itembuff <add|del> [name] [buff] [duration]");
                    player.SendErrorMessage("/class ammo <add|del> [name] [refresh time] [maximum ammo count]");
                    return;
                }
            }

            player.SendErrorMessage("Aliases: /class, /cs");

            player.SendErrorMessage("/class select [name]");
            player.SendErrorMessage("/class list");
            player.SendErrorMessage("/class preview [name]");
            player.SendErrorMessage("/class description [name]");
            if (player.HasPermission("CS.admin"))
                player.SendErrorMessage("/class help admin");
            return;
        }
    }
}
