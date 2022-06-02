namespace Next.ManagerControl
{
    partial class dashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartGenderPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartExperienceLevel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.totalSalary = new Next.ButtonStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.avgSalary = new Next.ButtonStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.maxSalary = new Next.ButtonStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.minSalary = new Next.ButtonStyle();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartGenderPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartExperienceLevel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartGenderPie
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGenderPie.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGenderPie.Legends.Add(legend1);
            this.chartGenderPie.Location = new System.Drawing.Point(45, 22);
            this.chartGenderPie.Name = "chartGenderPie";
            this.chartGenderPie.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "genderPercentage";
            this.chartGenderPie.Series.Add(series1);
            this.chartGenderPie.Size = new System.Drawing.Size(359, 300);
            this.chartGenderPie.TabIndex = 0;
            this.chartGenderPie.Text = "gender percentage";
            title1.Font = new System.Drawing.Font("Andalus", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "genderPercentage";
            title1.Text = "Gender Percentage";
            this.chartGenderPie.Titles.Add(title1);
            // 
            // chartExperienceLevel
            // 
            chartArea2.Name = "ChartArea1";
            this.chartExperienceLevel.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartExperienceLevel.Legends.Add(legend2);
            this.chartExperienceLevel.Location = new System.Drawing.Point(455, 22);
            this.chartExperienceLevel.Name = "chartExperienceLevel";
            this.chartExperienceLevel.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Experience Level";
            this.chartExperienceLevel.Series.Add(series2);
            this.chartExperienceLevel.Size = new System.Drawing.Size(426, 300);
            this.chartExperienceLevel.TabIndex = 1;
            this.chartExperienceLevel.Text = "experienceLevel";
            title2.Font = new System.Drawing.Font("Andalus", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "experienceLevel";
            title2.Text = "Experience Level";
            this.chartExperienceLevel.Titles.Add(title2);
            // 
            // totalSalary
            // 
            this.totalSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.totalSalary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.totalSalary.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.totalSalary.BorderRadius = 15;
            this.totalSalary.BorderSize = 0;
            this.totalSalary.FlatAppearance.BorderSize = 0;
            this.totalSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalSalary.Font = new System.Drawing.Font("Andalus", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSalary.ForeColor = System.Drawing.Color.White;
            this.totalSalary.Location = new System.Drawing.Point(57, 64);
            this.totalSalary.Name = "totalSalary";
            this.totalSalary.Size = new System.Drawing.Size(177, 96);
            this.totalSalary.TabIndex = 2;
            this.totalSalary.TextColor = System.Drawing.Color.White;
            this.totalSalary.UseVisualStyleBackColor = false;
            this.totalSalary.Click += new System.EventHandler(this.buttonStyle1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Andalus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.label1.Location = new System.Drawing.Point(87, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Salary";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.minSalary);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.maxSalary);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.avgSalary);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.totalSalary);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 191);
            this.panel1.TabIndex = 4;
            // 
            // avgSalary
            // 
            this.avgSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.avgSalary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.avgSalary.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.avgSalary.BorderRadius = 15;
            this.avgSalary.BorderSize = 0;
            this.avgSalary.FlatAppearance.BorderSize = 0;
            this.avgSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.avgSalary.Font = new System.Drawing.Font("Andalus", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgSalary.ForeColor = System.Drawing.Color.White;
            this.avgSalary.Location = new System.Drawing.Point(262, 64);
            this.avgSalary.Name = "avgSalary";
            this.avgSalary.Size = new System.Drawing.Size(177, 96);
            this.avgSalary.TabIndex = 4;
            this.avgSalary.TextColor = System.Drawing.Color.White;
            this.avgSalary.UseVisualStyleBackColor = false;
            this.avgSalary.Click += new System.EventHandler(this.buttonStyle1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Andalus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.label2.Location = new System.Drawing.Point(279, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Average Salary";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // maxSalary
            // 
            this.maxSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.maxSalary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.maxSalary.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.maxSalary.BorderRadius = 15;
            this.maxSalary.BorderSize = 0;
            this.maxSalary.FlatAppearance.BorderSize = 0;
            this.maxSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maxSalary.Font = new System.Drawing.Font("Andalus", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxSalary.ForeColor = System.Drawing.Color.White;
            this.maxSalary.Location = new System.Drawing.Point(467, 64);
            this.maxSalary.Name = "maxSalary";
            this.maxSalary.Size = new System.Drawing.Size(177, 96);
            this.maxSalary.TabIndex = 6;
            this.maxSalary.TextColor = System.Drawing.Color.White;
            this.maxSalary.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Andalus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.label3.Location = new System.Drawing.Point(498, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "Max Salary";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // minSalary
            // 
            this.minSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.minSalary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.minSalary.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.minSalary.BorderRadius = 15;
            this.minSalary.BorderSize = 0;
            this.minSalary.FlatAppearance.BorderSize = 0;
            this.minSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minSalary.Font = new System.Drawing.Font("Andalus", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minSalary.ForeColor = System.Drawing.Color.White;
            this.minSalary.Location = new System.Drawing.Point(675, 64);
            this.minSalary.Name = "minSalary";
            this.minSalary.Size = new System.Drawing.Size(177, 96);
            this.minSalary.TabIndex = 8;
            this.minSalary.TextColor = System.Drawing.Color.White;
            this.minSalary.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Andalus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(156)))), ((int)(((byte)(103)))));
            this.label4.Location = new System.Drawing.Point(708, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "Min Salary";
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartExperienceLevel);
            this.Controls.Add(this.chartGenderPie);
            this.Name = "dashboard";
            this.Size = new System.Drawing.Size(908, 585);
            this.Load += new System.EventHandler(this.dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartGenderPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartExperienceLevel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGenderPie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartExperienceLevel;
        private ButtonStyle totalSalary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private ButtonStyle avgSalary;
        private System.Windows.Forms.Label label2;
        private ButtonStyle minSalary;
        private System.Windows.Forms.Label label4;
        private ButtonStyle maxSalary;
        private System.Windows.Forms.Label label3;
    }
}
