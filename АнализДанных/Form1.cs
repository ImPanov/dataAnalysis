using Aspose.Cells;
using System.Collections.Concurrent;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace АнализДанных
{
    public partial class Form1 : Form
    {
        ConcurrentDictionary<string, Dictionary<string, double>> fileParameterValue = new();
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Multiselect = true;

            chart1.Series[0].Name = "VALUE";
            chart1.Series[0].MarkerStep = 5;
            chart1.Series[0].XValueType = ChartValueType.String;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileParameterValue.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Parallel.ForEach(openFileDialog1.FileNames, file =>
                {
                    using (Workbook doc = new Workbook(file))
                    {
                        //ListBox listBox = new ListBox();
                        var sheet = doc.Worksheets[0];
                        var cells = sheet.Cells;
                        int rows = cells.MaxDataRow;
                        int cols = cells.MaxDataColumn;
                        StringBuilder @string = new StringBuilder();
                        Dictionary<string, double> parametrValues = new Dictionary<string, double>();

                        for (int i = 1; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j += 2)
                            {
                                try
                                {
                                    parametrValues.Add(cells[i, 0].Value.ToString(), double.Parse(cells[i, 2].Value.ToString()));
                                }
                                catch
                                {
                                    continue;
                                }
                                @string.Append(sheet.Cells[i, j].Value + " ");
                            }
                            //Action action = () => { listBox1.Items.Add(@string); };                           
                            //listBox1.Invoke(action);
                            //@string.Clear();
                            //var cells = sheetPart.Worksheet.Descendants<Cell>().Select(c => c.InnerText).ToList();
                            //cells.ForEach(cell=> { listBox.Items.Add(cell); });
                            //Action action = () => { listBox1.Items.AddRange(listBox.Items); };
                            //listBox1.Invoke(action);
                        }
                        fileParameterValue.OrderBy(s => s.Key);
                        fileParameterValue.TryAdd(doc.FileName.Substring(doc.FileName.Length - 13, 8).Replace("_", ":"), parametrValues);
                    }
                });
            }
            checkedListBox1.Items.AddRange(fileParameterValue.ElementAt(0).Value.Keys.ToArray());

        }

        private void PrintChart()
        {
            chart1.Series.Clear();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                var xValues = new List<string>();
                var yValues = new List<double>();
                foreach (var key in fileParameterValue.Keys)
                {
                    xValues.Add(key);
                    yValues.Add(fileParameterValue[key][item.ToString()]);
                }
                Series series = new(item.ToString());
                series.ChartType = SeriesChartType.Line;
                series.Points.DataBindXY(xValues, yValues);
                chart1.Series.Add(series);
                chart1.Titles[0].Text = string.Join(" , ", chart1.Series.Select(s => s.Name).ToArray());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                var xValues = new List<string>();
                var yValues = new List<double>();
                foreach (var key in fileParameterValue.Keys)
                {
                    xValues.Add(key);
                    yValues.Add(fileParameterValue[key][item.ToString()]);
                }
                Series series = new(item.ToString());
                series.ChartType = SeriesChartType.Line;
                series.Points.DataBindXY(xValues, yValues);
                chart1.Series.Add(series);
                chart1.Titles[0].Text = string.Join(" , ", chart1.Series.Select(s => s.Name).ToArray());
            }
        }
    }
}