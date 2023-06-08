using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.API.Filters;
public class IsExistsAttribute : TypeFilterAttribute {
    public IsExistsAttribute() : base(typeof(IsExistsFilter)) { }
}