using CalyxAPI_v.beta.Models;

using Microsoft.EntityFrameworkCore;

namespace CalyxAPI_v.beta.Data;

public partial class CalyxDbContext : DbContext
{
    public CalyxDbContext()
    {
    }

    public CalyxDbContext(DbContextOptions<CalyxDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamDetail> ExamDetails { get; set; }

    public virtual DbSet<IdentityType> IdentityTypes { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<PersonContact> PersonContacts { get; set; }

    public virtual DbSet<PersonIdentity> PersonIdentities { get; set; }

    public virtual DbSet<PersonLocation> PersonLocations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsMode> StudentsModes { get; set; }

    public virtual DbSet<StudentsStatus> StudentsStatuses { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectClass> SubjectClasses { get; set; }

    public virtual DbSet<SubjectClassStudent> SubjectClassStudents { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("courses");

            entity.HasIndex(e => e.Name, "UQ_courses_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("course_id");
            entity.Property(e => e.CourseYear).HasColumnName("course_year");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasMany(d => d.Subjects).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_subjects_TO_course_subjects"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_courses_TO_course_subjects"),
                    j =>
                    {
                        j.HasKey("CourseId", "SubjectId");
                        j.ToTable("course_subjects");
                        j.IndexerProperty<int>("CourseId").HasColumnName("course_id");
                        j.IndexerProperty<int>("SubjectId").HasColumnName("subject_id");
                    });
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.ToTable("exams", tb => tb.HasTrigger("valid_teacher_for_exam"));

            entity.HasIndex(e => new { e.SubjectId, e.TeacherId, e.Date }, "UQ_exams").IsUnique();

            entity.Property(e => e.Id).HasColumnName("exam_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Subject).WithMany(p => p.Exams)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subjects_TO_exams");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Exams)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_teachers_TO_exams");
        });

        modelBuilder.Entity<ExamDetail>(entity =>
        {
            entity.HasKey(e => e.ExamId);

            entity.ToTable("exam_details", tb => tb.HasTrigger("valid_student_for_exam"));

            entity.HasIndex(e => new { e.ExamId, e.StudentId }, "UQ_exam_details").IsUnique();

            entity.Property(e => e.ExamId)
                .ValueGeneratedNever()
                .HasColumnName("exam_id");
            entity.Property(e => e.Attendance)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("attendance");
            entity.Property(e => e.Grade)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("grade");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Exam).WithOne(p => p.ExamDetail)
                .HasForeignKey<ExamDetail>(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_exams_TO_exam_details");

            entity.HasOne(d => d.Student).WithMany(p => p.ExamDetails)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_students_TO_exam_details");
        });

        modelBuilder.Entity<IdentityType>(entity =>
        {
            entity.ToTable("identity_types");

            entity.Property(e => e.IdentityTypeId).HasColumnName("identity_type_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("short_description");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("persons");

            entity.Property(e => e.Id).HasColumnName("person_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<PersonContact>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.ToTable("person_contacts");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("person_id");
            entity.Property(e => e.CellphoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cellphone_number");
            entity.Property(e => e.PersonalNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("personal_number");
            entity.Property(e => e.PrimaryEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("primary_email");
            entity.Property(e => e.SecondaryEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("secondary_email");

            entity.HasOne(d => d.Person).WithOne(p => p.PersonContact)
                .HasForeignKey<PersonContact>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_persons_TO_person_contacts");
        });

        modelBuilder.Entity<PersonIdentity>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.ToTable("person_identities");

            entity.HasIndex(e => new { e.IdentityTypeId, e.IdentityNumber }, "UQ_person_identities").IsUnique();

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("person_id");
            entity.Property(e => e.IdentityNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("identity_number");
            entity.Property(e => e.IdentityTypeId).HasColumnName("identity_type_id");

            entity.HasOne(d => d.IdentityType).WithMany(p => p.PersonIdentities)
                .HasForeignKey(d => d.IdentityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_identity_types_TO_person_identities");

            entity.HasOne(d => d.Person).WithOne(p => p.PersonIdentity)
                .HasForeignKey<PersonIdentity>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_persons_TO_person_identities");
        });

        modelBuilder.Entity<PersonLocation>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.ToTable("person_locations");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("person_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.EstateId).HasColumnName("estate_id");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("postal_code");

            entity.HasOne(d => d.Person).WithOne(p => p.PersonLocation)
                .HasForeignKey<PersonLocation>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_persons_TO_person_locations");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("students", tb => tb.HasTrigger("students_cant_be_teachers"));

            entity.HasIndex(e => new { e.PersonId, e.CourseId }, "UQ_students").IsUnique();

            entity.Property(e => e.Id).HasColumnName("student_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Enabled).HasColumnName("enabled");
            entity.Property(e => e.Mode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mode");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_courses_TO_students");

            entity.HasOne(d => d.ModeNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Mode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_students_mode_TO_students");

            entity.HasOne(d => d.Person).WithMany(p => p.Students)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_persons_TO_students");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_students_status_TO_students");
        });

        modelBuilder.Entity<StudentsMode>(entity =>
        {
            entity.HasKey(e => e.Mode);

            entity.ToTable("students_mode");

            entity.Property(e => e.Mode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mode");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<StudentsStatus>(entity =>
        {
            entity.HasKey(e => e.Status);

            entity.ToTable("students_status");

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("subjects");

            entity.HasIndex(e => e.Name, "UQ_subjects_name").IsUnique();

            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SubjectClass>(entity =>
        {
            entity.HasKey(e => e.ClassId);

            entity.ToTable("subject_class", tb => tb.HasTrigger("valid_teacher_for_subject_class"));

            entity.HasIndex(e => new { e.Date, e.SubjectId, e.TeacherId }, "UQ_subject_class").IsUnique();

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectClasses)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subjects_TO_subject_class");

            entity.HasOne(d => d.Teacher).WithMany(p => p.SubjectClasses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_teachers_TO_subject_class");
        });

        modelBuilder.Entity<SubjectClassStudent>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.StudentId });

            entity.ToTable("subject_class_students", tb => tb.HasTrigger("valid_student_for_subject_class"));

            entity.HasIndex(e => new { e.ClassId, e.StudentId }, "UQ_subject_class_students").IsUnique();

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.Attendance)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("attendance");

            entity.HasOne(d => d.Class).WithMany(p => p.SubjectClassStudents)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subject_class_TO_subject_class_students");

            entity.HasOne(d => d.Student).WithMany(p => p.SubjectClassStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_students_TO_subject_class_students");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("teachers", tb => tb.HasTrigger("teachers_cant_be_students"));

            entity.HasIndex(e => new { e.PersonId, e.CourseId }, "UQ_teachers").IsUnique();

            entity.Property(e => e.Id).HasColumnName("teacher_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Enabled).HasColumnName("enabled");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Course).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_courses_TO_teachers");

            entity.HasOne(d => d.Person).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_persons_TO_teachers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
