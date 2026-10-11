using Microsoft.AspNetCore.Mvc;
using ResumeBuilder.Api.Models;
using ResumeBuilder.Api.Services;

namespace ResumeBuilder.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResumeController : ControllerBase
{
    private readonly ResumeEnhancementService _enhancementService;
    private readonly TemplateService _templateService;

    public ResumeController(ResumeEnhancementService enhancementService, TemplateService templateService)
    {
        _enhancementService = enhancementService;
        _templateService = templateService;
    }

    [HttpGet("templates")]
    public ActionResult<List<ResumeTemplate>> GetTemplates()
    {
        return Ok(_templateService.GetTemplates());
    }

    [HttpPost("build")]
    public ActionResult<ResumeDraft> BuildResume([FromBody] ResumeDraft draft)
    {
        return Ok(draft);
    }

    [HttpPost("import")]
    public ActionResult<ResumeDraft> ImportResume([FromBody] ResumeImportRequest request)
    {
        var resume = _templateService.ApplyTemplate(request.TemplateId);

        if (string.IsNullOrWhiteSpace(request.Text))
        {
            return Ok(resume);
        }

        var lines = request.Text
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();

        if (lines.Count == 0)
        {
            return Ok(resume);
        }

        resume.FullName = lines.FirstOrDefault() ?? resume.FullName;
        resume.Title = lines.Skip(1).FirstOrDefault() ?? resume.Title;
        resume.Summary = lines.Skip(2).FirstOrDefault() ?? resume.Summary;

        var skills = lines
            .Where(x => x.Contains("skill", StringComparison.OrdinalIgnoreCase) || x.Contains("tool", StringComparison.OrdinalIgnoreCase) || x.Contains("technology", StringComparison.OrdinalIgnoreCase))
            .SelectMany(x => x.Split(',', ';', '|'))
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();

        if (skills.Count > 0)
        {
            resume.Skills = skills.Take(8).ToList();
        }

        return Ok(resume);
    }

    [HttpPost("enhance")]
    public ActionResult<ResumeEnhancementResult> EnhanceResume([FromBody] ResumeEnhancementRequest request)
    {
        return Ok(_enhancementService.EnhanceResume(request.Resume));
    }

    [HttpGet("export-options")]
    public ActionResult<ExportOptions> GetExportOptions()
    {
        return Ok(new ExportOptions { Formats = new List<string> { "PDF", "DOCX" } });
    }
}
