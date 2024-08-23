namespace WebAPIBasic.Models.Shared
{


    /// <summary>
    /// 分页数据信息基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DtoPageList<T>
    {

        /// <summary>
        /// 数据总量
        /// </summary>
        public int Total { get; set; }




        /// <summary>
        /// 具体数据内容
        /// </summary>
        public List<T>? List { get; set; }

        //T 代表一個數據類型，但類型是甚麼我們不知道，在使用時才會知道
        //List<T>:T這個未知類型的集合

    }
}
