using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementFile.API.Models;

namespace StudentManagementFile.API.Services
{
    public interface ICourseService
    {
        List<Course> GetAll();
        Course? GetById(int id);
        Course Add(Course course);
        bool Update(Course course, int id);
        bool Delete(int id);
    }
}