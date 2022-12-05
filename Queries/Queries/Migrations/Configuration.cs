namespace Queries.Migrations
{
    using Queries.Core.Domain;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Queries.Persistence.LearningContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Queries.Persistence.LearningContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            #region
            var Cover = new List<Cover>()
            {
                new Cover(){CoverTitle="Up Comming"},
                new Cover(){CoverTitle="Advanced Level"},
                new Cover(){CoverTitle="Top Rating"},
                new Cover(){CoverTitle="New"},
                new Cover(){CoverTitle="Updated"}
            };
            foreach (var item in Cover)
            {
                context.Covers.AddOrUpdate(c => c.Id, item);
            }
            #endregion
            #region Add Tags
            var tags = new Dictionary<string, Tag>
            {
                {"c#", new Tag {Id = 1, Title = "c#"}},
                {"angularjs", new Tag {Id = 2, Title = "angularjs"}},
                {"javascript", new Tag {Id = 3, Title = "javascript"}},
                {"nodejs", new Tag {Id = 4, Title = "nodejs"}},
                {"oop", new Tag {Id = 5, Title = "oop"}},
                {"linq", new Tag {Id = 6, Title = "linq"}},
            };

            foreach (var tag in tags.Values)
                context.Tags.AddOrUpdate(t => t.Id, tag);
            #endregion

            #region Add Students
            var Students = new Dictionary<string, Student>
            {
                {"Muhammad", new Student {Name = "Muhammad"}},
                {"Ali", new Student {Name = "Ali"}},
                {"Hammad Ali", new Student {Name = "Hammad Ali"}},
                {"Saif", new Student {Name = "Saif"}},
                {"Adina", new Student {Name = "Adina"}},
                {"Tayeba", new Student {Name = "Tayeba"}},
            };

            foreach (var student in Students.Values)
            {
                context.Users.AddOrUpdate(t => t.Id, student);
            }

            #endregion

            #region Add Categories
            var Categories = new List<Category>
            {
                new Category()
                {
                    Name="Web development"
                },
                 new Category()
                {
                    Name="Mobile development"
                },
                  new Category()
                {
                    Name="Desktop development"
                }
            };

            foreach (var category in Categories)
            {
                context.Categories.AddOrUpdate(c => c.Id, category);
            }
            #endregion

            #region Add Authors
            var authors = new List<Teachers>
            {
                new Teachers
                {

                    Name = "Mosh Hamedani",
                    Students= new Collection<Student>()
                    {
                        Students["Muhammad"],
                        Students["Ali"]
                    },
                },
                new Teachers
                {

                    Name = "Muhammad Shahid",
                    Students= new Collection<Student>()
                    {

                        Students["Ali"]
                    },
                },
                new Teachers
                {

                    Name = "Eric Wise",
                    Students= new Collection<Student>()
                    {

                        Students["Saif"]
                    },
                },
                new Teachers
                {

                    Name = "Muhammad Ahamd",
                    Students= new Collection<Student>()
                    {
                        Students["Hammad Ali"],

                    },
                },
                new Teachers
                {

                    Name = "Sara Masood",
                    Students= new Collection<Student>()
                    {
                        Students["Adina"],
                        Students["Ali"]
                    },
                }
            };

            foreach (var author in authors)
                context.Users.AddOrUpdate(a => a.Id, author);
            #endregion

            #region Add Courses
            var courses = new List<Course>
            {
                new Course
                {

                    CourseTitle = "C# Basics",
                    Cover= Cover[0],
                    Teacher = new Collection<Teachers>()
                    {
                        authors[0],
                        authors[1],
                    },
                    FullPrice = 49,
                    Description = "Description for C# Basics",
                    Level = 1,
                    Category = Categories[0],
                    Students= new Collection<Student>()
                    {
                        Students["Muhammad"]
                    },
                    Tags = new Collection<Tag>()
                    {
                        tags["c#"]
                    }
                },
                new Course
                {

                    CourseTitle = "C# Intermediate",
                    Cover=Cover[1],
                    Teacher = new Collection<Teachers>()
                    {
                        authors[2],
                        authors[1],
                    },
                    FullPrice = 49,
                    Description = "Description for C# Intermediate",
                    Level = 2,
                    Category = Categories[1],
                    Students= new Collection<Student>()
                    {
                        Students["Muhammad"]
                    },
                    Tags = new Collection<Tag>()
                    {
                        tags["c#"],
                        tags["oop"]
                    }
                },
                new Course
                {

                    CourseTitle = "C# Advanced",
                    Cover=Cover[2],
                    Teacher = new Collection<Teachers>()
                    {
                        authors[1],
                        authors[2]
                    },
                    Category = Categories[1],
                    FullPrice = 69,
                    Description = "Description for C# Advanced",
                    Level = 3,
                    Students= new Collection<Student>()
                    {
                        Students["Muhammad"]
                    },
                    Tags = new Collection<Tag>()
                    {
                        tags["c#"]
                    }
                },
                new Course
                {

                    CourseTitle = "Javascript: Understanding the Weird Parts",
                    Cover= Cover[3],
                    Teacher = new Collection<Teachers>()
                    {
                        authors[0],
                        authors[1]
                    },
                    FullPrice = 149,
                    Description = "Description for Javascript",
                    Level = 2,
                    Students=new Collection<Student>()
                    {
                        Students["Ali"]
                    },
                    Tags = new Collection<Tag>()
                    {
                        tags["javascript"]
                    }
                },
                new Course
                {

                    CourseTitle = "Learn and Understand AngularJS",
                    Cover= Cover[4],
                    Teacher = new Collection<Teachers>()
                    {
                        authors[0],
                        authors[1]
                    },
                    FullPrice = 99,
                    Description = "Description for AngularJS",
                    Level = 2,
                    Students=new Collection<Student>()
                    {
                        Students["Saif"]
                    }
                    ,
                    Tags = new Collection<Tag>()
                    {
                        tags["angularjs"]
                    }
                },
                new Course
                {

                    CourseTitle = "Learn and Understand NodeJS",
                    Cover=Cover[0],
                    Teacher = new Collection<Teachers>()
                    {
                        authors[0],
                        authors[2]
                    },
                    Category = Categories[2],
                    FullPrice = 149,
                    Description = "Description for NodeJS",
                    Level = 2,
                    Students=new Collection<Student>()
                    {
                        Students["Adina"]
                    }
                    ,
                    Tags = new Collection<Tag>()
                    {
                        tags["nodejs"]
                    }
                },
                new Course
                {

                    CourseTitle = "Programming for Complete Beginners",
                    Cover= Cover[4],
                    Teacher = new Collection<Teachers>()
                    {
                        authors[0],
                        authors[2]
                    },
                    Category = Categories[2],
                    FullPrice = 45,
                    Description = "Description for Programming for Beginners",
                    Level = 1,
                    Students=new Collection<Student>()
                    {
                        Students["Tayeba"]
                    },
                    Tags = new Collection<Tag>()
                    {
                        tags["c#"]
                    }
                },
                new Course
                {

                    Cover= Cover[4],
                    CourseTitle = "A 16 Hour C# Course with Visual Studio 2013",
                    Teacher = new Collection<Teachers>()
                    {
                        authors[1],
                        authors[2]
                    },
                    Category = Categories[0],
                    FullPrice = 150,
                    Description = "Description 16 Hour Course",
                    Level = 1,
                    Students= new Collection<Student>()
                    {
                        Students["Hammad Ali"]
                    },
                    Tags = new Collection<Tag>()
                    {
                        tags["c#"]
                    }
                },
                new Course
                {

                    Cover= Cover[3],
                    CourseTitle = "Learn JavaScript Through Visual Studio 2013",
                    Teacher = new Collection<Teachers>()
                    {
                        authors[2],
                        authors[1]
                    },
                    Category = Categories[0],
                    FullPrice = 20,
                    Description = "Description Learn Javascript",
                    Level = 1,
                    Students= new Collection<Student>()
                    {
                        Students["Hammad Ali"]
                    },
                    Tags = new Collection<Tag>()
                    {
                        tags["javascript"]
                    }
                }
            };

            foreach (var course in courses)
                context.Courses.AddOrUpdate(c => c.Id, course);
            #endregion
        }
    }
}
