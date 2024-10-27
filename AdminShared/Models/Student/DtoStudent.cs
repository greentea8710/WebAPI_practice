using Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repository.Database.TStudent;
using static Repository.Database.TCourse;
using AdminShared.Models.Course;

namespace AdminShared.Models.Student
{
    public class DtoStudent
    {
        /// <summary>
        /// 標示學生ID
        /// </summary>
        public long Id { get; set; }



        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///學號 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public EnumGender Gender { get; set; }



        /// <summary>
        /// 電話
        /// </summary>
        public string Phone { get; set; }


        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTimeOffset CreateTime { get; set; }


        //#################################################################

        /// <summary>
        /// 包含班級資訊
        /// </summary>
        public DtoCourse Course { get; set; }

        //#################################################################






    }
}
