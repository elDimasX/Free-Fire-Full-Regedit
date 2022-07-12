///
/// Campeão
///

using Microsoft.Win32;
using System.Text;

namespace RoyalRegedit
{

    class Legendary
    {

        // Local do Mouse
        static string Mouse = "Control Panel\\Mouse";

        // Valores com nomes diminuidos
        static RegistryValueKind s = Regedit.StringReg;
        static RegistryValueKind d = Regedit.DWordReg;
        static RegistryValueKind b = Regedit.BinaryReg;
        static RegistryValueKind q = Regedit.QWordReg;

        // MouseX Curve
        static string SmoothMouseXCurve = "00,00,00,00,00,00,00,00,15,6e,00,00,00,00,00,00,00,40,01,00,00,00,00,00,29, dc,03,00,00,00,00,00,00,00,28,00,00,00,00,00";

        // MouseY Curve
        static string SmoothMouseYCurve = "00,00,00,00,00,00,00,00,fd,11,01,00,00,00,00,00,00,24,04,00,00,00,00,00,00, fc,12,00,00,00,00,00,00, c0, bb,01,00,00,00,00";

        // Local do Mouse em HKEY_USERS
        static string Users = ".DEFAULT\\Control Panel\\Mouse";

        // Local do Redirect
        static string Redirect = "SOFTWARE\\BlueStacks\\Guests\\Android\\Network\\Redirect";

        /// <summary>
        /// Converte uma string para byte
        /// </summary>
        public static byte[] StringToByteArray(string hex)
        {
            // Converta
            return Encoding.ASCII.GetBytes(hex.Replace(",", " "));
        }

        /// <summary>
        /// Seta os valores em Legendary
        /// </summary>
        public static void SetValues()
        {
            // Sete o valor em Mouse
            Regedit.SetValueCurrentUser(Mouse, "SmoothMouseXCurve", StringToByteArray(SmoothMouseXCurve), b);
            Regedit.SetValueCurrentUser(Mouse, "SmoothMouseYCurve", StringToByteArray(SmoothMouseYCurve), b);

            // Sete o valor em Mouse
            Regedit.SetValueCurrentUser(Mouse, "ActiveWindowTracking", "00000001", d);
            Regedit.SetValueCurrentUser(Mouse, "Beep", "No", s);
            Regedit.SetValueCurrentUser(Mouse, "DoubleClickHeight", "4", s);
            Regedit.SetValueCurrentUser(Mouse, "DoubleClickSpeed", StringToByteArray("-856-64"), b);
            Regedit.SetValueCurrentUser(Mouse, "DoubleClickWidth", StringToByteArray("125-65"), b);
            Regedit.SetValueCurrentUser(Mouse, "MouseHoverHeight", "4", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseSensitivity", "6", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseSpeed", "123", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseThreshold1", "24", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseThreshold2", "52", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseTrails", "0", s);
            Regedit.SetValueCurrentUser(Mouse, "TcpWindowSize", "0005ae4c",d);
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

            // Seta os valores em Network
            //Regedit.SetValueLocalMachine(Network, "InboundRules", StringToByteArray(InboundRules), b);


            // Seta os valores em Redirect
            Regedit.SetValueLocalMachine(Redirect, "tcp/5555", "000015b3", d);
            Regedit.SetValueLocalMachine(Redirect, "tcp/6666", "00001a0a", d);
            Regedit.SetValueLocalMachine(Redirect, "tcp/7777", "00001e61", d);
            Regedit.SetValueLocalMachine(Redirect, "tcp/9999", "0000270f", d);
            Regedit.SetValueLocalMachine(Redirect, "udp/12000", "00002ee0", d);

        }

    }
}
