
using Common;
using System.Security.Cryptography;
using System.Text;

namespace HashConsole
{
    public class Program
    {
        /// <summary>
        /// 隨機生成英數混和的字串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomString(int length)
        {
            var str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var next = new Random();
            var builder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                builder.Append(str[next.Next(0, str.Length)]);
            }
            return builder.ToString();
        }


        public static void Main(string[] args)
        {
            string name = "呂璇";

            //常用的Hash
            string md5Hash=CryptoHelper.MD5HashData(name);
            string sha1Hash=CryptoHelper.SHA1HashData(name);
            string sha256Hash = CryptoHelper.SHA256HashData(name);
            string sha384Hash = CryptoHelper.SHA384HashData(name);
            string sha512Hash = CryptoHelper.SHA512HashData(name);

            //字串長度
            int md5 = md5Hash.Count();  //32
            int sha1 = sha1Hash.Count();  //40
            int sha256 = sha256Hash.Count();  //64
            int sha384 = sha384Hash.Count();  //96
            int sha512 = sha512Hash.Count();  //128

            //HMAC：Hash-based Message Authentication Code
            //說明不同私鑰，即使相同內容，也會有不一樣的 HMAC
            string hmacMD5_a = CryptoHelper.HMACMD5HashData(name, "1234");
            string hmacMD5_b = CryptoHelper.HMACMD5HashData(name, "55555");
            string hmacSHA256_a = CryptoHelper.HMACSHA256HashData(name, "12345");
            string hmacSHA256_b = CryptoHelper.HMACSHA256HashData(name, "666666");

            //其他HMAC
            string hmacSHA1 = CryptoHelper.HMACSHA1HashData(name, "1234");
            string hmacSHA384 = CryptoHelper.HMACSHA384HashData(name, "1234");
            string hmacSHA512 = CryptoHelper.HMACSHA512HashData(name, "1234");
            
            //與上面 int sha384、sha512比較長度=>結論：長度相同
            int HMACsha384 = hmacSHA384.Count();  //96
            int HMACsha512 = hmacSHA512.Count();  //128



            //為什麼不直接用加密就好，要用hash?
            //因為加密解密非常消耗CPU，使用hash時間比較短


            //====================================   AesEncrypt、AesDecrypt   ====================================

            // 16位采用Aes128、base64
            string privateKey_1 = "1234567890abcdef"; 
            string _AesEn = CryptoHelper.AesEncrypt(name, privateKey_1, "base64");
            string myName = CryptoHelper.AesDecrypt(_AesEn, privateKey_1, "base64");

            // 24位采用Aes192、base64
            string privateKey_2 = "1234567890abcdef78901234"; //24位采用Aes192
            string _AesEn2 = CryptoHelper.AesEncrypt(name, privateKey_2, "base64");
            string myName2 = CryptoHelper.AesDecrypt(_AesEn2, privateKey_2, "base64");

            // 32位采用Aes256、base64
            string privateKey_3 = "1234567890abcdef1234567890abcdef";
            string _AesEn3 = CryptoHelper.AesEncrypt(name, privateKey_3, "base64");
            string myName3 = CryptoHelper.AesDecrypt(_AesEn3, privateKey_3, "base64");



            // 16位采用Aes128、hex
            string privateKey_11 = "1234567890abcdef";
            string _AesEn1 = CryptoHelper.AesEncrypt(name, privateKey_11, "hex");
            string myName1 = CryptoHelper.AesDecrypt(_AesEn1, privateKey_11, "hex");

            // 24位采用Aes192、hex
            string privateKey_22 = "1234567890abcdef78901234"; //24位采用Aes192
            string _AesEn22 = CryptoHelper.AesEncrypt(name, privateKey_22, "hex");
            string myName22 = CryptoHelper.AesDecrypt(_AesEn22, privateKey_22, "hex");

            // 32位采用Aes256、hex
            string privateKey_33 = "1234567890abcdef1234567890abcdef";
            string _AesEn33 = CryptoHelper.AesEncrypt(name, privateKey_33, "hex");
            string myName33 = CryptoHelper.AesDecrypt(_AesEn33, privateKey_33, "hex");


            //====================================   AesGcmDecrypt、AesGcmEncrypt   ====================================

            string text = "這是需要加密的文本";

            // 定義密鑰 (32 字節 = 256 位，適合 Aes256)
            string privateKey = "0123456789abcdef0123456789abcdef"; // 32 字符

            // 定義 12 字節的 nonce（可以隨機生成）
            string nonce = GetRandomString(12);
            string nonce2 = GetRandomString(12);

            // 可以是 null
            string associatedText = "相關聯的數據";

            // base64 或 hex
            string encoding = "base64";

            // 加密
            string AesGcm_encryptedText = CryptoHelper.AesGcmEncrypt(text, privateKey, nonce, associatedText, encoding);
            // 解密
            string AesGcm_decryptedText = CryptoHelper.AesGcmDecrypt(AesGcm_encryptedText, privateKey, nonce, associatedText, encoding);
            // 加密 2 (nonce2)
            string AesGcm_encryptedText2 = CryptoHelper.AesGcmEncrypt(text, privateKey, nonce2, associatedText, encoding);
            // 解密 2 (nonce2)
            string AesGcm_decryptedText2 = CryptoHelper.AesGcmDecrypt(AesGcm_encryptedText2, privateKey, nonce2, associatedText, encoding);
            //結論：每次加密時，使用一個唯一的隨機數（nonce）來確保加密過程是安全的，即使加密相同的數據也會生成不同的密文


            //========================================  RSAEncrypt 、 RSADecrypt  ==========================================

            //使用在線生成公私鑰

            //RSAEncrypt
            string _publicKey = "-----BEGIN RSA PUBLIC KEY-----\r\nMEgCQQDW8AZgTfrHzTwqM3TkTnzkmjFZLxXBYPKXZrY8kPNysw4h1vPqSK38xWQH\r\nAImnpsz3KTCWCHr0hn4SGmiywJaTAgMBAAE=\r\n-----END RSA PUBLIC KEY-----";
            string content = "需要加密的數據";
            string stringEncoding = "base64"; // 可以是 "base64" 或 "hex"
            RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1; // 選擇加密填充模式為Pkcs1
            string encryptedData = CryptoHelper.RSAEncrypt(_publicKey, content, stringEncoding, padding);

            //RSADecrypt
            string _privateKey = "-----BEGIN PRIVATE KEY-----\r\nMIIBVQIBADANBgkqhkiG9w0BAQEFAASCAT8wggE7AgEAAkEA1vAGYE36x808KjN0\r\n5E585JoxWS8VwWDyl2a2PJDzcrMOIdbz6kit/MVkBwCJp6bM9ykwlgh69IZ+Ehpo\r\nssCWkwIDAQABAkBXNk1gBkQbjks7VGW5vZ8vouEjLtfE/3FvvV10ddxSTVam2TN+\r\n3wxQ5mu4sH7Q5J/Pu7kL1gpdswJlduyCsI0BAiEA77bzgf5OokJMaaY3SHmixLtW\r\n7L7RMw9Kpk5EBL6W/RcCIQDliiiBZrcWqkXfRvIAKkkveD6eVpvNtm769OI7Wdn3\r\n5QIhANaPhv3/xhpuBT87S5hPZ2V32aImWdG+Ci85NqCYh0UZAiBtoGJgCvJ+fKwK\r\nSxPhSFDTvxYJAUxAH1U5viMePXeAkQIhAJ/IHaH1qXkWC7bzBvUw03iR7vAlEPTh\r\n8Wwo2oR/ufHs\r\n-----END PRIVATE KEY-----";
            string decryptedData = CryptoHelper.RSADecrypt(_privateKey, encryptedData, stringEncoding, padding);


            //========================================  RSASignData 、 RSAVerifyData  ==========================================



            int stop = 0;
        }

    }
}
