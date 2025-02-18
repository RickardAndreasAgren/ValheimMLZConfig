using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MonsterLabZConfig
{
    public static class Utils
    {
        public static IEnumerable<GameObject> ChildrenOfGameObject(GameObject gObject)
        {
            List<GameObject> kids = new();
            int count = gObject.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                kids.Add(gObject.transform.GetChild(i).gameObject);
            }
            return kids;
        }
    }
}
