using homework5.Entities.Base;

namespace homework5.Entities;
public sealed class HomeworkEntity : Entity {
    public String Name { get; private set; }
    public String Description { get; private set; }

    public List<Dictionary<StudentEntity, Int32>> StudentsWithGrades { get; private set; }
    public HomeworkEntity() { }

    public HomeworkEntity(String name, String description) {
        this.Name = name;
        this.Description = description;
        this.StudentsWithGrades = new();
    }

    public void StudentCompletedHomework(StudentEntity student, Int32 homeworkPoint) {
        this.StudentsWithGrades.Add(new() {
            { student, homeworkPoint }
        });
        student.IncreaseCompletedHomework();
    }

    public override String ToString() {
        return $"{this.Id} - {this.Name} : {this.SetDescription()} #Tamamlayan öğrenci sayısı {this.StudentsWithGrades.Count}";
    }

    private String SetDescription() {
        return this.Description.Length > 32
             ? $"{this.Description[..29]}..."
             : this.Description;
    }
}