using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MyProgram : Control
    {
        protected SymmetricAlgorithm alg;
        string filePath;
        public string extractPath;
        string key;
        bool inprogress;
        EventHandler<double> Process;
        Action a;
        private bool HandleFlag;
        private event EventHandler<double> onStatus;
        private event EventHandler onExitEvent;
        public event ExitEvent exitEvent;
        public event EventHandler<Exception> ThrownExceptions;
        public event EventHandler<double> Status;

        public MyProgram()
        {
            inprogress = false;
            onStatus = new EventHandler<double>(OnStatus);
            onExitEvent = new EventHandler(OnExitEvent);
            HandleFlag = false;
        }


        void OnStatus(object sender, double a)
        {
            if (Status != null)
                Status(sender, a);
        }

        void OnExitEvent(object sender, EventArgs arg)
        {
            inprogress = false;
            if (exitEvent != null)
                exitEvent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (HandleFlag)
                DoAction();
        }

        void DoAction()
        {
            if (inprogress)
                return;
            Check();
            if (IsHandleCreated)
            {

                Thread tmp = new Thread(new ThreadStart(ThreadProcedure));
                inprogress = true;
                tmp.Start();
            }
            else
                HandleFlag = true;
        }

        public void EnCode()
        {
            a = new Action(Encrypt);
            try
            {
                DoAction();
            }
            catch(Exception e)
            {
                if (ThrownExceptions != null)
                    ThrownExceptions(this, e);
            }
        }
        void Encrypt()
        {
            try
            {
                extractPath += "//TMP_ARCHIVE.zip";
                ZipFile.CreateFromDirectory(filePath, extractPath);
                using (var Input = new FileStream(extractPath, FileMode.Open, FileAccess.Read))
                using (var Output = new FileStream(extractPath + "e", FileMode.Create, FileAccess.Write))
                {
                    var encryptor = alg.CreateEncryptor();
                    Int64 filesize = Input.Length;
                    UInt64 done = 0;
                    using (var CStream = new CryptoStream(Output, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] buffer = new byte[16384];
                        int read = Input.Read(buffer, 0, buffer.Length);
                        if (read == 0)
                            throw new Exception("Zero file size");
                        done = (ulong)read;
                        while (read == buffer.Length)
                        {
                            CStream.Write(buffer, 0, buffer.Length);
                            BeginInvoke(onStatus, new object[] { this, (double)done / filesize });
                            read = Input.Read(buffer, 0, buffer.Length);
                            done += (ulong)read;
                        }
                        buffer[read++] = 0x80;
                        int temp = read / (alg.BlockSize >> 3);
                        if (read % (alg.BlockSize >> 3) != 0) temp++;
                        temp *= (alg.BlockSize >> 3);
                        for (int i = read; i < temp && i < buffer.Length; i++)
                            buffer[i] = 0;
                        read = temp;
                        CStream.Write(buffer, 0, read);
                    }
                }
                File.Delete(extractPath);
            }
            finally
            { BeginInvoke(onExitEvent, new object[] { this, EventArgs.Empty }); }
        }


        void Decrypt()
        {
            try
            {
                using (var Input = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var Output = new FileStream(extractPath + "//TMP_ARCHIVE.zip", FileMode.Create, FileAccess.Write))
                {
                    var encryptor = alg.CreateDecryptor();
                    Int64 filesize = Input.Length;
                    UInt64 done = 0;
                    using (var CStream = new CryptoStream(Output, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] buffer = new byte[16384];
                        int read = Input.Read(buffer, 0, buffer.Length);
                        done = (UInt64)read;
                        if (read == 0)
                            throw new Exception("Zero file size");
                        while (read == buffer.Length)
                        {
                            CStream.Write(buffer, 0, buffer.Length);
                            BeginInvoke(onStatus, new object[] { this, (double)done / filesize });
                            read = Input.Read(buffer, 0, buffer.Length);
                            done += (UInt64)read;
                        }
                        int temp = alg.BlockSize >> 3;
                        int i;
                        for (i = 0; read > temp; i++, read -= temp)
                            CStream.Write(buffer, i * temp, temp);
                        byte[] tmp = new byte[temp];
                        encryptor.TransformBlock(buffer, temp * i, temp, tmp, 0);
                        i = temp - 1;
                        while (i >= 0 && tmp[i] != 0x80)
                            i--;
                        CStream.Flush();
                        Output.Write(tmp, 0, i);
                    }
                }
                ZipFile.ExtractToDirectory(extractPath + "/TMP_ARCHIVE.zip", extractPath);
                File.Delete(extractPath + "/TMP_ARCHIVE.zip");
            }
            finally
            { BeginInvoke(onExitEvent, new object[] { this, EventArgs.Empty }); }
        }

        public void DeCode()
        {
            a = new Action(Decrypt);
            DoAction();
        }


        void Check()
        {
            try
            {
                Path.GetFullPath(filePath);
                filePath = filePath.TrimEnd('\\');
                Path.GetFullPath(extractPath.Substring(0, extractPath.LastIndexOf('\\')));
                extractPath = extractPath.TrimEnd('\\');
            }
            catch (Exception e)
            {
                throw new Exception("Invalid path");
            }
            byte[] tmp = GetBytes(key);
            if (tmp.Length < (alg.KeySize >> 3))
                throw new Exception("Too small key");
            alg.Key = new byte[alg.KeySize >> 3];
            for (int i = (alg.KeySize >> 3) - 1; i >= 0; i--)
                alg.Key[i] = tmp[i];

        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }


        public void Set(string pathSource, string pathTarget, string key)
        {
            filePath = pathSource;
            extractPath = pathTarget;
            this.key = key;

        }

        void ThreadProcedure()
        {
            a();
        }
    }
}
