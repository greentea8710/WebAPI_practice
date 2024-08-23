﻿using Repository.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    /// <summary>
    /// 學生表
    /// </summary>
    public class TStudent : CUD
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Column(TypeName = "citext")]
        public string Name { get; set; }

        /// <summary>
        ///學號 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public EnumGender Gender { get; set; }

        public enum EnumGender
        {
            /// <summary>
            /// 未指定
            /// </summary>
            None = 0,

            /// <summary>
            /// 男性
            /// </summary>
            Male = 1,

            /// <summary>
            /// 女性
            /// </summary>
            Female = 2
        }

        /// <summary>
        /// 電話
        /// </summary>
        public string Phone { get; set; }

    }
}
