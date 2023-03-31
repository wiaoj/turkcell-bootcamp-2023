using homework5.Entities;

namespace homework5.Services.Abstracts;
public interface IStudentService {
    public void AddStudent(StudentEntity studentEntity);
    public void DeleteStudent(StudentEntity studentEntity);
    public void DeleteStudentById(Guid id);
    public void DeleteStudentById(String id);

    public IEnumerable<StudentEntity> GetAllStudents();
    public StudentEntity GetStudentById(String id);
    public IEnumerable<StudentEntity> GetStudentsByNameLastName(String nameLastName);
}