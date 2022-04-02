﻿using Auth.GG_Winform_Example;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
///
/// Este formulário está desativado, para fazer a conexão com o mongoDB, você precisa configurar
/// Tudo antes, e depois, especificar sua chave aqui
///

using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROYAL_FULL
{
    public partial class login : Form
    {
        // Usado para login automatico
        string usuarioSalvo = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\nouserSave.txt";
        string senhaSalvo = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\nopassSave.txt";

        /// <summary>
        /// https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
        /// </summary>
        public static class StringCipher
        {
            // This constant is used to determine the keysize of the encryption algorithm in bits.
            // We divide this by 8 within the code below to get the equivalent number of bytes.
            private const int Keysize = 256;

            // This constant determines the number of iterations for the password bytes generation function.
            private const int DerivationIterations = 1000;

            public static string Encrypt(string plainText, string passPhrase)
            {
                // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
                // so that the same Salt and IV values can be used when decrypting.  
                var saltStringBytes = Generate256BitsOfRandomEntropy();
                var ivStringBytes = Generate256BitsOfRandomEntropy();
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
                {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.PKCS7;
                        using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                    var cipherTextBytes = saltStringBytes;
                                    cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                    cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                    memoryStream.Close();
                                    cryptoStream.Close();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            public static string Decrypt(string cipherText, string passPhrase)
            {
                // Get the complete stream of bytes that represent:
                // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
                var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
                // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
                var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
                // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
                var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
                // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
                var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
                {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.PKCS7;
                        using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                        {
                            using (var memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    var plainTextBytes = new byte[cipherTextBytes.Length];
                                    var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    memoryStream.Close();
                                    cryptoStream.Close();
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }

            private static byte[] Generate256BitsOfRandomEntropy()
            {
                var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    // Fill the array with cryptographically secure random bytes.
                    rngCsp.GetBytes(randomBytes);
                }
                return randomBytes;
            }
        }

        /// <summary>
        /// Atualização automatica
        /// </summary>
        #region
        public class LinksDownloads
        {
            // O link pra download da nova versão
            public static string urlNovoLink = "https://pastebin.com/raw/8VHE6Efa";

            // Obtemos a versão do programa
            public static string versaoPrograma = "https://pastebin.com/raw/n2udXcKq";
        }

        private void AtualizacaoAutomatica()
        {
            try
            {
                // Novo WebClient, ele vai ler a string do versaoPrograma
                WebClient web = new WebClient();
                string versao = web.DownloadString(LinksDownloads.versaoPrograma);

                // Se tiver uma versão diferente 
                if (Application.ProductVersion != versao)
                {
                    // Mensagem
                    MessageBox.Show("Encontramos uma nova versão, abrindo link...", "Royal Full", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Link para nova versão
                    string link = web.DownloadString(LinksDownloads.urlNovoLink);

                    // Inicie o link
                    Process.Start(link);

                    // Saia
                    Environment.Exit(0);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao tentar procurar atualizçaão", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        #endregion

        // Configuraçõs para conectar ao mongo
        // Coloque a sua chave aqui
        MongoClientSettings MongoConectar = MongoClientSettings.FromConnectionString("mongodb+srv://Usuarioaqui:senhaAqui@cluster0.vxtul.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");

        /// <summary>
        /// Obtém o ID do hardware
        /// </summary>
        /// <returns></returns>
        private string ObterHadrwareID()
        {
            try
            {
                ManagementObjectCollection mbsList = null;
                ManagementObjectSearcher mos = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
                mbsList = mos.Get();
                string processorId = string.Empty;
                foreach (ManagementBaseObject mo in mbsList)
                {
                    processorId = mo["ProcessorID"] as string;
                }

                mos = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");
                mbsList = mos.Get();
                string systemId = string.Empty;
                foreach (ManagementBaseObject mo in mbsList)
                {
                    systemId = mo["UUID"] as string;
                }

                var compIdStr = $"{processorId}{systemId}";
                return compIdStr;
            }
            catch (Exception) { }

            return "Fail to obtain!";
        }

        /// <summary>
        /// Verifica se o usuário existe, e retorna os dados
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        private bool Logar(string usuario, string senha)
        {
            try
            {
                // Cliente
                MongoClient cliente = new MongoClient(MongoConectar);

                // Banco de dados dos usuários 
                IMongoDatabase bancoDeDados = cliente.GetDatabase("DataUsers");

                // Coleção
                IMongoCollection<Dados> colecao = bancoDeDados.GetCollection<Dados>("usersInfo");

                // Verifique se o usuário existe
                bool existe = colecao.Find(d => d.Usuario == usuario && d.Senha == senha).Any();

                // Usuário existe
                if (existe)
                {
                    // Obtenha os dados deste usuário
                    Dados dados = colecao.AsQueryable().FirstOrDefault(d => d.Usuario == usuario && d.Senha == senha);

                    // Se já estiver ativado em outro computador
                    if (dados.JaAtivado == true && dados.MaquinaID != ObterHadrwareID())
                    {
                        // MessageBox
                        MessageBox.Show("O programa já foi ativado em outro computador, contate-nós para resolver o problema", "Royal Full");
                        return false;
                    }

                    // Atualizar valor, primeiro, atualiza o "JaAtivado", depois o ID da máquina
                    var update = Builders<Dados>.Update.Set(d => d.JaAtivado, true);
                    var update2 = Builders<Dados>.Update.Set(d => d.MaquinaID, ObterHadrwareID());

                    var filter = Builders<Dados>.Filter.Eq(s => s._id, dados._id);

                    // Atualize o JaAtivado
                    colecao.UpdateOne(filter, update);
                    colecao.UpdateOne(filter, update2);

                    // Altere
                    Dados.Logado.UsuarioAtual = usuario;
                    Dados.Logado.PlanoAtual = dados.Plano;

                    return true;
                }

                /* Inserir
                var documento = new BsonDocument
                {
                    {"Usuario", "teste" },
                    {"Senha", "teste" },
                    {"JaAtivado", false },
                    {"MaquinaID", "" }
                };

                collec.InsertOne(documento);
                */

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); Environment.Exit(0); }

            return false;
        }


        /// <summary>
        /// Quando iniciar
        /// </summary>
        public login()
        {
            AtualizacaoAutomatica();
            InitializeComponent();

            try
            {
                if (File.Exists(usuarioSalvo))
                {
                    guna2CheckBox1.Checked = true;

                    string usuario = StringCipher.Decrypt(File.ReadAllText(usuarioSalvo), "ecoil5ecrypt");
                    string senha = StringCipher.Decrypt(File.ReadAllText(senhaSalvo), "eoi45232l5ecrypt");

                    username.Text = usuario;
                    password.Text = senha;
                }
            }
            catch (Exception) { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Botão de login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            // Se conseguir logal
            if (Logar(username.Text, password.Text) == true)
            {
                MessageBox.Show("Logado!", "Royal Full");

                // Marcado
                if (guna2CheckBox1.Checked == true)
                {
                    File.WriteAllText(usuarioSalvo, StringCipher.Encrypt(username.Text, "ecoil5ecrypt"));
                    File.WriteAllText(senhaSalvo, StringCipher.Encrypt(password.Text, "eoi45232l5ecrypt"));
                }

                Form2 main = new Form2();
                main.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Falha ao logar!", "Royal Full");
                Environment.Exit(0);
            }

            /*
            if (API.Login(username.Text, password.Text))
            {
               
                MessageBox.Show("Logado con succeso!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                API.Log(User.Username, "Signed in");
                Form2 main = new Form2();
                main.Show();
                this.Hide();


                try
                {
                    File.Delete(usuarioSalvo);
                    File.Delete(senhaSalvo);
                }
                catch (Exception) { }

                try
                {

                    if (guna2CheckBox1.Checked == true)
                    {
                        File.WriteAllText(usuarioSalvo, StringCipher.Encrypt(username.Text, "ecoil5ecrypt"));
                        File.WriteAllText(senhaSalvo, StringCipher.Encrypt(password.Text, "eoi45232l5ecrypt"));
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Erro", "Não foi fazer o login automático", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            */
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            Form2 main = new Form2();
            main.Show();
            this.Hide();
        }
    }
}