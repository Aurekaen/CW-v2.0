using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TShockAPI;

namespace Class_Wars_2._0
{
    public static class Utils
    {
        public static Dictionary<string, int> Colors;
        public static int bluePaintID, redPaintID;

        public static void OnInit()
        {
            Colors.Add("blank", 0);

            var item = new Item();
            for (int i = -48; i < Main.maxItemTypes; i++)
            {
                item.netDefaults(i);
                if (item.paint > 0)
                    Colors.Add(item.Name.Substring(0, item.Name.Length - 6).ToLowerInvariant(), item.paint);
            }

            bluePaintID = GetColorID("blue");
            redPaintID = GetColorID("red");
        }

        public static int GetColorID(string color)
        {
            int ID = -1;
            if (int.TryParse(color, out ID) && ID >= 0 && ID < Main.numTileColors)
                return ID;

            foreach(var kvp in Colors)
            {
                if (kvp.Key == color)
                    return kvp.Value;
                if (kvp.Key.StartsWith(color))
                {
                    if (ID == -1)
                        ID = kvp.Value;
                    else
                        return -1; //Multiple matches
                }
            }
            return ID;
        }
    }
}
