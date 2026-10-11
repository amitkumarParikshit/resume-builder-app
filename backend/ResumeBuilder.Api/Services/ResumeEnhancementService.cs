using ResumeBuilder.Api.Models;

namespace ResumeBuilder.Api.Services;

public class ResumeEnhancementService
{
    public ResumeEnhancementResult EnhanceResume(ResumeDraft resume)
    {
        var summary = ImproveSummary(resume.Summary);
        var skills = resume.Skills.Select(UpgradeSkill).ToList();
        var highlights = resume.Experience.SelectMany(x => x.Achievements).Select(UpgradeAchievement).ToList();

        return new ResumeEnhancementResult
        {
            Summary = summary,
            Skills = skills,
            ExperienceHighlights = highlights,
            Message = "AI enhancement applied to the resume summary, skills, and achievements."
        };
    }

    private static string ImproveSummary(string original)
    {
        if (string.IsNullOrWhiteSpace(original))
        {
            return "Results-driven professional with strong communication, analytical thinking, and a proven record of delivering measurable business impact.";
        }

        return original
            .Replace("with", "bringing")
            .Replace("experience", "experience delivering measurable impact")
            .Replace("focused", "results-driven")
            .Replace("digital", "high-impact digital")
            .Trim();
    }

    private static string UpgradeSkill(string skill)
    {
        var normalized = skill.Trim();
        var map = new Dictionary<string, string>
        {
            { "Figma", "Figma + Design Systems" },
            { "UX Strategy", "UX Strategy & Research" },
            { "Product Thinking", "Product Strategy & Execution" },
            { "Communication", "Stakeholder Communication" }
        };

        return map.TryGetValue(normalized, out var replacement) ? replacement : normalized;
    }

    private static string UpgradeAchievement(string content)
    {
        var text = content.Trim();
        if (string.IsNullOrWhiteSpace(text))
        {
            return "Delivered high-impact outcomes that improved business efficiency and customer experience.";
        }

        if (!text.Contains("increased", StringComparison.OrdinalIgnoreCase) && !text.Contains("improved", StringComparison.OrdinalIgnoreCase))
        {
            return $"Improved business outcomes by {char.ToLowerInvariant(text[0])}{text.Substring(1)}";
        }

        return text;
    }
}