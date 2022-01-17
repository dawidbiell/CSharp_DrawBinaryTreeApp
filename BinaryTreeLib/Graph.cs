using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib
{
    public class Graph
    {
        private int _levels;
        private Dictionary<int, List<ObjectModel>> _objectDictionary;
        private ObjectModel treeRoot;

        public int Levels { get => _levels; }
        public Dictionary<int, List<ObjectModel>> ObjectDictionary { get => _objectDictionary; }

        public void CreateTree(int levels)
        {
            _levels = levels;
            _objectDictionary = new Dictionary<int, List<ObjectModel>>();

            treeRoot = new ObjectModel();
            treeRoot = CreateObject(null, 1, _levels);
        }

        private ObjectModel CreateObject(ObjectModel? parentId, int level, int levels)
        {
            ObjectModel output = new ObjectModel();
            Random random = new Random();

            output.Id = Guid.NewGuid();
            output.Caption = random.Next(1, 99).ToString();
            output.Parent = parentId;
            output.Level = level;

            if (level <= levels)
            {
                ObjectModel leftChild = new ObjectModel();
                leftChild = CreateObject(output, level + 1, levels);

                ObjectModel rightChild = new ObjectModel();
                rightChild = CreateObject(output, level + 1, levels);

                output.LeftChild = leftChild;
                output.RightChild = rightChild;

            }
            return output;
        }
    }
}
