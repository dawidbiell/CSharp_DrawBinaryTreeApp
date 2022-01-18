using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib
{
    public class ObjectModel
    {

        private string _caption;
        public Guid Id { get; set; }
        
        public ObjectModel? Parent { get; set; }
        public ObjectModel? LeftChild { get; set; }
        public ObjectModel? RightChild { get; set; }
        public int Level { get; set; }
        public ObjectPosition? Position { get; set; }

        public string Caption 
        { 
            get { return $"[{_caption}]"; }
            set { _caption = value; }
        }

        public int Length
        {
            get { return Caption.Length; }
        }

        public override string ToString()
        {
            return $"[{Caption}]";
        }
    }
}
