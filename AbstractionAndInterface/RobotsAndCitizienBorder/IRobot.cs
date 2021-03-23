using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IRobot
    {
        public string Id { get; }
        public string Model { get;  }
    }
}
