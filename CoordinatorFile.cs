using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS4396Solution
{
    public class CoordinatorFile
    {
        string fileName, comments;
        int fileId, portfolioId;
        DateTime submitDate;
        byte[] fileData;

        public int FileId
        {
            get { return fileId; }
            set { fileId = value; }
        }

        public int PortfolioId
        {
            get { return portfolioId; }
            set { portfolioId = value; }
        }

        public DateTime SubmitDate
        {
            get { return submitDate; }
            set { submitDate = value; }
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public byte[] FileData
        {
            get { return fileData; }
            set { fileData = value; }
        }
    }
}