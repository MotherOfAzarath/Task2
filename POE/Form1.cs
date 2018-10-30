using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace POE
{
    //ahTh9
    //Tinyiko Mbenyane 18005615
    [Serializable]
    public partial class Form1 : Form
    {
        int Turn = 0;
        Random r = new Random();
        Map map = new Map(20, 20, 20);

        const int spacing = 20;
        const int Size = 20;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        private void DisplayMap()
        {
            groupBox1.Controls.Clear();
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(MeeleeUnit))
                {
                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    MeeleeUnit m = (MeeleeUnit)u;
                    PictureBox Pbox = new PictureBox();

                    Pbox.Size = new Size(Size, Size);
                    Pbox.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));
                    Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                    Pbox.ImageLocation = "ground.jpg";

                    if (m.Fact == 1)
                    {
                        Pbox.ImageLocation = "red.png";
                    }
                    else
                    {
                        Pbox.ImageLocation = "red.png";
                    }
                    if (m.isDead())
                    {
                        Pbox.ImageLocation = "ground.jpg";
                    }
                    groupBox1.Controls.Add(Pbox);
                    Pbox.Click += new EventHandler(Picture_Click);
                }

            }
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(RangedUnit))
                {
                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    RangedUnit m = (RangedUnit)u;
                    PictureBox Pbox = new PictureBox();

                    Pbox.Size = new Size(Size, Size);
                    Pbox.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));
                    Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                    Pbox.ImageLocation = "ground.jpg";

                    if (m.Fact == 1)
                    {

                        Pbox.ImageLocation = "purple.png";

                    }
                    else
                    {

                        Pbox.ImageLocation = "purple.png";
                    }
                    if (m.isDead())
                    {
                        Pbox.ImageLocation = "DirtGround.jpg";
                    }
                    groupBox1.Controls.Add(Pbox);
                    Pbox.Click += new EventHandler(Picture_Click);
                }

            }
        }
        private void UpdateMap()
        {
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(MeeleeUnit))
                {
                    MeeleeUnit m = (MeeleeUnit)u;

                    if (m.health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: ((MeeleeUnit)u).NewMovePos(Direction.North); break;
                            case 1: ((MeeleeUnit)u).NewMovePos(Direction.East); break;
                            case 2: ((MeeleeUnit)u).NewMovePos(Direction.South); break;
                            case 3: ((MeeleeUnit)u).NewMovePos(Direction.West); break;

                        }
                    }
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {

                            if (u.AttackRange(e))
                            {
                                u.Combat(e);
                                inCombat = true;
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = u.UnitDistance(map.Units);
                            m.NewMovePos(m.Directionto(c));
                        }

                    }

                }

            }
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(RangedUnit))
                {
                    RangedUnit m = (RangedUnit)u;

                    if (m.health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: ((RangedUnit)u).NewMovePos(Direction.North); break;
                            case 1: ((RangedUnit)u).NewMovePos(Direction.East); break;
                            case 2: ((RangedUnit)u).NewMovePos(Direction.South); break;
                            case 3: ((RangedUnit)u).NewMovePos(Direction.West); break;

                        }
                    }
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {

                            if (u.AttackRange(e))
                            {
                                u.Combat(e);
                                inCombat = true;
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = u.UnitDistance(map.Units);
                            m.NewMovePos(m.Directionto(c));
                        }

                    }

                }

            }
        }
        public void Picture_Click(object sender, EventArgs args)
        {
            int x = (((PictureBox)sender).Location.X - groupBox1.Location.X) / Size;
            int Y = (((PictureBox)sender).Location.Y - groupBox1.Location.Y) / Size;
            textBox2.Text = "Button Clicked at: " + ((PictureBox)sender).Location;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            UpdateMap();
            DisplayMap();
            textBox1.Text = (++Turn).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = true;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
        }

        private void save()
        {
            BinaryFormatter ef = new BinaryFormatter();
            FileStream fsout = new FileStream("save.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    ef.Serialize(fsout, map);
                    MessageBox.Show("Info Saved");
                }
            }
            catch (Exception except)
            {
                MessageBox.Show("Error" + except.Message);
            }
        }

        private void read()
        {
            BinaryFormatter ef = new BinaryFormatter();
            FileStream fsin = new FileStream("save.dat", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    ef.Serialize(fsin, map);
                    MessageBox.Show("Info Loaded");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            UpdateMap();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            read();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            save();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
