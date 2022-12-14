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
            var SingleCourse = unitOfWork.Courses.SingleOrDefault(c=>c.CourseTitle== "Learn JavaScript Through Visual Studio 2013");
            
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
                    {"Muhammad", new Student { Name = "Muhammad"}},
                    {"Ali", new Student {Name = "Ali"}},

                };
            foreach (var item in Students.Values)
            {
                unitOfWork.User.Add(item);
            }

            #endregion
            var Teacher = new Teachers()
            {


                Name= "Muhammad Shahid",
                Students = Students.Values,

            };
            unitOfWork.User.Add(Teacher);

            // Example4
            var teachers = unitOfWork.Teachers.GetAuthorWithCourses(1);
            //unitOfWork.Courses.RemoveRange(teachers.Courses);
            //unitOfWork.Teachers.Remove(teachers);



            unitOfWork.Save();
            Console.ReadKey();

        }
    }
}
