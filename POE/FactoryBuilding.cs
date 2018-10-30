using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE
{
    //ahTh9
    //Tinyiko Mbenyane 18005615
    class FactoryBuilding : Building
    {
        private int units;

        public int Units
        {
            get { return units; }
            set { units = value; }
        }
        private int rateProduction;

        public int RateProduction
        {
            get { return rateProduction; }
            set { rateProduction = value; }
        }
        private int spawnpt;

        public int SpawnPt
        {
            get { return spawnpt; }
            set { spawnpt = value; }
        }

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

        public FactoryBuilding(int X_position, int Y_position, int Health, int Faction, string image)
        {
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            Fact = Faction;
            Pic = image;

        }
        public override bool isDestoryed()
        {
            //if (Health <= 0)
            //{
            //    isDestoryed = true;
            //}
            //else 
            return false;
        }
        public override string ToString()
        {
            return units + ", " + spawnpt + ", " + Xpos + Ypos;
        }
        public void SpawnUnits()
        {
            throw new NotImplementedException();
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
