//
//  Program.cs
//
//  Author:
//       Natalia Portillo <claunia@claunia.com>
//
//  Copyright (c) 2017 © Claunia.com
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//
using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Numerics;

namespace TestSIMD
{
	public class MD5Benchs
	{
		private const int N = 65536;
		private readonly byte[] data;

		private readonly MD5 md5 = MD5.Create();
        private readonly MD5Managed md5m = new MD5Managed();
		private readonly VectorMD5 md5v =new VectorMD5();
		private readonly MonoMD5 md5s = new MonoMD5();

		public MD5Benchs()
		{
			data = new byte[N];
			new Random(42).NextBytes(data);
		}

		[Benchmark]
		public byte[] Md5() => md5.ComputeHash(data);

        [Benchmark]
		public byte[] Md5Managed() => md5m.ComputeHash(data);

		[Benchmark]
		public byte[] Md5Vectorized() => md5v.ComputeHash(data);

        [Benchmark]
        public byte[] Md5Mono() => md5s.ComputeHash(data);
	}

    class MainClass
    {
        public static void Main(string[] args)
        {
			Console.WriteLine("Vector.IsHardwareAccelerated = {0}", Vector.IsHardwareAccelerated);

			MD5Benchs foo = new MD5Benchs();

			byte[] std = foo.Md5();
			byte[] mgd = foo.Md5Managed();
			byte[] vec = foo.Md5Vectorized();
			byte[] mno = foo.Md5Mono();

			Console.WriteLine("std: {0:x2}{1:x2}{2:x2}{3:x2}", std[0], std[1], std[2], std[3]);
			Console.WriteLine("mgd: {0:x2}{1:x2}{2:x2}{3:x2}", mgd[0], mgd[1], mgd[2], mgd[3]);
			Console.WriteLine("vec: {0:x2}{1:x2}{2:x2}{3:x2}", vec[0], vec[1], vec[2], vec[3]);
			Console.WriteLine("mno: {0:x2}{1:x2}{2:x2}{3:x2}", mno[0], mno[1], mno[2], mno[3]);
			
            var summary = BenchmarkRunner.Run<MD5Benchs>();
		}
    }
}
