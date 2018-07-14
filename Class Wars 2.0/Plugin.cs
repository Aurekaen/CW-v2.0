using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace Class_Wars_2._0
{
    public class ClassWars : TerrariaPlugin
    {
        public override string Name { get { return "ClassWars 2.0"; } }
        public override string Author { get { return "Alec"; } }
        public override string Description { get { return "Automatic Class Wars hosting plugin."; } }
        public override Version Version { get { return new Version(1, 0, 0, 0); } }

        public ClassWars(Main game) : base(game)
        {
            Order = 10;
        }

        public override void Initialize()
        {
            ServerApi.Hooks.NetGetData.Register(this, OnGetData);
            ServerApi.Hooks.ServerLeave.Register(this, OnPlayerLeave);
            ServerApi.Hooks.GameUpdate.Register(this, OnUpdate);
            ServerApi.Hooks.NetGreetPlayer.Register(this, OnGreet);

            Commands.ChatCommands.Add(new Command("cw.main", CW, "cw", "classwars"));
            Commands.ChatCommands.Add(new Command("CS.main", CSelect, "class", "cs"));
        }

        #region Hooks
        private void OnGreet(GreetPlayerEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void OnUpdate(EventArgs args)
        {
            throw new NotImplementedException();
        }

        private void OnPlayerLeave(LeaveEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void OnGetData(GetDataEventArgs args)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CW Command
        public void CW(CommandArgs args)
        {
            TSPlayer player = args.Player;
            if (args.Parameters.Count == 0 || args.Parameters[0].ToLowerInvariant() == "help")
            {
                CWCommand.DetailedCWHelp(args);
                return;
            }
            if (args.Parameters[0] == "add")
            {
                CWCommand.AddArena(args);
                return;
            }

        }
        #endregion

        #region ClassSelect Command
        public void CSelect(CommandArgs args)
        {

        }
        #endregion
    }
}
