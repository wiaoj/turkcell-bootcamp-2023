using CourseApp.Entities;

namespace CourseApp.Infrastructure.Data;
public static class DatabaseSeeding {
    public static void SeedDatabase(CourseDbContext context) {
        seedCategoryIfNotExists(context);
        seedCourseIfNotExists(context);
    }

    private static void seedCategoryIfNotExists(CourseDbContext context) {
        if(context.Categories.Any() is false) {
            List<Category> categories = new() {
                new() {
                    Name = "Yabancı Dil Kursları",
                    Description = "...."
                },
                new() {
                    Name = "Kişisel Gelişim Kursları",
                    Description = "...."
                },
                new() {
                    Name = "Yazılım Geliştirme Eğitimleri",
                    Description = "...."
                }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }

    private static void seedCourseIfNotExists(CourseDbContext context) {
        if(context.Courses.Any() is false) {
            List<Course> courses = new() {
                new() {
                    CategoryId = 1,
                    ImageUrl = "https://loremflickr.com/320/240",
                    Title = "İspanyolca",
                    Price = 10.72M,
                    Rating = 5,
                    TotalHours = 120
                },
                new() {
                    CategoryId = 2,
                    ImageUrl = "https://loremflickr.com/320/240",
                    Title = "Stres ile Mücadele",
                    Price = 50M,
                    Rating = 3,
                    TotalHours = 100
                },
                new() {
                    CategoryId = 3,
                    ImageUrl = "https://loremflickr.com/320/240",
                    Title = ".Net 7 Eğitimi",
                    Price = 120.12M,
                    Rating = 5,
                    TotalHours = 10
                }
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();
        }
    }
}