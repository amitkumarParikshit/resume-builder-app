namespace ResumeBuilder.Api.Models;

public class ResumeDraft
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string TemplateId { get; set; } = "classic";
    public string FullName { get; set; } = "Jane Doe";
    public string Title { get; set; } = "Senior Product Designer";
    public string Email { get; set; } = "jane@example.com";
    public string Phone { get; set; } = "+1 (555) 123-4567";
    public string Location { get; set; } = "Seattle, WA";
    public string LinkedIn { get; set; } = "linkedin.com/in/janedoe";
    public string Summary { get; set; } = "Product-focused designer with 8+ years of experience building data-driven digital experiences.";
    public List<string> Skills { get; set; } = new()
    {
        "UX Strategy",
        "User Research",
        "Figma",
        "Design Systems",
        "Product Thinking"
    };
    public List<WorkExperience> Experience { get; set; } = new()
    {
        new WorkExperience
        {
            Company = "Northwind Labs",
            Role = "Senior Product Designer",
            Period = "2021 - Present",
            Achievements = new List<string>
            {
                "Led a redesign that improved user task completion by 31%.",
                "Built design systems that reduced design handoff time by 40%."
            }
        }
    };
    public List<EducationEntry> Education { get; set; } = new()
    {
        new EducationEntry
        {
            Institution = "University of Washington",
            Degree = "B.A. in Human Centered Design",
            Period = "2014 - 2018"
        }
    };
}

public class WorkExperience
{
    public string Company { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;
    public List<string> Achievements { get; set; } = new();
}

public class EducationEntry
{
    public string Institution { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;
}

public class ResumeTemplate
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ResumeDraft Resume { get; set; } = new();
}

public class ResumeImportRequest
{
    public string TemplateId { get; set; } = "classic";
    public string? Text { get; set; }
}

public class ResumeEnhancementRequest
{
    public ResumeDraft Resume { get; set; } = new();
}

public class ResumeEnhancementResult
{
    public string Summary { get; set; } = string.Empty;
    public List<string> Skills { get; set; } = new();
    public List<string> ExperienceHighlights { get; set; } = new();
    public string Message { get; set; } = "Content improved for impact and clarity.";
}

public class ExportOptions
{
    public List<string> Formats { get; set; } = new();
}