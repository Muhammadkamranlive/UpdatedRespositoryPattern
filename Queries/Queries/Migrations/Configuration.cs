using Queries.Core.Domain;
using Queries.Persistence;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Queries.Migrations
{
    using Queries.Core.Domain;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LearningContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LearningContext context)
        {
            #region Add Tags
            var tags = new Dictionary<string, Tag>
            {
                {"c#", new Tag {Id = 1, Name = "c#"}},
                {"angularjs", new Tag {Id = 2, Name = "angularjs"}},
                {"javascript", new Tag {Id = 3, Name = "javascript"}},
                {"nodejs", new Tag {Id = 4, Name = "nodejs"}},
                {"oop", new Tag {Id = 5, Name = "oop"}},
                {"linq", new Tag {Id = 6, Name = "linq"}},
            };

            foreach (var tag in tags.Values)
                context.Tags.AddOrUpdate(t => t.Id, tag);
            #endregion

            #region Add Students
            var Students = new Dictionary<string, Student>
            {
                {"Muhammad", new Student {Id = 1, Name = "Muhammad"}},
                {"Ali", new Student {Id = 2, Name = "Ali"}},
                {"Hammad Ali", new Student {Id = 3, Name = "Hammad Ali"}},
                {"Saif", new Student {Id = 4, Name = "Saif"}},
                {"Adina", new Student {Id = 5, Name = "Adina"}},
                {"Tayeba", new Student {Id = 6, Name = "Tayeba"}},
            };

            foreach(var student in Students.Values)
            {
                context.Students.AddOrUpdate(t => t.Id, student);   
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
                    Id = 1,
                    Name = "Mosh Hamedani",
                    Students= new Collection<Student>()
                    {
                        Students["Muhammad"],
                        Students["Ali"]
                    },
                },
                new Teachers
                {
                    Id = 2,
                    Name = "Anthony Alicea",
                    Students= new Collection<Student>()
                    {
                       
                        Students["Ali"]
                    },
                },
                new Teachers
                {
                    Id = 3,
                    Name = "Eric Wise",
                    Students= new Collection<Student>()
                    {
                      
                        Students["Saif"]
                    },
                },
                new Teachers
                {
                    Id = 4,
                    Name = "Tom Owsiak",
                    Students= new Collection<Student>()
                    {
                        Students["Hammad Ali"],
                       
                    },
                },
                new Teachers
                {
                    Id = 5,
                    Name = "John Smith",
                    Students= new Collection<Student>()
                    {
                        Students["Adina"],
                        Students["Ali"]
                    },
                }
            };

            foreach (var author in authors)
                context.Teachers.AddOrUpdate(a => a.Id, author);
            #endregion

            #region Add Courses
            var courses = new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Name = "C# Basics",
                    Author = authors[0],
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
                    Id = 2,
                    Name = "C# Intermediate",
                    Author = authors[0],
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
                    Id = 3,
                    Name = "C# Advanced",
                    Author = authors[0],
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
                    Id = 4,
                    Name = "Javascript: Understanding the Weird Parts",
                    Author = authors[1],
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
                    Id = 5,
                    Name = "Learn and Understand AngularJS",
                    Author = authors[1],
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
                    Id = 6,
                    Name = "Learn and Understand NodeJS",
                    Author = authors[1],
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
                    Id = 7,
                    Name = "Programming for Complete Beginners",
                    Author = authors[2],
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
                    Id = 8,
                    Name = "A 16 Hour C# Course with Visual Studio 2013",
                    Author = authors[3],
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
                    Id = 9,
                    Name = "Learn JavaScript Through Visual Studio 2013",
                    Author = authors[3],
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
