using AdminShared.Models;
using AdminShared.Models.Student;
using AdminShared.Models.Course;
using IdentifierGenerator;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Repository.Database;
using WebAPIBasic.Filters;
using WebAPIBasic.Libraries;

namespace AdminAPI.Controllers
{

    [Route("[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly DatabaseContext db;
        private readonly IdService idService;

        private readonly long userId;



        public StudentController(DatabaseContext db, IdService idService, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.idService = idService;

            var userIdStr = httpContextAccessor.HttpContext?.GetClaimByUser("userId");
            if (userIdStr != null)
            {
                userId = long.Parse(userIdStr);
            }
        }



        /// <summary>
        /// 获取學生管理列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public DtoPageList<DtoStudent> GetStudentList([FromQuery] DtoPageRequest request)
        {
            DtoPageList<DtoStudent> data = new();

            var query = db.TStudent.Where(t => t.Course != null);


            // 加入 Include 來同時載入學生的班級 (Course) 資料
            //var query = db.TStudent
            //              .Include(s => s.Course)  
            //              .AsQueryable();


            data.Total = query.Count();

            data.List = query.OrderByDescending(t => t.CreateTime).Select(t => new DtoStudent
            {

                Id = t.Id,
                Name = t.Name,
                Number = t.Number,
                Gender = t.Gender,
                Phone = t.Phone,
                CreateTime = t.CreateTime,

                Course = new DtoCourse  // 包含所屬班級資訊
                {
                    Id = t.Course.Id,
                    Name = t.Course.Name,
                }

            }).Skip(request.Skip()).Take(request.PageSize).ToList();

            return data;

        }



        /// <summary>
        /// 获取學生管理
        /// </summary>
        /// <param name="studentId">链接ID</param>
        /// <returns></returns>
        [HttpGet]
        public DtoStudent? GetStudent(long studentId)
        {
            //var query = db.TStudent.Include(t => t.Course).AsQueryable();

            var student = db.TStudent.Where(t => t.Id == studentId).Select(t => new DtoStudent
            {
                Id = t.Id,
                Name = t.Name,
                CreateTime = t.CreateTime,
            }).FirstOrDefault();


            //var student = db.TStudent
            //        .Include(t => t.Course) // 加載課程資料
            //        .Where(t => t.Id == studentId)
            //        .Select(t => new DtoStudent
            //        {
            //            Id = t.Id,
            //            Name = t.Name,
            //            Number = t.Number,
            //            Phone = t.Phone,
            //            Gender = t.Gender,
            //            CreateTime = t.CreateTime,

            //            //包含所屬課程資訊
            //            Course = new DtoCourse
            //            {
            //                Id = t.Course.Id,
            //                CourseName = t.Course.Name
            //            }
            //        })
            //        .FirstOrDefault();

            return student;
        }




        /// <summary>
        /// 创建學生資料
        /// </summary>
        /// <param name="createStudent"></param>
        /// <returns></returns>
        [HttpPost]
        public long CreateStudent(DtoEditStudent createStudent)
        {


            TStudent student = new()
            {
                Id = idService.GetId(),
                Name = createStudent.Name,
                Number = createStudent.Number,
                Gender = (TStudent.EnumGender)createStudent.Gender,
                Phone = createStudent.Phone,
                //CourseId = studentCourse.Id,
                CreateUserId = userId,

            };

            db.TStudent.Add(student);

            db.SaveChanges();

            return student.Id;
        }




        /// <summary>
        /// 更新學生管理
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="updateStudent"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateStudent(long studentId, DtoEditStudent updateStudent)
        {
            var student = db.TStudent.Where(t => t.Id == studentId).FirstOrDefault();



            if (student != null)
            {
                student.Name = updateStudent.Name;
                student.Number = updateStudent.Number;
                student.Gender = (TStudent.EnumGender)updateStudent.Gender;
                student.Phone = updateStudent.Phone;
                //student.CourseId = updateStudent.CourseId;                
                student.UpdateUserId = userId;

                db.SaveChanges();
            }

            return true;
        }



        [HttpDelete]
        public bool DeleteStudent(long id)
        {
            var student = db.TStudent.Where(t => t.Id == id).FirstOrDefault();

            if (student != null)
            {
                student.IsDelete = true;
                student.DeleteUserId = userId;

                db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
