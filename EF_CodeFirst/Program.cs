using System;
using System.Data.Entity;
using System.Linq;
using EF_CodeFirst.Infra;

namespace EF_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing the database and populating seed data using DropCreateDatabaseIfModelChanges initializer
            (new DropCreateDBOnModelChanged()).InitializeDatabase(new SchoolContext());
            Console.WriteLine("Listando os cursos.");
            using (var context = new SchoolContext())
            {
                var courses = (from cursos in context.Courses
                               select cursos);

                foreach (var curso in courses)
                {
                    Console.WriteLine("Nome do curso: {0}.", curso.Name);

                    foreach (var student in curso.Students)
                    {
                        Console.WriteLine("Nome do estudante: {0}.", student.Name);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
