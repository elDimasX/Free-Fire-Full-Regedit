using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LagSwitch
{
    public partial class Form1 : Form
    {
        // LagSwitchOperacoes
        // Operações de lag
        public class LagSwitchOperacoes
        {
            static bool executandoOperacao = false;

            public async static void Lag()
            {
                if (executandoOperacao == false)
                {
                    executandoOperacao = true;

                    try
                    {
                        string local = Process.GetProcessesByName("HD-Player")[0].MainModule.FileName;

                        ProcessStartInfo AddRuleIn = new ProcessStartInfo("cmd.exe", "/c netsh advfirewall firewall add rule name=\"UCLagSwitch\" dir=in action=block program=\"" + local + "\" enable=yes");
                        ProcessStartInfo AddRuleOut = new ProcessStartInfo("cmd.exe", "/c netsh advfirewall firewall add rule name=\"UCLagSwitch\" dir=out action=block program=\"" + local + "\" enable=yes");
                        ProcessStartInfo DeleteRule = new ProcessStartInfo("cmd.exe", "/c netsh advfirewall firewall delete rule name=\"UCLagSwitch\" program=\"" + local + "\"");

                        //Use WindowStyle Hidden to hide the command line windows
                        AddRuleIn.WindowStyle = ProcessWindowStyle.Hidden;
                        AddRuleOut.WindowStyle = ProcessWindowStyle.Hidden;
                        DeleteRule.WindowStyle = ProcessWindowStyle.Hidden;

                        //Add the firewall rules
                        Process.Start(AddRuleIn);
                        Process.Start(AddRuleOut);

                        //Sleep for the set duration
                        Thread.Sleep(2000);
                        //Delete the firewall rule
                        Process.Start(DeleteRule);
                    } catch (Exception) { }
                }

                executandoOperacao = false;
            }
        }

        public class Teclas
        {
            private int key;
            private IntPtr hWnd;
            private int id;

            [DllImport("user32.dll")]
            private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

            [DllImport("user32.dll")]
            private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

            public Teclas(Keys key, Form form)
            {
                this.key = (int)key;
                this.hWnd = form.Handle;
                id = this.GetHashCode();
            }

            public override int GetHashCode()
            {
                return key ^ hWnd.ToInt32();
            }

            public bool Register()
            {
                return RegisterHotKey(hWnd, id, 0, key);
            }

            public bool Unregiser()
            {
                return UnregisterHotKey(hWnd, id);
            }



        }

        private Teclas ghk;

        public Form1()
        {
            InitializeComponent();

            // F9
            ghk = new Teclas(Keys.F9, this);
            ghk.Register();

            // F1
            ghk = new Teclas(Keys.F1, this);
            ghk.Register();
            //LagSwitchOperacoes.Lag();
        }

        bool oculto = false;

        protected override void WndProc(ref Message m)
        {
            // Se for uma tecla pressionada
            if (m.Msg == 0x0312)
            {

                // Se for o F1
                if (m.LParam.ToString() == "7340032")
                {
                    LagSwitchOperacoes.Lag();
                }

                // Se for o F9
                else if (m.LParam.ToString() == "7864320")
                {
                    if (oculto == true)
                    {
                        oculto = false;
                        Opacity = 1;
                        WindowState = FormWindowState.Normal;

                        TopMost = true;
                        TopMost = false;
                    }
                    else
                    {
                        oculto = true;
                        WindowState = FormWindowState.Minimized;

                        Opacity = 0;
                        TopMost = false;
                    }
                }

            }

            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
