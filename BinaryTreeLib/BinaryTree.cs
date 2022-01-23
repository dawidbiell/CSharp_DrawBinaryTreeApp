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
        }

        public void Draw()
        {
            _treeRoot = CreateTree(null, 1, _levels);
            AddObjectToDic(_levelsDictionary, _treeRoot);

            Console.WriteLine("Tree objects:");
            DrawBinaryTreeObjects();

            int offset = 0;
            UpdateChildsPosition(_treeRoot, ref offset);

            Console.WriteLine("Tree figure:");
            DrawBinaryTreeFigure(offset);
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

        private void DrawBinaryTreeObjects()
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

        private void DrawBinaryTreeFigure(int lineLength)
        {
            StringBuilder output = new StringBuilder();
            string objLine;
            string branchLine;

            for (int level = _levels; level > 0; level--)
            {
                var list = _levelsDictionary[level];
                objLine = DrawObjectLine(list, lineLength);
                output.Insert(0, objLine);
                branchLine = DrawBranchLines(list, lineLength);
                output.Insert(0, branchLine);
            }

            Console.WriteLine(output.ToString());
        }
        private string DrawObjectLine(List<ObjectModel> list, int lineLength)
        {
            StringBuilder line = new StringBuilder();
            line.Insert(0, " ", lineLength);

            foreach (var obj in list)
            {
                line.Insert(obj.Position.StartPosition, obj.Caption);
            }
            line.AppendLine();

            return line.ToString();
        }
        private string DrawBranchLines(List<ObjectModel> list, int lineLength)
        {
            StringBuilder branchLines = new StringBuilder();
            bool lastBanchLine = true;
            int startPosition;
            int endPosition;
            int offset = 0;

            do
            {
                StringBuilder line = new StringBuilder();
                line.Insert(0, " ", lineLength);

                foreach (var obj in list)
                {
                    if (obj.Parent == null) continue;

                    if (obj.IsLeftChild)
                    {
                        startPosition = obj.Position.EndPosition + offset;
                        endPosition = obj.Parent.Position.StartPosition;

                        line.Insert(startPosition, @"/");
                        lastBanchLine = startPosition - endPosition == 0;
                    }

                    if (obj.IsRightChild)
                    {
                        startPosition = obj.Position.StartPosition - offset;
                        endPosition = obj.Parent.Position.EndPosition;

                        line.Insert(startPosition, @"\");
                        lastBanchLine = startPosition - endPosition == 0;
                    }
                }

                branchLines.Insert(0, line.AppendLine().ToString());

                offset++;

            } while (!lastBanchLine);

            return branchLines.ToString();
        }

        





    }
}

