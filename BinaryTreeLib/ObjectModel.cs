using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib
{
    public class ObjectModel
    {
        public Guid Id { get; set; }
        public string Caption { get; set; }
        public ObjectModel? Parent { get; set; }
        public ObjectModel? LeftChild { get; set; }
        public ObjectModel? RightChild { get; set; }
        public int Level { get; set; }
    }
}
