using OpenLibSys;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstapp
{
    class TestByWinRing0
    {
        Ols MyOls;
        public bool Initialize()
        {
            MyOls = new OpenLibSys.Ols();
            return MyOls.GetStatus() == (uint)OpenLibSys.Ols.Status.NO_ERROR;
        }
        //#define IBFMASK	0x02
        //#define OBFMASK	0x01

        //#define WaitIBFE while(((inportb(0x66)) & (0x02)) == 0x02)

        //#define WaitOBFF while(((inportb(0x66)) & (0x01)) == 0x00)

        //unsigned char ReadECRAM(unsigned char Address)
        //{
        //    while (((inportb(0x66)) & (0x02)) == 0x02) ;
        //    outportb(0x66, 0x80);
        //    while (((inportb(0x66)) & (0x02)) == 0x02) ;
        //    outportb(0x62, Address);
        //    while (((inportb(0x66)) & (0x01)) == 0x00) ;
        //    return inportb(0x62);
        //}

        /*public Byte ReadECRAM(Byte Address)
        {
            while (((MyOls.ReadIoPortByte(0x66)) & (0x02)) == 0x02) ;

            MyOls.WriteIoPortByte(0x66, 0x80);
            while (((MyOls.ReadIoPortByte(0x66)) & (0x02)) == 0x02) ;
            MyOls.WriteIoPortByte(0x62, Address);
            while (((MyOls.ReadIoPortByte(0x66)) & (0x01)) == 0x00) ;
            return MyOls.ReadIoPortByte(0x62);
        }*/

        public Byte ReadECRAM(Byte Address)
        {
            
            while (((MyOls.ReadIoPortByte(0x66)) & (0x02)) == 0x02) ;

            MyOls.WriteIoPortByte(0x66, 0x80);

            while (((MyOls.ReadIoPortByte(0x66)) & (0x02)) == 0x02) ;

            MyOls.WriteIoPortByte(0x62, Address);

            while (((MyOls.ReadIoPortByte(0x66)) & (0x01)) == 0x00) ;

            return MyOls.ReadIoPortByte(0x62);

        }
    }
}
