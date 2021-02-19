using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_MLS.Models.Data
{
    public class ListOperations
    {
        public IEnumerable<PlayerModel> Search(IEnumerable<PlayerModel> list, Func<PlayerModel, bool> Comparer)
        {
            List<PlayerModel> result = new List<PlayerModel>();
            for(int i  = 0; i < list.Count(); i++)
            {
                if(Comparer.Invoke(list.ElementAt(i)))
                {
                    result.Add(list.ElementAt(i));
                }
            }
            return result;
        }
    }
}
