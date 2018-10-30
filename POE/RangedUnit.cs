using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE
{
    //ahTh9
    //Tinyiko Mbenyane 18005615
    class RangedUnit : Unit
    {
        public int Xpos
        {
            get { return X_position; }
            set { X_position = value; }
        }
        public int Ypos
        {
            get { return Y_position; }
            set { Y_position = value; }
        }
        public int health
        {
            get { return Health; }
            set { Health = value; }
        }
        public int attack
        {
            get { return Attack; }
            set { Attack = value; }
        }
        public int attackRange
        {
            get { return Attack_range; }
            set { Attack_range = value; }
        }
        public int speed
        {
            get { return Speed; }
            set { Speed = value; }
        }
        public int Fact
        {
            get { return Faction; }
            set { Faction = value; }
        }
        public string Pic
        {
            get { return Image; }
            set { Image = value; }
        }

        private string unitType;

        public string UnitType
        {
            get { return unitType; }
            set { unitType = value; }
        }

        public RangedUnit(int X_position, int Y_position, int Health, int Attack, int Speed, int Attack_range, int Faction, string image, string type)
        {
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            attack = Attack;
            speed = Speed;
            attackRange = Attack_range;
            Fact = Faction;
            Pic = image;
            unitType = type;
        }


        public override void NewMovePos(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    {
                        Ypos -= Speed;
                        break;
                    }
                case Direction.East:
                    {
                        Xpos += Speed;
                        break;
                    }
                case Direction.South:
                    {
                        Ypos += Speed;
                        break;
                    }
                case Direction.West:
                    {
                        Xpos -= Speed;
                        break;
                    }
            }


        }
        public override void Combat(Unit u)
        {
            if (u.GetType() == typeof(RangedUnit))
            {
                Health -= ((RangedUnit)u).Attack;
            }

        }
        public override bool AttackRange(Unit u)
        {
            if (u.GetType() == typeof(RangedUnit))
            {
                RangedUnit M = (RangedUnit)u;
                if (DistanceTo(u) <= attackRange)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public override Unit UnitDistance(Unit[] units)
        {
            Unit closest = this;
            int closestDist = 50;
            foreach (Unit u in units)
            {
                if (((MeeleeUnit)u).Fact != Fact)
                {
                    if (DistanceTo((MeeleeUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo((MeeleeUnit)u);
                    }
                }
                if (u.GetType() == typeof(MeeleeUnit))
                {
                    if (DistanceTo((MeeleeUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
                else if (u.GetType() == typeof(RangedUnit))
                {
                    if (DistanceTo((RangedUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
            }

            return closest;

        }
        public override bool isDead()
        {
            if (Health < 1)
            {
                return true;
            }
            else

                return false;

        }
        public override string ToString()
        {
            return "RU:  " + Xpos + "," + Ypos + "," + Health + "," + Unit_Type;
        }
        private int DistanceTo(Unit u)
        {
            if (u.GetType() == typeof(RangedUnit))
            {
                RangedUnit m = (RangedUnit)u;
                int d = Math.Abs(Xpos - m.Xpos) + Math.Abs(Ypos - m.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }
        public Direction Directionto(Unit u)
        {
            if (u.GetType() == typeof(RangedUnit))
            {
                RangedUnit m = (RangedUnit)u;
                if (m.Xpos < Xpos)
                {
                    return Direction.North;
                }
                else if (m.Xpos > Xpos)
                {
                    return Direction.South;
                }
                else if (m.Ypos < Ypos)
                {
                    return Direction.West;
                }
                else
                {
                    return Direction.East;
                }
            }
            else
            {
                return Direction.North;
            }

        }
        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Read()
        {
            throw new NotImplementedException();
        }
    }
}
