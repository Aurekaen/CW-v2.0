using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShockAPI;

namespace Class_Wars_2._0
{
    static class CWCommand
    {
        public static void DetailedCWHelp(CommandArgs args)
        {
            TSPlayer player = args.Player;
            #region Thorough Help
            if (args.Parameters.Count > 1)
            {
                string[] parameters = args.Parameters.Select(x => x.ToLowerInvariant()).ToArray();
                
                if (parameters[1] == "start")
                {
                    player.SendInfoMessage("/cw start [arena]");
                    player.SendInfoMessage("Begins a game of Class Wars, using the specified arena.");
                    return;
                    }

                if (parameters[1] == "add")
                {
                    player.SendInfoMessage("/cw add [arena]");
                    player.SendInfoMessage("Adds a new Class Wars arena, using the specified name.");
                    return;
                }

                if (parameters[1] == "set")
                    {
                        if (parameters.Count() > 2)
                        {
                            if (parameters[2] == "host")
                            {
                                player.SendInfoMessage("/cw set [arena] host");
                                player.SendInfoMessage("This sets the host location to your current location.");
                                player.SendInfoMessage("This location is used as the teleport destination when using \"/cw goto\" or \"/cw spectate\"");
                                return;
                            }

                            if (parameters[2] == "redspawn" || parameters[2] == "bluespawn")
                            {
                                player.SendInfoMessage("/cw set [arena] <redspawn|bluespawn>");
                                player.SendInfoMessage("This sets the spawn of the respective team to your current location, for the specified arena.");
                                player.SendInfoMessage("This command can be abbreviated as \"/cw set [arena] <rs|bs>\"");
                                return;
                            }

                            if (parameters[2] == "arenabounds" || parameters[2] == "ab")
                            {
                                player.SendInfoMessage("/cw set [arena] arenabounds <1/2>");
                                player.SendInfoMessage("This command sets point 1 or 2 to the next block you break or place.");
                                player.SendInfoMessage("/cw set [arena] arenabounds define");
                                player.SendInfoMessage("This command sets the arena boundaries to the rectangle defined by points 1 and 2");
                                player.SendInfoMessage("These commands define the boundaries of a given arena, which is used to determine the number of blocks remaining in the bunker.");
                                player.SendInfoMessage("These commands can be abbreviated by replacing \"arenabounds\" with \"ab\"");
                                return;
                            }

                            if (parameters[2] == "spawn" || parameters[2] == "spawndelay")
                            {
                                player.SendInfoMessage("/cw set [arena] spawndelay <milliseconds>");
                                player.SendInfoMessage("This command specifies the delay in milliseconds between a player spawning and being teleported to the arena.");
                                player.SendInfoMessage("This cannot be smaller than 25 or larger than 20000");
                                player.SendInfoMessage("This command can be abbreviated by replacing \"spawndelay\" with \"spawn\" or \"s\"");
                                return;
                            }
                        }

                        player.SendInfoMessage("/cw set [arena] <host|redspawn|bluespawn|arenabounds|spawndelay>");
                        player.SendInfoMessage("This command is used to specify parameters for a given arena.");
                        player.SendInfoMessage("Use the following command for more detailed information:");
                        player.SendInfoMessage("/cw help set <host|redspawn|bluespawn|arenabounds|spawndelay>");
                        return;
                    }

                if (parameters[1] == "command" || parameters[1] == "com")
                {
                    player.SendInfoMessage("/cw command [arena] [command] [delay] [repeat]");
                    player.SendInfoMessage("This enables you to specify commands that should be run at the start of a game.");
                    player.SendInfoMessage("Ensure that the command parameter is in quotes.");
                    player.SendInfoMessage("\'%n\' will be replaced by the name of a person in the game and execute for every person playing.");
                    player.SendInfoMessage("\'%c:[class]\' will be replaced by the name of anyone playing [class] and execute for anyone with that class equipped.");
                    player.SendInfoMessage("[delay] is the time in seconds from the start of the game before the command executes.");
                    player.SendInfoMessage("[repeat] should be \"true\" or \"false\", and dictates if the command will be repeated, with [delay] seconds in between.");
                    return;
                }

                if (parameters[1] == "del")
                {
                    player.SendInfoMessage("/cw del [arena]");
                    player.SendInfoMessage("This command deletes the specified arena.");
                    player.SendInfoMessage("Permanently.");
                    player.SendInfoMessage("Use with caution.");
                    return;
                }

                if (parameters[1] == "goto")
                {
                    player.SendInfoMessage("/cw goto [arena]");
                    player.SendInfoMessage("This command teleports you to the host location of the specified arena.");
                    return;
                }

                if (parameters[1] == "spectate" || parameters[1] == "spec")
                {
                    player.SendInfoMessage("/cw spectate");
                    player.SendInfoMessage("This command toggles spectator mode.");
                    player.SendInfoMessage("Spectators are teleported to the host location of the arena.");
                    player.SendInfoMessage("They are also made invisible, prevented from enabling pvp, and included in score updates.");
                    return;
                }

                if (parameters[1] == "help")
                {
                    player.SendInfoMessage("/cw help");
                    player.SendInfoMessage("This command specifies command usage for Class Wars.");
                    player.SendInfoMessage("Bracket notation: <something|else> is to be replaced by either \"something\" or \"else\".");
                    player.SendInfoMessage("[name] is to be replaced by the name of the thing requested.");
                    return;
                }
            }
            #endregion

            #region Default Help
            player.SendErrorMessage("Aliases: /classwars, /cw");

            if (player.HasPermission("cw.start"))
                player.SendErrorMessage("/cw start [arena]");

            if (player.HasPermission("cw.add"))
            {
                player.SendErrorMessage("/cw add [arena]");
                player.SendErrorMessage("/cw set [arena] <host|redspawn|bluespawn|arenabounds|spawndelay>");
                player.SendErrorMessage("/cw command [arena] [command] [delay] [repeat]");
            }

            if (player.HasPermission("cw.del"))
                player.SendErrorMessage("/cw del [arena]");

            if (player.HasPermission("tshock.admin.warp"))
            {
                player.SendErrorMessage("/cw goto [arena]");
                player.SendErrorMessage("/cw spectate");
            }
            player.SendErrorMessage("/cw list");
            player.SendInfoMessage("Is this help command confusing? Just use this command for more help: \"/cw help help\"");
            #endregion
            return;
        }

        public static void AddArena(CommandArgs args)
        {
            TSPlayer player = args.Player;
            if (!player.HasPermission("cw.add"))
            {
                player.SendErrorMessage("You do not have permission to add arenas.");
                return;
            }

            if (args.Parameters.Count < 2)
            {
                DetailedCWHelp(args);
                return;
            }

            switch (args.Parameters[1])
            {
                case "none":
                    player.SendInfoMessage("\'None\' is reserved for internal plugin use.");
                    return;
                case "grandom":
                    player.SendInfoMessage("\'grandom\' is reserved for selecting random maps in the \'good\' category.");
                    return;
                case "crandom":
                    player.SendInfoMessage("\'crandom\' is reserved for selecting random maps in the \'crap\' category.");
                    return;
                case "random":
                    player.SendInfoMessage("\'random\' is reserved for selecting random maps.");
                    return;
            }

            Arenas arenas = new Arenas();

            args.Parameters.RemoveAt(0);
            string x = string.Join(" ", args.Parameters);
            if (arenas.Exists(x))
            {
                player.SendInfoMessage("There is already an arena named \'" + x + "\'.");
                return;
            }

            Arena tempArena = new Arena(x);
            player.SendInfoMessage("Arena " + x + " has been added. Please remember to assign all values with /cw set before playing.");
            arenas.Add(tempArena);
            return;
        }

        public static void DelArena(CommandArgs args)
        {
            TSPlayer player = args.Player;
            if (!player.HasPermission("cw.del"))
            {
                args.Player.SendErrorMessage("You do not have permission to delete arenas.");
                return;
            }

            if (args.Parameters.Count < 2)
            {
                DetailedCWHelp(args);
                return;
            }

            Arenas arenas = new Arenas();

            args.Parameters.RemoveAt(0);
            string x = string.Join(" ", args.Parameters);

            if (arenas.Exists(x))
            {
                arenas.Delete(x);
                player.SendInfoMessage("Arena " + x + " has been deleted. Forever. Can you live with yourself?");
                return;
            }

            player.SendInfoMessage("Arena " + x + " not found. Try using /cw list to check your spelling.");
            return;
        }

        public static void SetArena(CommandArgs args)
        {

        }
    }
}