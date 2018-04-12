using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;


namespace Tools
{
    /// <summary>
    /// Clase de ayuda para encriptar por el metodo AES (Rijndael)
    /// </summary>
    public static class Encriptacion
    {
        public static int Iteraciones = 10000;

        /// <summary>
        /// Llave binaria por defecto
        /// </summary>
        public static byte[] key = new byte[] {
           0xE9,0x0C,0xF0,0x91,0x45,0x43,0x8A,0x71,0x31,0x79,0x04,0xFA,0xEB,0xAD,0x11,0x10,0x5A,0x4E,
           0x93,0x7D,0x08,0xAC,0x0B,0x63,0x38,0x86,0x96,0xA3,0x4F,0x71,0x16,0xEC       
        }; 

        /// <summary>
        /// Encriptar cadena
        /// </summary>
        /// <param name="strEncriptar">Cadena a encriptar</param>
        /// <param name="bytPK">llave</param>
        /// <returns>Encriptacion</returns>
        private static byte[] Encriptar(string strEncriptar, byte[] bytPK)
        {
            Rijndael miRijndael = Rijndael.Create();
            miRijndael.Mode = CipherMode.CBC;
            byte[] encrypted = null;
            byte[] returnValue = null;

            try
            {
                miRijndael.Key = bytPK;
                miRijndael.GenerateIV();

                byte[] toEncrypt = System.Text.Encoding.UTF8.GetBytes(strEncriptar);
                encrypted = (miRijndael.CreateEncryptor()).TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);

                returnValue = new byte[miRijndael.IV.Length + encrypted.Length];
                miRijndael.IV.CopyTo(returnValue, 0);
                encrypted.CopyTo(returnValue, miRijndael.IV.Length);
            }
            catch { }
            finally { miRijndael.Clear(); }

            return returnValue;
        }

        /// <summary>
        /// Desencripta información
        /// </summary>
        /// <param name="bytDesEncriptar">Cadena a desencriptar</param>
        /// <param name="bytPK">Llave</param>
        /// <returns></returns>
        private static string Desencriptar(byte[] bytDesEncriptar, byte[] bytPK)
        {
            Rijndael miRijndael = Rijndael.Create();
            byte[] tempArray = new byte[miRijndael.IV.Length];
            byte[] encrypted = new byte[bytDesEncriptar.Length - miRijndael.IV.Length];
            string returnValue = string.Empty;

            try
            {
                miRijndael.Key = bytPK;

                Array.Copy(bytDesEncriptar, tempArray, tempArray.Length);
                Array.Copy(bytDesEncriptar, tempArray.Length, encrypted, 0, encrypted.Length);
                miRijndael.IV = tempArray;

                returnValue = System.Text.Encoding.UTF8.GetString((miRijndael.CreateDecryptor
                                ()).TransformFinalBlock(encrypted, 0, encrypted.Length));
            }
            catch { }
            finally { miRijndael.Clear(); }

            return returnValue;
        }

        /// <summary>
        /// Encriptar cadena
        /// </summary>
        /// <param name="strEncriptar"></param>
        /// <param name="strPK"></param>
        /// <returns></returns>
        public static byte[] Encriptar(string strEncriptar, string strPK=null)
        {            
            // Deriva la llave de encriptacion
            if (string.IsNullOrEmpty(strPK))
            {
                return Encriptar(strEncriptar, (new PasswordDeriveBytes(key, null)).GetBytes(32));
            }
            else
            {
                return Encriptar(strEncriptar, (new PasswordDeriveBytes(strPK, null)).GetBytes(32));
            }
        }

        /// <summary>
        /// Desencriptar cadena
        /// </summary>
        /// <param name="bytDesEncriptar"></param>
        /// <param name="strPK"></param>
        /// <returns></returns>
        public static string Desencriptar(byte[] bytDesEncriptar, string strPK=null)
        {
            if (string.IsNullOrEmpty(strPK))
            {
                return Desencriptar(bytDesEncriptar, (new PasswordDeriveBytes(key, null)).GetBytes(32));
            }
            else
            {
                return Desencriptar(bytDesEncriptar, (new PasswordDeriveBytes(strPK, null)).GetBytes(32));
            }
        }

        public static string EncriptarContraseña(string strPassword, string strSalt)
        {
            if (string.IsNullOrEmpty(strPassword))
            {
                throw new Exception("password no puede estar vacio");
            }
            if (!string.IsNullOrEmpty(strSalt))
            {
                if (strSalt.Length > 40)
                {
                    throw new Exception("El Salt no puede ser mayor a 40 Carácteres");
                }
                else
                {
                    Iteraciones = 0;
                    foreach (char c in strSalt)
                    {
                        Iteraciones += c;// Convert.ToInt16(c);
                    }
                }
            }
            

            string _pwsSalt = strPassword + strSalt;
            SHA256Managed _objSha256 = new SHA256Managed();
            byte[] _pwsTemporal = null;

            try
            {
                _pwsTemporal = System.Text.Encoding.UTF8.GetBytes(_pwsSalt);
                for (int i = 0; i <= Iteraciones - 1; i++)
                {
                    _pwsTemporal = _objSha256.ComputeHash(_pwsTemporal);
                }
            }
            finally 
            {
                _objSha256.Clear(); //elimina de memoria
            }

            return Convert.ToBase64String(_pwsTemporal);            
        }
    }
}
