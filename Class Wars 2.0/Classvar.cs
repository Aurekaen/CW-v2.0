using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShockAPI;

namespace Class_Wars_2._0
{
    class Classvar
    {
        public string name, category;
        public NetItem[] inventory;
        internal List<string> description;
        internal int maxHealth, maxMana;
        internal int? extraSlot;
        internal List<Buff> buffs;
        internal List<ItemBuff> itemBuffs;
        internal List<AmmoRegen> ammoRegens;
        
        public Classvar(string name, string category, NetItem[] inventory, List<string> description, int maxHealth, int maxMana, int? extraSlot, List<Buff> buffs, List<ItemBuff> itemBuffs, List<AmmoRegen> ammoRegens)
        {
            this.name = name;
            this.category = category;
            this.inventory = inventory;
            this.description = description;
            this.maxHealth = maxHealth;
            this.maxMana = maxMana;
            this.extraSlot = extraSlot;
            this.buffs = buffs;
            this.itemBuffs = itemBuffs;
        }
    }
}
