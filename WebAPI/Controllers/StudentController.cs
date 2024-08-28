using Common;
using IdentifierGenerator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Database;
using TencentCloud.Iotvideoindustry.V20201201.Models;
using WebAPI.Models.Student;
using WebAPIBasic.Models.Shared;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        //需要引用資料庫
        //定義了一個 StudentController 類別，並使用了依賴注入 (Dependency Injection, DI) 的方式來初始化資料庫上下文 DatabaseContext
        //初始化 StudentController 類別
        //讓 StudentController 可以在其方法中使用 db 來與資料庫進行操作
        private readonly DatabaseContext db;

        private readonly IdService idService;

        public StudentController(DatabaseContext _db, IdService _idService)
        {
            db = _db;  //將建構函數參數 _db 的值賦給成員變數 db
            idService = _idService;
        }



        //查詢(列出)所有資料
        [HttpGet]
        public DtoPageList<DtoStudent> GetStudentList([FromQuery] DtoGetStudentRequest request)
        {
            //FromQuery & FromBody 區別

            DtoPageList<DtoStudent> pageList = new();

            //query=查詢條件
            var query = db.TStudent.AsQueryable();
            //AsQueryable:想像成SELECT XX FROM XX "WHERE"
            //若有有輸入檢所則放在WHERE後面，無則省略

            if (!string.IsNullOrWhiteSpace(request.SearchKey))   //檢索有輸入文字
            {
                query = query.Where(t => t.Name.Contains(request.SearchKey) || t.Phone.Contains(request.SearchKey) || t.Number.Contains(request.SearchKey));              
            }
            //檢索輸入甚麼值，就查詢什麼



            if (request.StartTime != null) 
            {
                var startTime = DateTimeHelper.TimeErase(request.StartTime.Value).ToUniversalTime();
                //TimeErase抹零時間：年月日時分秒>>年月日 (時間去掉剩下日期)

                query = query.Where(t => t.CreateTime >= startTime);
            }

            if (request.EndTime != null)
            {
                var endTime = DateTimeHelper.TimeErase(request.EndTime.Value).ToUniversalTime();
                query = query.Where(t => t.CreateTime < endTime);
            }



            pageList.Total = query.Count();


            pageList.List = query.OrderBy(t => t.CreateTime).Select(t => new DtoStudent
            {
                Id = t.Id,
                Name = t.Name,
                Gender = t.Gender,
                Phone = t.Phone,
                Number = t.Number,
                CreateTime = t.CreateTime,
                ClassId = t.ClassId,
                ClassName = t.Class.Name,
                ClassCreateTime=t.Class.CreateTime
            }).Skip(request.Skip()).Take(request.PageSize).ToList();
            //假設一頁100條數據，若要查詢第七頁，要skip 600 條數據，才能顯示第七頁的601~700的數據

            return pageList;
        }




        //修改數據
        [HttpPost]
        public bool UpdateStudent(DtoUpdateStudent request)
        {
            var student = db.TStudent.Where(t => t.Id == request.Id).FirstOrDefault();
            if (student != null)
            {
                student.Number = request.Number;
                student.Name = request.Name;
                student.Gender = request.Gender;
                student.Phone = request.Phone;

                db.SaveChanges();

                return true;
            }
            else
            {
                throw new CustomException("未找到對應的學生");
            }
        }

        //API新增數據到資料庫
        [HttpPost]  //提交數據到伺服器
        public long CreateStudent(DtoCreateStudent request)//用這個方法(DtoCreateStudent)傳入參數(request)
        {
            //判斷資料庫中Number是否已經存在
            var isHave = db.TStudent.Where(t => t.Number == request.Number).Any();

            if (!isHave)
            {
                TStudent student = new()
                {
                    Id = idService.GetId(),
                    Number = request.Number,
                    Name = request.Name,
                    Gender = request.Gender,
                    Phone = request.Phone
                };

                db.TStudent.Add(student);

                db.SaveChanges();

                return student.Id;
            }
            else
            {
                throw new CustomException("學號已存在");
            }
        }


        //刪除數據
        [HttpDelete]
        public bool DeleteStudent(long id)
        {
            var student = db.TStudent.Where(t => t.Id == id).FirstOrDefault();
            if (student != null)
            {
                student.IsDelete = true;
                student.DeleteTime = DateTimeOffset.UtcNow;

                db.SaveChanges();
                return true;

            }
            else
            {
                throw new CustomException("未找到對應的學生");
            }
        }


    }
}
