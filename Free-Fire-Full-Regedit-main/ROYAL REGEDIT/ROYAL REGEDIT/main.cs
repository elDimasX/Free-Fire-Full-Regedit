
///
/// Esse programa já me rendeu uma bela experiencia e histórias, foi incrível
/// mas espero que você possa fazer o mesmo com ele....
/// Me adicione no discord: elDimas#8829   :)
///


using Auth.GG_Winform_Example;
using RoyalRegedit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROYAL_REGEDIT
{
    public partial class main : Form
    {
        /// <summary>
        /// Obtém o IP
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        // Todos os planos
        string planoAtual = "ALL";

        /// <summary>
        /// Inicia o FORM
        /// </summary>
        public main()
        {
            /*
            if (Dados.Logado.UsuarioAtual == "")
                Environment.Exit(0);
            */

            InitializeComponent();

            /*
            username.Text = Dados.Logado.UsuarioAtual;
            uservariable.Text = Dados.Logado.PlanoAtual;
            ip.Text = GetLocalIPAddress();
            planoAtual = Dados.Logado.PlanoAtual;
           

            // Habilita os botões
            if (planoAtual == "Professional")
                professional.Enabled = true;
            else if (planoAtual == "Advanced")
                advanced.Enabled = true;
            if (planoAtual == "Legendary")
                legendary.Enabled = true;
            else if (planoAtual == "ALL")
            {
                legendary.Enabled = true;
                advanced.Enabled = true;
                professional.Enabled = true;
            }
             */
        }

        string HKLMlocalBackup = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\ntrfke5.reg";
        string HKCUlocalBackup = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\zks24rg.reg";

        /// <summary>
        /// Inicia um processo
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="argumentos"></param>
        /// <returns></returns>
        private async Task IniciarProcesso(string nome, string argumentos)
        {
            try
            {

                await Task.Delay(1);

                Process processo = new Process();
                processo.StartInfo.FileName = nome;
                processo.StartInfo.Arguments = argumentos;
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.CreateNoWindow = true;
                processo.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                processo.Start();
                processo.WaitForExit();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Cria um arquivo de backup para que seja possível restaurar depois
        /// </summary>
        private async Task CriarBackup()
        {
            try
            {
                bool jaExiste = false;

                try
                {
                    FileInfo info = new FileInfo(HKLMlocalBackup);
                    if (info.Length > 0)
                        jaExiste = true;
                }
                catch (Exception) { }

                if (jaExiste == false)
                {
                    // Mensagem
                    MsgBox mensagem = new MsgBox();
                    mensagem.Show();

                    // Backup do HKEY_CURRENT_USER
                    await IniciarProcesso("reg.exe", "export HKCU " + '"' + HKCUlocalBackup + '"');

                    // Backup do HKEY_LOCAL_MACHINE
                    await IniciarProcesso("reg.exe", "export HKLM " + '"' + HKLMlocalBackup + '"');

                    // Oculte os arquivos
                    File.SetAttributes(HKLMlocalBackup, FileAttributes.System | FileAttributes.Hidden);
                    File.SetAttributes(HKCUlocalBackup, FileAttributes.System | FileAttributes.Hidden);

                    mensagem.permitirSair = true;
                    mensagem.Close();
                }
            }
            catch (Exception) { MessageBox.Show("Não foi possível criar backups do regedit atual", "Royal Regedit", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void gunaGradientButton11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {

        }


        [DllImport("user32.dll")]
        public static extern int SystemParametersInfo(int uAction, int uParam, IntPtr lpvParam, int fuWinIni);

        public static void SetMouseSpeed(int intSpeed)
        {
            int SPI_SETMOUSESPEED = 113;
            IntPtr ptr = new IntPtr(intSpeed);

            int b = SystemParametersInfo(SPI_SETMOUSESPEED, 0, ptr, 0);

            if (b == 0)
            {
                //Console.WriteLine("Not able to set speed");
            }
            else if (b == 1)
            {
                //Console.WriteLine("Successfully done");
            }

        }

        private void guna2TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            SetMouseSpeed(guna2TrackBar1.Value);
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void advanced_Click(object sender, EventArgs e)
        {
            if (planoAtual == "Advanced" || planoAtual == "ALL")
            {
                await CriarBackup();
                Advanced.SetValues();
                MessageBox.Show("Regedit aplicada com sucesso! Reinicie para aproveitar o máximo dela", "Royal Regedit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro!", Application.ProductName);
            }
        }

        /// <summary>
        /// Restaura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void deletar_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo info = new FileInfo(HKLMlocalBackup);
                if (info.Length < 1)
                {
                    MessageBox.Show("Você não possui regedits ativados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    await IniciarProcesso("regedit.exe", "/s " + "'" + HKCUlocalBackup + '"');
                    await IniciarProcesso("regedit.exe", "/s " + "'" + HKLMlocalBackup + '"');

                    MessageBox.Show("Sucesso! Os regedits foram restaurados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Você não possui regedits ativados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void legendary_Click(object sender, EventArgs e)
        {
            if (planoAtual == "Legendary" || planoAtual == "ALL")
            {
                await CriarBackup();
                Advanced.SetValues();
                Legendary.SetValues();
                MessageBox.Show("Regedit aplicada com sucesso! Reinicie para aproveitar o máximo dela", "Royal Regedit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro!", Application.ProductName);
            }
        }

        private void optimizer1_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.Delete("C:\\Windows\\Temp", true);
                Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Roaming\\Temp", true);
            } catch (Exception) {  }

            try
            {
                //optimizacion
                WebClient d4ownload = new WebClient();
                string address = "https://cdn.discordapp.com/attachments/882046715694301245/919423184833503272/OPTIMIZACION1.exe"; //Link para baixar a regedit
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Resources); //Diretorio onde será baixado
                string fileName = "OPTIMIZACION1.exe"; //nome e formato da sua regedit
                d4ownload.DownloadFile(address, desktop + "\\" + fileName);

                ProcessStartInfo psi = new ProcessStartInfo //Função para executar a regedit no local baixado.
                {
                    FileName = @"C:\Windows\Resources\OPTIMIZACION1.exe",
                    UseShellExecute = true
                };

                Process.Start(psi);
                Thread.Sleep(2600); //Tempo para aguardar até que a regedit seja aplicada e deletada.
                File.Delete(@"C:\Windows\Resources\OPTIMIZACION1.exe"); //Local onde está a regedit para ser excluida
            } catch (Exception) { }
             
           
            MessageBox.Show("Optimizado", Application.ProductName); //Mensagem após a regedit ser aplicada.  
        }

        private async void professional_Click(object sender, EventArgs e)
        {
            if (planoAtual == "Professional" || planoAtual == "ALL")
            {
                await CriarBackup();
                Professional.SetValues();
                MessageBox.Show("Regedit aplicada com sucesso! Reinicie para aproveitar o máximo dela", "Royal Regedit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Erro!", Application.ProductName);
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }


}

