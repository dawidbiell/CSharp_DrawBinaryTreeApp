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
        public Guid Parent { get; set; }
        public Guid LeftChild { get; set; }
        public Guid RightChild { get; set; }
        public int Level { get; set; }
    }
}
