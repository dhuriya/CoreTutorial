using System.Threading.Tasks;
using StudentManagementFile.API.Models;

namespace StudentManagementFile.API.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student? GetById(int id);
        Student Add(Student student);
        bool Update(int id, Student student);
        bool Delete(int id);
        PagedResult<Student> GetFiltered(StudentQueryParameters query);
    }
}