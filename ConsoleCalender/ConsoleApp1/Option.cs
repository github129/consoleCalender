// <copyright file="Option.cs" company="PlaceholderCompany">
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
    /// オプションを保持しているクラス
    /// </summary>
    public class Option
    {
        /// <summary>
        /// nに入力されたカレンダーを増やすための値
        /// </summary>
        private int calenderCreateCount = 1;

        /// <summary>
        /// 曜日の始まり判断用
        /// </summary>
        private bool datePriontChangeFlg = true;

        /// <summary>
        /// bgColor判断用
        /// </summary>
        private bool todayColorChangeFlg = true;

        /// <summary>
        /// 入力年月
        /// </summary>
        private DateTime inputDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        /// <summary>
        /// Gets or sets カレンダーを作る量　-nの後の値
        /// </summary>
        public int CalenderCreateCount
        {
            get { return this.calenderCreateCount; }
            set { this.calenderCreateCount = value; }
        }

        /// <summary>
        /// Gets or sets 入力された年月日
        /// </summary>
        public DateTime InputDate
        {
            get { return this.inputDate; }
            set { this.inputDate = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 曜日の変更用のプロパティ
        /// </summary>
        public bool DatePriontChangeFlg
        {
            get { return this.datePriontChangeFlg; }
            set { this.datePriontChangeFlg = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether bgColor変更用のプロパティ
        /// </summary>
        public bool TodayColorChangeFlg
        {
            get { return this.todayColorChangeFlg; }
            set { this.todayColorChangeFlg = value; }
        }
    }
}