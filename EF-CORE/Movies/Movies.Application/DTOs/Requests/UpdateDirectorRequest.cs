namespace Movies.Application.DTOs.Requests;
public class UpdateDirectorRequest {
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public String LastName { get; set; }
    public String? Info { get; set; }
}