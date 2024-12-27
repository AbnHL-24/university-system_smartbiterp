using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using UniversitySystem.Domain.Models;
using UniversitySystem.Domain.Models.Course;
using UniversitySystem.Domain.Repositories;
using UniversitySystem.Domain.Services;

namespace UniversitySystem.Application.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    public async Task<IEnumerable<CourseModel>> GetCoursesAsync()
    {
        return await courseRepository.GetCoursesAsync();
    }
    
    public async Task<IEnumerable<AssignedCourse>> GetCoursesByStudentAsync(int studentCode)
    {
        return await courseRepository.GetCoursesByStudentAsync(studentCode);
    }

    public async Task<MemoryStream> GeneratePDF(IEnumerable<AssignedCourse> assignedCourses, int studentCode, string studentName)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(document =>
        {
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Purple.Medium);
            document.Page(page =>
            {
                page.Size(PageSizes.Letter.Portrait());
                page.Margin(30);
                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(column =>
                    {
                        column.Item().Text("Constancia de cursos").Style(titleStyle);

                        column.Item().Text(text =>
                        {
                            text.Span("Codigo Estudiante: ").SemiBold();
                            text.Span(studentCode.ToString());
                        });
                        
                        column.Item().Text(text =>
                        {
                            text.Span("Nombre Estudiante: ").SemiBold();
                            text.Span(studentName);
                        });

                        column.Item().Text(text =>
                        {
                            text.Span("Fecha impresión: ").SemiBold();
                            text.Span($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                        });
                    });

                });
                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });
            
                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Codigo");
                        header.Cell().Element(CellStyle).Text("Nombre");
                        header.Cell().Element(CellStyle).AlignCenter().Text("Año");
                        header.Cell().Element(CellStyle).AlignCenter().Text("Semestre");
                        header.Cell().Element(CellStyle).AlignCenter().Text("Nota");
                
                        static IContainer CellStyle(IContainer container)
                        {
                            return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                        }
                    });
            
                    foreach (var item in assignedCourses)
                    {
                        table.Cell().Element(CellStyle).Text(item.CourseCode.ToString());
                        table.Cell().Element(CellStyle).Text(item.CourseName);
                        table.Cell().Element(CellStyle).AlignRight().Text(item.Year.ToString());
                        table.Cell().Element(CellStyle).AlignRight().Text(item.Semester.ToString());
                        table.Cell().Element(CellStyle).AlignRight().Text(item.Grade.ToString());
                
                        static IContainer CellStyle(IContainer container)
                        {
                            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                        }
                    }
                });

                page.Footer().AlignCenter().Text(text =>
                {
                    text.CurrentPageNumber();
                    text.Span(" / ");
                    text.TotalPages();
                });
            });
        });
        
        return new MemoryStream(document.GeneratePdf());
    }

    public async Task<CourseModel?> GetCourseAsync(int courseCode)
    {
        return await courseRepository.GetCourseAsync(courseCode);
    }

    public async Task AddCourseAsync(CourseModel courseModel)
    {
        await courseRepository.AddCourseAsync(courseModel);
    }

    public async Task UpdateCourseAsync(CourseModel courseModel)
    {
        await courseRepository.UpdateCourseAsync(courseModel);
    }

    public async Task DeleteCourseAsync(int courseCode)
    {
        await courseRepository.DeleteCourseAsync(courseCode);
    }
}