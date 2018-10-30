using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE
{
    //ahTh9
    //Tinyiko Mbenyane 18005615
    class ResourceBuilding : Building
    {
        private int iron;

        public int Iron
        {
            get { return iron; }
            set { iron = value; }
        }
        private int rate;

        public int Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        private int remaining;

        public int Remaining
        {
            get { return remaining; }
            set { remaining = value; }
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

        public ResourceBuilding(int X_position, int Y_position, int Health, int Faction, string image)
        {
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            Fact = Faction;
            Pic = image;

        }
        public override bool isDestoryed()
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
            return Iron + ", " + Remaining + ", " + Rate + ", " + Xpos + Ypos;
        }
        public void GenerateResources()
        {
            Random r = new Random();
            int resourceTotal = r.Next(1, 100);
            bool isUsedUp = false;
        
            while (resourceTotal != 0)
            {
                resourceTotal = resourceTotal - iron;
                    if (resourceTotal <= 0)
                    {
                       isUsedUp = true;
                    }
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
