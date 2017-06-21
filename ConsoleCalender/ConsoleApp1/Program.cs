// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CalenderApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 実行クラス
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 実行メソッド
        /// </summary>
        /// <param name="args">cmd引数</param>
        public static void Main(string[] args)
        {
            var check = new ConsoleCheck();
            var op = check.Check(args);
            Calender cal = new Calender();
            var list = cal.Create(op);
            var print = new ConsolePrint();
            print.CalenderConsoleCreate(list, op);
        }
    }
}