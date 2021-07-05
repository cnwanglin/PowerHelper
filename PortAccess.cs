using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MyFirstapp
{
    class PortAccess
    {
        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(int adress, int value);

        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern int Input(int adress);
    }
}
