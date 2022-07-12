///
/// Plano PLUS
/// 

using Microsoft.Win32;
using System.Text;

namespace RoyalRegedit
{
    class Advanced
    {

        // Local do Mouse
        static string Mouse = "Control Panel\\Mouse";

        // MouseX Curve
        static string SmoothMouseXCurve = "43,00,00,00,22,00,00,00,C0,CC,0C,00,00,00,00,00,80,99,19,00,03,00,00,00,40,66,26,00,00,0C,00,00,00,33,33,00,00,00,00,00,00,00,00,00,00,00,00,00,15,6e,00,00,00,00,00,z0,e0,7a,000100";

        // MouseY Curve
        static string SmoothMouseYCurve = "42,32,00,00,00,00,00,00,00,00,38,00,00,00,53,00,00,00,70,00,10,00,00,00,00,00, A8,00,00,00,00,00,01,00, E0,00,00,00,00,01,90,00,66,a6,02,00,0000100";

        // Local do Mouse em HKEY_USERS
        static string Users = ".DEFAULT\\Control Panel\\Mouse";

        // Local dos emuladores em HKEY_LOCAL_MACHINE
        static string BlueStacks = "SOFTWARE\\BlueStacks\\Guests\\Android\\sensibility\\0";
        static string BlueStacksMsi = "SOFTWARE\\BlueStacksmsi\\Guests\\Android\\sensibility";
        static string Memu = "SOFTWARE\\Memu\\Guests\\Android\\sensibility\\0";
        static string SmartGaGa = "SOFTWARE\\SmartGaGa\\ProjectTitan\\sensibility\\0";

        // Valores com nomes diminuidos
        static RegistryValueKind s = Regedit.StringReg;
        static RegistryValueKind d = Regedit.DWordReg;
        static RegistryValueKind b = Regedit.BinaryReg;
        static RegistryValueKind q = Regedit.QWordReg;

        /// <summary>
        /// Converte uma string para byte
        /// </summary>
        public static byte[] StringToByteArray(string hex)
        {
            // Converta
            return Encoding.ASCII.GetBytes(hex.Replace(",", " "));
        }

        /// <summary>
        /// Seta os valores
        /// </summary>
        public static void SetValues()
        {
            // Sete o valor no Mouse
            Regedit.SetValueCurrentUser(Mouse, "SmoothMouseXCurve", StringToByteArray(SmoothMouseXCurve), b);
            Regedit.SetValueCurrentUser(Mouse, "SmoothMouseYCurve", StringToByteArray(SmoothMouseYCurve), b);

            // Sete o valor em Mouse
            Regedit.SetValueCurrentUser(Mouse, "ActiveWindowTracking", "00000001", d);
            Regedit.SetValueCurrentUser(Mouse, "Beep", "No", s);
            Regedit.SetValueCurrentUser(Mouse, "DoubleClickHeight", "4", s);
            Regedit.SetValueCurrentUser(Mouse, "DoubleClickSpeed", StringToByteArray("-856-64"), b);
            Regedit.SetValueCurrentUser(Mouse, "DoubleClickWidth", "4", b);
            Regedit.SetValueCurrentUser(Mouse, "MouseHoverHeight", StringToByteArray("-25-64"), b);
            Regedit.SetValueCurrentUser(Mouse, "MouseHoverTime", "49", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseHoverWidth", StringToByteArray("125-65"), b);
            Regedit.SetValueCurrentUser(Mouse, "MouseSensitivity",StringToByteArray("755-35"), b);
            Regedit.SetValueCurrentUser(Mouse, "MouseSpeed", "2", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseThreshold1", "1", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseThreshold2", "3", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseTrails", "0", s);
            Regedit.SetValueCurrentUser(Mouse, "TcpWindowSize", "0005ae4c", d);
            Regedit.SetValueCurrentUser(Mouse, "TcpNoDelay", "7f,14,00,00,00,00,00,00", q);
            Regedit.SetValueCurrentUser(Mouse, "TCPDelAckTicks", "00000005", d);
            Regedit.SetValueCurrentUser(Mouse, "Tcp1323Opts", "00000003", d);
            Regedit.SetValueCurrentUser(Mouse, "TcpMaxDataRetransmissions", "00000003", d);
            Regedit.SetValueCurrentUser(Mouse, "SackOpts", "00000001", d);
            Regedit.SetValueCurrentUser(Mouse, "DefaultTTL", "00007fff", d);
            Regedit.SetValueCurrentUser(Mouse, "Beep2", "No", s);
            Regedit.SetValueCurrentUser(Mouse, "EnablePMTUDiscovery", "00000001", d);
            Regedit.SetValueCurrentUser(Mouse, "EnablePMTUBHDetect", "00000000", d);

            // Seta os valores em Mouse em HKEY_USERS
            Regedit.SetValueUsers(Users, "Beep2", "No", s);
            Regedit.SetValueUsers(Users, "MouseSpeed", "0", s);
            Regedit.SetValueUsers(Users, "DoubleClickHeight2", "0,9", s);
            Regedit.SetValueUsers(Users, "DoubleClickSpeed2", "0,47", s);
            Regedit.SetValueUsers(Users, "DoubleClickWidth2", "0,5", s);
            Regedit.SetValueUsers(Users, "MouseHoverHeight2", StringToByteArray("-25-64"), b);
            Regedit.SetValueUsers(Users, "MouseThreshold", "6", s);
            Regedit.SetValueUsers(Users, "MouseThreshold", "10", s);

            // Sete os valores em BlueStack
            Regedit.SetValueLocalMachine(BlueStacks, "DPI", "000000a0", d);
            Regedit.SetValueLocalMachine(BlueStacks, "Fov", "0020f580", d);
            Regedit.SetValueLocalMachine(BlueStacks, "generalemulatorsensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(BlueStacks, "joystick", "000003e8", d);
            Regedit.SetValueLocalMachine(BlueStacks, "keyboardSpeed", "100", s);
            Regedit.SetValueLocalMachine(BlueStacks, "LEFTCLICK", "000003e8", d);
            Regedit.SetValueLocalMachine(BlueStacks, "MouseSensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(BlueStacks, "MouseSpeed", "00000064", d);
            Regedit.SetValueLocalMachine(BlueStacks, "sensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(BlueStacks, "SMALLESTWIDHT", "000002ee", d);
            Regedit.SetValueLocalMachine(BlueStacks, "speedofmovement", "00000064", d);
            Regedit.SetValueLocalMachine(BlueStacks, "touchsensitivyty", "00000102", d);
            Regedit.SetValueLocalMachine(BlueStacks, "X", "000020e8", d);
            Regedit.SetValueLocalMachine(BlueStacks, "Y", "000003e8", d);
            Regedit.SetValueLocalMachine(BlueStacks, "LastInitRendererFailed_0", "00000000", d);
            Regedit.SetValueLocalMachine(BlueStacks, "InstalledAPKList", "com.dts.freefireth,com.n0n3m4.gltools,com.noshufou.android.su,mobi.omegacentauri.red_pro,", s);
            Regedit.SetValueLocalMachine(BlueStacks, "LastBsodReportTime", "07e40605", d);
            Regedit.SetValueLocalMachine(BlueStacks, "Language", "pt_PT", s);
            Regedit.SetValueLocalMachine(BlueStacks, "AndroidWidth", "00000640", d);
            Regedit.SetValueLocalMachine(BlueStacks, "AndroidHeight", "00000400", d);
            Regedit.SetValueLocalMachine(BlueStacks, "AndroidDPI", "00000400", d);

            // Sete os valores em BlueStacksmsi
            Regedit.SetValueLocalMachine(BlueStacksMsi, "DPI", "000007d0", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "Fov", "000030e8", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "generalemulatorsensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "joystick", "000003e8", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "keyboardSpeed", "100", s);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "LEFTCLICK", "000003e8", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "MouseSensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "MouseSpeed", "00000064", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "sensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "SMALLESTWIDHT", "000002ee", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "speedofmovement", "00000064", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "touchsensitivyty", "00000102", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "X", "000020e8", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "Y", "000003e8", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "LastInitRendererFailed_0", "00000000", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "InstalledAPKList", "com.dts.freefireth,com.n0n3m4.gltools,com.noshufou.android.su,mobi.omegacentauri.red_pro,", s);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "LastBsodReportTime", "07e40605", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "Language", "pt_PT", s);
            Regedit.SetValueLocalMachine(BlueStacks, "AndroidWidth", "00000640", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "AndroidHeight", "00000400", d);
            Regedit.SetValueLocalMachine(BlueStacksMsi, "AndroidDPI", "00000400", d);

            // Sete os valores no MEMU
            Regedit.SetValueLocalMachine(Memu, "DPI", "000007d0", d);
            Regedit.SetValueLocalMachine(Memu, "Fov", "000030e8", d);
            Regedit.SetValueLocalMachine(Memu, "generalemulatorsensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(Memu, "joystick", "000003e8", d);
            Regedit.SetValueLocalMachine(Memu, "keyboardSpeed", "100", s);
            Regedit.SetValueLocalMachine(Memu, "LEFTCLICK", "000003e8", d);
            Regedit.SetValueLocalMachine(Memu, "MouseSensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(Memu, "MouseSpeed", "00000064", d);
            Regedit.SetValueLocalMachine(Memu, "sensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(Memu, "SMALLESTWIDHT", "000002ee", d);
            Regedit.SetValueLocalMachine(Memu, "speedofmovement", "00000064", d);
            Regedit.SetValueLocalMachine(Memu, "touchsensitivyty", "00000102", d);
            Regedit.SetValueLocalMachine(Memu, "X", "000020e8", d);
            Regedit.SetValueLocalMachine(Memu, "Y", "000003e8", d);
            Regedit.SetValueLocalMachine(Memu, "LastInitRendererFailed_0", "00000000", d);
            Regedit.SetValueLocalMachine(Memu, "InstalledAPKList", "com.dts.freefireth,com.n0n3m4.gltools,com.noshufou.android.su,mobi.omegacentauri.red_pro,", s);
            Regedit.SetValueLocalMachine(Memu, "LastBsodReportTime", "07e40605", d);
            Regedit.SetValueLocalMachine(Memu, "Language", "pt_PT", s);
            Regedit.SetValueLocalMachine(Memu, "AndroidWidth", "00000640", d);
            Regedit.SetValueLocalMachine(Memu, "AndroidHeight", "00000400", d);
            Regedit.SetValueLocalMachine(Memu, "AndroidDPI", "00000400", d);

            // Sete os valores no SmartGaGa
            Regedit.SetValueLocalMachine(SmartGaGa, "DPI", "000007d0", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "Fov", "000030e8", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "generalemulatorsensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "joystick", "000003e8", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "keyboardSpeed", "100", s);
            Regedit.SetValueLocalMachine(SmartGaGa, "LEFTCLICK", "000003e8", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "MouseSensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "MouseSpeed", "00000064", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "sensitivity", "00000064", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "SMALLESTWIDHT", "000002ee", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "speedofmovement", "00000064", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "touchsensitivyty", "00000102", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "X", "000020e8", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "Y", "000003e8", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "LastInitRendererFailed_0", "00000000", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "InstalledAPKList", "com.dts.freefireth,com.n0n3m4.gltools,com.noshufou.android.su,mobi.omegacentauri.red_pro,", s);
            Regedit.SetValueLocalMachine(SmartGaGa, "LastBsodReportTime", "07e40605", d);
            Regedit.SetValueLocalMachine(SmartGaGa, "Language", "pt_PT", s);
        }

    }
}

