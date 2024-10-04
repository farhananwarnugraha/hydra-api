using System;
using HydraAPI.Interfaces;

namespace HydraAPI.Courses;

public class CourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

}
