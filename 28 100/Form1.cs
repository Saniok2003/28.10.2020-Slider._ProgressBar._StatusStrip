using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _28_100
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Button bt in groupBox1.Controls.OfType<Button>())
            {
                bt.Enabled = false;
            }
        }
        int startValue = 0;
        private void button11_Click_1(object sender, EventArgs e)
        {
            foreach (Button bt in groupBox1.Controls.OfType<Button>())
            {
                bt.BackColor = Color.Transparent;
            }
            int size = 10;
            int[] nums = new int[size];
            int j;
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < nums.Length; i++)
            {
                do
                {
                    j = rand.Next(1, size + 1);
                } while (nums.Contains<int>(j));
                nums[i] = j;
            }
            int k = 0;
            foreach (Button bt in groupBox1.Controls.OfType<Button>())
            {
                bt.Text = nums[k++].ToString();
            }

            if (trackBar1.Value == 1)
            {
                startValue = 10000;
            }
            else if (trackBar1.Value == 2)
            {
                startValue = 20000;
            }
            else if (trackBar1.Value == 3)
            {
                startValue = 30000;
            }
            foreach (Button bt in groupBox1.Controls.OfType<Button>())
            {
                bt.Enabled = true;
            }
            timer1.Start();
        }
        int m = 1;
        private void button_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text == m.ToString())
            {
                (sender as Button).BackColor = System.Drawing.Color.Aquamarine;
                toolStripProgressBar1.Value++;
                m++;
                if (m == 11)
                {
                    m = 1;
                    foreach (Button bt in groupBox1.Controls.OfType<Button>())
                    {
                        bt.BackColor = Color.Transparent;
                    }
                    timer1.Stop();
                    MessageBox.Show("Good!","You WIN");
                }
            }
            else
            {
                (sender as Button).BackColor = System.Drawing.Color.Red;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (startValue != 0)
            {
                startValue = startValue - 1000;
                label5.Text = (startValue / 1000).ToString();
            }
            else
            {
                timer1.Stop();
                m = 1;
                foreach (Button bt in groupBox1.Controls.OfType<Button>())
                {
                    bt.BackColor = Color.Transparent;
                }
                MessageBox.Show("Время кончилось!");
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
