
///
/// Esse programa já me rendeu uma bela experiencia e histórias, foi incrível
/// mas espero que você possa fazer o mesmo com ele....
/// Me adicione no discord: elDimas#8829   :)
///

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Memory;
using Auth.GG_Winform_Example;
using System.Diagnostics;
using LagSwitch;

namespace ROYAL_FULL
{

    public partial class Form2 : Form
    {
        // LagSwitchOperacoes
        public Form2()
        {
            InitializeComponent();

            //LagSwitchOperacoes.Lag();
            
            /*
            btnnorecoil.Enabled = false;
            btnaimfov.Enabled = false;
            precisao.Enabled = false;
            btnaimlock.Enabled = false;
            btnvermelho.Enabled = false;
            btnantena.Enabled = false;
            btnheadlock.Enabled = false;
            btnaimleg.Enabled = false;
            btnlagswitch.Enabled = false;
            //nuevos
            btnpresiçaoplus.Enabled = false;
            aimlockplus.Enabled = false;
            bala.Enabled = false;
            superaimlock.Enabled = false;
            btnblock.Enabled = false;
            */

        }

        //cheats codes
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
                //aimfov
                {
                    ChANGINNNNNNGGG_AOB();
                }
                else if (type == "2")
                //no recoil
                {
                    NORECOIL();
                }
                else if (type == "3")
                //antena
                {
                    ANTENA();
                }
                else if (type == "4")
                //presiçao
                {
                    MiraP();
                }
                else if (type == "5")
                //vermelho
                {
                    Vermelhão();
                }

                else if (type == "6")
                //presicao ++
                {
                    nop();
                }
                //aimlock
                else if (type == "7")
                {
                    Aimlock();
                }
                //aimlock v2
                else if (type == "8")
                {
                    AimlockV2();
                }
                else if (type == "9")
                {
                    presiçaoplus();
                }
                else if (type == "10")
                {
                    aimlock_plus();
                }
                else if (type == "11")
                {
                    balamagica();
                }
                else if (type == "12")
                {
                    super();
                }
                else if (type == "13")
                {
                    block();
                }

            }

            return intPtr;
        }

        public async void DRIERSSSS_LOAD_AUTO_IN_PROCESSS(string type)
        {
            x = 0;
            await FUCK_IS_ALWAYS_REAL(type);
        }
        public long enumerable = new long();

        public async void ChANGINNNNNNGGG_AOB()
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

                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "AE 47 01 3F", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "80 7B E1 FF FF FF FF FF", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("1");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void NORECOIL()
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


                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "80 37 8F 3C", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 D7 5B 00", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("2");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void ANTENA()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "00 00 80 3F CF F7 AD 34", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "33 33 34 43 CF F7 AD 34", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("3");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void MiraP()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 41", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 00 71 41 00 00 0F 38 00 00 72 41 00 00 47 45", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("4");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void Vermelhão()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "96 00 00 00 00 00 B0 40 00 00 80 3F 00 00 40 3F", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "96 00 00 00 00 00 B8 40 00 00 00 00 00 00 00 00", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("5");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void nop()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "7F 45 4C 46 01 01 01 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "01 00 A0 E3 1E FF 2F E1", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("6");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void Aimlock()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 41", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 00 71 41 00 00 0F 38 00 00 72 41 00 00 47 45", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("7");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void presiçaoplus()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "7F 45 4C 46 01 01 01 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "01 00 A0 E3 1E FF 2F E1", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("9");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void AimlockV2()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "7F 45 4C 46 01 01 01 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "70 4C 2D E9 10 B0 8D E", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("8");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void aimlock_plus()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "7F 45 4C 46 01 01 01 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "70 4C 2D E9 10 B0 8D E", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("10");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void balamagica()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "7F 45 4C 46 01 01 01 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 00 80 3F", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("11");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void super()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "30 19 8F 05", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "D0 64 C1 00", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("12");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void block()
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



                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, "7F 45 4C 46 01 01 01 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "10 02 90 E5 1E FF 2F E1", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    PSPS.Text = "Aplicado com Sucesso!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    PSPS.ForeColor = Color.Yellow;
                    PSPS.Text = "Falha ao Aplicar! Re-Aplicando...";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("13");
                }
                else
                {
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

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

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return dtDateTime;
        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        //cheats
        #region 

        private void btnnorecoil_Click(object sender, EventArgs e)
        {
            if (norecoil == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("2");
            }
        }

        private void btnaimfov_Click(object sender, EventArgs e)
        {
            if (aimov == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("1");
            }
        }

        private void precisao_Click(object sender, EventArgs e)
        {
            if (precisaover == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("4");
            }
        }

        private void vermelho_Click(object sender, EventArgs e)
        {
            if (vermelho == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("5");
            }
        }

        private void btnantena_Click(object sender, EventArgs e)
        {
            if (antena == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("3");
            }
        }

        private void btnheadlock_Click(object sender, EventArgs e)
        {
            if (headlock == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("6");
            }
        }

        private void btnaimlock_Click(object sender, EventArgs e)
        {
            if (aimlock == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("7");
            }
            #endregion
        }
        //lag

        private void btnbuget_Click(object sender, EventArgs e)
        {
            if (lagswitch == true)
            {
                Hide();
                Form1 main = new Form1();
                main.ShowDialog();
                Show();
            }
        }

        private void AIMLEG_Click(object sender, EventArgs e)
        {
            if (aimleg == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("8");
            }
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            DESABILITAR main = new DESABILITAR();
            main.Show();
            this.Hide();
        }

        bool norecoil = false;
        bool aimov = false;
        bool precisaover = false;
        bool aimlock = false;
        bool aimleg = false;
        bool lagswitch = false;
        bool vermelho = false;
        bool antena = false;
        bool headlock = false;


        bool superAimlock = false;
        bool Block = false;
        bool precisaoPlus = false;
        bool aimlockPlus = false;
        bool balaMagica = false;

        //nuevos

        /// <summary>
        /// Você deve especificar isso no Form2 [Design]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            username.Text = "" + Dados.Logado.UsuarioAtual;

            rankverify.Text = "" + Dados.Logado.PlanoAtual;
            if (rankverify.Text == "0")
            {
                btnnorecoil.Enabled = false;
                btnnorecoil.BaseColor1 = Color.Gray;
                btnnorecoil.BaseColor2 = Color.Gray;

                btnaimfov.Enabled = false;
                btnaimfov.BaseColor1 = Color.Gray;
                btnaimfov.BaseColor2 = Color.Gray;

                precisao.Enabled = false;
                precisao.BaseColor1 = Color.Gray;
                precisao.BaseColor2 = Color.Gray;

                btnaimlock.Enabled = false;
                btnaimlock.BaseColor1 = Color.Gray;
                btnaimlock.BaseColor2 = Color.Gray;

                btnvermelho.Enabled = false;
                btnvermelho.BaseColor1 = Color.Gray;
                btnvermelho.BaseColor2 = Color.Gray;

                btnantena.Enabled = false;
                btnantena.BaseColor1 = Color.Gray;
                btnantena.BaseColor2 = Color.Gray;

                btnheadlock.Enabled = false;
                btnheadlock.BaseColor1 = Color.Gray;
                btnheadlock.BaseColor2 = Color.Gray;

                btnlagswitch.Enabled = false;
                btnlagswitch.BaseColor1 = Color.Gray;
                btnlagswitch.BaseColor2 = Color.Gray;

                btnaimleg.Enabled = false;
                btnaimleg.BaseColor1 = Color.Gray;
                btnaimleg.BaseColor2 = Color.Gray;

                btnpresiçaoplus.Enabled = false;
                btnpresiçaoplus.BaseColor1 = Color.Gray;
                btnpresiçaoplus.BaseColor2 = Color.Gray;

                btnpresiçaoplus.Enabled = false;
                btnpresiçaoplus.BaseColor1 = Color.Gray;
                btnpresiçaoplus.BaseColor2 = Color.Gray;


                aimlockplus.Enabled = false;
                aimlockplus.BaseColor1 = Color.Gray;
                aimlockplus.BaseColor2 = Color.Gray;

                bala.Enabled = false;
                bala.BaseColor1 = Color.Gray;
                bala.BaseColor2 = Color.Gray;

                superaimlock.Enabled = false;
                superaimlock.BaseColor1 = Color.Gray;
                superaimlock.BaseColor2 = Color.Gray;

                btnblock.Enabled = false;
                btnblock.BaseColor1 = Color.Gray;
                btnblock.BaseColor2 = Color.Gray;








            }

            else if (rankverify.Text == "1")
            {
                btnnorecoil.Enabled = true;
                norecoil = true;
            }

            else if (rankverify.Text == "2")
            {
                btnaimfov.Enabled = true;
                aimov = true;
            }

            else if (rankverify.Text == "3")
            {
                precisao.Enabled = true;
                precisaover = true;
            }

            else if (rankverify.Text == "4")
            {
                btnaimlock.Enabled = true;
                aimlock = true;
            }

            else if (rankverify.Text == "5")
            {
                btnvermelho.Enabled = true;
                vermelho = true;
            }
            else if (rankverify.Text == "6")
            {
                btnantena.Enabled = true;
                antena = true;
            }

            else if (rankverify.Text == "7")
            {
                btnheadlock.Enabled = true;
                headlock = true;
            }
            else if (rankverify.Text == "8")
            {
                btnheadlock.Enabled = true;
                btnaimlock.Enabled = true;
                precisao.Enabled = true;

                headlock = true;
                aimlock = true;
                precisaover = true;
            }
            else if (rankverify.Text == "9")
            {
                btnnorecoil.Enabled = true;
                btnaimlock.Enabled = true;
                btnheadlock.Enabled = true;
                btnaimleg.Enabled = true;

                norecoil = true;
                aimlock = true;
                headlock = true;
                aimleg = true;
            }
            else if (rankverify.Text == "10")
            {
                btnnorecoil.Enabled = true;
                btnaimfov.Enabled = true;
                btnantena.Enabled = true;

                norecoil = true;
                aimov = true;
                antena = true;
            }
            else if (rankverify.Text == "100")
            {
                btnnorecoil.Enabled = true;
                btnaimfov.Enabled = true;
                precisao.Enabled = true;
                btnaimlock.Enabled = true;
                btnvermelho.Enabled = true;
                btnheadlock.Enabled = true;
                btnantena.Enabled = true;

                norecoil = true;
                aimov = true;
                precisaover = true;
                aimlock = true;
                vermelho = true;
                headlock = true;
                antena = true;
            }
            else if (rankverify.Text == "200")
            {
                btnnorecoil.Enabled = true;
                btnaimfov.Enabled = true;
                precisao.Enabled = true;
                btnaimlock.Enabled = true;
                btnvermelho.Enabled = true;
                btnheadlock.Enabled = true;
                btnantena.Enabled = true;
                btnaimleg.Enabled = true;
                btnlagswitch.Enabled = true;

                norecoil = true;
                aimov = true;
                precisaover = true;
                aimlock = true;
                vermelho = true;
                headlock = true;
                antena = true;
                aimleg = true;
                lagswitch = true;
            }

            else if (rankverify.Text == "300")
            {
                btnnorecoil.Enabled = true;
                btnaimfov.Enabled = true;
                precisao.Enabled = true;
                btnaimlock.Enabled = true;
                btnvermelho.Enabled = true;
                btnheadlock.Enabled = true;
                btnantena.Enabled = true;
                btnaimleg.Enabled = true;
                btnlagswitch.Enabled = true;

                norecoil = true;
                aimov = true;
                precisaover = true;
                aimlock = true;
                vermelho = true;
                headlock = true;
                antena = true;
                aimleg = true;
                lagswitch = true;

                superAimlock = true;
                Block = true;
                precisaoPlus = true;
                aimlockPlus = true;
                balaMagica = true;

                //nuevos
                btnpresiçaoplus.Enabled = true;
                aimlockplus.Enabled = true;
                bala.Enabled = true;
                superaimlock.Enabled = true;
                btnblock.Enabled = true;
            }



        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnpresiçaoplus_Click(object sender, EventArgs e)
        {
            if (precisaoPlus == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("9");
            }
        }

        private void aimlockplus_Click(object sender, EventArgs e)
        {
            if (aimlockPlus == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("10");
            }
        }

        private void bala_Click(object sender, EventArgs e)
        {
            if (balaMagica == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("11");
            }
        }

        private void superaimlock_Click(object sender, EventArgs e)
        {
            if (superAimlock == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("12");
            }
        }

        private void btnblock_Click(object sender, EventArgs e)
        {
            if (Block == true)
            {
                PSPS.Text = "Conectando...";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("13");
            }
        }

        private void gunaGradientButton9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("en BREVE");
        }


    }
}
