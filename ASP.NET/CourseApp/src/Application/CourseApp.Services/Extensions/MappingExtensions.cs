﻿using AutoMapper;
using CourseApp.DataTransferObjects.Responses;
using CourseApp.Entities;

namespace CourseApp.Services.Extensions;
public static class MappingExtensions {
    public static T ConvertToDto<T>(this IEnumerable<Course> courses, IMapper mapper) {
        return mapper.Map<T>(courses);
    }

    public static IEnumerable<CourseDisplayResponse> ConvertToDisplayResponses(this IEnumerable<Course> course, IMapper mapper) {
        return mapper.Map<IEnumerable<CourseDisplayResponse>>(course);
    }

    public static IEnumerable<CategoryDisplayResponse> ConvertToDto(this IEnumerable<Category> categories, IMapper mapper) {
        return mapper.Map<IEnumerable<CategoryDisplayResponse>>(categories);
    }
}