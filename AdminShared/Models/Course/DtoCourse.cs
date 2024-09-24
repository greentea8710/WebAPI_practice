using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminShared.Models.Course
{
    public class DtoCourse
    {

        /// <summary>
        /// 標示Id
        /// </summary>
        public long Id { get; set; }


        /// <summary>
        /// 課程名稱
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 網址
        /// </summary>
        public string? Url { get; set; }



        /// <summary>
        /// 學生總數
        /// </summary>
        public int StudentTotal { get; set; }


        /// <summary>
        /// 男性人數
        /// </summary>
        public int MaleStudentTotal { get; set; }


        /// <summary>
        /// 女性人數
        /// </summary>
        public int FemaleStudentTotal { get; set; }


        /// <summary>
        /// 年級
        /// </summary>
        public string Grade { get; set; }



        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTimeOffset CreateTime { get; set; }

    }
}
