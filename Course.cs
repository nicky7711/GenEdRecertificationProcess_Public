using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS4396Solution
{
    public class Course
    {
        string courseTitle, subjectCode, courseSubjectNumber, areaCode, courseNumber;
        int courseId, deptId;

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public string CourseNumber
        {
            get { return courseNumber; }
            set { courseNumber = value; }
        }

        public int DeptId
        {
            get { return deptId; }
            set { deptId = value; }
        }

        public string CourseTitle
        {
            get { return courseTitle; }
            set { courseTitle = value; }
        }

        public string SubjectCode
        {
            get { return subjectCode; }
            set { subjectCode = value; }
        }

        public string CourseSubjectNumber
        {
            get { return courseSubjectNumber; }
            set { courseSubjectNumber = value; }
        }

        public string AreaCode
        {
            get { return areaCode; }
            set { areaCode = value; }
        }
    }
}