// <copyright file="ConsoleCheck.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalenderApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// オプションを確認するクラス
    /// </summary>
    public class ConsoleCheck
    {
        /// <summary>
        /// コンソールに入力された情報の確認
        /// </summary>
        /// <param name="args">cmd引数</param>
        /// <returns>Option オプションクラスの情報</returns>
        public Option Check(string[] args)
        {
            var reg = new Regex("[1-9]");
            var opc = new Option();
            var count = 0;
            var skipCount = 0;
            var calenderCount = false;

            for (int i = 0; i < args.Length; i++)
            {
                if (skipCount > 0)
                {
                    skipCount--;
                    continue;
                }

                if (args[i].Contains("-"))
                {
                    var option = args[i].Substring(1);
                    switch (option)
                    {
                        case "s":
                            opc.DatePriontChangeFlg = true;
                            break;
                        case "m":
                            opc.DatePriontChangeFlg = false;
                            break;
                        case "h":
                            opc.TodayColorChangeFlg = false;
                            break;
                        case "n":
                            opc.CalenderCreateCount = int.Parse(args[i + 1]);
                            calenderCount = true;
                            skipCount = 1;
                            break;
                    }
                }
                else
                {
                    if (count == 0)
                    {
                        opc.InputDate = new DateTime(int.Parse(args[i]), 1, 1);
                        count++;
                    }
                    else if (count == 1)
                    {
                        opc.InputDate = new DateTime(opc.InputDate.Year, int.Parse(args[i]), 1);
                        count++;
                    }
                }
            }

            if (count == 1 && !calenderCount)
            {
                opc.InputDate = new DateTime(opc.InputDate.Year, 1, 1);
                opc.CalenderCreateCount = 12;
            }
            else if (calenderCount && count == 2)
            {
                opc.InputDate = opc.InputDate.AddMonths(-1);
            }

            return opc;
        }
    }
}
