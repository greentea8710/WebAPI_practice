using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static Repository.Database.TStudent;
using static Repository.Database.TCourse;
using Repository.Database;
using AdminShared.Models.Course;

namespace AdminShared.Models.Student
{
    public class DtoEditStudent
    {



        //public long CourseId { get; set; }

        //// 當前可選的課程列表 (如果需要在前端顯示課程)
        //public List<DtoCourse> Course { get; set; }







        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不可以空")]
        public string Name { get; set; }


        /// <summary>
        /// 學號 
        /// </summary>
        [Required(ErrorMessage = "座號不可以空")]
        public string Number { get; set; }


        /// <summary>
        /// 性別
        /// </summary>
        [Required(ErrorMessage = "Gender不可以空")]
        public EnumGender Gender { get; set; }

        /// <summary>
        /// 電話
        /// </summary>
        [Required(ErrorMessage = "Phone不可以空")]
        public string Phone { get; set; }









    }
}
