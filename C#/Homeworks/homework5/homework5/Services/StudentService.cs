using homework5.Entities;
using homework5.Repository.Abstracts;
using homework5.Services.Abstracts;

namespace homework5.Services;
public sealed class StudentService : IStudentService {
    private readonly IStudentWriteRepository studentWriteRepository;
    private readonly IStudentReadRepository studentReadRepository;

    public StudentService(IStudentWriteRepository studentWriteRepository,
                          IStudentReadRepository studentReadRepository) {
        this.studentWriteRepository = studentWriteRepository;
        this.studentReadRepository = studentReadRepository;
    }

    public void AddStudent(StudentEntity studentEntity) {
        if(this.studentReadRepository.Any(studentEntity.Id))
            throw new Exception("Bu öğrenci zaten mevcut");

        this.studentWriteRepository.Insert(studentEntity);
    }

    public void DeleteStudent(StudentEntity studentEntity) {
        this.studentWriteRepository.Delete(studentEntity);
    }

    public void DeleteStudentById(Guid id) {
        this.studentWriteRepository.DeleteById(id);
    }

    public void DeleteStudentById(String id) {
        this.studentWriteRepository.DeleteById(id);
    }

    public IEnumerable<StudentEntity> GetAllStudents() {
        return this.studentReadRepository.GetAll();
    }

    public StudentEntity GetStudentById(String id) {
        return this.studentReadRepository.GetById(id);
    }

    public IEnumerable<StudentEntity> GetStudentsByNameLastName(String nameLastName) {
        return this.studentReadRepository
            .FindAll(
            student => $"{student.Name} {student.LastName}".Contains(nameLastName, StringComparison.InvariantCultureIgnoreCase));
    }
}