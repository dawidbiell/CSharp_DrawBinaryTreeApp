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
        private string _treeFigure;
        private ObjectModel _treeRoot = new ObjectModel();
        private Dictionary<int, List<ObjectModel>> _levelsDictionary = new Dictionary<int, List<ObjectModel>>();

        public int Levels { get => _levels; }
        public string TreeFigure { get => _treeFigure; }
        public ObjectModel TreeRoot { get => _treeRoot; }


        public BinaryTree(int levels)
        {
            _levels = levels;
            _treeRoot = CreateTree(null, 1, _levels);
            AddObjectToDic(_levelsDictionary, _treeRoot);

            DrawBinaryTreeFigure();

            int offset = 0;
            UpdateChildsPosition(_treeRoot, ref offset);

            _treeFigure = DrawBinaryTreeFigure(offset);

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

                dic.Add(objectModel.Level, list);
            }
            else
            {
                list = dic[objectModel.Level];
                list.Add(objectModel);
            }

            if (objectModel.LeftChild != null)
                AddObjectToDic(dic, objectModel.LeftChild);

            if (objectModel.RightChild != null)
                AddObjectToDic(dic, objectModel.RightChild);


        }


        private void UpdateChildsPosition(ObjectModel me, ref int offset)
        {

            if (me.LeftChild != null)
            {
                UpdateChildsPosition(me.LeftChild, ref offset);
            }
            me.Position.StartPosition = offset;
            offset = me.Position.EndPosition;

            if (me.RightChild != null)
            {
                UpdateChildsPosition(me.RightChild, ref offset);
            }
        }

        public string DrawBinaryTreeFigure(int lineLength)
        {
            StringBuilder output = new StringBuilder();
            string check;

            for (int level = _levels; level > 0; level--)
            {
                StringBuilder line = new StringBuilder();
                line.Insert(0, " ", lineLength);
                check = line.ToString();

                var list = _levelsDictionary[level];
                foreach (var obj in list)
                {
                    line.Insert(obj.Position.StartPosition, obj.Caption);
                    check = line.ToString();
                }
                line.AppendLine();
                output.Insert(0, line.ToString());
            }


            return output.ToString();
        }

        public void DrawBinaryTreeFigure()
        {
            StringBuilder output = new StringBuilder();

            for (int level = _levels; level > 0; level--)
            {
                StringBuilder line = new StringBuilder();

                var list = _levelsDictionary[level];
                foreach (var obj in list)
                {
                    line.Append(obj.Caption);
                }
                line.AppendLine();
                output.Insert(0, line.ToString());
            }


            Console.WriteLine(output.ToString());
        }




    }
}

