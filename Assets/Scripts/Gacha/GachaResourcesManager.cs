using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;

namespace Krevechous.Gacha
{
    public class GachaResourcesManager
    {
        public List<GachaObject> LoadNotObtainedObjects()
        {
            List<GachaObject> gachas = Resources.LoadAll<GachaObject>("Gacha").Where(t => t.Obtained == false).ToList();
            return gachas;
        }
    }
}