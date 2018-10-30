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
    public enum Direction { North, East, South, West }
    abstract class Unit
    {
        protected int X_position;
        protected int Y_position;
        protected int Health;
        protected int Speed;
        protected int Attack;
        protected int Attack_range;
        protected int Faction;
        protected string Image;
        protected string Unit_Type;

        public Unit() { }
        abstract public void NewMovePos(Direction direction);
        abstract public void Combat(Unit u);
        abstract public bool AttackRange(Unit u);
        abstract public Unit UnitDistance(Unit[] units);
        abstract public bool isDead();
        abstract public string ToString();
        abstract public void Save();
        abstract public void Read();
     
    }
}