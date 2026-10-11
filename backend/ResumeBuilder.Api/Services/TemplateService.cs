using ResumeBuilder.Api.Models;

namespace ResumeBuilder.Api.Services;

public class TemplateService
{
    public List<ResumeTemplate> GetTemplates()
    {
        return new List<ResumeTemplate>
        {
            new()
            {
                Id = "classic",
                Name = "Classic Professional",
                Description = "Clean, traditional black-and-white format for formal roles.",
                Resume = new ResumeDraft
                {
                    TemplateId = "classic",
                    FullName = "Olivia Parker",
                    Title = "Project Manager",
                    Email = "olivia.parker@example.com",
                    Phone = "+1 (415) 980-4560",
                    Location = "San Francisco, CA",
                    LinkedIn = "linkedin.com/in/olivia-parker",
                    Summary = "Project manager with 7+ years of experience leading cross-functional teams and delivering business-critical initiatives on time and within budget.",
                    Skills = new List<string> { "Stakeholder Management", "Agile Delivery", "Risk Management", "Budget Planning", "Reporting" },
                    Experience = new List<WorkExperience>
                    {
                        new()
                        {
                            Company = "Summit Dynamics",
                            Role = "Senior Project Manager",
                            Period = "2021 - Present",
                            Achievements = new List<string>
                            {
                                "Led a portfolio of projects that improved operational efficiency by 28%.",
                                "Partnered with engineering, design, and business leaders to ship high-priority roadmap items."
                            }
                        },
                        new()
                        {
                            Company = "BluePeak Inc.",
                            Role = "Project Coordinator",
                            Period = "2018 - 2021",
                            Achievements = new List<string>
                            {
                                "Streamlined reporting workflows and reduced cycle time by 22%.",
                                "Coordinated launch schedules for multi-team product releases."
                            }
                        }
                    },
                    Education = new List<EducationEntry>
                    {
                        new()
                        {
                            Institution = "University of California, Berkeley",
                            Degree = "M.S. in Industrial Engineering",
                            Period = "2014 - 2018"
                        }
                    }
                }
            },
            new()
            {
                Id = "modern",
                Name = "Modern Executive",
                Description = "Strong visual format for leadership roles and growth-focused teams.",
                Resume = new ResumeDraft
                {
                    TemplateId = "modern",
                    FullName = "Daniel Nguyen",
                    Title = "VP of Engineering",
                    Email = "dan.nguyen@example.com",
                    Phone = "+1 (206) 451-8876",
                    Location = "Seattle, WA",
                    LinkedIn = "linkedin.com/in/daniel-nguyen",
                    Summary = "Executive technology leader with 12+ years of experience scaling distributed teams and building resilient digital platforms with measurable business impact.",
                    Skills = new List<string> { "Platform Strategy", "Cloud Architecture", "Leadership", "Delivery Excellence", "Innovation" },
                    Experience = new List<WorkExperience>
                    {
                        new()
                        {
                            Company = "Northstar Cloud",
                            Role = "VP of Engineering",
                            Period = "2020 - Present",
                            Achievements = new List<string>
                            {
                                "Scaled engineering operations to support 4x customer growth in under 18 months.",
                                "Built a robust platform roadmap to improve release quality and customer trust."
                            }
                        }
                    },
                    Education = new List<EducationEntry>
                    {
                        new()
                        {
                            Institution = "Massachusetts Institute of Technology",
                            Degree = "B.S. in Computer Science",
                            Period = "2007 - 2011"
                        }
                    }
                }
            },
            new()
            {
                Id = "creative",
                Name = "Creative Portfolio",
                Description = "Dynamic design-oriented resume for modern creative and product roles.",
                Resume = new ResumeDraft
                {
                    TemplateId = "creative",
                    FullName = "Aisha Brooks",
                    Title = "Senior UX Designer",
                    Email = "aisha.brooks@example.com",
                    Phone = "+1 (312) 554-1020",
                    Location = "Chicago, IL",
                    LinkedIn = "linkedin.com/in/aishabrooks",
                    Summary = "Creative UX designer crafting human-centered digital experiences for customer delight, business growth, and product clarity.",
                    Skills = new List<string> { "UX Research", "Design Systems", "Prototyping", "Wireframing", "Storytelling" },
                    Experience = new List<WorkExperience>
                    {
                        new()
                        {
                            Company = "Pixel Harbor",
                            Role = "Senior UX Designer",
                            Period = "2019 - Present",
                            Achievements = new List<string>
                            {
                                "Designed customer journeys that improved activation rates by 35%.",
                                "Created design system components used across 3 product lines and 12 teams."
                            }
                        }
                    },
                    Education = new List<EducationEntry>
                    {
                        new()
                        {
                            Institution = "School of the Art Institute of Chicago",
                            Degree = "B.A. in Visual Communication",
                            Period = "2011 - 2015"
                        }
                    }
                }
            }
        };
    }

    public ResumeDraft ApplyTemplate(string templateId)
    {
        var template = GetTemplates().FirstOrDefault(t => t.Id.Equals(templateId, StringComparison.OrdinalIgnoreCase));
        return template?.Resume ?? GetTemplates().First().Resume;
    }
}