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
            UpdateChildsPosition(_treeRoot,0);
        }

        private ObjectModel CreateTree(ObjectModel? parent, int level, int levels)
        {
            ObjectModel output = new ObjectModel();
            Random random = new Random();

            output.Id = Guid.NewGuid();
            output.Caption = random.Next(1, 99).ToString();
            output.Parent = parent;
            output.Level = level;
            output.Position = new ObjectPosition(output.Caption.Length);

            if (level < levels)
            {
                ObjectModel leftChild = new ObjectModel();
                leftChild = CreateTree(output, level + 1, levels);

                ObjectModel rightChild = new ObjectModel();
                rightChild = CreateTree(output, level + 1, levels);

                output.LeftChild = leftChild;
                output.RightChild = rightChild;

            }


            return output;
        }

        private void AddObjectToDic(Dictionary<int, List<ObjectModel>> dic, ObjectModel objectModel)
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

            if(objectModel.LeftChild != null)
                AddObjectToDic(dic,objectModel.LeftChild);
            
            if (objectModel.RightChild != null)
                AddObjectToDic(dic, objectModel.RightChild);

            
        }


        private void UpdateChildsPosition(ObjectModel parent, int offset)
        {

            if (parent.LeftChild != null)
            {
                parent.LeftChild.Position.StartPosition = +offset;
                UpdateChildsPosition(parent.LeftChild, offset);
            }
            else
            {
                parent.Position.StartPosition = +offset;
                offset = parent.Caption.Length - 1;
                UpdateParentsPosition(parent, offset);
            }

            if (parent.RightChild != null)
            {
                parent.RightChild.Position.StartPosition = +offset;
                UpdateChildsPosition(parent.RightChild, offset);
            }
            else
            {
                parent.Position.StartPosition = +offset;
                offset = parent.Caption.Length - 1;
                UpdateParentsPosition(parent, offset);
            }
        }

        private void UpdateParentsPosition(ObjectModel child, int offset)
        {
            if (child.Parent == null) return;

            if (child.IsLeftChild)
            {
                child.Parent.Position.StartPosition =+ offset;

            }

            UpdateParentsPosition(child.Parent, offset);

        }

        public string DrawBinaryTreeFigure()
        {
            StringBuilder output = new StringBuilder();
            int firstCharPosition;
            int lastCharPosition;
            int spacesCount;

            for (int level = _levels; level > 0; level--)
            {
                StringBuilder line = new StringBuilder();

                var list = _levelsDictionary[level];
                foreach (var obj in list)
                {
                    line.Insert(obj.Position.StartPosition, obj.Caption);
                }
                line.AppendLine();
                output.Insert(0, line.ToString());
                //Console.WriteLine(line.ToString());
            }


            return output.ToString();
        }


        

    }
}

