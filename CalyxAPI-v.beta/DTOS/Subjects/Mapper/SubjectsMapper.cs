using CalyxAPI_v.beta.DTOS.Courses.Mapper;
using CalyxAPI_v.beta.DTOS.Subjects.Response;
using CalyxAPI_v.beta.Models;

namespace CalyxAPI_v.beta.DTOS.Subjects.Mapper;

public static class SubjectsMapper
{
    public static SubjectBasicResponse ToSubjectBasic(this Subject subject)
    {
        return new SubjectBasicResponse
        {
            SubjectName = subject.Name,
            Description = subject.Description
        };
    }

    public static SubjectCoursesResponse ToSubjectCourses(this Subject subject)
    {
        var subjectResponse = new SubjectCoursesResponse
        {
            SubjectName = subject.Name,
            Description = subject.Description
        };

        foreach (var course in subject.Courses)        
            subjectResponse.Courses.Add(course.ToCourseBasic());

        return subjectResponse;
    }

}
