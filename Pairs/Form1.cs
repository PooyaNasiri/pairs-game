using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Pairs
{
    public partial class Form1 : Form
    {
        const int n = Program.n;
        card[,] cards = new card[n, n];
        int TwoClickCounter = 0 , c=0;
        int[] x = new int[3], y = new int[3];
        Stopwatch a = new Stopwatch();
        public Form1(){ InitializeComponent();}

        private void Form1_Load(object sender, EventArgs e) { Start(); a.Start(); }

        private void Start()
        {
            x[0] = y[0] = n + 1;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    cards[i, j] = new card();
                    button[i, j].Text = "card" + (j + i * n + 1);
                    button[i, j].BackColor = Color.LightSkyBlue;
                }

            for (int j = 1; j <= (n * n) / 2; j++)
            {
                Random r = new Random();
                int xx, yy;
                do
                {
                    xx = r.Next(0, n);
                    yy = r.Next(0, n);
                } while (cards[xx, yy].value != 0);
                cards[xx, yy].value = j;

                do
                {
                    xx = r.Next(0, n);
                    yy = r.Next(0, n);
                } while (cards[xx, yy].value != 0);
                cards[xx, yy].value = j;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (x[0] <= n && y[0] <= n && TwoClickCounter == 0)
                if (!(cards[x[0], y[0]].value == cards[x[1], y[1]].value))
                {
                    button[x[0], y[0]].Text = "card" + (y[0] + x[0] * n + 1);
                    button[x[1], y[1]].Text = "card" + (y[1] + x[1] * n + 1);
                    button[x[0], y[0]].BackColor = Color.LightSkyBlue;
                    button[x[1], y[1]].BackColor = Color.LightSkyBlue;

                    
                }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (button[i, j].Capture)
                        if (!cards[i, j].omitted
                        && TwoClickCounter < 2
                        && !(x[0] == i && y[0] == j))
                        {
                            status.Text = "Click count:  " + ++c + "      |    Time: " + (a.ElapsedMilliseconds / 1000) + "s";
                            x[TwoClickCounter] = i;
                            y[TwoClickCounter] = j;
                            TwoClickCounter++;
                            button[i, j].Text = cards[i, j].value + "";
                            button[i, j].BackColor = Color.Yellow;
                        }

            if (TwoClickCounter >= 2)
            {
                TwoClickCounter = 0;
                if (cards[x[0], y[0]].value == cards[x[1], y[1]].value)
                {
                    cards[x[0], y[0]].omitted = true;
                    cards[x[1], y[1]].omitted = true;
                    button[x[0], y[0]].BackColor = Color.Green;
                    button[x[1], y[1]].BackColor = Color.Green;
                    if (checkWin())
                    {
                        MessageBox.Show("You win!", "Finish");
                        Start();
                    }
                }
                else
                {
                    button[x[0], y[0]].BackColor = Color.Red;
                    button[x[1], y[1]].BackColor = Color.Red;
                }
            }
        }

        private bool checkWin()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (!cards[i, j].omitted)
                        return false;
            return true;
        }
    }

    public class card
    {
        public int value;
        public bool omitted;
        public card() { value = 0; omitted = false; }
    }
}
