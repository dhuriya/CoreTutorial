namespace CoreLearn.Models
{
    public interface IStudentRepository
    {
        Student GetStudentById(int StudentId);
        List<Student> GetAllStudents();
    }
}