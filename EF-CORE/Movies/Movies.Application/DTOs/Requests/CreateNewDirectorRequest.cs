namespace Movies.Application.DTOs.Requests;
public class CreateNewDirectorRequest {
    public String Name { get; set; }
    public String LastName { get; set; }
    public String? Info { get; set; }
}