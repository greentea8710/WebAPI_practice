using IdentifierGenerator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Database;
using WebAPI.Models.Class;
using Common;
using WebAPIBasic.Models.Shared;
using WebAPI.Models.Student;
using DistributedLock;

namespace WebAPI.Controllers
{

    /*
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClassController(DatabaseContext db , IdService idService) : ControllerBase
    {

    */
    //IdService idService = 要做數據的插入才需要這個


    [Route("[controller]/[action]")]
    [ApiController]
    public class classController : ControllerBase
    {
        private readonly DatabaseContext db;
        private readonly IdService idService;

        private readonly IDistributedLock distributedLock;

        public classController(DatabaseContext _db, IdService _idService, IHttpContextAccessor httpContextAccessor, IDistributedLock distributedLock)
        {
            db = _db;  
            idService = _idService;
            this.distributedLock = distributedLock;
        }




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



        //共三種方式:內存、lock、distributedlock

        private static object checkClassName = "";

        //新增數據到資料庫--distributedLock--[高併發下使用分佈式鎖]
        [HttpPost]
        public long CreateClass(DtoCreateClass request)
        {
            //將原本存在內存的值，抽出去到redis儲存(不管啟動幾個，redis都保持一個)
            //就可以在多個程序間共享redis的值
            using (var handle = distributedLock.TryLock("checkClassName"))
            {
                //using:在跑完using內部的程式之後，會自動釋放鎖定
                //TryLock:嘗試看看有沒有鎖住，傳值給handle，如果handle有值，就執行---使其他沒有搶到位置的，直接離開
                //Lock:其他沒有等到位置的，要繼續排隊等待，所以花費時間比較久


                if (handle != null)
                {
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
                else
                {
                    throw new CustomException("班級已存在");
                }
            }

        }



        /*
        
        //static靜態:程式啟動後就只有new一次，不會一直重複
        //不管有多少請求，這個在內存中只有一份      
        private static object checkClassName = "";
        //搭配lock (checkClassName)使用
        //lock只能用在鎖定一個程序中的資源，但如果有多台API或伺服器或相同程序在執行，就無法只鎖定一個


        //新增數據到資料庫
        [HttpPost]  //提交數據到伺服器
        public long CreateClass(DtoCreateClass request)//用這個方法(DtoCreateClass)傳入參數(request)
        {
            //lock:所有請求一次過來，但lock只會提供一個位置給一個請求做
            lock (checkClassName)
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
        }

        */



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
