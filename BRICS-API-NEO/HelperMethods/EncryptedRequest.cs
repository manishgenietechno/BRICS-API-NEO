using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;

namespace BRICS_API_NEO.HelperMethods
{
    public class EncryptedRequest
    {
        private readonly IConfiguration _configuration;
        
        public EncryptedRequest() 
        {

        }
        
        public string EncryptedRequestBody(string requestBody, string publickKeyPath)
        {
            // Load the public key
            AsymmetricKeyParameter publicKey = LoadPublicKey(publickKeyPath);

            // Encrypt the message
            string encryptedBody = Encrypt(requestBody, publicKey);

            return encryptedBody;
        }

        private AsymmetricKeyParameter LoadPublicKey(string publicKeyPath)
        {
            using (var reader = File.OpenText(publicKeyPath))
            {
                var pemReader = new PemReader(reader);
                return (AsymmetricKeyParameter)pemReader.ReadObject();
            }
        }

        private string Encrypt(string message, AsymmetricKeyParameter publicKey)
        {
            var bytesToEncrypt = System.Text.Encoding.UTF8.GetBytes(message);

            var encryptEngine = new Pkcs1Encoding(new RsaEngine());
            encryptEngine.Init(true, publicKey);

            var encryptedBytes = encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);

            return Convert.ToBase64String(encryptedBytes);
        }
    }
}
