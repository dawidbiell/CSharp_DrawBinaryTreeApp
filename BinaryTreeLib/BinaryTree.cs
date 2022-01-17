using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib
{

    public class BinaryTree
    {
        private int _levels;
        private ObjectModel _treeRoot = new ObjectModel();
        private Dictionary<int, List<ObjectModel>> _levelsDictionary = new Dictionary<int, List<ObjectModel>>();

        public int Levels { get => _levels; }
        public ObjectModel TreeRoot { get => _treeRoot; }


        public BinaryTree(int levels)
        {
            _levels = levels;
            _treeRoot = CreateTree(null, 1, _levels);
            AddObjectToDic(_levelsDictionary, _treeRoot);
        }

        private ObjectModel CreateTree(ObjectModel? parentId, int level, int levels)
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

        public void AddObjectToDic(Dictionary<int, List<ObjectModel>> dic, ObjectModel objectModel)
        {
            List<ObjectModel> list;

            bool containsKey = dic.ContainsKey(objectModel.Level);
            if (!containsKey)
            {
                list = new List<ObjectModel>();
                list.Add(objectModel);

                dic.Add(objectModel.Level,list);
            }
            else
            {
                list = dic[objectModel.Level];
                list.Add(objectModel);
            }

            if (objectModel.RightChild != null)
                AddObjectToDic(dic, objectModel.RightChild);

            if(objectModel.LeftChild != null)
                AddObjectToDic(dic,objectModel.LeftChild);
        }
    }
}

