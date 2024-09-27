using Repository.Attributes;
using Repository.Bases;
using Repository.Database.Bases;

namespace Repository.Database
{

    /// <summary>
    /// 班級信息表
    /// </summary>
    public class TCourse : CUD_User
    {



        /// <summary>
        /// 班級名称
        /// </summary>
        public string Name { get; set; }



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



        //一對多:一個班級對到多個學生
        public virtual List<TStudent> Students { get; set; }


    }
}
