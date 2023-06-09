namespace АнализДанных
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            checkedListBox1 = new CheckedListBox();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            time = new DataGridViewTextBoxColumn();
            Parameter = new DataGridViewTextBoxColumn();
            value = new DataGridViewTextBoxColumn();
            button3 = new Button();
            saveFileDialog1 = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Location = new Point(12, 13);
            button1.Name = "button1";
            button1.Size = new Size(133, 56);
            button1.TabIndex = 1;
            button1.Text = "Выберить файлы";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(434, 14);
            chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(1130, 626);
            chart1.TabIndex = 4;
            chart1.Tag = "";
            chart1.Text = "Данные";
            title1.Name = "Title1";
            chart1.Titles.Add(title1);
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(151, 14);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(277, 114);
            checkedListBox1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(12, 75);
            button2.Name = "button2";
            button2.Size = new Size(133, 53);
            button2.TabIndex = 6;
            button2.Text = "Выгрузить данные";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { time, Parameter, value });
            dataGridView1.Location = new Point(12, 134);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(416, 506);
            dataGridView1.TabIndex = 7;
            // 
            // time
            // 
            time.HeaderText = "Время";
            time.MinimumWidth = 6;
            time.Name = "time";
            time.ReadOnly = true;
            // 
            // Parameter
            // 
            Parameter.HeaderText = "Параметр";
            Parameter.MinimumWidth = 6;
            Parameter.Name = "Parameter";
            Parameter.ReadOnly = true;
            // 
            // value
            // 
            value.HeaderText = "Значение";
            value.MinimumWidth = 6;
            value.Name = "value";
            value.ReadOnly = true;
            // 
            // button3
            // 
            button3.Location = new Point(12, 646);
            button3.Name = "button3";
            button3.Size = new Size(142, 29);
            button3.TabIndex = 8;
            button3.Text = "Сохранить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1576, 860);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(checkedListBox1);
            Controls.Add(chart1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private CheckedListBox checkedListBox1;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button3;
        private SaveFileDialog saveFileDialog1;
        private DataGridViewTextBoxColumn time;
        private DataGridViewTextBoxColumn Parameter;
        private DataGridViewTextBoxColumn value;
    }
}