///
/// Operações do Regedit
///

using Microsoft.Win32;
using System;

namespace RoyalRegedit
{
    class Regedit
    {
        // String
        public static RegistryValueKind StringReg = RegistryValueKind.String;

        // DWORD
        public static RegistryValueKind DWordReg = RegistryValueKind.DWord;

        // QWORD
        public static RegistryValueKind QWordReg = RegistryValueKind.QWord;

        // Binary
        public static RegistryValueKind BinaryReg = RegistryValueKind.Binary;

        /// <summary>
        /// Seta um valor no registro no HKEY_CURRENT_USER
        /// </summary>
        public static void SetValueCurrentUser(string subkey, string valueName, object value, RegistryValueKind typeRegistry)
        {
            try
            {
                // Key
                RegistryKey key;

                // Abra uma chave no registro
                key = Registry.CurrentUser.OpenSubKey(subkey, true);

                // Agora, sete o valor
                key.SetValue(valueName, value, typeRegistry);
            } catch (Exception) { }
            
        }

        /// <summary>
        /// Seta um valor no registro no HKEY_LOCAL_MACHINE
        /// </summary>
        public static void SetValueLocalMachine(string subkey, string valueName, object value, RegistryValueKind typeRegistry)
        {
            try
            {
                // Key
                RegistryKey key;

                // Abra uma chave no registro
                key = Registry.LocalMachine.OpenSubKey(subkey, true);

                // Agora, sete o valor
                key.SetValue(valueName, value, typeRegistry);
            } catch (Exception) { }
        }

        /// <summary>
        /// Seta um valor no registro no HKEY_USERS
        /// </summary>
        public static void SetValueUsers(string subkey, string valueName, object value, RegistryValueKind typeRegistry)
        {
            try
            {
                // Key
                RegistryKey key;

                // Abra uma chave no registro
                key = Registry.Users.OpenSubKey(subkey, true);

                // Agora, sete o valor
                key.SetValue(valueName, value, typeRegistry);
            } catch (Exception) { }
        }

    }
}
