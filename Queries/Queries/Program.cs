using Queries.Core.Domain;
using Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var unitOfWork = new UnitOfWork(new LearningContext());

            // by Expression Function
            var CousesByFind = unitOfWork.Courses.Find(a => a.Id == 1);

            // Find Single By Lambda Epression Tree 
            //var SingleCourse = unitOfWork.Courses.SingleOrDefault(a => a.Teacher.Name == "Mosh Hamedani");
            
            // Example1
            var course = unitOfWork.Courses.Get(1);
            Console.WriteLine(course.CourseTitle);
            Console.WriteLine("Updating");

            //Update
            course.CourseTitle = "New Updated Course Tag";
            unitOfWork.Save();

            // Example2
            var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);


            // Example 3

            #region Add Students
            var Students = new Dictionary<string, Student>
                {
                    {"Muhammad", new Student {Id = 1, Name = "Muhammad"}},
                    {"Ali", new Student {Id = 2, Name = "Ali"}},

                };

            #endregion
            //var Teacher = new Teachers()
            //{


            //    Tag = "Muhammad Shahid",
            //    Students = Students.Values,

            //};
            //unitOfWork.Teachers.Add(Teacher);

            // Example4
            //var teachers = unitOfWork.Teachers.GetAuthorWithCourses(1);
            //unitOfWork.Courses.RemoveRange(teachers.Courses);
            //unitOfWork.Teachers.Remove(teachers);
            unitOfWork.Save();
            Console.ReadKey();

        }
    }
}
