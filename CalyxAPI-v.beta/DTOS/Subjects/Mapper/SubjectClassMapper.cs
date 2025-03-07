using CalyxAPI_v.beta.DTOS.Students.Mapper;
using CalyxAPI_v.beta.DTOS.Subjects.Response;
using CalyxAPI_v.beta.DTOS.Teachers.Mapper;
using CalyxAPI_v.beta.Models;

namespace CalyxAPI_v.beta.DTOS.Subjects.Mapper;

public static class SubjectClassMapper
{
    public static SubjectClassResponse ToSubjectClass(this SubjectClass subjectClass)
    {
        var teacherName = subjectClass.Teacher.GetFullNameIdentity();
        var subjectName = subjectClass.Subject.Name;

        var subjectClassResponse = new SubjectClassResponse
        {
            SubjectName = subjectName,
            TeacherName = teacherName,
            SubjectDate = subjectClass.Date
        };

        foreach (var student in subjectClass.SubjectClassStudents)
            subjectClassResponse.Students.Add(student.ToStudentSubjectClass());

        return subjectClassResponse;
    }
}
