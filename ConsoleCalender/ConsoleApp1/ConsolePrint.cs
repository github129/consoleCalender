// <copyright file="ConsolePrint.cs" company="PlaceholderCompany">
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
    /// 表示関係のクラス
    /// </summary>
    public class ConsolePrint
    {
        /// <summary>
        /// 曜日の入った配列 sFlgがtureの場合
        /// </summary>
        private static readonly string[] DateListS = { "日", "月", "火", "水", "木", "金", "土" };

        /// <summary>
        /// 曜日の入った配列　sFlgがfalseの場合
        /// </summary>
        private static readonly string[] DateListM = { "月", "火", "水", "木", "金", "土", "日" };

        /// <summary>
        /// カレンダー出力用の配列
        /// </summary>
        private string[,] calender = new string[9, 27];

        /// <summary>
        /// bgcolorを変更する位置
        /// </summary>
        private int bgColorReverse;

        /// <summary>
        /// カレンダーを作成するメソッド
        /// </summary>
        /// <param name="list">カレンダーの情報が入ったリスト</param>
        /// <param name="op">オプションクラスのデータ</param>
        public void CalenderConsoleCreate(IList<CalenderData> list, Option op)
        {
            this.bgColorReverse = 27;
            var start = 0;
            for (var i = 0; i < list.Count; i++)
            {
                this.CreateCalenderYearMonth(list[i].CreateYear, list[i].CreateMonth, start);

                // 曜日
                if (op.DatePriontChangeFlg)
                {
                    this.CreateCalenderDate(start, ConsolePrint.DateListS);
                }
                else
                {
                    this.CreateCalenderDate(start, ConsolePrint.DateListM);
                }

                this.CreateCalender(start, list[i].CalenderLastDay, list[i].CreateYear, list[i].CreateMonth, list[i].FastDate);

                start += 9;

                if ((i + 1) % 3 == 0 || (i + 1) == list.Count)
                {
                    bool reverseColor = op.TodayColorChangeFlg;
                    this.ConsoleCalenderPrint(this.calender, this.bgColorReverse, reverseColor);
                    this.calender = new string[9, 27];
                    start = 0;
                }
            }
        }

        /// <summary>
        /// 配列に日にちを追加するメソッド
        /// </summary>
        /// <param name="start">開始位置</param>
        /// <param name="lastDay">最終日</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="fastDate">最初の曜日</param>
        public void CreateCalender(int start, int lastDay, int year, int month, int fastDate)
        {
            int day = 1;
            for (int y = 2; y < 9; y++)
            {
                if (y == 2)
                {
                    for (int x = fastDate + start; x < 27; x++)
                    {
                        if (day == DateTime.Now.Day && year == DateTime.Now.Year
                            && month == DateTime.Now.Month)
                        {
                            this.bgColorReverse = x;
                        }

                        if (x > 6 + start)
                        {
                            this.calender[y, x] = "  ";
                            continue;
                        }

                        this.calender[y, x] = " " + day.ToString();
                        day++;
                    }
                }
                else
                {
                    for (int x = 0 + start; x < 27; x++)
                    {
                        if (day == DateTime.Now.Day && year == DateTime.Now.Year
                            && month == DateTime.Now.Month)
                        {
                            this.bgColorReverse = x;
                        }

                        if (x > 6 + start)
                        {
                            this.calender[y, x] = "  ";
                            continue;
                        }
                        else if (day > lastDay)
                        {
                            continue;
                        }

                        if (day < 10)
                        {
                            this.calender[y, x] = " " + day.ToString();
                        }
                        else
                        {
                            this.calender[y, x] = day.ToString();
                        }

                        day++;
                    }
                }
            }
        }

        /// <summary>
        /// 曜日を追加するメソッド
        /// </summary>
        /// <param name="start">入力し始める場所</param>
        /// <param name="dateList">曜日の入った配列</param>
        public void CreateCalenderDate(int start, string[] dateList)
        {
            for (int x = 0; x < 7; x++)
            {
                this.calender[1, start + x] = dateList[x];
            }
        }

        /// <summary>
        /// 年と月を追加するメソッド
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="start">追加し始める場所</param>
        public void CreateCalenderYearMonth(int year, int month, int start)
        {
            this.calender[0, start] = "  " + year + "年" + month + "月";
            for (int x = start + 1; x < 27; x++)
            {
                this.calender[0, x] = " ";
            }
        }

        /// <summary>
        /// コンソールにカレンダーを表示するメソッド
        /// </summary>
        /// <param name="list">カレンダーの入った配列</param>
        /// <param name="bgColorReverseX">BGcolor反転位置X</param>
        /// <param name="reverseColor">色を反転するかどうかの判断用フラグ</param>
        public void ConsoleCalenderPrint(string[,] list, int bgColorReverseX, bool reverseColor)
        {
            var reg = new Regex("[1-9]");
            var cal = new Calender();
            Console.WriteLine(); // 改行

            for (var y = 0; y < 9; y++)
            {
                Console.WriteLine();
                for (var x = 0; x < 27; x++)
                {
                    if (list[y, x] == null)
                    {
                    Console.Write("   ");
                    }
                    else
                    {
                        if (reverseColor && x == bgColorReverseX && reg.IsMatch(list[y, x]) &&
                            int.Parse(list[y, x]) == DateTime.Now.Day)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(list[y, x] + " ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(list[y, x] + " ");
                        }
                    }
                }
            }
        }
    }
}