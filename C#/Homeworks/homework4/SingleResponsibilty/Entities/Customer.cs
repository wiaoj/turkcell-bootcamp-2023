namespace SingleResponsibilty.Entities;
public sealed class Customer : Entity {
    public String FirstName { get; private set; }
    public String LastName { get; private set; }

    public Customer() { } // for generic interfaces

    public Customer(String firstName, String lastName) {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}