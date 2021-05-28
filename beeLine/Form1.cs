using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Label op = new Label();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public static int MinimumDistance(int[] dist, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;
            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        private static string print(int[] distance, int dest)
        {
            String text = $"The shortest distance is {distance[dest]}";
            return text;
        }
        public static string DijAlgo(int[,] graph, int source, int verticesCount, int dest)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];
            for (int i = 0; i < verticesCount; i++)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }
            distance[source] = 0;
            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;
                for (int v = 0; v < verticesCount; v++)
                {
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }
                }
            }
            string text = print(distance, dest);
            return text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String source = comboBox1.Text;
            String destination = comboBox2.Text;
            int vc = 4;
            /*0.jayanagar 
             * 1.malleshwaram
             * 2.peenya
             * 3.rajajinagar*/
            var map = new Dictionary<string, int>();
            map.Add("Jayanagar", 0);
            map.Add("Malleshwaram", 1);
            map.Add("Peenya", 2);
            map.Add("Rajajinagar", 3);
            int s = map[source];
            int d = map[destination];
            int[,] graph =
            {
                {0,12,0,0},
                {12,0,6,2},
                { 0, 6, 0, 4 },
                { 0,2,4,0}
            };
            string t = DijAlgo(graph, s, vc, d);

            op.Text = t;
            op.AutoSize = true;
            op.Location = new Point(50, 400);
            op.BorderStyle = BorderStyle.Fixed3D;
            op.Font = new Font("Calibri", 18);
            this.Controls.Add(op);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            op.Text = "";
        }
    }
}
