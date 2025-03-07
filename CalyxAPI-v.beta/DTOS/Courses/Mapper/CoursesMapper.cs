using CalyxAPI_v.beta.DTOS.Courses.Response;
using CalyxAPI_v.beta.DTOS.Students.Mapper;
using CalyxAPI_v.beta.DTOS.Subjects.Mapper;
using CalyxAPI_v.beta.Models;

namespace CalyxAPI_v.beta.DTOS.Courses.Mapper;

public static class CoursesMapper
{
    public static CourseBasicResponse ToCourseBasic(this Course course)
    {
        return new CourseBasicResponse
        {
            CourseName = course.Name,
            Description = course.Description,
            CourseYear = course.CourseYear
        };
    }

    public static IEnumerable<CourseStudentsResponse> ToCourseStudents(this IEnumerable<Course> courses)
    {
        foreach (var course in courses)
            yield return course.ToCourseStudents();
    }

    public static CourseStudentsResponse ToCourseStudents(this Course course)
    {
        var courseResponse = new CourseStudentsResponse
        {
            CourseName = course.Name,
            CourseYear = course.CourseYear
        };

        foreach (var student in course.Students)
            courseResponse.Students.Add(student.ToStudentCourse(false));

        return courseResponse;
    }

    public static IEnumerable<CourseSubjectsResponse> ToCourseSubjects(this IEnumerable<Course> courses)
    {
        foreach (var course in courses)
            yield return course.ToCourseSubjects();
    }

    public static CourseSubjectsResponse ToCourseSubjects(this Course course)
    {
        var courseResponse = new CourseSubjectsResponse
        {
            CourseName = course.Name,
            CourseYear = course.CourseYear
        };

        foreach (var subject in course.Subjects)
            courseResponse.Subjects.Add(subject.ToSubjectBasic());

        return courseResponse;
    }
}
