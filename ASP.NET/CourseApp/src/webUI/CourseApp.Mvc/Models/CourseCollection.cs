using CourseApp.DataTransferObjects.Responses;
using CourseApp.Entities;

namespace CourseApp.Mvc.Models;
public class CourseCollection {
    public List<CourseItem> CourseItems { get; set; }

    public CourseCollection() {
        this.CourseItems = new();
    }

    public void ClearAll() => this.CourseItems.Clear();
    public Decimal TotalCoursePrice() => this.CourseItems.Sum(item => (Decimal)item.Course.Price * item.Quantity);
    public Int32 TotalCoursesCount() => this.CourseItems.Sum(item => item.Quantity);

    public void AddNewCourse(CourseItem courseItem) {
        var exists = this.CourseItems.FirstOrDefault(item => item.Course.Id == courseItem.Course.Id);

        if(exists is null) {
            this.CourseItems.Add(courseItem);
            return;
        }
        exists.Quantity += courseItem.Quantity;
    }
}

public class CourseItem {
    public CourseDisplayResponse Course { get; set; }
    public Int32 Quantity { get; set; }
    public Boolean ApplyCoupon { get; set; }
}