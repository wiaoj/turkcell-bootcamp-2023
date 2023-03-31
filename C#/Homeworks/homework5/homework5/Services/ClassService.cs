using homework5.Entities;
using homework5.Repository.Abstracts;
using homework5.Services.Abstracts;

namespace homework5.Services;
public sealed class ClassService : IClassService {
    private readonly IClassWriteRepository classWriteRepository;
    private readonly IClassReadRepository classReadRepository;
    private readonly ITeacherReadRepository teacherReadRepository;

    public ClassService(IClassWriteRepository classWrireRepository,
                        IClassReadRepository classReadRepository,
                        ITeacherReadRepository teacherReadRepository) {
        this.classWriteRepository = classWrireRepository;
        this.classReadRepository = classReadRepository;
        this.teacherReadRepository = teacherReadRepository;
    }

    public void AddClass(ClassEntity classEntity) {
        if(this.classReadRepository.Any(classEntity.Id))
            throw new Exception("Bu sınıf zaten mevcut");

        this.classWriteRepository.Insert(classEntity);
    }

    public ClassEntity AddClass(String className, String teacherId) {
        TeacherEntity teacher = this.teacherReadRepository.GetById(teacherId);
        ArgumentNullException.ThrowIfNull(teacher);

        ClassEntity @class = new(className, teacher);
        teacher.SetClass(@class);
        this.classWriteRepository.Insert(@class);
        return @class;
    }

    public void DeleteClass(ClassEntity classEntity) {
        this.classWriteRepository.Delete(classEntity);
    }

    public void DeleteClassById(Guid id) {
        this.classWriteRepository.DeleteById(id);
    }

    public IEnumerable<ClassEntity> GetAllClasses() {
        return this.classReadRepository.GetAll();
    }

    public ClassEntity GetClassById(String id) {
        return this.classReadRepository.GetById(id);
    }

    public IEnumerable<ClassEntity> GetClassesByName(String name) {
        return this.classReadRepository
            .FindAll(
            student => $"{student.Name}".Contains(name, StringComparison.InvariantCultureIgnoreCase));
    }
}