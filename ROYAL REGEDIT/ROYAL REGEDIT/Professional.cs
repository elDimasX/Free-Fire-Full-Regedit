///
/// PRO
///

using Microsoft.Win32;

namespace RoyalRegedit
{
    class Professional
    {
        // Local do Mouse
        static string Mouse = "Control Panel\\Mouse";

        // MouseX Curve
        static string SmoothMouseXCurve = "43,00,00,00,22,00,00,00,C0,CC,0C,00,00,00,00,00,80,99,19,00,03,00,00,00,40,66,26,00,00,0C,00,00,00,33,33,00,00,00,00,00,00,00,00,00,00,00,00,00,15,6e,00,00,00,00,00,z0,e0,7a,000100";

        // MouseY Curve
        static string SmoothMouseYCurve = "42,32,00,00,00,00,00,00,00,00,38,00,00,00,53,00,00,00,70,00,10,00,00,00,00,00, A8,00,00,00,00,00,01,00, E0,00,00,00,00,01,90,,66, a6,02,00,0000100";

        // Valores com nomes diminuidos
        static RegistryValueKind s = Regedit.StringReg;
        static RegistryValueKind d = Regedit.DWordReg;
        static RegistryValueKind b = Regedit.BinaryReg;
        static RegistryValueKind q = Regedit.QWordReg;

        /// <summary>
        /// Altera os valores no regedit
        /// </summary>
        public static void SetValues()
        {
            // Sete o valor no Mouse
            Regedit.SetValueCurrentUser(Mouse, "SmoothMouseXCurve", Legendary.StringToByteArray(SmoothMouseXCurve), b);
            Regedit.SetValueCurrentUser(Mouse, "SmoothMouseYCurve", Legendary.StringToByteArray(SmoothMouseYCurve), b);

            // Sete o valor em Mouse
            Regedit.SetValueCurrentUser(Mouse, "ActiveWindowTracking", "00000001", d);
            Regedit.SetValueCurrentUser(Mouse, "Beep", "No", s);
            Regedit.SetValueCurrentUser(Mouse, "DoubleClickHeight", "4", s);
            Regedit.SetValueCurrentUser(Mouse, "DoubleClickSpeed", "500", b);
            Regedit.SetValueCurrentUser(Mouse, "DoubleClickWidth", "4", b);
            Regedit.SetValueCurrentUser(Mouse, "MouseHoverHeight", "4", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseHoverTime", "9", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseSensitivity", "10", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseSpeed", "2", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseThreshold1", "0", s);
            Regedit.SetValueCurrentUser(Mouse, "MouseThreshold2", "0", s);
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
        }

    }
}
