using homework5.Entities;

namespace homework5.Services.Abstracts;
public interface ITeacherService {
    public void AddTeacher(TeacherEntity teacherEntity);
    public void DeleteTeacher(TeacherEntity teacherEntity);
    public void DeleteTeacherById(Guid id);

    public IEnumerable<TeacherEntity> GetAllTeachers();

    public TeacherEntity GetTeacherById(String id);
    public IEnumerable<TeacherEntity> GetTeachersByNameLastName(String nameLastName);
}