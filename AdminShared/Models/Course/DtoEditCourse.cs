using System.ComponentModel.DataAnnotations;



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



    }
}