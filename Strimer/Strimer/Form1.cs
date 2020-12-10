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
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Media;
using WMPLib;

namespace Strimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 20;            
        }

        private int angle = 1;
        Timer timer;
        int number = 50;
        int period = 0;
        
    
        private void timer_Tick(object sender, EventArgs e)
        {
            period++;
            if (period < 100)
            angle += number;
            if (period >= 100 && period <= 130)
            {
                angle +=10 ;                          
            }

            if (period >= 130 && period <= 160)
            {
                angle += 5;
            }
            if (period >= 161 && period <= 190)
            {
                angle += 2;
            }

            pictureBox1.Invalidate();
            if (period > 190)
            {

                ShowName();
                timer.Enabled = false;
                
                PlayEndSound();
                //player.URL = "SoundEnd.mp3";
                //player.settings.setMode("loop", false);
                //player.controls.play();
            }
        }

        private void PlayEndSound()
        {
            byte[] b = Properties.Resources.SoundEnd;
            FileInfo fileInfo = new FileInfo("3.mp3");
            FileStream fs = fileInfo.OpenWrite();
            fs.Write(b, 0, b.Length);
            fs.Close();
            player.settings.setMode("loop", false);
            player.URL = fileInfo.Name;
            player.controls.play();
        }

        // Воспроизведение звуков.
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        private void PlaySound()
        {
            byte[] b = Properties.Resources.Rotate;
            
            FileInfo fileInfo = new FileInfo("Rotate.mp3");
            try
            {
                FileStream fs = fileInfo.OpenWrite();
                fs.Write(b, 0, b.Length);
                fs.Close();
                player.URL = fileInfo.Name;
                player.settings.setMode("loop", true);
            }
            catch (System.IO.IOException)
            {
                ;
            }
           
            player.controls.play();
        }
        PictureBox picture;
        private void ShowName()
        {
            picture = new PictureBox();
            picture.BackColor = System.Drawing.Color.FromArgb(20, System.Drawing.Color.Black);
            picture.Paint += new PaintEventHandler(picture_Paint);
            picture.Width = 600;
            picture.Height = 600;
            picture.Top = 0;
            picture.Left = 0;
            #region
            // Label lbName = new Label();          
            // lbName.Width = picture.Width+100;
            //lbName.BackColor = System.Drawing.Color.FromArgb(150, System.Drawing.Color.Black);
            //lbName.Height = 100;
            //lbName.ForeColor = System.Drawing.Color.White;
            //lbName.TextAlign = ContentAlignment.MiddleLeft;
            //lbName.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
            //lbName.Text = "                            " + ReadLines("Names.csv") ;

            //lbName.Left = 0 ;
            //lbName.Top = picture.Height / 2 - 100;
            // picture.Controls.Add(lbName);
            #endregion
            

            pictureBox1.Controls.Add(picture);            
        }
        string name = "";
        private void picture_Paint(object sender, PaintEventArgs e)
        {
          
            var br = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, 
                System.Drawing.Color.Empty,  System.Drawing.Color.Empty, 
                LinearGradientMode.Vertical);

            var cb = new ColorBlend(3);
            cb.Positions = new float[] { 0f, 0.4f, 1f };
            cb.Colors = new System.Drawing.Color[] {
           System.Drawing.Color.FromArgb(100,System.Drawing.Color.Black),
           System.Drawing.Color.Black,
           System.Drawing.Color.FromArgb(100, System.Drawing.Color.Black) };
            br.InterpolationColors = cb;
            e.Graphics.FillRectangle(br, ClientRectangle);
            Font font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
           
            if (haveClick)
            {
                name = ReadLines("Names.csv");
                ToCenterName(name, e, font);
                
            }
           else
            {
                ToCenterName(name, e, font);
            }

            haveClick = false;
            



        }

        private void ToCenterName(string name, PaintEventArgs e, Font font)
        {
            switch (name.Length )
            {
                case 1:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 78, picture.Height / 2 - 67);
                        break;
                    }
                case 2:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 68, picture.Height / 2 - 67);
                        break;
                    }

                case 3:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 70, picture.Height / 2 - 67);
                        break;
                    }

                case 4:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 72, picture.Height / 2 - 67);
                        break;
                    }
                case 5:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 76, picture.Height / 2 - 67);
                        break;
                    }
                case 6:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 80, picture.Height / 2 - 67);
                        break;
                    }

                case 7:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 84, picture.Height / 2 - 67);
                        break;
                    }
                case 8:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 88, picture.Height / 2 - 67);
                        break;
                    }
                case 9:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 92, picture.Height / 2 - 67);
                        break;
                    }
                case 10:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 96, picture.Height / 2 - 67);
                        break;
                    }
                case 11:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 102, picture.Height / 2 - 67);
                        break;
                    }
                case 12:
                    {
                        e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                        picture.Width / 2 - 107, picture.Height / 2 - 67);
                        break;
                    }




            }

            if (name.Length > 12 && name.Length <= 15 )
                e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                    picture.Width / 2 - 110, picture.Height / 2 - 60);

            if (name.Length >= 16)
                e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
                    picture.Width / 2 - 140, picture.Height / 2 - 60);


            //if (name.Length <= 6)
            //    e.Graphics.DrawString(name, font, System.Drawing.Brushes.White,
            //        picture.Width / 2 - 75, picture.Height / 2 - 70);

        }




        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            {
                e.Graphics.TranslateTransform(bitmap.Width / 2, bitmap.Height / 2);
                e.Graphics.RotateTransform(angle);
                e.Graphics.DrawImage(bitmap, new Point(-bitmap.Width / 2, -bitmap.Height / 2));
            }
        }

        Bitmap bitmap;
        bool Start = true;
        bool haveClick = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Start)
            {
                timer.Enabled = true;
                PlaySound();
                haveClick = true;
            }
            this.Form1_Load(null, null);
            pictureBox1.Invalidate();
            Start = !Start;
        }


        private void Form1_Load(object sender, EventArgs e)
        {                        
            bitmap =  new Bitmap(Strimer.Properties.Resources.Колесо);
            pictureBox1.Image = bitmap;
            period = 0;
        }

        // Берем ник из списка в файле 
        private string ReadLines(string fileName)
        {
            var list = new List<string>();
            List<string> lines = File.ReadAllLines(fileName).Skip(1).ToList();
            string nikName = "";
            foreach ( string line in lines)
            {
                nikName = line.Substring(line.LastIndexOf(',') + 1).Trim('"');
                list.Add(nikName);
            }
            Random random = new Random();
            return list[random.Next(0,lines.Count()-1)].ToString();

        }
     

        private void Form1_Click(object sender, EventArgs e)
        {
            pictureBox1.Controls.Clear();
            Start = true;
         
        }

        bool VolumePhoto = false;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (VolumePhoto == true)
            {
                pictureBox2.Image = Strimer.Properties.Resources.Volume;
                player.settings.mute = false;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.VolumeMute;
                player.settings.mute = true;
            }
            VolumePhoto = !VolumePhoto;
        }


    }
}
