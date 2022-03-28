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
                case 4:
                    return FifthFunc;
                default:
                    return DefaultFunc;
            }
        }

        private static double FirstFunc(double x)
            => 16 + x - 2 * x * x + 3 * x * x * x;
        
        private static double SecondFunc(double x)
            => 2 * Math.Cos(x) - Math.Sin(x);

        private static double ThirdFunc(double x)
            => Math.Cos(Math.PI * x / 2) + Math.Exp(-1 / x);

        private static double FourthFunc(double x)
            => x * x + 2 * x;

        private static double FifthFunc(double x)
            => x * x;

        private static double DefaultFunc(double x)
            => x * x;

        private void PLot()
        {
            //Отрисовка сплайна и функции
            var splinePane = PolynomialGraph.GraphPane;
            splinePane.CurveList.Clear();

            PaneInit(splinePane);

            double[] xPoints;
            var yPoints = new double[100];
            var ePoints = new double[100];
            var sPoints = new double[100];
            var func = GetChosenFunc();

            if (IsUniformCheckBox.Checked)
            {
                xPoints = Distribution.EvenNodes(
                    Convert.ToDouble(ATextBox.Text),
                    Convert.ToDouble(BTextBox.Text),
                    100
                );
            }
            else
            {
                xPoints = Distribution.ChebushevNodes(
                    Convert.ToDouble(ATextBox.Text),
                    Convert.ToDouble(BTextBox.Text),
                    100
                );
            }

            for (var i = 0; i < 100; i++)
            {
                yPoints[i] = func(xPoints[i]);
                sPoints[i] = _cubicSpline.Spline(xPoints[i]);
                ePoints[i] = Math.Abs(sPoints[i] - yPoints[i]);
            }

            //Исходная функция
            DrawScatterPlot(
                splinePane,
                _cubicSpline.XDoubles,
                _cubicSpline.YDoubles,
                _cubicSpline.N + 1,
                "Исходная функция",
                Color.Red
            );

            //Интерполяционный кубический сплайн
            DrawGraph(
                splinePane,
                xPoints,
                sPoints,
                100,
                "Интерполяционный кубический сплайн",
                Color.Blue
            );

            PolynomialGraph.AxisChange();
            PolynomialGraph.Invalidate();

            //Отрисовка графика погрешности
            var errorPane = ErrorGraph.GraphPane;
            errorPane.CurveList.Clear();

            PaneInit(errorPane);

            ////Погрешность
            //DrawGraph(
            //    errorPane,
            //    xPoints,
            //    ePoints,
            //    Convert.ToInt32(
            //        ePoints.Length * GetErrorPointsPercentage() / 100 < 1 ? 
            //            ePoints.Length : ePoints.Length * GetErrorPointsPercentage() / 100),
            //    "Погрешность",
            //    Color.DarkGreen
            //);

            //Погрешность
            DrawGraph(
                errorPane,
                _cubicSpline.XDoubles,
                _cubicSpline.ErrorDoubles,
                Convert.ToInt32(
                    _cubicSpline.ErrorDoubles.Length * GetErrorPointsPercentage() / 100 < 1 ?
                        _cubicSpline.ErrorDoubles.Length : _cubicSpline.ErrorDoubles.Length * GetErrorPointsPercentage() / 100),
                "Погрешность",
                Color.DarkGreen
            );


            ErrorGraph.AxisChange();
            ErrorGraph.Invalidate();
            
        }

        private void PaneInit(GraphPane pane)
        {
            // !!!
            // Включаем отображение сетки напротив крупных рисок по оси X
            pane.XAxis.MajorGrid.IsVisible = true;

            // Включаем отображение сетки напротив крупных рисок по оси Y
            pane.YAxis.MajorGrid.IsVisible = true;

            //Если не установлена галочка над чекбоксом, то не делаем автоматическое масштабирование
            if (!setGraphSizeCheckBox.Checked) return;

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
            int n,
            string graphName,
            Color color
            )
        {
            var list = new PointPairList();

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
            int n,
            string graphName,
            Color color
        )
        {
            var list = new PointPairList();

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
                Convert.ToDouble(leftConditionTextBox.Text),
                Convert.ToDouble(rightConditionTextBox.Text),
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
        private void UpdateGraphs()
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
                conditionLeftTrackBar.Value / 1000.0 - 5;
        }

        private double GetRightConditionValue()
        {
            return
                conditionRightTrackBar.Value / 1000.0 - 5;
        }

        private void conditionLeftTrackBar_Scroll(object sender, EventArgs e)
        {
            leftConditionTextBox.Text = GetLeftConditionValue().ToString();
            if (_cubicSpline != null)
                UpdateGraphs();
        }

        private void conditionRightTrackBar_Scroll(object sender, EventArgs e)
        {
            rightConditionTextBox.Text = GetRightConditionValue().ToString();
            if (_cubicSpline != null)
                UpdateGraphs();
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

        private void errorPointsToShowTrackBar_Scroll(object sender, EventArgs e)
        {
            errorPointsToShowPercentageTextBox.Text = GetErrorPointsPercentage().ToString();
            if (_cubicSpline != null)
                UpdateGraphs();
        }

        private int GetErrorPointsPercentage()
        {
            return errorPointsToShowTrackBar.Value;
        }

    }
}
