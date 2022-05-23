namespace Exam.Domain;

public class Quote
{
    public int Id { get; set; }
    public string? QuoteName { get; set; }
    public string? CategoryName { get; set; }
    public string? Author { get; set; }
}

public class UIQuote{
    public int Id { get; set; }
    public string? QuoteName { get; set; }
    public int CategoryId { get; set; }
    public string? Author { get; set; }
}
