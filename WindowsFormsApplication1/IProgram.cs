using System;

namespace WindowsFormsApplication1
{
    delegate void ProcessStatus(double a);
    public delegate void ExitEvent();
    interface IProgram
    {
        event EventHandler<double> Status;
        event ExitEvent exitEvent;
        void EnCode();
        void DeCode();
        void Set(string pathSource, string pathTarget, string key);

    }
}