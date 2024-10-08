﻿using System.ComponentModel.DataAnnotations;



namespace AdminShared.Models.Course
{

    /// <summary>
    /// 更新班級資訊
    /// </summary>
    public class DtoEditCourse
    {



        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名稱不可以空")]
        public string Name { get; set; }


        

        /// <summary>
        /// 學生總數
        /// </summary>
        [Required(ErrorMessage = "StudentTotal不可以空")]
        public int StudentTotal { get; set; }

        /// <summary>
        /// 男性人數
        /// </summary>
        [Required(ErrorMessage = "MaleStudentTotal不可以空")]
        public int MaleStudentTotal { get; set; }


        /// <summary>
        /// 女性人數
        /// </summary>
        [Required(ErrorMessage = "FemaleStudentTotal不可以空")]
        public int FemaleStudentTotal { get; set; }


        /// <summary>
        /// 年級
        /// </summary>
        [Required(ErrorMessage = "Grade不可以空")]
        public string Grade { get; set; }


    }
}