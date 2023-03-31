using homework5.Entities.Base;

namespace homework5.Entities;
public sealed class ClassEntity : Entity {
    public String Name { get; private set; }
    public List<StudentEntity> Students { get; private set; }
    public TeacherEntity Teacher { get; private set; }
    public List<HomeworkEntity> Homeworks { get; private set; }

    public ClassEntity() { } // for generic repository interface

    public ClassEntity(String name, TeacherEntity teacher) {
        this.Name = name;
        this.Teacher = teacher;
        this.Students = new();
        this.Homeworks = new() { new("Test", "Bu bir deneme ödevidir") };
    }

    public void SetTeacher(TeacherEntity teacher) {
        ArgumentNullException.ThrowIfNull(teacher, $"{nameof(teacher)} boş olamaz");
        this.Teacher = teacher;
    }

    public void AddStudent(StudentEntity student) {
        // Check student class
        this.Students.ForEach(x => {
            if(x.Id == student.Id) {
                throw new Exception("Bu sınıfta böyle bir öğrenci mevcut");
            }
        });
        this.Students.Add(student);
    }

    public void AddStudent(IEnumerable<StudentEntity> students) {
        this.Students.AddRange(students);
    }

    public void AddHomework(HomeworkEntity homework) {
        this.Homeworks.Add(homework);
    }

    public override String ToString() {
        this.PrintConsole();
        return String.Empty;
    }

    public void PrintConsole() {
        String line = new('-', 20);
        Console.WriteLine(line);
        Console.WriteLine($"Sınıf: {this.Name} - Sorumlu: {this.Teacher}");
        //Console.WriteLine($"Öğrenci Sayısı - {this.Students.Count} ## Ödev Sayısı - {this.Homeworks.Count}");

        this.PrintStudents();
        this.PrintHomeworks();

        Console.WriteLine(line);
    }

    public void PrintStudents() {
        if(this.Students.Count is default(Int32)) {
            Console.WriteLine("Sınıfta öğrenci bulunmamaktadır.");
            return;
        }

        Console.WriteLine($"Öğrenci Sayısı - {this.Students.Count}");
        this.Students.ForEach(student => {
            Boolean isStudentCompletedAllHomework = this.Homeworks.Count is not default(Int32) && student.CompletedHomeworkCount == this.Homeworks.Count;
            if(isStudentCompletedAllHomework)
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\t {student.StudentWithCompletedHomework}/{this.Homeworks.Count}");
            //Console.ForegroundColor = ConsoleColor.White;
            Console.ResetColor();
        });
    }

    public void PrintHomeworks() {
        Console.ForegroundColor = ConsoleColor.Blue;
        if(this.Homeworks.Count is default(Int32)) {
            Console.WriteLine("Sınıfa verilen herhangi bir ödev yok.");
            return;
        }

        Console.WriteLine($"Ödev Sayısı - {this.Homeworks.Count}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        this.Homeworks.ForEach(homework => Console.WriteLine($"\t {homework}"));
        Console.ResetColor();
    }
}