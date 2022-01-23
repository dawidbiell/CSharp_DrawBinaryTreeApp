using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib
{
    public class NodeModel
    {

        private string _caption;
        public Guid Id { get; set; }

        public NodeModel? Parent { get; set; }
        public NodeModel? LeftChild { get; set; }
        public NodeModel? RightChild { get; set; }
        public int Level { get; set; }
        public NodePosition Position { get; set; }

        public string Caption
        {
            get { return $"[{_caption}]"; }
            set { _caption = value; }
        }

        //public int Length
        //{
        //    get { return Caption.Length; }
        //}
        public bool IsLeftChild
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.LeftChild == this;
                }
                else { return false; }
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.RightChild == this;
                }
                else { return false; }

            }
        }

        public override string ToString()
        {
            return $"[{Caption}]";
        }
    }
}



