using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    abstract class MyAES : SymmetricAlgorithm
    {
        public override int BlockSize
        {
            get
            {
                return 128;
            }
        }

        public override void GenerateIV()
        {
            RandomNumberGenerator _random = RandomNumberGenerator.Create();
            IVValue = new byte[16];
            _random.GetBytes(IVValue);
        }
        public override void GenerateKey()
        {
            RandomNumberGenerator _random = RandomNumberGenerator.Create();
            KeyValue = new byte[KeySize >> 3];
            _random.GetBytes(KeyValue);
        }
        public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
        {
            return new MyAESEncryptor(rgbKey, rgbIV, KeySize);
        }
        public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
        {
            return new MyAESDecryptor(rgbKey, rgbIV, KeySize);
        }
    }

    class MyAESManager : MyAES
    {
        public MyAESManager()
        {
            LegalKeySizesValue = new KeySizes[] { new KeySizes(128, 256, 64) };
            LegalBlockSizesValue = new KeySizes[] { new KeySizes(128, 128, 0) };
            KeySize = 256;
        }
    }
}