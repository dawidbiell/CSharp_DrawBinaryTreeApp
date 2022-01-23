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
        private NodeModel _treeRoot = new NodeModel();
        private Dictionary<int, List<NodeModel>> _levelsDictionary = new Dictionary<int, List<NodeModel>>();

        public int Levels { get => _levels; }
        public NodeModel TreeRoot { get => _treeRoot; }

        public BinaryTree(int levels)
        {
            _levels = levels;
        }

        public void Draw()
        {
            _treeRoot = CreateTree(null, 1, _levels);
            AddObjectToDic(_levelsDictionary, _treeRoot);

            Console.WriteLine("Tree nodes:");
            DrawBinaryTreeNodes();

            int offset = 0;
            UpdateChildsPosition(_treeRoot, ref offset);

            Console.WriteLine("Tree figure:");
            DrawBinaryTreeFigure(offset);
        }

        private NodeModel CreateTree(NodeModel? parent, int level, int levels)
        {
            NodeModel output = new NodeModel();
            Random random = new Random();
            bool addLeftChild;
            bool addRightChild;

            output.Id = Guid.NewGuid();
            output.Caption = random.Next(1, 99).ToString();
            output.Parent = parent;
            output.Level = level;
            output.Position = new NodePosition(output.Caption.Length);

            if (level < levels)
            {
                NodeModel leftChild = new NodeModel();
                leftChild = CreateTree(output, level + 1, levels);

                NodeModel rightChild = new NodeModel();
                rightChild = CreateTree(output, level + 1, levels);

                output.LeftChild = leftChild;
                output.RightChild = rightChild;
            }
            return output;
        }

        private void AddObjectToDic(Dictionary<int, List<NodeModel>> dic, NodeModel objectModel)
        {
            List<NodeModel> list;

            bool containsKey = dic.ContainsKey(objectModel.Level);
            if (!containsKey)
            {
                list = new List<NodeModel>();
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

        private void UpdateChildsPosition(NodeModel me, ref int offset)
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

        private void DrawBinaryTreeNodes()
        {
            StringBuilder output = new StringBuilder();

            for (int level = _levels; level > 0; level--)
            {
                StringBuilder line = new StringBuilder();

                var list = _levelsDictionary[level];
                foreach (var node in list)
                {
                    line.Append(node.Caption);
                }
                line.AppendLine();
                output.Insert(0, line.ToString());
            }
            Console.WriteLine(output.ToString());
        }

        private void DrawBinaryTreeFigure(int lineLength)
        {
            StringBuilder output = new StringBuilder();
            string nodeLine;
            string branchLine;

            for (int level = _levels; level > 0; level--)
            {
                var list = _levelsDictionary[level];
                nodeLine = DrawNodeLine(list, lineLength);
                output.Insert(0, nodeLine);
                branchLine = DrawBranchLines(list, lineLength);
                output.Insert(0, branchLine);
            }
            Console.WriteLine(output.ToString());
        }
        private string DrawNodeLine(List<NodeModel> list, int lineLength)
        {
            StringBuilder line = new StringBuilder();
            line.Insert(0, " ", lineLength);

            foreach (var node in list)
            {
                line.Insert(node.Position.StartPosition, node.Caption);
            }
            line.AppendLine();

            return line.ToString();
        }
        private string DrawBranchLines(List<NodeModel> list, int lineLength)
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

                foreach (var node in list)
                {
                    if (node.Parent == null) continue;

                    if (node.IsLeftChild)
                    {
                        startPosition = node.Position.EndPosition + offset;
                        endPosition = node.Parent.Position.StartPosition;

                        line.Insert(startPosition, @"/");
                        lastBanchLine = startPosition - endPosition == 0;
                    }

                    if (node.IsRightChild)
                    {
                        startPosition = node.Position.StartPosition - offset;
                        endPosition = node.Parent.Position.EndPosition;

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

