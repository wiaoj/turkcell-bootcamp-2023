namespace CourseApp.API.Exceptions;
public class CourseNotIncludeParticipantException : Exception {
    private String message;
    public CourseNotIncludeParticipantException(String message) {
        this.message = message;
    }

    public CourseNotIncludeParticipantException() {
        this.message = "Bu kurs öğrenci içermiyor";
    }

    public override String Message => this.message;
}