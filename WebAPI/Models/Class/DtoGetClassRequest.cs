using WebAPIBasic.Models.Shared;

namespace WebAPI.Models.Class
{
    public class DtoGetClassRequest : DtoPageRequest
    {

        public string? SearchKey { get; set; }



        public DateTimeOffset? StartTime { get; set; }



        public DateTimeOffset? EndTime { get; set; }
    }
}
