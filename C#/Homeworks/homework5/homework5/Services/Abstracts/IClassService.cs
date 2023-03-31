using homework5.Entities;

namespace homework5.Services.Abstracts;
public interface IClassService {
    public void AddClass(ClassEntity classEntity);
    public ClassEntity AddClass(String className, String teacherId);
    public void DeleteClass(ClassEntity classEntity);
    public void DeleteClassById(Guid id);

    public IEnumerable<ClassEntity> GetAllClasses();

    public ClassEntity GetClassById(String id);
    public IEnumerable<ClassEntity> GetClassesByName(String name);
}