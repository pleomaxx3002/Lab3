using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MyAESDecryptor : MyAESAbstractTransform
    {
        public MyAESDecryptor(byte[] Key, byte[] IV, int KeySize)
            : base(Key, IV, KeySize)
        {
            row = new byte[,] { { 0x0e, 0x0b, 0x0d, 0x09 }, { 0x09, 0x0e, 0x0b, 0x0d }, { 0x0d, 0x09, 0x0e, 0x0b }, { 0x0b, 0x0d, 0x09, 0x0e } };
        }
        protected override byte[,] Transform(byte[,] state)
        {
            addRoundKey(ref state, Nr << 2);
            for (int i = Nr - 1; i >= 1; i--)
            {
                invShiftRows(ref state);
                invSubBytes(ref state);
                addRoundKey(ref state, i << 2);
                mixColumns(ref state);
            }
            invShiftRows(ref state);
            invSubBytes(ref state);
            addRoundKey(ref state, 0);
            return state;
        }
        public override byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            return new byte[0];
        }
    }
}
