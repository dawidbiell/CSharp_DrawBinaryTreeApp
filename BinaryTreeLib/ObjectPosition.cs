using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib
{
    public class ObjectPosition
    {
        private int _length=0;
        private int _startPosition=1;

        public ObjectPosition(int length)
        {
            _length = length;
        }

        public int StartPosition
        {
            get { return _startPosition; }
            set { _startPosition = value; }
        }

        public int EndPosition 
        { 
            get { return StartPosition + _length - 1; } 
        }
    }
}
