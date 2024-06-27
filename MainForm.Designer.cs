namespace mydownload
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_down = new System.Windows.Forms.Button();
            this.textBox_uri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_filepath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label_down_info = new System.Windows.Forms.Label();
            this.comboBox_mode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_aria2param = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_down
            // 
            this.button_down.Location = new System.Drawing.Point(330, 353);
            this.button_down.Margin = new System.Windows.Forms.Padding(4);
            this.button_down.Name = "button_down";
            this.button_down.Size = new System.Drawing.Size(208, 68);
            this.button_down.TabIndex = 0;
            this.button_down.Text = "下载";
            this.button_down.UseVisualStyleBackColor = true;
            this.button_down.Click += new System.EventHandler(this.button_down_Click);
            // 
            // textBox_uri
            // 
            this.textBox_uri.Location = new System.Drawing.Point(158, 105);
            this.textBox_uri.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_uri.Name = "textBox_uri";
            this.textBox_uri.Size = new System.Drawing.Size(673, 26);
            this.textBox_uri.TabIndex = 1;
            this.textBox_uri.TextChanged += new System.EventHandler(this.textBox_uri_TextChanged);
            this.textBox_uri.MouseCaptureChanged += new System.EventHandler(this.textBox_uri_MouseCaptureChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "源地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "保存路径和文件名";
            // 
            // textBox_filepath
            // 
            this.textBox_filepath.Location = new System.Drawing.Point(158, 179);
            this.textBox_filepath.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_filepath.Name = "textBox_filepath";
            this.textBox_filepath.Size = new System.Drawing.Size(583, 26);
            this.textBox_filepath.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(750, 179);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 26);
            this.button2.TabIndex = 5;
            this.button2.Text = "选择...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_down_info
            // 
            this.label_down_info.Location = new System.Drawing.Point(155, 231);
            this.label_down_info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_down_info.Name = "label_down_info";
            this.label_down_info.Size = new System.Drawing.Size(676, 25);
            this.label_down_info.TabIndex = 6;
            this.label_down_info.Text = "下载进度:";
            // 
            // comboBox_mode
            // 
            this.comboBox_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_mode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_mode.FormattingEnabled = true;
            this.comboBox_mode.Location = new System.Drawing.Point(158, 39);
            this.comboBox_mode.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_mode.Name = "comboBox_mode";
            this.comboBox_mode.Size = new System.Drawing.Size(270, 24);
            this.comboBox_mode.TabIndex = 7;
            this.comboBox_mode.SelectedIndexChanged += new System.EventHandler(this.comboBox_mode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "下载模式";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(158, 273);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(583, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_aria2param);
            this.groupBox1.Location = new System.Drawing.Point(466, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 65);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aria2参数(不含文件地址和路径)";
            // 
            // textBox_aria2param
            // 
            this.textBox_aria2param.Location = new System.Drawing.Point(18, 25);
            this.textBox_aria2param.Name = "textBox_aria2param";
            this.textBox_aria2param.Size = new System.Drawing.Size(347, 26);
            this.textBox_aria2param.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 459);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_mode);
            this.Controls.Add(this.label_down_info);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_filepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_uri);
            this.Controls.Add(this.button_down);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载文件测试小程序";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_down;
        private System.Windows.Forms.TextBox textBox_uri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_filepath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_down_info;
        private System.Windows.Forms.ComboBox comboBox_mode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_aria2param;
    }
}

