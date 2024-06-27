using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection.Emit;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Xml;

namespace mydownload
{


    public partial class MainForm : Form
    {
        const string FORMAT_STR1 = @"下载进度:   总{0}  已经{1}  百分比 {2}% ";

        MyDownloader mydownfile;
        private delegate void update_ui_delegate();
        private System.Timers.Timer mytimer;
        private int start_sign=0;

        public void TimerUpdateUI()
        {
            mytimer = new System.Timers.Timer(500);
            mytimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUpdateUI_Handle);
            mytimer.AutoReset = true;
            mytimer.Enabled = true;
        }
        private void TimerUpdateUI_Handle(object source, System.Timers.ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                 this.Invoke(new update_ui_delegate(update_ui));
            }
            else
            {
                update_ui();
            }
        }

        private void update_ui()
        {
            switch(start_sign)
            {
                case 0:
                case 1:
                    label_down_info.Text = string.Format(FORMAT_STR1, mydownfile.file_size, mydownfile.file_downed_size, mydownfile.file_downed_pecent);
                    progressBar1.Value = mydownfile.file_downed_pecent;
                    break;

                case 2:
                    label_down_info.Text = mydownfile.down_info;
                    progressBar1.PerformStep();
                    break;
                default:
                    label_down_info.Text = mydownfile.down_info;
                    progressBar1.Value = 100;
                    start_sign = -1;
                    mytimer.Enabled = false;
                    break;
            }

            if(mydownfile.file_downed_size == mydownfile.file_size)
            {
                progressBar1.Value = 100;
                mytimer.Enabled = false;
            }

        }

        private void update_end()
        {
            mydownfile.file_downed_size = mydownfile.file_size;
            Process.Start("explorer.exe", "/select," + mydownfile.file_fullpath);
        }

        public void down1_process(object sender, DownloadProgressChangedEventArgs e)
        {
            mydownfile.file_size = e.TotalBytesToReceive;
            mydownfile.file_downed_size = e.BytesReceived;
        }

        private void down1_end(object sender, AsyncCompletedEventArgs e)
        {
            update_end();
        }


        private void update_error()
        {
            start_sign = -1;
        }




        void down3_process(object sender, DataReceivedEventArgs info)
        {
            if (string.IsNullOrWhiteSpace(info.Data))
            {
                return;
            }
            mydownfile.down_info =  info.Data?.Trim();
        }


        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDlg = new OpenFileDialog();
            openfileDlg.Title = "选择文件保存的路径和文件名";
            openfileDlg.InitialDirectory = Path.GetDirectoryName(textBox_filepath.Text);
            openfileDlg.CheckFileExists = false;
            if (openfileDlg.ShowDialog() == DialogResult.OK)
            {
                textBox_filepath.Text = openfileDlg.FileName;
            }

        }
        private void button_down_Click(object sender, EventArgs e)
        {
            
            if (false == Uri.TryCreate(textBox_uri.Text, UriKind.Absolute, out mydownfile.file_uri))
            {
                MessageBox.Show("下载地址错误!");
                return;
            };

            if(false == Directory.Exists(Path.GetDirectoryName(textBox_filepath.Text)))
            {
                MessageBox.Show("保存目录不存在!");
                return;
            }
            mydownfile.file_fullpath = textBox_filepath.Text;

            mydownfile.file_downed_size = 0;
            start_sign = comboBox_mode.SelectedIndex;
            
            switch (start_sign)
            {
                case 0:
                    mydownfile.down1(down1_process, down1_end);
                    break;
                case 1:
                    Thread down2thread = new Thread(() => mydownfile.down2());
                    down2thread.IsBackground = true;
                    down2thread.Start();
                    break;
                case 2:
                    Thread down3thread = new Thread(() => mydownfile.down3(textBox_aria2param.Text.Trim(), down3_process));
                    down3thread.IsBackground = true;
                    down3thread.Start();
                    break;

                default:
                    start_sign = -1;
                    break;

            }
            TimerUpdateUI();

        }
 


        private void Form1_Load(object sender, EventArgs e)
        {
            string appsettingspath;
            appsettingspath = Application.StartupPath.TrimEnd('\\') + "\\settings.xml";
            XmlDocument myxml=new XmlDocument();
            try
            {
                myxml.Load(appsettingspath);
                XmlNode selectNode = myxml.SelectSingleNode("settings");
                textBox_uri.Text = selectNode.SelectSingleNode("uri").InnerText;
                textBox_filepath.Text = selectNode.SelectSingleNode("filepath").InnerText;
                textBox_aria2param.Text = selectNode.SelectSingleNode("aria2param").InnerText;
               
            }
            catch
            {
                textBox_uri.Text = @"填入下载网址,如:http://dl.360safe.com/drvmgr/guanwang__360DrvMgrInstaller_beta.exe";
                textBox_filepath.Text = @"填入保存的路径和文件名,如:F:\downloads\aaa.exe";
                textBox_aria2param.Text = "-x 8 -s 8";
            }
            
            comboBox_mode.Items.Add("webclient");
            comboBox_mode.Items.Add("webquest and response");
            comboBox_mode.Items.Add("Aria2");
            comboBox_mode.SelectedIndex = 2;

            start_sign = -1;

            mydownfile = new MyDownloader();
            mydownfile.OnError += update_error;
           // mydownfile.OnCompleted += update_ui;
            mydownfile.OnCompleted += update_end;

        }

        private void comboBox_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_mode.SelectedIndex==2)
            {
                groupBox1.Visible = true;
            }else
            {
                groupBox1.Visible = false;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string appsettingspath;
            appsettingspath = Application.StartupPath.TrimEnd('\\') + "\\settings.xml";
            XmlDocument myxml = new XmlDocument();
            try
            {
                myxml.Load(appsettingspath);
                XmlNode selectNode = myxml.SelectSingleNode("settings");
                selectNode.SelectSingleNode("uri").InnerText=textBox_uri.Text;
                selectNode.SelectSingleNode("filepath").InnerText=textBox_filepath.Text;
                selectNode.SelectSingleNode("aria2param").InnerText=textBox_aria2param.Text;
                myxml.Save(appsettingspath);

            }
            catch
            {
                myxml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>"+
                            @"<settings><uri>填入下载网址,如:http://dl.360safe.com/drvmgr/guanwang__360DrvMgrInstaller_beta.exe</uri><filepath>填入保存的路径和文件名,如:F:\downloads\aaa.exe</filepath><aria2param>-x 8 -s 8</aria2param></settings>"
                        );
                myxml.Save(appsettingspath);
            }
        }

        private void textBox_uri_MouseCaptureChanged(object sender, EventArgs e)
        {
            string str = Clipboard.GetText();
            Uri realuri;
            if (true == Uri.TryCreate(str, UriKind.Absolute, out realuri))
            {
                textBox_uri.Text = realuri.ToString();
            };
        }

        private void textBox_uri_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class MyDownloader
    {
        public Uri file_uri;
        public string file_fullpath;
        public long file_size;
        public long file_downed_size;
        public string down_info;


        public delegate void DownloadEventHandler();
        public delegate void CompletedEventHandler();
        public delegate void ErrorEventHandler();

        public event DownloadEventHandler OnDownload;
        public event CompletedEventHandler OnCompleted;
        public event ErrorEventHandler OnError;

        const string ARIA_PATH = "\\aria2-1.36.0-win-64bit-build1\\aria2c.exe";
        public int file_downed_pecent
        {
            get { return (int)((file_downed_size * 100) / file_size); }
        }

        public MyDownloader()
        {
            file_uri = new Uri(@"file:///C:/windows/regedit.exe");
            file_fullpath = @"file:///C:/regedit.exe";
            file_size = 0x1;
            file_downed_size = 0;
        }
        public MyDownloader(Uri uri, string filefullpath)
        {
            file_uri = uri;
            file_fullpath = filefullpath;
            file_size = 0x1;
            file_downed_size = 0;
        }


        public void down1()
        {
            var webclient = new WebClient();
            webclient.DownloadFileAsync(file_uri, file_fullpath);
        }

        public void down1(DownloadProgressChangedEventHandler dpHandle, AsyncCompletedEventHandler cpHandle)
        {
            var webclient = new WebClient();
            webclient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(dpHandle);
            webclient.DownloadFileCompleted += new AsyncCompletedEventHandler(cpHandle);
            webclient.DownloadFileAsync(file_uri, file_fullpath);
        }

        public void down2()
        {
            WebRequest request = WebRequest.Create(file_uri);
            try
            {
                WebResponse response = request.GetResponse();
                if (response.ContentType.ToLower().Length > 0)
                {
                    file_downed_size = 0;
                    file_size = response.ContentLength;

                    using (Stream reader = response.GetResponseStream())
                    {
                        using (FileStream writer = new FileStream(file_fullpath, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            byte[] buffer = new byte[4096];
                            int count = 0;
                            while ((count = reader.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                writer.Write(buffer, 0, count);
                                file_downed_size += count;
                                if (OnDownload != null)
                                {
                                    OnDownload();
                                }

                            }

                        }
                    }
                    response.Close();
                    if (OnCompleted != null)
                    {
                        OnCompleted();
                    }
                }
            }
            catch
            {
                if (OnError != null)
                {
                    OnError();
                }
                return;
            }
        }
        public void down3()
        {
            down3("", null);
        }
        public void down3(string aria_param)
        {
            down3(aria_param, null);
        }

        public void down3(string aria_param, DataReceivedEventHandler AriaOutput)
        {

            string dir = Path.GetDirectoryName(file_fullpath);
            string name = Path.GetFileName(file_fullpath);
            string exe = Application.StartupPath.TrimEnd('\\') + ARIA_PATH;

            var args = $"{aria_param} --dir={dir} --out={Path.GetFileName(name)} {file_uri}";



            var psi_info = new ProcessStartInfo(exe, args)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            if (File.Exists(file_fullpath))
            {
                File.Delete(file_fullpath);
            }
            using (var p = new Process { StartInfo = psi_info, EnableRaisingEvents = true })
            {
                if (!p.Start())
                {
                    down_info = "aria 启动失败";
                }
                p.ErrorDataReceived += AriaOutput;
                p.OutputDataReceived += AriaOutput;
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();
                p.OutputDataReceived -= AriaOutput;
                p.ErrorDataReceived -= AriaOutput;
            }

            var fi = new FileInfo(file_fullpath);
            if (!fi.Exists || fi.Length == 0)
            {
                file_downed_size = 0;
                down_info = "文件下载失败!";
                if (OnError != null)
                {
                    OnError();
                }
            }
            else
            {
                file_downed_size = file_size;
                down_info = "下载成功!";
                if (OnCompleted != null)
                {
                    OnCompleted();
                }
            }
        }

    }

}
