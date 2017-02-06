using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS4396Solution
{
    public class Portfolio
    {
        string comments, contactId, areaCd;
        int portfolioId, coursePortfolioId, packageId, courseId;
        DateTime submitDate;
        Questionnaire questionnaire;

        public Questionnaire Questionnaire
        {
            get { return questionnaire; }
            set { questionnaire = value; }
        }
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public string ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public string AreaCD
        {
            get { return areaCd; }
            set { areaCd = value; }
        }

        public int PortfolioId
        {
            get { return portfolioId; }
            set { portfolioId = value; }
        }

        public int CoursePortfolioId
        {
            get { return coursePortfolioId; }
            set { coursePortfolioId = value; }
        }

        public int PackageId
        {
            get { return packageId; }
            set { packageId = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public DateTime SubmitDate
        {
            get { return submitDate; }
            set { submitDate = value; }
        }
    }
}