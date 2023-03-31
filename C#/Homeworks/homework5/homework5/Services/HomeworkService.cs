using homework5.Entities;
using homework5.Repository.Abstracts;
using homework5.Services.Abstracts;

namespace homework5.Services;
public sealed class HomeworkService : IHomeworkService {
    private readonly IClassReadRepository classReadRepository;
    private readonly IStudentReadRepository studentReadRepository;
    private readonly IHomeworkWriteRepository homeworkWriteRepository;
    private readonly IHomeworkReadRepository homeworkReadRepository;

    public HomeworkService(IClassReadRepository classReadRepository,
                           IStudentReadRepository studentReadRepository,
                           IHomeworkWriteRepository homeworkWriteRepository,
                           IHomeworkReadRepository homeworkReadRepository) {
        this.classReadRepository = classReadRepository;
        this.studentReadRepository = studentReadRepository;
        this.homeworkWriteRepository = homeworkWriteRepository;
        this.homeworkReadRepository = homeworkReadRepository;
    }

    public HomeworkEntity AddHomework(String classId, String homeworkName, String homeworkDescription) {
        ClassEntity @class = this.classReadRepository.GetById(classId);

        HomeworkEntity homework = new(homeworkName, homeworkDescription);

        @class.AddHomework(homework);
        this.homeworkWriteRepository.Insert(homework);
        return homework;
    }

    public void CompleteHomework(String homeworkId, String studentId, Int32 score) {
        HomeworkEntity homework = this.homeworkReadRepository.GetById(homeworkId);
        StudentEntity student = this.studentReadRepository.GetById(studentId);
        homework.StudentCompletedHomework(student, score);
    }
}