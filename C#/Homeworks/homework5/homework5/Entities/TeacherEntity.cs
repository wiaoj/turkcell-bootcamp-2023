using homework5.Entities.Base;

namespace homework5.Entities;
public sealed class TeacherEntity : Entity {
    public String Name { get; private set; }
    public String LastName { get; private set; }
    public ClassEntity? ClassEntity { get; private set; }

    public TeacherEntity() { } // for generic repository
    public TeacherEntity(String name, String lastName) {
        this.Name = name;
        this.LastName = lastName;
    }

    public void SetClass(ClassEntity classEntity) {
        if(this.ClassEntity is not null)
            throw new Exception("Eğitmen zaten bir sınıfa sahip");

        this.ClassEntity = classEntity;
    }

    public void DeleteClass() {
        this.ClassEntity = null;
    }

    public override String ToString() {
        String responsibleClass = this.ClassEntity is not null ? $"Sorumlu olduğu sınıf: {this.ClassEntity.Name}" : String.Empty;
        return $"{this.Name} {this.LastName} {responsibleClass}";
    }
}