using Common;
using IdentifierGenerator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Database;
using WebAPI.Models.Student;

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

    public StudentController(DatabaseContext _db,IdService _idService)
    {
      db =_db;  //將建構函數參數 _db 的值賦給成員變數 db
      idService = _idService;
    }


    //查詢(列出)所有資料
    [HttpGet]
    public List<DtoStudent> GetStudentList()
    { 
      var studentList = db.TStudent.Select(t => new DtoStudent
      { Id = t.Id,
        Name = t.Name,
        Gender = t.Gender,
        Phone = t.Phone,
        Number = t.Number,
        CreateTime = t.CreateTime
      }).ToList();

      return studentList;
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
