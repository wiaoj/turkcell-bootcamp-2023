using homework5;
using homework5.Menu;
using homework5.Services.Abstracts;

internal sealed class Program {
    private static void Main(String[] args) {

        IClassService classService = DependencyInjection.ClassService;
        ITeacherService teacherService = DependencyInjection.TeacherService;
        IStudentService studentService = DependencyInjection.StudentService;
        IHomeworkService homeworkService = DependencyInjection.HomeworkService;

        //TeacherEntity teacher1 = new("Öğretmen 1", "Soyisim");
        //TeacherEntity teacher2 = new("Öğretmen 2", "Soyisim");
        //TeacherEntity teacher3 = new("Öğretmen 3", "Soyisim");

        //teacherService.AddTeacher(teacher1);
        //teacherService.AddTeacher(teacher2);
        //teacherService.AddTeacher(teacher3);

        //ClassEntity classEntity = new("Sınıf 1", teacher2);
        //classEntity.AddStudent(studentService.GetAllStudents());
        //classService.AddClass(classEntity);

        //Random random = new();
        //for(Int32 index = default; index < 30; index++) {
        //    StudentEntity student = new(random.NextName(), random.NextName());
        //    student.SetClass(classEntity);
        //    studentService.AddStudent(student);
        //}



        Menu menu = Menu.Create(studentService, teacherService, classService, homeworkService);
        Boolean isQuit = default;

        while(isQuit is default(Boolean)) {
            try {

                menu.Print(ref isQuit);

            } catch(Exception exception) {
                Console.WriteLine(exception.Message);
                Console.ResetColor();
            }
        }
    }
}