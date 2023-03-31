using homework5.Entities;
using homework5.Repository.Abstracts;
using homework5.Services.Abstracts;

namespace homework5.Services;
public sealed class TeacherService : ITeacherService {
    private readonly ITeacherWriteRepository teacherWriteRepository;
    private readonly ITeacherReadRepository teacherReadRepository;

    public TeacherService(ITeacherWriteRepository teacherWriteRepository,
                          ITeacherReadRepository teacherReadRepository) {
        this.teacherWriteRepository = teacherWriteRepository;
        this.teacherReadRepository = teacherReadRepository;
    }

    public void AddTeacher(TeacherEntity teacherEntity) {
        if(this.teacherReadRepository.Any(teacherEntity.Id))
            throw new Exception("Bu eğitmen zaten mevcut");

        this.teacherWriteRepository.Insert(teacherEntity);
    }

    public void DeleteTeacher(TeacherEntity teacherEntity) {
        this.teacherWriteRepository.Delete(teacherEntity);
    }

    public void DeleteTeacherById(Guid id) {
        this.teacherWriteRepository.DeleteById(id);
    }

    public IEnumerable<TeacherEntity> GetAllTeachers() {
        return this.teacherReadRepository.GetAll();
    }

    public TeacherEntity GetTeacherById(String id) {
        return this.teacherReadRepository.GetById(id);
    }

    public IEnumerable<TeacherEntity> GetTeachersByNameLastName(String nameLastName) {
        return this.teacherReadRepository
            .FindAll(
            teacher => $"{teacher.Name} {teacher.LastName}".Contains(nameLastName, StringComparison.InvariantCultureIgnoreCase));
    }
}