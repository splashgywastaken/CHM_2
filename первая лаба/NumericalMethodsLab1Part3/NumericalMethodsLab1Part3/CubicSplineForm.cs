using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace NumericalMethodsLab1Part3
{
    public partial class CubicSplineForm : Form
    {
        public CubicSplineForm()
        {
            InitializeComponent();
        }

        private NumericalMethodsSolver _cubicSpline;

        private void BuildSplineButton_Click(object sender, EventArgs e)
        {
            UpdateWithGeneration();
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
                case 3:
                    return FourthFunc;
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

        private static double FourthFunc(double x)
            => x * x + 2 * x;

        private static double DefaultFunc(double x)
            => x * x * x;

        private void PLot()
        {
            //Отрисовка сплайна и функции
            var splinePane = PolynomialGraph.GraphPane;
            splinePane.CurveList.Clear();

            PaneInit(splinePane);

            //var x_points = new double[100];
            //var y_points = new double[100];
            //var e_points = new double[100];
            //var s_points = new double[100];
            //var func = GetChosenFunc();
            //var Interpolate = _cubicSpline.Spline;

            //var h = (Convert.ToDouble(BTextBox.Text) - Convert.ToDouble(ATextBox.Text)) / 100;

            //x_points[0] = Convert.ToDouble(ATextBox.Text);
            //y_points[0] = func(x_points[0]);
            //s_points[0] = Interpolate(x_points[0]);
            //e_points[0] = Math.Abs(s_points[0] - y_points[0]);
            //for (var i = 1; i < _cubicSpline.N; i++)
            //{
            //    x_points[i] = x_points[i - 1] + h;
            //    y_points[i] = func(x_points[i]);
            //    s_points[i] = Interpolate(x_points[i]);
            //    e_points[i] = Math.Abs(s_points[i] - y_points[i]);
            //}

            ////Исходная функция
            //DrawGraph(
            //    splinePane,
            //    x_points,
            //    y_points,
            //    "Исходная функция",
            //    Color.Red
            //);

            ////Интерполяционный кубический сплайн
            //DrawGraph(
            //    splinePane,
            //    x_points,
            //    s_points,
            //    "Интерполяционный кубический сплайн",
            //    Color.Blue
            //);

            //PolynomialGraph.AxisChange();
            //PolynomialGraph.Invalidate();

            ////Отрисовка графика погрешности
            //var errorPane = ErrorGraph.GraphPane;
            //errorPane.CurveList.Clear();

            //PaneInit(errorPane);

            ////Погрешность
            //DrawGraph(
            //    errorPane,
            //    x_points,
            //    e_points,
            //    "Погрешность",
            //    Color.DarkGreen
            //);

            //Исходная функция
            DrawGraph(
                splinePane,
                _cubicSpline.XDoubles,
                _cubicSpline.YDoubles,
                "Исходная функция",
                Color.Red
            );

            //Интерполяционный кубический сплайн
            DrawGraph(
                splinePane,
                _cubicSpline.XDoubles,
                _cubicSpline.SDoubles,
                "Интерполяционный кубический сплайн",
                Color.Blue
            );

            PolynomialGraph.AxisChange();
            PolynomialGraph.Invalidate();

            //Отрисовка графика погрешности
            var errorPane = ErrorGraph.GraphPane;
            errorPane.CurveList.Clear();

            PaneInit(errorPane);
            
            //Погрешность
            DrawGraph(
                errorPane,
                _cubicSpline.XDoubles,
                _cubicSpline.ErrorDoubles,
                "Погрешность",
                Color.DarkGreen
            );

            ErrorGraph.AxisChange();
            ErrorGraph.Invalidate();
            
        }

        private static void PaneInit(GraphPane pane)
        {
            // !!!
            // Включаем отображение сетки напротив крупных рисок по оси X
            pane.XAxis.MajorGrid.IsVisible = true;

            // Включаем отображение сетки напротив крупных рисок по оси Y
            pane.YAxis.MajorGrid.IsVisible = true;

            // Установим масштаб по умолчанию для оси X
            pane.XAxis.Scale.MinAuto = true;
            pane.XAxis.Scale.MaxAuto = true;

            // Установим масштаб по умолчанию для оси Y
            pane.YAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
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

            for (var index = 0; index < n; index++)
            {
                list.Add(xData[index], yData[index]);
            }

            var myCurve = pane.AddCurve(graphName, list, color, SymbolType.Diamond);

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

            for (var index = 0; index < n; index++)
            {
                list.Add(xData[index], yData[index]);
            }

            pane.AddCurve(graphName, list, color, SymbolType.Circle);
        }

        private void GenerateData()
        {
            _cubicSpline = new NumericalMethodsSolver(
                Convert.ToDouble(ATextBox.Text),
                Convert.ToDouble(BTextBox.Text),
                Convert.ToInt32(NTextBox.Text),
                GetChosenFunc(),
                GetLeftConditionValue(),
                GetRightConditionValue(),
                IsUniformCheckBox.Checked
            );
        }

        // Новая генерация данных и обновление отрисованных графиков
        private void UpdateWithGeneration()
        {
            //Обновление информации о сплайне через функцию генерации:
            GenerateData();

            //Обновление информации о погрешности
            errorTextBox.Text = _cubicSpline.GetError().ToString();

            //Отрисовка сплайна и функции
            PLot();

        }

        //Обновление информации о сплайне и построение его графика
        private void Update()
        {
            // Обновление информации о левой и правой границах
            _cubicSpline.LeftCondition = GetLeftConditionValue();
            _cubicSpline.RightCondition = GetRightConditionValue();
            
            // Построение нового сплайна:
            _cubicSpline.BuildSpline();

            //Обновление информации о погрешности
            _cubicSpline.CalculateErrors(); 
            errorTextBox.Text = _cubicSpline.GetError().ToString();

            //Отрисовка сплайна и функции
            PLot();

        }

        private double GetLeftConditionValue()
        {
            return
                conditionLeftTrackBar.Value / 100.0 - 5;
        }

        private double GetRightConditionValue()
        {
            return
                conditionRightTrackBar.Value / 100.0 - 5;
        }

        private void conditionLeftTrackBar_Scroll(object sender, EventArgs e)
        {
            leftConditionTextBox.Text = GetLeftConditionValue().ToString();
            if (_cubicSpline != null)
                Update();
        }

        private void conditionRightTrackBar_Scroll(object sender, EventArgs e)
        {
            rightConditionTextBox.Text = GetRightConditionValue().ToString();
            if (_cubicSpline != null)
                Update();
        }

        private void conditionLeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PolynomialGraph_Load(object sender, EventArgs e)
        {

        }
    }
}
