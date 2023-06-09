using Aspose.Cells;
using Aspose.Cells.Charts;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace АнализДанных
{
    public partial class Form1 : Form
    {
        ConcurrentDictionary<string, Dictionary<string, double>> fileParameterValue = new();
        Dictionary<string, Dictionary<string, double>> dictFileParameterValue = new();
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
                                    parametrValues.Add(cells[i, 0].Value.ToString(), double.Parse(cells[i, 2].Value.ToString().Replace(".",",")));
                                }
                                catch
                                {
                                    continue;
                                }
                                @string.Append(sheet.Cells[i, j].Value + " ");
                            }
                        }
                        fileParameterValue.TryAdd(doc.FileName.Substring(doc.FileName.Length - 13, 8).Replace("_", ":"), parametrValues);
                    }
                });
            }
            dictFileParameterValue = fileParameterValue.OrderBy(s => s.Key).ToDictionary(t => t.Key, t => t.Value);
            checkedListBox1.Items.AddRange(fileParameterValue.ElementAt(0).Value.Keys.ToArray());
            PrintDataGrid();
        }
        private void PrintDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var key in dictFileParameterValue.First().Value.Keys)
            {
                foreach (var value in dictFileParameterValue.Keys)
                {
                    try
                    {
                        dataGridView1.Rows.Add(value, key, dictFileParameterValue[value][key]);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }

            }
        }

        private void PrintSelectedParameters()
        {
            dataGridView1.Rows.Clear();
            chart1.Series.Clear();
            chart1.ResetAutoValues();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                var xValues = new List<string>();
                var yValues = new List<double>();
                foreach (var key in dictFileParameterValue.Keys)
                {
                    xValues.Add(key);
                    yValues.Add(dictFileParameterValue[key][item.ToString()]);
                    dataGridView1.Rows.Add(key, item.ToString(), dictFileParameterValue[key][item.ToString()]);
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
            PrintSelectedParameters();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG Image|*.png|JPeg Image|*.jpg";
            saveFileDialog1.Title = "Save Chart As Image File";
            saveFileDialog1.FileName = "Sample.png";

            DialogResult result = saveFileDialog1.ShowDialog();
            saveFileDialog1.RestoreDirectory = true;

            if (result == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                try
                {
                    if (saveFileDialog1.CheckPathExists)
                    {
                        if (saveFileDialog1.FilterIndex == 2)
                        {
                            chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Jpeg);
                        }
                        else if (saveFileDialog1.FilterIndex == 1)
                        {
                            chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Given Path does not exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //chart1.SaveImage($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{DateTime.Now.ToString().Replace(" ", "T")}.Png", ChartImageFormat.Png);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            chart1.Series.Clear();
            chart1.ResetAutoValues();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            foreach (var item in checkedListBox1.Items)
            {
                
                foreach (var key in dictFileParameterValue.Keys)
                {
                    dataGridView1.Rows.Add(key, item.ToString(), dictFileParameterValue[key][item.ToString()]);
                }
            }
        }
    }
}