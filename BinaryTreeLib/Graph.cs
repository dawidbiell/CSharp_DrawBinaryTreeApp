using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib
{
    public static class Graph
    {
        private static int _levels;
        private static Dictionary<Guid, ObjectModel> _objectDictionary = new Dictionary<Guid, ObjectModel>();

        public static int Levels { get => _levels; }
        //public static Dictionary<Guid, ObjectModel> ObjectDictionary { get => _objectDictionary; }


        public static void CreateGraphTree(int levels)
        {
            _levels = levels;

            for (int level = 0; level < levels; level++)
            {

            }


        }

        private static void CreateObject(Guid parentId,int level)
        {

        }
    }
}
