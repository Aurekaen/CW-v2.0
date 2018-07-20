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
            if (arenas.FindAll(a => a.name.ToLowerInvariant() == name.ToLowerInvariant()).Count() == 0)
                return false;
            return true;
        }

        public bool Get(string name, ref Arena a)
        {
            if (Exists(name))
            {
                a = arenas.FindAll(x => x.name.ToLowerInvariant() == name.ToLowerInvariant()).ToList()[0];
                return true;
            }
            return false;
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

        public void Delete(string a)
        {
            GoodDelete(a);
        }

        private void GoodDelete(string x) //Makes sure capitalization matches what's in the 
        {
            List<Arena> _arenas = arenas.FindAll(a => a.name.ToLowerInvariant() == x.ToLowerInvariant());
            if (_arenas.Count > 0)
                arena_db.DeleteArenaByName(_arenas[0].name);
        }

        public void Update(Arena a)
        {
            arena_db.UpdateArena(a);
        }
    }
}
