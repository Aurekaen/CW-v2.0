using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Wars_2._0
{
    class Buff
    {
        protected int id, duration;

        public Buff(int id, int duration)
        {
            this.id = id;
            this.duration = duration;
        }
    }

    class ItemBuff : Buff
    {
        internal int item;

        public ItemBuff(int id, int duration, int item) : base(id, duration)
        {
            this.item = item;
        }
    }

    class AmmoRegen
    {
        internal int refresh, item, quantity, maxCount, prefix;

        public AmmoRegen(int refresh, int item, int quantity, int maxCount, int prefix)
        {
            this.refresh = refresh;
            this.item = item;
            this.quantity = quantity;
            this.maxCount = maxCount;
            this.prefix = prefix;
        }
    }
}
