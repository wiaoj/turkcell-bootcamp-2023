using homework5.Repository.Abstracts;
using homework5.Repository.Concretes;
using homework5.Services;
using homework5.Services.Abstracts;

namespace homework5;
public sealed class DependencyInjection {
    private static ITeacherWriteRepository teacherWriteRepository => new TeacherWriteRepository();
    private static ITeacherReadRepository teacherReadRepository => new TeacherReadRepository();
    internal static ITeacherService TeacherService => new TeacherService(teacherWriteRepository, teacherReadRepository);

    private static IClassWriteRepository classWriteRepository => new ClassWriteRepository();
    private static IClassReadRepository classReadRepository => new ClassReadRepository();
    internal static IClassService ClassService => new ClassService(classWriteRepository, classReadRepository, teacherReadRepository);

    private static IStudentWriteRepository studentWriteRepository => new StudentWriteRepository();
    private static IStudentReadRepository studentReadRepository => new StudentReadRepository();
    internal static IStudentService StudentService => new StudentService(studentWriteRepository, studentReadRepository);

    private static IHomeworkWriteRepository homeworkWriteRepository => new HomeworkWriteRepository();
    private static IHomeworkReadRepository homeworkReadRepository => new HomeworkReadRepository();
    internal static IHomeworkService HomeworkService => new HomeworkService(classReadRepository, studentReadRepository, homeworkWriteRepository, homeworkReadRepository);
}