using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ROYAL_FULL.Form2;

namespace ROYAL_FULL
{
    public partial class DESABILITAR : Form
    {
        public DESABILITAR()
        {
            InitializeComponent();
        }
        //config
        #region
        [DllImport("KERNEL32.DLL")]
        public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32First(IntPtr handle, ref ProcessEntry32 pe);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32Next(IntPtr handle, ref ProcessEntry32 pe);

        private async Task PutTaskDelay(int Time)
        {
            await Task.Delay(Time);
        }
        private async Task<IntPtr> FUCK_IS_ALWAYS_REAL(string type)
        {
            string gameloop = "HD-Player";
            string gaga = "AndroidProccess";

            var intPtr = IntPtr.Zero;
            uint num = 0U;
            var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
            if ((int)intPtr2 > 0)
            {
                ProcessEntry32 processEntry = default;
                processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                int num2 = Process32First(intPtr2, ref processEntry);
                while (num2 == 1)
                {
                    var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                    Marshal.StructureToPtr(processEntry, intPtr3, true);
                    ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                    Marshal.FreeHGlobal(intPtr3);
                    if (processEntry2.szExeFile.Contains(gameloop) && processEntry2.cntThreads > num)
                    {
                        num = processEntry2.cntThreads;
                        intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                    }

                    num2 = Process32Next(intPtr2, ref processEntry);
                }
                PID.Text = Convert.ToString(intPtr);
                await PutTaskDelay(1000);
                if (type == "1")
                //no recoil
                {
                    DESABILITAR_NO_RECOIL();
                }
                if (type == "2")
                //no recoil
                {
                    remover_antena();
                }
                if (type == "3")
                //no recoil
                {
                    DESABILITAR_VERMELHO();
                }
                if (type == "4")
                //no recoil
                {
                    remover_aimleg();
                }



            }

            return intPtr;
        }
        private string sr;

        public async void DRIERSSSS_LOAD_AUTO_IN_PROCESSS(string type)
        {
            x = 0;
            await FUCK_IS_ALWAYS_REAL(type);
        }
        public long enumerable = new long();
#endregion
        //norecoil
        #region
        public async void DESABILITAR_NO_RECOIL()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Falha ao Conectar.";
            }
            else
            {
                PSPS.ForeColor = Color.Green;
                PSPS.Text = "Conectado.";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                PSPS.ForeColor = Color.Orange;
                PSPS.Text = "Aplicando...";


                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "00 D7 5B 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "80 37 8F 3C", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Removido com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Removido ! Re-removendo...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("1");
                }
                else
                {
                    PSPS.Text = "Falha ao Remover ";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        #endregion
        //antena
        #region
        public async void remover_antena()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Falha ao Remover .";
            }
            else
            {
                PSPS.ForeColor = Color.Green;
                PSPS.Text = "Conectado.";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                PSPS.ForeColor = Color.Orange;
                PSPS.Text = "Aplicando...";



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "33 33 34 43 CF F7 AD 34", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 00 80 3F CF F7 AD 34", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Removido  com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao remover! Re-Removendo...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("2");
                }
                else
                {
                    PSPS.Text = "Falha ao Remover ";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        #endregion
        //VERMELHO
        #region
        public async void DESABILITAR_VERMELHO()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Falha ao Conectar.";
            }
            else
            {
                PSPS.ForeColor = Color.Green;
                PSPS.Text = "Conectado.";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                PSPS.ForeColor = Color.Orange;
                PSPS.Text = "Removendo...";



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "96 00 00 00 00 00 B8 40 00 00 00 00 00 00 00 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "96 00 00 00 00 00 B0 40 00 00 80 3F 00 00 40 3F", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Removido com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao remover! Re-removendo...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("3");
                }
                else
                {
                    PSPS.Text = "Falha ao remover";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        #endregion
        #region

        public async void remover_aimleg()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Falha ao Conectar.";
            }
            else
            {
                PSPS.ForeColor = Color.Green;
                PSPS.Text = "Conectado.";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                PSPS.ForeColor = Color.Orange;
                PSPS.Text = "Removendo...";



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "70 4C 2D E9 10 B0 8D E", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "7F 45 4C 46 01 01 01 00", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Removido com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao remover! Re-removendo...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("4");
                }
                else
                {
                    PSPS.Text = "Falha ao remover";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        #endregion


        private int x;
        public Mem MemLib = new Mem();
        private static string string_0;
        private IContainer icontainer_0;

        public struct ProcessEntry32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }

        private void DESABILITAR_Load(object sender, EventArgs e)
        {

        }

        private void btnnorecoil_Click(object sender, EventArgs e)
        {
            PSPS.Text = "Conectando...";
            PSPS.ForeColor = Color.Orange;
            DRIERSSSS_LOAD_AUTO_IN_PROCESSS("1");
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            PSPS.Text = "Conectando...";
            PSPS.ForeColor = Color.Orange;
            DRIERSSSS_LOAD_AUTO_IN_PROCESSS("2");
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            PSPS.Text = "Conectando...";
            PSPS.ForeColor = Color.Orange;
            DRIERSSSS_LOAD_AUTO_IN_PROCESSS("3");
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            Form2 main = new Form2();
            main.Show();
            this.Hide();
        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            PSPS.Text = "Conectando...";
            PSPS.ForeColor = Color.Orange;
            DRIERSSSS_LOAD_AUTO_IN_PROCESSS("4");
        }
    }
}