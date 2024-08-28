using IdentifierGenerator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Database;
using WebAPI.Models.Class;
using Common;
using WebAPIBasic.Models.Shared;
using WebAPI.Models.Student;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClassController(DatabaseContext db , IdService idService) : ControllerBase
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
                Grade = t.Grade,
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



        //修改數據
        [HttpPost]
        public bool UpdateClass(DtoUpdateClass request)
        {
            var Class = db.TClass.Where(t => t.Id == request.Id).FirstOrDefault();
            if (Class != null)
            {
                Class.Name = request.Name;
                Class.Grade = request.Grade;
                
                db.SaveChanges();
                
                return true;
            }
            else
            {
                throw new CustomException("未找到對應的班級");
            }
        }


        //新增數據到資料庫
        [HttpPost]  //提交數據到伺服器
        public long CreateClass(DtoCreateClass request)//用這個方法(DtoCreateClass)傳入參數(request)
        {
            //判斷資料庫中Name是否已經存在
            var isHave = db.TClass.Where(t => t.Name == request.Name).Any();

            if (!isHave)
            {
                TClass Class = new()
                {
                    Id = idService.GetId(),
                    Name = request.Name,
                    Grade = request.Grade,
                };

                db.TClass.Add(Class);

                db.SaveChanges();

                return Class.Id;
            }
            else
            {
                throw new CustomException("班級已存在");
            }
        }





        //刪除數據
        [HttpDelete]
        public bool DeleteClass(long id)
        {
            var _class = db.TClass.Where(t => t.Id == id).FirstOrDefault();
            if (_class != null)
            {
                _class.IsDelete = true;
                _class.DeleteTime = DateTimeOffset.UtcNow;

                db.SaveChanges();

                return true;
            }
            else
            {
                throw new CustomException("未找到對應的班級");
            }
        }




    }
}
