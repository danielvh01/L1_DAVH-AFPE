using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_MLS.Models.Data
{

        public sealed class Singleton
        {
            private readonly static Singleton _instance = new Singleton();
            public List<PlayerModel> PlayersList;
            private Singleton()
            {
                PlayersList = new List<PlayerModel>();
            }

            public static Singleton Instance
            {
                get
                {
                    return _instance;
                }
            }

        }
}
