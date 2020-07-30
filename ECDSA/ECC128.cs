using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECDSA128
{
    public class ECC128
    {
       static IDsa dsa;
        static string AlgoName = "SHA-256withECDSA";
        public static string GenerateSignature(string InputData, string PrivateKeyPath, string PublicKeyPath)
        {
            string s = InputData;
            // s = "20685b5fbfe1898fbb080b0719acc9ed2f365128627f21ffcc1b1ee27471e69e";
            try
            {
                IDsaEncoding encoding = StandardDsaEncoding.Instance;
                var encoder = new ASCIIEncoding();
                var bencoder = new Base64Encoder();
                //var key = GenerateKeys(128);
                AsymmetricCipherKeyPair MyKey = getPrivateKeyFromPemFile(PrivateKeyPath);
                ECPublicKeyParameters pubicKey = getPublicKeyFromPemFile(PublicKeyPath);
                //var pubicKey = (ECPublicKeyParameters)(MyKey1.Public);
                var privateKey = (ECPrivateKeyParameters)(MyKey.Private);
                var signature = GetSignature(s, privateKey);
                BigInteger[] sig = encoding.Decode(GetOrder(), signature);
                //System.Numerics.BigInteger sigval = 0;
                //System.Numerics.BigInteger.TryParse(sig[1].ToString(), out sigval);
                var finalsignature = sig[0].ToString(16) + sig[1].ToString(16);
                var signatureOK = VerifySignature(pubicKey, s, signature);
                if (signatureOK) { return finalsignature; } else { return ""; } 
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private static AsymmetricCipherKeyPair getPrivateKeyFromPemFile(string pemFilename)
        {
            try
            {
                StreamReader fileStream = System.IO.File.OpenText(pemFilename);
                PemReader pemReader = new PemReader(fileStream);
                var ss = pemReader.ReadObject();
                //AsymmetricKeyParameter keyParameter = (AsymmetricKeyParameter)pemReader.ReadObject();
                return (AsymmetricCipherKeyPair)ss;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private static Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters getPublicKeyFromPemFile(string pemFilename)
        {
            StreamReader fileStream = System.IO.File.OpenText(pemFilename);
            PemReader pemReader = new PemReader(fileStream);
            Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters ss = (Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters)pemReader.ReadObject();
            return ss;
        }
        static BigInteger GetOrder()
        {
            return dsa is IDsaExt ? ((IDsaExt)dsa).Order : null;
        }
        private static byte[] GetSignature(string s, ECPrivateKeyParameters Pkey)
        {
            var secureRandom = new SecureRandom();
            var encoder = new ASCIIEncoding();
            var inputData = encoder.GetBytes(s);
            var signer = SignerUtilities.GetSigner(AlgoName);
            signer.Init(true, Pkey);
            signer.BlockUpdate(inputData, 0, inputData.Length);
            return signer.GenerateSignature();
        }


        private static bool VerifySignature(ECPublicKeyParameters Publickkey, string plainText, byte[] signature)
        {
            var encoder = new ASCIIEncoding();
            var inputData = encoder.GetBytes(plainText);
            var signer = SignerUtilities.GetSigner(AlgoName);
            signer.Init(false, Publickkey);
            signer.BlockUpdate(inputData, 0, inputData.Length);
            return signer.VerifySignature(signature);
        }
        
    }
}
