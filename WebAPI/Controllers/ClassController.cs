using IdentifierGenerator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Database;
using WebAPI.Models.Class;
using Common;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClassController(DatabaseContext db /*, IdService idService */ ) : ControllerBase
    {
        //IdService idService = 要做數據的插入才需要這個


        //獲取(查詢)班級訊息的一個API
        [HttpGet]
        public DtoClass GetClass(long id)
        { 
            var info = db.TClass.Where(t => t.Id == id).Select(t => new DtoClass 
            {
                //因為下面的 return "info" 要跟 public "DtoClass" GetClass 同類型，所以要用上面 new DtoClass 
                Id = t.Id,
                Name = t.Name,
                CreateTime = t.CreateTime, 
                StudentTotal = t.Students.Count(),
                //因為我們在TStudent學生表中有紀錄每個學生所書班級，所以可用StudentTotal = t.Students.Count(),
                MaleStudentTotal=t.Students.Where(a=>a.Gender== TStudent.EnumGender.Male).Count(),
                FemaleStudentTotal= t.Students.Where(a => a.Gender == TStudent.EnumGender.Female).Count(),
            }).FirstOrDefault();

            if (info != null)
            {
                return info;
            }
            else 
            {
                throw new CustomException("無效的Id，未查詢到對應的班級");
            }
            
        }




    }
}
