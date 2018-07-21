using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShockAPI;

namespace Class_Wars_2._0
{
    public class PlayerInfo
    {
        internal int UserID;
        public Classvar Class;
        public bool team; //false for blue, true for red

        public PlayerInfo(int uid)
        {
            UserID = uid;
        }

        public TSPlayer Player()
        {
            return TShock.Players[UserID];
        }

        public void Teleport(Vector2 coords)
        {
            Player().Teleport(coords.X * 16, coords.Y * 16);
        }

        public void AssignTeam(bool t)
        {
            team = t;
        }

    }
}
