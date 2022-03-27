using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FirstLabWindowsFormsApp.Main;
using FirstLabWindowsFormsApp.Strategies.Distribution;
using ZedGraph;

namespace FirstLabWindowsFormsApp.Forms;

public partial class SecondTaskForm : Form
{
    private Approximation _approximation;

    public SecondTaskForm()
    {
        InitializeComponent();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void generate_Click(object sender, EventArgs e)
    {
        GenerateData();
    }

    private void GenerateData()
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

        if (_approximation != null)
        {
            _approximation.A = Convert.ToInt32(aTextBox.Text);
            _approximation.B = Convert.ToInt32(bTextBox.Text);
            _approximation.N = Convert.ToInt32(nTextBox.Text);
        }
        else
        {
            _approximation = new Approximation(
                Convert.ToDouble(aTextBox.Text),
                Convert.ToDouble(bTextBox.Text),
                Convert.ToInt32(nTextBox.Text),
                new UniformDistribution(),
                comboBox1.SelectedIndex
            );
        }

        _approximation.GenerateData();

        approximationCoefficientsTextBox.Text =
            string.Join(", ", _approximation.ApproximationCoefficients);

        errorTextBox.Text = Convert.ToString(
            _approximation.SquaredError,
            CultureInfo.InvariantCulture
        );

    }

    private void plot_Click(object sender, EventArgs e)
    {
        Plot();
    }

    private void Plot()
    {
        var pane = ApproximationPlot.GraphPane;
        pane.CurveList.Clear();

        if (checkBox1.Checked)
        {
            //Табличная функция
            DrawScatterPlot(
                pane,
                _approximation.XDoubles,
                _approximation.FTableDoubles,
                "Таблично заданная функция",
                Color.Red
            );
        }
        //Экспериментальная функция
        DrawGraph(
            pane,
            _approximation.XDoubles,
            _approximation.FDoubles,
            "Экспериментальная функция",
            Color.Green
        );
        //Аппроксимирующая функция
        DrawGraph(
            pane,
            _approximation.XDoubles,
            _approximation.PhiDoubles,
            "Функция аппроксимации",
            Color.Blue
        );

        PaneInit(pane);

        ApproximationPlot.AxisChange();
        ApproximationPlot.Invalidate();
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

        var n = _approximation.N;

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

        var n = _approximation.N;

        for (int index = 0; index < n; index++)
        {
            list.Add(xData[index], yData[index]);
        }

        pane.AddCurve(graphName, list, color, SymbolType.Circle);
    }

    private void compactValuesButton_Click(object sender, EventArgs e)
    {
        _approximation.Condense();
        UpdateForm();   
    }

    private void UpdateForm()
    {
        Plot();

        approximationCoefficientsTextBox.Text =
            string.Join(", ", _approximation.ApproximationCoefficients);

        errorTextBox.Text = Convert.ToString(
            _approximation.SquaredError,
            CultureInfo.InvariantCulture
        );

        nTextBox.Text = _approximation.N.ToString();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        _approximation?.SetFunction(Convert.ToInt32(comboBox1.SelectedIndex));
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (_approximation == null) return;

        _approximation.UseDGeneration = checkBox1.Checked;
        _approximation.GenerateData();
        UpdateForm();
    }
}