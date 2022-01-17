using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace NeuroFuzzyIdentification
{
    public partial class Graphic : Form
    {

        public ZedGraphControl graph;
        public Graphic()
        {
            InitializeComponent();
            ZedGraphControl zedGraph = new ZedGraphControl();

            zedGraph.Location = new System.Drawing.Point(0, 0);
            zedGraph.Name = "zedGraph";
            zedGraph.Size = new System.Drawing.Size(800, 800);
            this.Controls.Add(zedGraph);
            this.graph = zedGraph;
        }

        private void Graphic_Load(object sender, EventArgs e)
        {

        }

        public List<Func<double, double>> functions;
        public double leftBound;
        public double rightBound;

        Random random = new Random();

        private void DrawGraph(Func<double, double> func, string name)
        {
            GraphPane pane = graph.GraphPane;
            PointPairList list = new PointPairList();

            double xmin = leftBound;
            double xmax = rightBound;

            for (double x = xmin; x <= xmax; x += 0.005)
            {
                list.Add(x, func(x));
            }
            
            LineItem myCurve = pane.AddCurve(name, list, System.Drawing.Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255)), SymbolType.None);
            myCurve.Line.Width = 3.0F;
            graph.AxisChange();
            
        }

        private void DrawGraph(List<double> values, string name, System.Drawing.Drawing2D.DashStyle style, SymbolType symbolType)
        {
            GraphPane pane = graph.GraphPane;
            PointPairList list = new PointPairList();

            double xmin = 0;
            double xmax = values.Count;

            for (int i = 0; i < values.Count; i++)
            {
                list.Add(i+1, values[i]);
            }
            
            //LineItem myCurve = pane.AddCurve(name, list, System.Drawing.Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255)), symbolType);
            LineItem myCurve = pane.AddCurve(name, list, System.Drawing.Color.FromArgb(255, 0, 0, 0), symbolType);
            
            myCurve.Line.Width = 3.0F;
            myCurve.Line.Style = style;
            graph.AxisChange();

        }
        public void build(string name, string variableName)
        {
            var index = 0;
            foreach (Func<double, double> func in functions)
            {
                DrawGraph(func, "Терм " + (index + 1));
                index++;
            }
            graph.GraphPane.Title.Text = name;
            graph.GraphPane.XAxis.Title.Text = variableName;
            graph.GraphPane.YAxis.Title.Text = "μ(x)";
            graph.Invalidate();
        }

        public void buildScatter(string name, List<List<double>> values)
        {
            var styles = new List<System.Drawing.Drawing2D.DashStyle>();
            styles.Add(System.Drawing.Drawing2D.DashStyle.Solid);
            styles.Add(System.Drawing.Drawing2D.DashStyle.Dash);

            var names = new List<string>();
            names.Add("Вибірка");
            names.Add("Результати розрахунку по моделі");

            var symbolTypes = new List<SymbolType>();
            symbolTypes.Add(SymbolType.Square);
            symbolTypes.Add(SymbolType.Triangle);

            for (int i = 0; i < values.Count; i++)
            {
                DrawGraph(values[i], names[i], styles[i], symbolTypes[i]);
            }
            graph.GraphPane.Title.Text = name;
            graph.GraphPane.XAxis.Title.Text = "Номер елемента вибірки";
            graph.GraphPane.YAxis.Title.Text = "Значення";
            graph.Invalidate();
        }
    }
}
