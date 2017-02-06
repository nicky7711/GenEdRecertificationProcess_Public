using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS4396Solution
{
    public class Package
    {
        int packageId, deptId, academicYrId, courseId, contactId, statusCode;
        DateTime dueDate;
        string areaCode;

        public int PackageId
        {
            get { return packageId; }
            set { packageId = value; }
        }

        public int DeptId
        {
            get { return deptId; }
            set { deptId = value; }
        }

        public int AcademicYrId
        {
            get { return academicYrId; }
            set { academicYrId = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public int ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public int StatusCode
        {
            get { return statusCode; }
            set { statusCode = value; }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public string AreaCode
        {
            get { return areaCode; }
            set { areaCode = value; }
        }
    }
}