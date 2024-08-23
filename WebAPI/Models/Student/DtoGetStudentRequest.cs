using WebAPIBasic.Models.Shared;

namespace WebAPI.Models.Student
{
    /// <summary>
    /// 獲取學生列表的請求參數
    /// </summary>
    public class DtoGetStudentRequest : DtoPageRequest  //繼承分頁的設定
    {
        
        /// <summary>
        /// 搜索關鍵字
        /// </summary>
        public string? SearchKey { get; set; }


        public DateTimeOffset? StartTime { get; set; }



        public DateTimeOffset? EndTime { get; set; }

    }
}
