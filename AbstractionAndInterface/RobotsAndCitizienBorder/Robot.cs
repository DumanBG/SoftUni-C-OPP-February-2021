using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Robot : IRobot, IIdentifiable
    {
        private string id;
        private string model;

        public Robot(string id, string model)
        {
            this.Id = id;
            this.Model = model;
        }
        public string Id { get => this.id; private set => this.id = value; }

        public string Model { get => this.model; private set => this.model = value; }

    }
}
