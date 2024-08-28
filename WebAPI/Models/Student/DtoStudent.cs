using static Repository.Database.TStudent;

namespace WebAPI.Models.Student
{
    public class DtoStudent
    {
        /// <summary>
        /// 標示ID
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
        /// 所屬班級Id
        /// </summary>
        public long ClassId { get; set; }


        /// <summary>
        /// 所屬班級名稱
        /// </summary>
        public string ClassName { get; set; }




        public string Grade { get; set; }



        public DateTimeOffset ClassCreateTime { get; set; }


        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTimeOffset CreateTime { get; set; }


    }
}
