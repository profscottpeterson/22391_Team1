using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XAATArcade
{
    public partial class XAATArcade : Form
    {
        PictureBox title = new PictureBox();
        MenuButton setting = new MenuButton();
        MenuStrip settings = new MenuStrip();
        Button game1 = new Button();
        Button game2 = new Button();
        Button game3 = new Button();
        Button game4 = new Button();
        PictureBox fronts = new PictureBox();
        PictureBox backs = new PictureBox();
        int width = 70;
        int height = 110;
        int x = 10;
        int y = 10;
        List<PictureBox> backsList = new List<PictureBox>();
        List<PictureBox> frontList = new List<PictureBox>();

        public XAATArcade()
        {
            InitializeComponent();
        }

        private void XAATArcade_Load(object sender, EventArgs e)
        {
            CreateTitlePage();
        }

        private void CreateTitlePage()
        {
            //PictureBox title = new PictureBox();
            title.Location = new Point(50, 10);
            title.Size = new Size(100, 100);
            title.BackColor = Color.Aqua;
            this.Controls.Add(title);

            
            game1.Location = new Point(50, 120);
            game1.Size = new Size(50, 50);
            game1.Text = "Reflex";
            this.Controls.Add(game1);

            game2.Location = new Point(50, 180);
            game2.Size = new Size(50, 50);
            game2.Text = "Memory";
            this.Controls.Add(game2);

            game3.Location = new Point(50, 240);
            game3.Size = new Size(50, 50);
            this.Controls.Add(game3);

            game4.Location = new Point(50, 300);
            game4.Size = new Size(50, 50);
            this.Controls.Add(game4);

            game1.Click += (s, z) => { Reflex(s, z); };
            game2.Click += (s, z) => { Memory(s, z); };

            setting.Location = new Point(200, 50);
            setting.Size = new Size(50, 50);
            setting.BackColor = Color.Pink;
            this.Controls.Add(setting);

          //  settings.Location = new Point(300, 10);
          //  settings.Size = new Size(10, 10);
          //  settings.BackColor = Color.Green;
          //  this.Controls.Add(settings);
        }

        private void RemoveTitlePage()
        {
            this.Controls.Remove(title);
            this.Controls.Remove(game1);
            this.Controls.Remove(game2);
            this.Controls.Remove(game3);
            this.Controls.Remove(game4);
           // game1.Enabled = false;
        }

        private void Memory(object sender, EventArgs e)
        {
            RemoveTitlePage();




            for (int row = 0; row <= 3; row++)
            {
                for (int column = 0; column <= 4; column++)
                {

                    fronts = new PictureBox();
                    fronts.Location = new Point(x + (column * (width + 5)), y + (row * (height + 5)));
                    fronts.Size = new Size(width, height);
                    fronts.Name = row + " , " + column;
                    fronts.BackColor = Color.Black;
                    //fronts.SendToBack();
                    this.Controls.Add(fronts);

                    backs = new PictureBox();
                    backs.Location = new Point(x + (column * (width + 5)), y + (row * (height + 5)));
                    backs.Size = new Size(width, height);
                    backs.Name = row + " , " + column;
                    backs.BackColor = Color.Yellow;
                    backsList.Add(backs);
                    this.Controls.Add(backs);

                }
            }

            foreach (PictureBox x in backsList)
            {
                x.BringToFront();
                
            }


            foreach (PictureBox x in frontList)
            {


            }






        }








        private void Reflex(object sender, EventArgs e)
        {
            MessageBox.Show("3");
        }

    }
}
