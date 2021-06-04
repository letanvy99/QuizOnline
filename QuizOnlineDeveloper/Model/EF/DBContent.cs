namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContent : DbContext
    {
        public DBContent()
            : base("name=DBContent1")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Class_Exams> Class_Exams { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Exam_Questions> Exam_Questions { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<User_Categories> User_Categories { get; set; }
        public virtual DbSet<User_Class> User_Class { get; set; }
        public virtual DbSet<User_Class_Exams> User_Class_Exams { get; set; }
        public virtual DbSet<User_Question_Answers> User_Question_Answers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Exams)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.ExamCategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.User_Categories)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class_Exams>()
                .HasMany(e => e.User_Class_Exams)
                .WithRequired(e => e.Class_Exams)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Class_Exams)
                .WithRequired(e => e.Class)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.User_Class)
                .WithRequired(e => e.Class)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.AcceptCode)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .HasMany(e => e.Class_Exams)
                .WithRequired(e => e.Exam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exam>()
                .HasMany(e => e.Exam_Questions)
                .WithRequired(e => e.Exam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Media)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Exam_Questions)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.User_Question_Answers)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_Class_Exams>()
                .Property(e => e.MaxPoint)
                .HasPrecision(4, 2);

            modelBuilder.Entity<User_Class_Exams>()
                .HasMany(e => e.User_Question_Answers)
                .WithRequired(e => e.User_Class_Exams)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_Question_Answers>()
                .Property(e => e.AnswerID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User_Categories)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User_Class)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User_Class_Exams)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
