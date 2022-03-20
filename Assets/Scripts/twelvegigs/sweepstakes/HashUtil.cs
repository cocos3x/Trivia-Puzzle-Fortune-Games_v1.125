using UnityEngine;

namespace twelvegigs.sweepstakes
{
    public static class HashUtil
    {
        // Methods
        public static string MD5(string text)
        {
            return twelvegigs.sweepstakes.HashUtil.MD5(bytes:  new System.Text.UTF8Encoding().GetBytes(s:  text));
        }
        public static string MD5(byte[] bytes)
        {
            string val_6;
            int val_6 = val_2.Length;
            val_6 = "";
            if(val_6 < 1)
            {
                    return val_6.PadLeft(totalWidth:  32, paddingChar:  '0');
            }
            
            var val_7 = 0;
            val_6 = val_6 & 4294967295;
            do
            {
                val_7 = val_7 + 1;
                val_6 = val_6 + System.Convert.ToString(value:  192, toBase:  16).PadLeft(totalWidth:  2, paddingChar:  '0')(System.Convert.ToString(value:  192, toBase:  16).PadLeft(totalWidth:  2, paddingChar:  '0'));
            }
            while(val_7 < (val_2.Length << ));
            
            return val_6.PadLeft(totalWidth:  32, paddingChar:  '0');
        }
        public static string MD5File(string path)
        {
            if((System.IO.File.Exists(path:  path)) == false)
            {
                    throw new System.ArgumentException(message:  "File not found.", paramName:  "path");
            }
            
            return twelvegigs.sweepstakes.HashUtil.MD5(bytes:  System.IO.File.ReadAllBytes(path:  path));
        }
        public static string SHA1(string text)
        {
            return twelvegigs.sweepstakes.HashUtil.SHA1(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  text));
        }
        public static string SHA1(byte[] bytes)
        {
            System.Security.Cryptography.SHA1Managed val_1 = new System.Security.Cryptography.SHA1Managed();
            val_1.Clear();
            return System.BitConverter.ToString(value:  val_1.ComputeHash(buffer:  bytes)).Replace(oldValue:  "-", newValue:  "").ToLower();
        }
        public static string SHA1File(string path)
        {
            if((System.IO.File.Exists(path:  path)) == false)
            {
                    throw new System.ArgumentException(message:  "File not found.", paramName:  "path");
            }
            
            return twelvegigs.sweepstakes.HashUtil.SHA1(bytes:  System.IO.File.ReadAllBytes(path:  path));
        }
        public static string SHA256(string text)
        {
            return twelvegigs.sweepstakes.HashUtil.SHA256(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  text));
        }
        public static string SHA256(byte[] bytes)
        {
            System.Security.Cryptography.SHA256Managed val_1 = new System.Security.Cryptography.SHA256Managed();
            val_1.Clear();
            return System.BitConverter.ToString(value:  val_1.ComputeHash(buffer:  bytes)).Replace(oldValue:  "-", newValue:  "").ToLower();
        }
        public static string SHA256File(string path)
        {
            if((System.IO.File.Exists(path:  path)) == false)
            {
                    throw new System.ArgumentException(message:  "File not found.", paramName:  "path");
            }
            
            return twelvegigs.sweepstakes.HashUtil.SHA256(bytes:  System.IO.File.ReadAllBytes(path:  path));
        }
        public static string SHA512(string text)
        {
            return twelvegigs.sweepstakes.HashUtil.SHA512(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  text));
        }
        public static string SHA512(byte[] bytes)
        {
            System.Security.Cryptography.SHA512Managed val_1 = new System.Security.Cryptography.SHA512Managed();
            val_1.Clear();
            return System.BitConverter.ToString(value:  val_1.ComputeHash(buffer:  bytes)).Replace(oldValue:  "-", newValue:  "").ToLower();
        }
        public static string SHA512File(string path)
        {
            if((System.IO.File.Exists(path:  path)) == false)
            {
                    throw new System.ArgumentException(message:  "File not found.", paramName:  "path");
            }
            
            return twelvegigs.sweepstakes.HashUtil.SHA512(bytes:  System.IO.File.ReadAllBytes(path:  path));
        }
        public static byte[] ToByte(string text)
        {
            return new System.Text.UTF8Encoding().GetBytes(s:  text);
        }
        public static string ToHex(byte[] me)
        {
            int val_3;
            int val_3 = me.Length;
            val_3 = System.String.alignConst;
            if(val_3 < 1)
            {
                    return val_3.ToLower();
            }
            
            var val_4 = 0;
            val_3 = val_3 & 4294967295;
            do
            {
                val_4 = val_4 + 1;
                val_3 = val_3 + me[32][val_4].ToString(format:  "X2")(me[32][val_4].ToString(format:  "X2"));
            }
            while(val_4 < (me.Length << ));
            
            return val_3.ToLower();
        }
    
    }

}
