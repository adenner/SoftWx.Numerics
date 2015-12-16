﻿// Copyright ©2015 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett
using SoftWx.Diagnostics;
using System;

namespace SoftWx.Numerics.Profile {
    class Program {
        static void Main(string[] args) {
            ((byte)1).LowBit(); // gets the assembly and class going
            ((byte)1).Log2(); // get the class going

            ProfileBitMath();
            ProfileLog2Math();

            Console.Write("press any key to exit...");
            Console.ReadKey();
        }
        static void ProfileLog2Math() {
            bool bo;
            byte b1; int br; b1 = 123;
            sbyte sb1, sbr; sb1 = 123;
            ushort us1, usr; us1 = 123;
            short s1, sr; s1 = 123;
            uint ui1, uir; ui1 = 123;
            int i1, ir; i1 = 123;
            ulong ul1, ulr; ul1 = 123;
            long l1, lr; l1 = 123;
            var bench = new Bench();
            bench.Time("byte.Log2", () => { br = b1.Log2(); br = b1.Log2(); br = b1.Log2(); br = b1.Log2(); br = b1.Log2(); }, 5);
            bench.Time("sbyte.Log2", () => { sbr = sb1.Log2(); sbr = sb1.Log2(); sbr = sb1.Log2(); sbr = sb1.Log2(); sbr = sb1.Log2(); }, 5);
            bench.Time("ushort.Log2", () => { usr = us1.Log2(); usr = us1.Log2(); usr = us1.Log2(); usr = us1.Log2(); usr = us1.Log2(); }, 5);
            bench.Time("short.Log2", () => { sr = s1.Log2(); sr = s1.Log2(); sr = s1.Log2(); sr = s1.Log2(); sr = s1.Log2(); }, 5);
            bench.Time("uint.Log2", () => { uir = ui1.Log2(); uir = ui1.Log2(); uir = ui1.Log2(); uir = ui1.Log2(); uir = ui1.Log2(); }, 5);
            bench.Time("int.Log2", () => { ir = i1.Log2(); ir = i1.Log2(); ir = i1.Log2(); ir = i1.Log2(); ir = i1.Log2(); }, 5);
            bench.Time("ulong.Log2", () => { ulr = ul1.Log2(); ulr = ul1.Log2(); ulr = ul1.Log2(); ulr = ul1.Log2(); ulr = ul1.Log2(); }, 5);
            bench.Time("long.Log2", () => { lr = l1.Log2(); lr = l1.Log2(); lr = l1.Log2(); lr = l1.Log2(); lr = l1.Log2(); }, 5);
            bench.Time("byte.IsPowerOf2", () => { bo = b1.IsPowerOf2(); bo = b1.IsPowerOf2(); bo = b1.IsPowerOf2(); bo = b1.IsPowerOf2(); bo = b1.IsPowerOf2(); }, 5);
            bench.Time("sbyte.IsPowerOf2", () => { bo = sb1.IsPowerOf2(); bo = sb1.IsPowerOf2(); bo = sb1.IsPowerOf2(); bo = sb1.IsPowerOf2(); bo = sb1.IsPowerOf2(); }, 5);
            bench.Time("ushort.IsPowerOf2", () => { bo = us1.IsPowerOf2(); bo = us1.IsPowerOf2(); bo = us1.IsPowerOf2(); bo = us1.IsPowerOf2(); bo = us1.IsPowerOf2(); }, 5);
            bench.Time("short.IsPowerOf2", () => { bo = s1.IsPowerOf2(); bo = s1.IsPowerOf2(); bo = s1.IsPowerOf2(); bo = s1.IsPowerOf2(); bo = s1.IsPowerOf2(); }, 5);
            bench.Time("uint.IsPowerOf2", () => { bo = ui1.IsPowerOf2(); bo = ui1.IsPowerOf2(); bo = ui1.IsPowerOf2(); bo = ui1.IsPowerOf2(); bo = ui1.IsPowerOf2(); }, 5);
            bench.Time("int.IsPowerOf2", () => { bo = i1.IsPowerOf2(); bo = i1.IsPowerOf2(); bo = i1.IsPowerOf2(); bo = i1.IsPowerOf2(); bo = i1.IsPowerOf2(); }, 5);
            bench.Time("ulong.IsPowerOf2", () => { bo = ul1.IsPowerOf2(); bo = ul1.IsPowerOf2(); bo = ul1.IsPowerOf2(); bo = ul1.IsPowerOf2(); bo = ul1.IsPowerOf2(); }, 5);
            bench.Time("long.IsPowerOf2", () => { bo = l1.IsPowerOf2(); bo = l1.IsPowerOf2(); bo = l1.IsPowerOf2(); bo = l1.IsPowerOf2(); bo = l1.IsPowerOf2(); }, 5);
            bench.Time("byte.PowerOf2Floor", () => { br = b1.PowerOf2Floor(); br = b1.PowerOf2Floor(); br = b1.PowerOf2Floor(); br = b1.PowerOf2Floor(); br = b1.PowerOf2Floor(); }, 5);
            bench.Time("sbyte.PowerOf2Floor", () => { sbr = sb1.PowerOf2Floor(); sbr = sb1.PowerOf2Floor(); sbr = sb1.PowerOf2Floor(); sbr = sb1.PowerOf2Floor(); sbr = sb1.PowerOf2Floor(); }, 5);
            bench.Time("ushort.PowerOf2Floor", () => { usr = us1.PowerOf2Floor(); usr = us1.PowerOf2Floor(); usr = us1.PowerOf2Floor(); usr = us1.PowerOf2Floor(); usr = us1.PowerOf2Floor(); }, 5);
            bench.Time("short.PowerOf2Floor", () => { sr = s1.PowerOf2Floor(); sr = s1.PowerOf2Floor(); sr = s1.PowerOf2Floor(); sr = s1.PowerOf2Floor(); sr = s1.PowerOf2Floor(); }, 5);
            bench.Time("uint.PowerOf2Floor", () => { uir = ui1.PowerOf2Floor(); uir = ui1.PowerOf2Floor(); uir = ui1.PowerOf2Floor(); uir = ui1.PowerOf2Floor(); uir = ui1.PowerOf2Floor(); }, 5);
            bench.Time("int.PowerOf2Floor", () => { ir = i1.PowerOf2Floor(); ir = i1.PowerOf2Floor(); ir = i1.PowerOf2Floor(); ir = i1.PowerOf2Floor(); ir = i1.PowerOf2Floor(); }, 5);
            bench.Time("ulong.PowerOf2Floor", () => { ulr = ul1.PowerOf2Floor(); ulr = ul1.PowerOf2Floor(); ulr = ul1.PowerOf2Floor(); ulr = ul1.PowerOf2Floor(); ulr = ul1.PowerOf2Floor(); }, 5);
            bench.Time("long.PowerOf2Floor", () => { lr = l1.PowerOf2Floor(); lr = l1.PowerOf2Floor(); lr = l1.PowerOf2Floor(); lr = l1.PowerOf2Floor(); lr = l1.PowerOf2Floor(); }, 5);
            bench.Time("byte.PowerOf2Ceiling", () => { br = b1.PowerOf2Ceiling(); br = b1.PowerOf2Ceiling(); br = b1.PowerOf2Ceiling(); br = b1.PowerOf2Ceiling(); br = b1.PowerOf2Ceiling(); }, 5);
            bench.Time("sbyte.PowerOf2Ceiling", () => { sbr = sb1.PowerOf2Ceiling(); sbr = sb1.PowerOf2Ceiling(); sbr = sb1.PowerOf2Ceiling(); sbr = sb1.PowerOf2Ceiling(); sbr = sb1.PowerOf2Ceiling(); }, 5);
            bench.Time("ushort.PowerOf2Ceiling", () => { usr = us1.PowerOf2Ceiling(); usr = us1.PowerOf2Ceiling(); usr = us1.PowerOf2Ceiling(); usr = us1.PowerOf2Ceiling(); usr = us1.PowerOf2Ceiling(); }, 5);
            bench.Time("short.PowerOf2Ceiling", () => { sr = s1.PowerOf2Ceiling(); sr = s1.PowerOf2Ceiling(); sr = s1.PowerOf2Ceiling(); sr = s1.PowerOf2Ceiling(); sr = s1.PowerOf2Ceiling(); }, 5);
            bench.Time("uint.PowerOf2Ceiling", () => { uir = ui1.PowerOf2Ceiling(); uir = ui1.PowerOf2Ceiling(); uir = ui1.PowerOf2Ceiling(); uir = ui1.PowerOf2Ceiling(); uir = ui1.PowerOf2Ceiling(); }, 5);
            bench.Time("int.PowerOf2Ceiling", () => { ir = i1.PowerOf2Ceiling(); ir = i1.PowerOf2Ceiling(); ir = i1.PowerOf2Ceiling(); ir = i1.PowerOf2Ceiling(); ir = i1.PowerOf2Ceiling(); }, 5);
            bench.Time("ulong.PowerOf2Ceiling", () => { ulr = ul1.PowerOf2Ceiling(); ulr = ul1.PowerOf2Ceiling(); ulr = ul1.PowerOf2Ceiling(); ulr = ul1.PowerOf2Ceiling(); ulr = ul1.PowerOf2Ceiling(); }, 5);
            bench.Time("long.PowerOf2Ceiling", () => { lr = l1.PowerOf2Ceiling(); lr = l1.PowerOf2Ceiling(); lr = l1.PowerOf2Ceiling(); lr = l1.PowerOf2Ceiling(); lr = l1.PowerOf2Ceiling(); }, 5);
        }
        static void ProfileBitMath() {
            byte b1, br; b1 = 123;
            sbyte sb1, sbr; sb1 = 123;
            ushort us1, usr; us1 = 123;
            short s1, sr; s1 = 123;
            uint ui1, uir; ui1 = 123;
            int i1, ir; i1 = 123;
            ulong ul1, ulr; ul1 = 123;
            long l1, lr; l1 = 123;
            var bench = new Bench();
            bench.Time("byte.LowBit", () => { br = b1.LowBit(); br = b1.LowBit(); br = b1.LowBit(); br = b1.LowBit(); br = b1.LowBit(); }, 5);
            bench.Time("sbyte.LowBit", () => { sbr = sb1.LowBit(); sbr = sb1.LowBit(); sbr = sb1.LowBit(); sbr = sb1.LowBit(); sbr = sb1.LowBit(); }, 5);
            bench.Time("ushort.LowBit", () => { usr = us1.LowBit(); usr = us1.LowBit(); usr = us1.LowBit(); usr = us1.LowBit(); usr = us1.LowBit(); }, 5);
            bench.Time("short.LowBit", () => { sr = s1.LowBit(); sr = s1.LowBit(); sr = s1.LowBit(); sr = s1.LowBit(); sr = s1.LowBit(); }, 5);
            bench.Time("uint.LowBit", () => { uir = ui1.LowBit(); uir = ui1.LowBit(); uir = ui1.LowBit(); uir = ui1.LowBit(); uir = ui1.LowBit(); }, 5);
            bench.Time("int.LowBit", () => { ir = i1.LowBit(); ir = i1.LowBit(); ir = i1.LowBit(); ir = i1.LowBit(); ir = i1.LowBit(); }, 5);
            bench.Time("ulong.LowBit", () => { ulr = ul1.LowBit(); ulr = ul1.LowBit(); ulr = ul1.LowBit(); ulr = ul1.LowBit(); ulr = ul1.LowBit(); }, 5);
            bench.Time("long.LowBit", () => { lr = l1.LowBit(); lr = l1.LowBit(); lr = l1.LowBit(); lr = l1.LowBit(); lr = l1.LowBit(); }, 5);
            bench.Time("byte.HighBit", () => { br = b1.HighBit(); br = b1.HighBit(); br = b1.HighBit(); br = b1.HighBit(); br = b1.HighBit(); }, 5);
            bench.Time("sbyte.HighBit", () => { sbr = sb1.HighBit(); sbr = sb1.HighBit(); sbr = sb1.HighBit(); sbr = sb1.HighBit(); sbr = sb1.HighBit(); }, 5);
            bench.Time("ushort.HighBit", () => { usr = us1.HighBit(); usr = us1.HighBit(); usr = us1.HighBit(); usr = us1.HighBit(); usr = us1.HighBit(); }, 5);
            bench.Time("short.HighBit", () => { sr = s1.HighBit(); sr = s1.HighBit(); sr = s1.HighBit(); sr = s1.HighBit(); sr = s1.HighBit(); }, 5);
            bench.Time("uint.HighBit", () => { uir = ui1.HighBit(); uir = ui1.HighBit(); uir = ui1.HighBit(); uir = ui1.HighBit(); uir = ui1.HighBit(); }, 5);
            bench.Time("int.HighBit", () => { ir = i1.HighBit(); ir = i1.HighBit(); ir = i1.HighBit(); ir = i1.HighBit(); ir = i1.HighBit(); }, 5);
            bench.Time("ulong.HighBit", () => { ulr = ul1.HighBit(); ulr = ul1.HighBit(); ulr = ul1.HighBit(); ulr = ul1.HighBit(); ulr = ul1.HighBit(); }, 5);
            bench.Time("long.HighBit", () => { lr = l1.HighBit(); lr = l1.HighBit(); lr = l1.HighBit(); lr = l1.HighBit(); lr = l1.HighBit(); }, 5);
            bench.Time("byte.LowBitPosition", () => { br = b1.LowBitPosition(); br = b1.LowBitPosition(); br = b1.LowBitPosition(); br = b1.LowBitPosition(); br = b1.LowBitPosition(); }, 5);
            bench.Time("sbyte.LowBitPosition", () => { sbr = sb1.LowBitPosition(); sbr = sb1.LowBitPosition(); sbr = sb1.LowBitPosition(); sbr = sb1.LowBitPosition(); sbr = sb1.LowBitPosition(); }, 5);
            bench.Time("ushort.LowBitPosition", () => { usr = us1.LowBitPosition(); usr = us1.LowBitPosition(); usr = us1.LowBitPosition(); usr = us1.LowBitPosition(); usr = us1.LowBitPosition(); }, 5);
            bench.Time("short.LowBitPosition", () => { sr = s1.LowBitPosition(); sr = s1.LowBitPosition(); sr = s1.LowBitPosition(); sr = s1.LowBitPosition(); sr = s1.LowBitPosition(); }, 5);
            bench.Time("uint.LowBitPosition", () => { uir = ui1.LowBitPosition(); uir = ui1.LowBitPosition(); uir = ui1.LowBitPosition(); uir = ui1.LowBitPosition(); uir = ui1.LowBitPosition(); }, 5);
            bench.Time("int.LowBitPosition", () => { ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); }, 5);
            bench.Time("ulong.LowBitPosition", () => { ulr = ul1.LowBitPosition(); ulr = ul1.LowBitPosition(); ulr = ul1.LowBitPosition(); ulr = ul1.LowBitPosition(); ulr = ul1.LowBitPosition(); }, 5);
            bench.Time("long.LowBitPosition", () => { lr = l1.LowBitPosition(); lr = l1.LowBitPosition(); lr = l1.LowBitPosition(); lr = l1.LowBitPosition(); lr = l1.LowBitPosition(); }, 5);
            bench.Time("byte.HighBitPosition", () => { br = b1.HighBitPosition(); br = b1.HighBitPosition(); br = b1.HighBitPosition(); br = b1.HighBitPosition(); br = b1.HighBitPosition(); }, 5);
            bench.Time("sbyte.HighBitPosition", () => { sbr = sb1.HighBitPosition(); sbr = sb1.HighBitPosition(); sbr = sb1.HighBitPosition(); sbr = sb1.HighBitPosition(); sbr = sb1.HighBitPosition(); }, 5);
            bench.Time("ushort.HighBitPosition", () => { usr = us1.HighBitPosition(); usr = us1.HighBitPosition(); usr = us1.HighBitPosition(); usr = us1.HighBitPosition(); usr = us1.HighBitPosition(); }, 5);
            bench.Time("short.HighBitPosition", () => { sr = s1.HighBitPosition(); sr = s1.HighBitPosition(); sr = s1.HighBitPosition(); sr = s1.HighBitPosition(); sr = s1.HighBitPosition(); }, 5);
            bench.Time("uint.HighBitPosition", () => { uir = ui1.HighBitPosition(); uir = ui1.HighBitPosition(); uir = ui1.HighBitPosition(); uir = ui1.HighBitPosition(); uir = ui1.HighBitPosition(); }, 5);
            bench.Time("int.HighBitPosition", () => { ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); }, 5);
            bench.Time("ulong.HighBitPosition", () => { ulr = ul1.HighBitPosition(); ulr = ul1.HighBitPosition(); ulr = ul1.HighBitPosition(); ulr = ul1.HighBitPosition(); ulr = ul1.HighBitPosition(); }, 5);
            bench.Time("long.HighBitPosition", () => { lr = l1.HighBitPosition(); lr = l1.HighBitPosition(); lr = l1.HighBitPosition(); lr = l1.HighBitPosition(); lr = l1.HighBitPosition(); }, 5);
            bench.Time("byte.LeadingZeroBits", () => { br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); }, 5);
            bench.Time("sbyte.LeadingZeroBits", () => { br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); }, 5);
            bench.Time("ushort.LeadingZeroBits", () => { usr = us1.LeadingZeroBits(); usr = us1.LeadingZeroBits(); usr = us1.LeadingZeroBits(); usr = us1.LeadingZeroBits(); usr = us1.LeadingZeroBits(); }, 5);
            bench.Time("short.LeadingZeroBits", () => { sr = s1.LeadingZeroBits(); sr = s1.LeadingZeroBits(); sr = s1.LeadingZeroBits(); sr = s1.LeadingZeroBits(); sr = s1.LeadingZeroBits(); }, 5);
            bench.Time("uint.LeadingZeroBits", () => { uir = ui1.LeadingZeroBits(); uir = ui1.LeadingZeroBits(); uir = ui1.LeadingZeroBits(); uir = ui1.LeadingZeroBits(); uir = ui1.LeadingZeroBits(); }, 5);
            bench.Time("int.LeadingZeroBits", () => { ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); }, 5);
            bench.Time("ulong.LeadingZeroBits", () => { ulr = ul1.LeadingZeroBits(); ulr = ul1.LeadingZeroBits(); ulr = ul1.LeadingZeroBits(); ulr = ul1.LeadingZeroBits(); ulr = ul1.LeadingZeroBits(); }, 5);
            bench.Time("long.LeadingZeroBits", () => { lr = l1.LeadingZeroBits(); lr = l1.LeadingZeroBits(); lr = l1.LeadingZeroBits(); lr = l1.LeadingZeroBits(); lr = l1.LeadingZeroBits(); }, 5);
            bench.Time("byte.BitCount", () => { br = b1.BitCount(); br = b1.BitCount(); br = b1.BitCount(); br = b1.BitCount(); br = b1.BitCount(); }, 5);
            bench.Time("sbyte.BitCount", () => { sbr = sb1.BitCount(); sbr = sb1.BitCount(); sbr = sb1.BitCount(); sbr = sb1.BitCount(); sbr = sb1.BitCount(); }, 5);
            bench.Time("ushort.BitCount", () => { usr = us1.BitCount(); usr = us1.BitCount(); usr = us1.BitCount(); usr = us1.BitCount(); usr = us1.BitCount(); }, 5);
            bench.Time("short.BitCount", () => { sr = s1.BitCount(); sr = s1.BitCount(); sr = s1.BitCount(); sr = s1.BitCount(); sr = s1.BitCount(); }, 5);
            bench.Time("uint.BitCount", () => { uir = ui1.BitCount(); uir = ui1.BitCount(); uir = ui1.BitCount(); uir = ui1.BitCount(); uir = ui1.BitCount(); }, 5);
            bench.Time("int.BitCount", () => { ir = i1.BitCount(); ir = i1.BitCount(); ir = i1.BitCount(); ir = i1.BitCount(); ir = i1.BitCount(); }, 5);
            bench.Time("ulong.BitCount", () => { ulr = ul1.BitCount(); ulr = ul1.BitCount(); ulr = ul1.BitCount(); ulr = ul1.BitCount(); ulr = ul1.BitCount(); }, 5);
            bench.Time("long.BitCount", () => { lr = l1.BitCount(); lr = l1.BitCount(); lr = l1.BitCount(); lr = l1.BitCount(); lr = l1.BitCount(); }, 5);
            bench.Time("byte.ReverseBits", () => { br = b1.ReverseBits(); br = b1.ReverseBits(); br = b1.ReverseBits(); br = b1.ReverseBits(); br = b1.ReverseBits(); }, 5);
            bench.Time("sbyte.ReverseBits", () => { sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); }, 5);
            bench.Time("ushort.ReverseBits", () => { usr = us1.ReverseBits(); usr = us1.ReverseBits(); usr = us1.ReverseBits(); usr = us1.ReverseBits(); usr = us1.ReverseBits(); }, 5);
            bench.Time("short.ReverseBits", () => { sr = s1.ReverseBits(); sr = s1.ReverseBits(); sr = s1.ReverseBits(); sr = s1.ReverseBits(); sr = s1.ReverseBits(); }, 5);
            bench.Time("uint.ReverseBits", () => { uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); }, 5);
            bench.Time("int.ReverseBits", () => { ir = i1.ReverseBits(); ir = i1.ReverseBits(); ir = i1.ReverseBits(); ir = i1.ReverseBits(); ir = i1.ReverseBits(); }, 5);
            bench.Time("ulong.ReverseBits", () => { ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); }, 5);
            bench.Time("long.ReverseBits", () => { lr = l1.ReverseBits(); lr = l1.ReverseBits(); lr = l1.ReverseBits(); lr = l1.ReverseBits(); lr = l1.ReverseBits(); }, 5);
        }
    }
}
