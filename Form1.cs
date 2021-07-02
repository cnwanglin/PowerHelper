using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - 633;//窗体的宽度
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - 275;//窗体的高度
            Point p = new Point(x, y);
            this.PointToScreen(p);
            this.Location = p;
        }
        int ii = 0;

        private void UpdateInfo(int flag)
        {
            PowerStatus power = new PowerStatus();
            this.textBox5.Text = power.PowerLineStatus.ToString();//是否充电
            string dianlaing = power.BatteryLifePercent.ToString();//电量百分比
            this.textBox6.Text = dianlaing+"%"; 
            this.textBox7.Text = power.BatteryChargeStatus.ToString();//电池状态
            if(this.textBox7.Text.ToString().Equals("0")) this.textBox7.Text = "Mid";
            string str = power.BatteryLifeRemaining.ToString();//电池剩余使用时间
            int sum = 0;
            for(int i=0;i<str.Length;i++)
            {
                int num = 1,j=i+1;
                while (j < str.Length)
                {
                    num *= 10;
                    j++;
                }
                sum += (str[i] - '0')*num;
            }
            int xiaoshi = sum / 3600;
            int fenzhong = (sum -3600*xiaoshi)/60;
            this.notifyIcon2.Icon = new Icon("image/dianliang/" + dianlaing + ".ico");
            if (str.Equals("-1") && this.textBox5.Text.Equals("Online"))
            {
                this.textBox8.Text = "您已接通电源！";
                
                this.pictureBox1.Image = Image.FromFile("image/charge/" + (ii % 4 + 1) + ".png");
            }
            else if (str.Equals("-1") && this.textBox5.Text.Equals("Offline"))
            {
                this.textBox8.Text = "正在计算电量";
                if (dianlaing.CompareTo("94") >= 0|| dianlaing.CompareTo("100")==0)
                {                   
                    this.pictureBox1.Image = Image.FromFile("image/charge/" + 4 + ".png");
                }
                else if (dianlaing.CompareTo("75") >= 0)
                {
                    this.pictureBox1.Image = Image.FromFile("image/charge/" + 3 + ".png");
                }
                else if (dianlaing.CompareTo("50") >= 0)
                {
                    this.pictureBox1.Image = Image.FromFile("image/charge/" + 2 + ".png");
                }
                else
                {
                    this.pictureBox1.Image = Image.FromFile("image/charge/" + 1 + ".png");
                }
            }
            else
            {
                if(xiaoshi==0) this.textBox8.Text = "剩余" +  fenzhong + "分钟";
                else this.textBox8.Text = "剩余" + xiaoshi + "小时" + fenzhong + "分钟";
                if (dianlaing.CompareTo("94") >= 0 || dianlaing.CompareTo("100") == 0)
                {
                    this.pictureBox1.Image = Image.FromFile("image/charge/" + 4 + ".png");
                }
                else if (dianlaing.CompareTo("75") >= 0)
                {
                    this.pictureBox1.Image = Image.FromFile("image/charge/" + 3 + ".png");
                }
                else if (dianlaing.CompareTo("50") >= 0)
                {
                    this.pictureBox1.Image = Image.FromFile("image/charge/" + 2 + ".png");
                }
                else
                {
                    this.pictureBox1.Image = Image.FromFile("image/charge/" + 1 + ".png");
                }
            }
        }
        private void Load_data(object sender, EventArgs e)
        {
            UpdateInfo(ii);
            timer1.Interval = 1000;//毫秒为单位
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateInfo(ii++);
        }

        private void zuixiaohua(object sender, FormClosingEventArgs e)
        {
            //取消关闭窗口
             e.Cancel = true;
            //最小化主窗口
            this.WindowState = FormWindowState.Minimized;
            //不在系统任务栏显示主窗口图标
            this.ShowInTaskbar = false;
            notifyIcon2.ShowBalloonTip(2000, "最小化到托盘", "程序已经缩小到托盘，单击打开程序。", ToolTipIcon.Info);
        }



        private void huifutuopan(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    //还原窗体
                    this.WindowState = FormWindowState.Normal;
                    //系统任务栏显示图标
                    this.ShowInTaskbar = true;
                }
                //激活窗体并获取焦点
                this.Activate();
            }

        }

        private void xianshi(object sender, MouseEventArgs e)
        {
            PowerStatus power1 = new PowerStatus();
            string str1= power1.BatteryLifePercent.ToString()+"%";
            string str2 = power1.PowerLineStatus.ToString();
            if (str2.Equals("Online")) notifyIcon2.Text = str1+"(正在充电)";
            else notifyIcon2.Text = str1;
            
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            //取消关闭窗口
            //e.Cancel = true;
            //最小化主窗口
            //this.WindowState = FormWindowState.Minimized;
            //不在系统任务栏显示主窗口图标
            //this.ShowInTaskbar = false;
            //notifyIcon2.ShowBalloonTip(2000, "最小化到托盘", "程序已经缩小到托盘，单击打开程序。", ToolTipIcon.Info);
        }
    }
}
