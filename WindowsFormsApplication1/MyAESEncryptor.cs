using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MyAESEncryptor : MyAESAbstractTransform
    {
        public MyAESEncryptor(byte[] Key, byte[] IV, int KeySize)
            : base(Key, IV, KeySize)
        {
            row = new byte[,] { { 0x02, 0x03, 0x01, 0x01 }, { 0x01, 0x02, 0x03, 0x01 }, { 0x01, 0x01, 0x02, 0x03 }, { 0x03, 0x01, 0x01, 0x02 } };
        }
        protected override byte[,] Transform(byte[,] state)
        {
            addRoundKey(ref state, 0);
            for (int i = 1; i < Nr; i++)
            {
                SubBytes(ref state);
                shiftRows(ref state);
                mixColumns(ref state);
                addRoundKey(ref state, i << 2);
            }

            SubBytes(ref state);
            shiftRows(ref state);
            addRoundKey(ref state, Nr << 2);
            return state;
        }
        public override byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            byte[,] state = new byte[4, 4];
            byte[] res;
            for (int i = 0; i < inputCount; i++)
                state[i & 3, i >> 2] = inputBuffer[i + inputOffset];
            if (inputCount == 16)
            {
                state = Transform(state);
                res = new byte[32];
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        res[(j << 2) + i] = state[i, j];
                state = new byte[4, 4];
                state[0, 0] = 0x80;
                state = Transform(state);
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        res[16 + (j << 2) + i] = state[i, j];
            }
            else
            {
                state[inputCount & 3, inputCount >> 2] = 0x80;
                res = new byte[16];
                state = Transform(state);
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        res[(j << 2) + i] = state[i, j];
            }
            return res;
        }

    }
}
