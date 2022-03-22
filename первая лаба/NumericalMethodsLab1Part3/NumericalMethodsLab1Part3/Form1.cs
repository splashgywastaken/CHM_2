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

namespace NumericalMethodsLab1Part3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CubicSplineInterpolation _cubicSpline;

        private void BuildSplineButton_Click(object sender, EventArgs e)
        {
            GenerateData();
            PLot();
            errorTextBox.Text = _cubicSpline.GetError().ToString();
        }

        private void GenerateData()
        {
            _cubicSpline = new CubicSplineInterpolation(
                Convert.ToDouble(ATextBox.Text),
                Convert.ToDouble(BTextBox.Text),
                Convert.ToInt32(NTextBox.Text),
                GetChosenFunc(),
                Convert.ToInt32(CompactTextBox.Text),
                Convert.ToDouble(SATextBox.Text),
                Convert.ToDouble(SBTextBox.Text),
                IsUniformCheckBox.Checked
            );
        }

        private Func<double, double> GetChosenFunc()
        {
            switch (funcCombobox.SelectedIndex)
            {
                case 0:
                    return FirstFunc;
                case 1:
                    return SecondFunc;
                case 2:
                    return ThirdFunc;
                default:
                    return DefaultFunc;
            }
        }

        private static double FirstFunc(double x)
            => 16 + x - 2 * x * x + 3 * x * x;
 
        private static double SecondFunc(double x)
            => 2 * Math.Cos(x) - Math.Sin(x);

        private static double ThirdFunc(double x)
            => Math.Cos(Math.PI * x / 2) + Math.Exp(-1 / x);

        private static double DefaultFunc(double x)
            => x * x * x;

        private void PLot()
        {
            //Отрисовка сплайна и функции
            var SplinePane = PGraph.GraphPane;
            SplinePane.CurveList.Clear();

            PaneInit(
                SplinePane,
                "Графики сплайна и исходной функции"
                );

            //Исходная функция
            DrawGraph(
                SplinePane,
                _cubicSpline.XDoubles,
                _cubicSpline.YDoubles,
                "Исходная функция",
                Color.Red
            );

            //Интерполяционный кубический сплайн
            DrawGraph(
                SplinePane,
                _cubicSpline.XDoubles,
                _cubicSpline.SDoubles,
                "Интерполяционный кубический сплайн",
                Color.Blue
            );

            PGraph.AxisChange();
            PGraph.Invalidate();

            //Отрисовка графика погрешности
            var ErrorPane = ErrorGraph.GraphPane;
            ErrorPane.CurveList.Clear();

            PaneInit(
                ErrorPane,
                "Погрешность"
                );

            //Погрешность
            DrawGraph(
                ErrorPane,
                _cubicSpline.XDoubles,
                _cubicSpline.ErrorDoubles,
                "Погрешность",
                Color.DarkGreen
            );

            ErrorGraph.AxisChange();
            ErrorGraph.Invalidate();
        }

        private static void PaneInit(GraphPane pane, string paneTitle)
        {
            pane.Title.Text = paneTitle;

            // !!!
            // Включаем отображение сетки напротив крупных рисок по оси X
            pane.XAxis.MajorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси X:
            // Длина штрихов равна 10 пикселям, ...
            pane.XAxis.MajorGrid.DashOn = 10;
            // затем 5 пикселей - пропуск
            pane.XAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив крупных рисок по оси Y
            pane.YAxis.MajorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив мелких рисок по оси X
            pane.YAxis.MinorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси Y:
            // Длина штрихов равна одному пикселю, ...
            pane.YAxis.MinorGrid.DashOn = 1;

            // затем 2 пикселя - пропуск
            pane.YAxis.MinorGrid.DashOff = 2;

            // Включаем отображение сетки напротив мелких рисок по оси Y
            pane.XAxis.MinorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            pane.XAxis.Scale.Max = 15.0;
            pane.YAxis.Scale.Max = 15.0;
        }

        private void DrawScatterPlot(
            GraphPane pane,
            IReadOnlyList<double> xData,
            IReadOnlyList<double> yData,
            string graphName,
            Color color
            )
        {
            var list = new PointPairList();

            var n = _cubicSpline.N;

            for (int index = 0; index < n; index++)
            {
                list.Add(xData[index], yData[index]);
            }

            LineItem myCurve = pane.AddCurve(graphName, list, color, SymbolType.Diamond);

            // !!!
            // У кривой линия будет невидимой
            myCurve.Line.IsVisible = false;

            // !!!
            // Цвет заполнения отметок (ромбиков) - голубой
            myCurve.Symbol.Fill.Color = color;

            // !!!
            // Тип заполнения - сплошная заливка
            myCurve.Symbol.Fill.Type = FillType.Solid;

            // !!!
            // Размер ромбиков
            myCurve.Symbol.Size = 7;
        }

        private void DrawGraph(
            GraphPane pane,
            IReadOnlyList<double> xData,
            IReadOnlyList<double> yData,
            string graphName,
            Color color
        )
        {
            var list = new PointPairList();

            var n = _cubicSpline.N;

            for (int index = 0; index < n; index++)
            {
                list.Add(xData[index], yData[index]);
            }

            pane.AddCurve(graphName, list, color, SymbolType.Circle);
        }

    }
}
