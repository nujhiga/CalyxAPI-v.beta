using CalyxAPI_v.beta.DTOS.Persons.Mapper;
using CalyxAPI_v.beta.DTOS.Teachers.Response;
using CalyxAPI_v.beta.Models;

namespace CalyxAPI_v.beta.DTOS.Teachers.Mapper;

public static class TeachersMapper
{

    public static TeacherBasicResponse ToTeacherBasic(this Teacher teacher)
    {
        var personIdentity = teacher.Person.PersonIdentity;
        return new TeacherBasicResponse
        {
            Name = teacher.Person.FullName,
            Identity = $"{personIdentity?.IdentityType.ShortDescription ?? string.Empty} {personIdentity?.IdentityNumber ?? string.Empty}",
            Enabled = teacher.Enabled
        };
    }

    public static TeacherCourseResponse ToTeacherCourse(this Teacher student)
    {
        var personIdentity = student.Person.PersonIdentity;

        return new TeacherCourseResponse
        {
            Name = student.Person.FullName,
            Identity = $"{personIdentity?.IdentityType.ShortDescription ?? string.Empty} {personIdentity?.IdentityNumber ?? string.Empty}",
            CourseName = student.Course.Name,
            CourseYear = student.Course.CourseYear,
            Enabled = student.Enabled
        };
    }

    public static string GetIdentity(this Teacher teacher) => teacher.Person.GetIdentity();
    public static string GetFullNameIdentity(this Teacher teacher) => teacher.Person.GetFullNameIdentity();

}
