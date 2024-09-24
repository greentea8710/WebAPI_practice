using AdminShared.Models;
using AdminShared.Models.Course;
using IdentifierGenerator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Database;
using WebAPIBasic.Filters;
using WebAPIBasic.Libraries;

namespace AdminAPI.Controllers
{

    [Route("[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly DatabaseContext db;
        private readonly IdService idService;

        private readonly long userId;



        public CourseController(DatabaseContext db, IdService idService, IHttpContextAccessor httpContextAccessor)
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
        /// 获取班級管理列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public DtoPageList<DtoCourse> GetCourseList([FromQuery] DtoPageRequest request)
        {
            DtoPageList<DtoCourse> data = new();

            var query = db.TCourse.AsQueryable();

            data.Total = query.Count();

            data.List = query.OrderByDescending(t => t.CreateTime).Select(t => new DtoCourse
            {
                Id = t.Id,
                Name = t.Name,
                StudentTotal = t.StudentTotal,
                MaleStudentTotal = t.MaleStudentTotal,
                FemaleStudentTotal = t.FemaleStudentTotal,
                Grade = t.Grade,
                CreateTime = t.CreateTime
            }).Skip(request.Skip()).Take(request.PageSize).ToList();

            return data;
        }



        /// <summary>
        /// 获取班級管理
        /// </summary>
        /// <param name="courseId">链接ID</param>
        /// <returns></returns>
        [HttpGet]
        public DtoCourse? GetCourse(long courseId)
        {
            var course = db.TCourse.Where(t => t.Id == courseId).Select(t => new DtoCourse
            {
                Id = t.Id,
                Name = t.Name,
                CreateTime = t.CreateTime
            }).FirstOrDefault();

            return course;
        }




        /// <summary>
        /// 创建班級資料
        /// </summary>
        /// <param name="createCourse"></param>
        /// <returns></returns>
        [HttpPost]
        public long CreateCourse(DtoEditCourse createCourse)
        {
            TCourse course = new()
            {
                Id = idService.GetId(),
                Name = createCourse.Name,
                StudentTotal = createCourse.StudentTotal,
                MaleStudentTotal = createCourse.MaleStudentTotal,
                FemaleStudentTotal = createCourse.FemaleStudentTotal,
                Grade = createCourse.Grade,
                CreateUserId = userId
            };

            db.TCourse.Add(course);

            db.SaveChanges();

            return course.Id;
        }




        /// <summary>
        /// 更新班級管理
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="updateCourse"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateCourse(long courseId, DtoEditCourse updateCourse)
        {
            var course = db.TCourse.Where(t => t.Id == courseId).FirstOrDefault();

            if (course != null)
            {
                course.Name = updateCourse.Name;
                course.StudentTotal = updateCourse.StudentTotal;
                course.MaleStudentTotal = updateCourse.MaleStudentTotal;
                course.FemaleStudentTotal = updateCourse.FemaleStudentTotal;
                course.Grade = updateCourse.Grade;
                course.UpdateUserId = userId;
               

                db.SaveChanges();
            }

            return true;
        }



        [HttpDelete]
        public bool DeleteCourse(long id)
        {
            var course = db.TCourse.Where(t => t.Id == id).FirstOrDefault();

            if (course != null)
            {
                course.IsDelete = true;
                course.DeleteUserId = userId;

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
