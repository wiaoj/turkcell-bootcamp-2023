namespace Domain.Exceptions;
public sealed class QuestionNotFoundException : Exception {
    public QuestionNotFoundException() : base("Böyle bir soru bulunamadı") { }
}