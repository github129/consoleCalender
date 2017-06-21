// <copyright file="Calender.cs" company="PlaceholderCompany">
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
    /// カレンダークラス
    /// カレンダーを完成させるクラス
    /// </summary>
    public class Calender
    {
        /// <summary>
        /// カレンダーを作成するメソッド
        /// </summary>
        /// <param name="op">オプションクラスの情報</param>
        /// <returns>dataList カレンダーデータの情報が入ったリスト</returns>
        public IList<CalenderData> Create(Option op)
        {
            var dataList = new List<CalenderData>();

            for (var i = 0; i < op.CalenderCreateCount; i++)
            {
                var data = new CalenderData();
                data.Update(op.InputDate.AddMonths(i), op.DatePriontChangeFlg);
                dataList.Add(data);
            }

            return dataList;
        }
    }
}
