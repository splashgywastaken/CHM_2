using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FirstLabWindowsFormsApp.Main;
using FirstLabWindowsFormsApp.Services;
using FirstLabWindowsFormsApp.Strategies.Distribution;
using ZedGraph;

namespace FirstLabWindowsFormsApp.Forms;

public partial class FirstTaskForm : Form
{

    private Interpolation _interpolation;
    private bool _drawPolynomial = true;
    private bool _drawFunction = true;
    private bool _drawErrors = true;

    public FirstTaskForm()
    {
        InitializeComponent();
    }

    private void Generate_Click(object sender, EventArgs e)
    {

        if (
               aTextBox.Text == string.Empty
            || bTextBox.Text == string.Empty
            || nTextBox.Text == string.Empty
            || coefficientsBox.Text == string.Empty
            || functionComboBox.SelectedItem == null
        )
        {
            MessageBox.Show(
                "Одно или несколько полей не заполнено, заполните поля чтобы продолжить работу",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return;
        }

        if (radioButtonChebushev.Checked)
        {
            Distribute(new ChebushevDistribution());
        }
        else
        {
            Distribute(new UniformDistribution());
        }

        _interpolation.GenerateData();

        errorTextBox.Text = Convert.ToString(
            _interpolation.GetMaxAbsoluteError(), 
            CultureInfo.InvariantCulture
            );

        if (
            _interpolation.XDoubles != Array.Empty<double>()
            && _interpolation.YDoubles != Array.Empty<double>()
        )
        {
            MessageBox.Show(
                "Массивы данных успешно созданы",
                "Данные заданы",
                MessageBoxButtons.OK,
                MessageBoxIcon.None
            );
        }
    }

    private void Distribute(IDistribution distribution)
    {
        if (
            aTextBox.Text == string.Empty
            || bTextBox.Text == string.Empty
            || nTextBox.Text == string.Empty
        )
        {
            MessageBox.Show(
                "Одно или несколько полей не заполнено, заполните поля чтобы продолжить работу",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return;
        }

        if (_interpolation != null)
        {
            _interpolation.A = Convert.ToInt32(aTextBox.Text);
            _interpolation.B = Convert.ToInt32(bTextBox.Text);
            _interpolation.N = Convert.ToInt32(nTextBox.Text);
            
            _interpolation.SetFunctionAndCoefficients(
                functionComboBox.SelectedIndex,
                coefficientsBox.Text.Split(' ').Select(Convert.ToDouble).ToArray()
            );

            _interpolation.Distribution = distribution;
        }
        else
        {
            _interpolation = new Interpolation(
                distribution,
                Convert.ToInt32(aTextBox.Text),
                Convert.ToInt32(bTextBox.Text),
                Convert.ToInt32(nTextBox.Text),
                coefficientsBox.Text.Split(' ').Select(Convert.ToDouble).ToArray(),
                functionComboBox.SelectedIndex
            );
        }
    }

    private void Plot_Click(object sender, EventArgs e)
    {
        Plot();
    }

    private void Plot()
    {
        var pane = InterpolationGraphPane.GraphPane;
        pane.CurveList.Clear();

        PaneInit(pane);

        var n = 100;
        var x = new double[n];
        var f = new double[n];
        var p = new double[n];
        var errors = new double[n];
        _interpolation.GenerateGraphData(
            ref x,
            ref f, 
            ref p,
            ref errors,
            n);

        if (p.Any(d => double.IsNaN(d) || double.IsInfinity(d))
            ||
            f.Any(d => double.IsInfinity(d) || double.IsNaN(d))
           )
        {

            MessageBox.Show(
                "В одном из массивов было получена бесконечность либо не число. Конец работы программы",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            return;

        }

        if (_drawPolynomial)
        {
            DrawGraph(
                pane,
                x,
                p,
                "Полином",
                Color.Blue,
                SymbolType.Star
            );
        }

        if (_drawFunction)
        {
            DrawGraph(
                pane,
                x,
                f,
                "Функция",
                Color.Red,
                SymbolType.Plus
            );
        }

        if (_drawErrors)
        {
            DrawGraph(
                pane,
                x,
                errors,
                "График погрешности интерполяции",
                Color.Green,
                SymbolType.Circle
            );
        }

        InterpolationGraphPane.AxisChange();
        InterpolationGraphPane.Invalidate();
    }

    private void PaneInit(GraphPane pane)
    {

        InterpolationGraphPane.BackColor = Color.BlanchedAlmond;

        pane.LineType = LineType.Normal;

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

        pane.XAxis.Scale.Max = 15.0;
        pane.YAxis.Scale.Max = 15.0;
    }

    private void DrawGraph(
        GraphPane pane,
        IReadOnlyList<double> xData,
        IReadOnlyList<double> yData,
        string graphName,
        Color color,
        SymbolType symbolType
    )
    {
        var list = new PointPairList();

        var n = xData.Count;

        for (var index = 0; index < n; index++)
        {
            list.Add(xData[index], yData[index]);
        }

        pane.AddCurve(graphName, list, color, symbolType);
    }

    

    private void ExitButton_Click(object sender, EventArgs e)
        => Close();

    private void FunctionComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_interpolation == null)
        {
            return;
        }

        if (coefficientsBox.Text == string.Empty)
        {
            MessageBox.Show(
                "Заполните поле с коэффициентами",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            
            functionComboBox.Text = "Выбор функции";

            return;
        }

        _interpolation.SetFunctionAndCoefficients(
            functionComboBox.SelectedIndex,
            coefficientsBox.Text.Split(' ').Select(Convert.ToDouble).ToArray()
        );
    }

    private void FirstTaskForm_Load(object sender, EventArgs e)
    {

    }

    private void ExitButton_Click_1(object sender, EventArgs e)
    {
        Close();
    }
    
    private void polynomialCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _drawPolynomial = drawPolynomialCheckBox.Checked;
        Plot();
    }

    private void drawFunctionCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _drawFunction = drawFunctionCheckBox.Checked;
        Plot();
    }

    private void drawErrorsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _drawErrors = drawErrorsCheckBox.Checked;
        Plot();
    }
}