using Aspose.Cells;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace АнализДанных
{
    public partial class Form1 : Form
    {
        List<FileStream> files = new();
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Multiselect = true;

            chart1.Series[0].Name = "VALUE";
            chart1.Series[0].MarkerStep = 5;
            for (int i = 0; i < 10; i++)
            {
                chart1.Series[0].Points.Add(new DataPoint(i + 5, i * 400));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Parallel.ForEach(openFileDialog1.FileNames, file =>
                {
                    using (Workbook doc = new Workbook(file))
                    {
                        //ListBox listBox = new ListBox();
                        var sheet = doc.Worksheets[0];
                        int rows = sheet.Cells.MaxDataRow;
                        int cols = sheet.Cells.MaxDataColumn;
                        StringBuilder @string = new StringBuilder();
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                @string.Append(sheet.Cells[i, j].Value + " | ");
                            }
                            Action action = () => { listBox1.Items.Add(@string); };
                            listBox1.Invoke(action);
                            if(listBox1.InvokeRequired)
                            {
                                listBox1.Invoke(action);
                            } else
                            {
                                listBox1.Items.Add(@string);
                            }
                            @string.Clear();
                        }
                        //var cells = sheetPart.Worksheet.Descendants<Cell>().Select(c => c.InnerText).ToList();
                        //cells.ForEach(cell=> { listBox.Items.Add(cell); });
                        //Action action = () => { listBox1.Items.AddRange(listBox.Items); };
                        //listBox1.Invoke(action);
                    }
                });
            }
        }
    }
}