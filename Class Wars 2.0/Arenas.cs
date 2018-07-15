using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Wars_2._0
{
    class Arenas
    {
        private Database arena_db;
        private List<Arena> arenas;

        public Arenas()
        {
            arena_db = Database.InitDb("CWArenas");
            arena_db.LoadArenas(ref arenas);
        }

        public bool Exists(string name)
        {
            if (arenas.Select(a => a.name.ToLowerInvariant() == name.ToLowerInvariant()).Count() == 0)
                return false;
            return true;
        }

        public void Reload()
        {
            arenas.Clear();
            arena_db.LoadArenas(ref arenas);
        }

        public void Add(Arena a)
        {
            arena_db.AddArena(a);
        }
    }
}
