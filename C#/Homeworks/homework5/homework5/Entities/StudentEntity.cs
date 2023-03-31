using homework5.Entities.Base;

namespace homework5.Entities;
public sealed class StudentEntity : Entity {
    public String Name { get; private set; }
    public String LastName { get; private set; }
    public Int32 CompletedHomeworkCount { get; private set; }
    public ClassEntity? StudentClass { get; private set; }

    public StudentEntity() { } // for generic repository

    public StudentEntity(String name, String lastName) {
        this.Name = name;
        this.LastName = lastName;
        this.StudentClass = null;
    }

    public void SetClass(ClassEntity studentClass) {
        ArgumentNullException.ThrowIfNull(studentClass);
        this.StudentClass = studentClass;
    }

    public void IncreaseCompletedHomework() {
        this.CompletedHomeworkCount++;
    }

    public override String ToString() {
        String studentClassName = this.StudentClass is null ? "####" : this.StudentClass.Name;
        return $"{studentClassName} - {this.ShortId} - {this.Name} {this.LastName}";
    }

    public String StudentWithCompletedHomework
        => $"{this.ShortId} - {this.Name} {this.LastName} Tamamlanan Ödev Sayısı: {this.CompletedHomeworkCount}";
}