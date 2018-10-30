using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace POE
{
    //ahTh9
    //Tinyiko Mbenyane 18005615
    [Serializable]
    class Map
    {
        private Unit[] units;
        Random r = new Random();

        public Unit[] Units
        {
            get { return units; }
            set { units = value; }
        }

        public Map(int maxX, int maxY, int numUnits)
        {
            units = new Unit[numUnits];
            for (int i = 0; i < numUnits; i++)
            {


                if (i <= 10)
                {
                    MeeleeUnit M = new MeeleeUnit(r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, r.Next(5, 20), 1, 1, i % 2, "ground.jpg", "archer");
                    Units[i] = M;
                }


                if (i > 10)
                {
                    RangedUnit R = new RangedUnit(r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, r.Next(5, 20), 1, 1, i % 2, "ground.jpg", "archer");
                    Units[i] = R;
                }
            }

        }
    }
}
