using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System;

namespace MyFirstapp
{
    [Flags]
    public enum BatteryChargeStatus : byte
    {
        High = 1,
        Low = 2,
        Critical = 4,
        Charging = 8,
        NoSystemBattery = 128,
        Unknown = 255
    }

    public enum PowerLineStatus : byte
    {
        Offline = 0,
        Online = 1,
        Unknown = 255
    }

    class PowerStatus
    {
        [DllImport("kernel32", EntryPoint = "GetSystemPowerStatus")]
        private static extern void GetSystemPowerStatus(ref SystemPowerStatus powerStatus);

        private struct SystemPowerStatus
        {
            public PowerLineStatus PowerLineStatus;
            public BatteryChargeStatus BatteryChargeStatus;
            public Byte BatteryLifePercent;
            public Byte Reserved;
            public int BatteryLifeRemaining;
            public int BatteryFullLifeTime;
        }

        private SystemPowerStatus _powerStatus;

        public PowerLineStatus PowerLineStatus
        {
            get
            {
                return _powerStatus.PowerLineStatus;
            }
        }

        public BatteryChargeStatus BatteryChargeStatus
        {
            get
            {
                return _powerStatus.BatteryChargeStatus;
            }
        }

        public float BatteryLifePercent
        {
            get
            {
                return _powerStatus.BatteryLifePercent;
            }
        }

        public int BatteryLifeRemaining
        {
            get
            {
                return _powerStatus.BatteryLifeRemaining;
            }
        }

        public int BatteryFullLifeTime
        {
            get
            {
                return _powerStatus.BatteryFullLifeTime;
            }
        }

        public PowerStatus()
        {
            UpdatePowerInfo();
        }


        public void UpdatePowerInfo()
        {
            GetSystemPowerStatus(ref _powerStatus);
        }
    }
}