using CalyxAPI_v.beta.DTOS.Students.Response;
using CalyxAPI_v.beta.DTOS.Persons.Mapper;  
using CalyxAPI_v.beta.Models;

namespace CalyxAPI_v.beta.DTOS.Students.Mapper;

public static class StudentsMapper
{
    public static StudentCourseResponse ToStudentCourse(this Student student, bool navigationProperties = true)
    {
        if (student is null) return null!;

        var personIdentity = student.Person.PersonIdentity;

        return new StudentCourseResponse
        {
            Name = student.Person.FullName,
            Identity = $"{personIdentity?.IdentityType.ShortDescription ?? string.Empty} {personIdentity?.IdentityNumber ?? string.Empty}",
            CourseName = student.Course.Name,
            CourseYear = student.Course.CourseYear,
            Mode = navigationProperties ? student.ModeNavigation.Description : student.Mode,
            Status = navigationProperties ? student.StatusNavigation.Description : student.Status,
            Enabled = student.Enabled
        };
    }

    public static StudentSubjectClassResponse ToStudentSubjectClass(this SubjectClassStudent student)
    {
        return new StudentSubjectClassResponse
        {
            StudentName = student.Student.GetFullNameIdentity(),
            Attendance = student.Attendance
        };
    }

    public static string GetIdentity(this Student student) => student.Person.GetIdentity();
    public static string GetFullNameIdentity(this Student student) => student.Person.GetFullNameIdentity();
}
