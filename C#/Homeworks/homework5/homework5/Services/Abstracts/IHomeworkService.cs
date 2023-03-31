using homework5.Entities;

namespace homework5.Services.Abstracts;
public interface IHomeworkService {
    public HomeworkEntity AddHomework(String classId, String homeworkName, String homeworkDescription);
    public void CompleteHomework(String homeworkId, String studentId, Int32 score);
}