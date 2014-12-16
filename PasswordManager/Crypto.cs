/*
This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
	*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace PasswordManager
{
    class Crypto
    {
        private static byte[] _salt = Encoding.ASCII.GetBytes("password-manager");
        private static byte[] iv = Encoding.ASCII.GetBytes("password-manager");
        static Properties.Settings settings = Properties.Settings.Default;

        public static void encrypt(string data)
        {
            using (RijndaelManaged aesAlg = new RijndaelManaged())
            {
                string secret = settings.pass;
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(secret, _salt, 20000);//pbkdf (pkcs#5)
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);//32 bytes, 256 bits / 8

                byte[] encrypted = EncryptStringToBytes(data, aesAlg.Key, iv);
                File.WriteAllBytes("acc.pwm", encrypted);
            }
        }

        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;//256 bits
                rijAlg.IV = IV;
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.Zeros;
                //block size 128 bits
                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public static string decrypt()
        {
            using (RijndaelManaged aesAlg = new RijndaelManaged())
            {
                string secret = settings.pass;
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(secret, _salt, 20000);
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                byte[] bytes = File.ReadAllBytes("acc.pwm");
                return DecryptStringFromBytes(bytes, aesAlg.Key, iv);
            }
        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.Zeros;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            return plaintext;
        }

        public static string hash(string password)
        {
            byte[] hashSalt = Encoding.UTF8.GetBytes(settings.salt);
            Rfc2898DeriveBytes pbkdf = new Rfc2898DeriveBytes(password, hashSalt, 20000);//pbkdf - we can use this as a hashing algorithm

            byte[] hash = pbkdf.GetBytes(32);
            string result = "";
            foreach (byte b in hash)
            {
                result += String.Format("{0:X2}", b);
            }
            return result;
        }
    }
}