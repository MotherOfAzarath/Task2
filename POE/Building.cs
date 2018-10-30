using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace POE
{
    //ahTh9
    //Tinyiko Mbenyane 18005615
    [Serializable]
    public abstract class Building
    {
        protected int X_position;
        protected int Y_position;
        protected int Health;
        protected int Speed;
        protected int Faction;
        protected string Image;

        public Building() { }

        abstract public bool isDestoryed();
        abstract public string ToString();
        abstract public void Save();
        abstract public void Read();
    }
}
