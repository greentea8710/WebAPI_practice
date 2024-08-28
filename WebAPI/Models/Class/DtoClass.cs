namespace WebAPI.Models.Class
{
    public class DtoClass
    {

        public long Id { get; set; }


        public string Name { get; set; }


        public DateTimeOffset CreateTime { get; set; }

        /// <summary>
        /// 學生總數
        /// </summary>
        public int StudentTotal { get; set; }


        public int MaleStudentTotal { get; set; }


        public int FemaleStudentTotal { get; set;}




    }
}
