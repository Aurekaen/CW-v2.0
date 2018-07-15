using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Wars_2._0
{
    public class Arena
    {
        internal string name;
        internal Vector2 host;
        internal Vector2 rSpawn, bSpawn, arenaTopL, arenaBottomR, switchPos;

    public Arena(string name, Vector2 host, Vector2 rSpawn, Vector2 bSpawn, Vector2 arenaTopL, Vector2 arenaBottomR, Vector2 switchPos)
        {
            this.name = name;
            this.host = host;
            this.rSpawn = rSpawn;
            this.bSpawn = bSpawn;
            this.arenaTopL = arenaTopL;
            this.arenaBottomR = arenaBottomR;
            this.switchPos = switchPos;
        }
    }

}
