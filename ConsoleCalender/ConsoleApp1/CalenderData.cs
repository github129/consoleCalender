// <copyright file="CalenderData.cs" company="PlaceholderCompany">
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
    /// カレンダーデータクラス
    /// カレンダーの情報を持っているクラス
    /// </summary>
    public class CalenderData
    {
        /// <summary>
        /// 年
        /// </summary>
        private int createYear = DateTime.Now.Year;

        /// <summary>
        /// 月
        /// </summary>
        private int createMonth = DateTime.Now.Month;

        /// <summary>
        /// １日の曜日
        /// </summary>
        private int fastDate;

        /// <summary>
        /// 最終日
        /// </summary>
        private int calenderLastDay;

        /// <summary>
        /// Gets or sets 最終日を扱うプロパティ
        /// </summary>
        public int CalenderLastDay
        {
            get { return this.calenderLastDay; }
            set => this.calenderLastDay = value;
        }

        /// <summary>
        /// Gets or sets 年を扱うプロパティ
        /// </summary>
        public int CreateYear
        {
            get { return this.createYear; }
            set => this.createYear = value;
        }

        /// <summary>
        /// Gets or sets 月を扱うプロパティ
        /// </summary>
        public int CreateMonth
        {
            get { return this.createMonth; }
            set => this.createMonth = value;
        }

        /// <summary>
        /// Gets fastDateを扱うプロパティ
        /// </summary>
        public int FastDate
        {
            get { return this.fastDate; }
            private set { this.fastDate = value; }
        }

        /// <summary>
        /// 年月日を更新するメソッド
        /// </summary>
        /// <param name="date">日</param>
        /// <param name="weekStartFlg"> 曜日が日曜始まりか月曜始まりかを判断するフラグ</param>
        public void Update(DateTime date, bool weekStartFlg)
        {
            this.CreateYear = date.Year;
            this.CreateMonth = date.Month;
            this.fastDate = this.FastDateCreate(weekStartFlg);
            this.LastDay();
        }

        /// <summary>
        /// 最初の曜日を求めるメソッド
        /// </summary>
        /// <param name="weekStartFlg"> 曜日が日曜始まりか月曜始まりかを判断するフラグ</param>
        /// <returns>fastDate 最初の曜日</returns>
        public int FastDateCreate(bool weekStartFlg)
        {
            var fastDay = 1;
            var dt = new DateTime(this.CreateYear, this.createMonth, fastDay);
            if (!weekStartFlg)
            {
                dt = dt.AddDays(-1);
            }

            var fastDate = (int)dt.DayOfWeek;
            return fastDate;
        }

        /// <summary>
        /// 最終日を求めるメソッド
        /// </summary>
        public void LastDay()
        {
            this.CalenderLastDay = DateTime.DaysInMonth(this.CreateYear, this.CreateMonth);
        }
    }
}