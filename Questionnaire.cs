using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS4396Solution
{
    [Serializable]
    public class Questionnaire
    {
        string userId = "tud12345", question1 = "No answer", question2 = "No answer", question3 = "No answer", question4 = "No answer", question5 = "No answer", question6 = "No answer", question7 = "No answer",
            question8 = "No answer", question9 = "No answer", question10 = "No answer", question11 = "No answer", question12 = "No answer", question13 = "No answer", question14 = "No answer",
            question18 = "No answer", question22 = "No answer", question30 = "No answer", question31 = "No answer", question32 = "No answer";
        bool question15 = false, question16 = false, question17 = false, question19 = false, question20 = false, question21 = false, question23 = false, question24 = false, question25 = false,
            question26 = false, question27 = false, question28 = false, question29 = false;

        public string UserId
        { get { return userId; } set { userId = value; } }

        public string Question1
        {get { return question1; }set { question1 = value; }}

        public string Question2
        { get { return question2; } set { question2 = value; } }

        public string Question3
        { get { return question3; } set { question3 = value; } }

        public string Question4
        { get { return question4; } set { question4 = value; } }

        public string Question5
        { get { return question5; } set { question5 = value; } }

        public string Question6
        { get { return question6; } set { question6 = value; } }

        public string Question7
        { get { return question7; } set { question7 = value; } }

        public string Question8
        { get { return question8; } set { question8 = value; } }

        public string Question9
        { get { return question9; } set { question9 = value; } }

        public string Question10
        { get { return question10; } set { question10 = value; } }

        public string Question11
        { get { return question11; } set { question11 = value; } }

        public string Question12
        { get { return question12; } set { question12 = value; } }

        public string Question13
        { get { return question13; } set { question13 = value; } }

        public string Question14
        { get { return question14; } set { question14 = value; } }

        public bool Question15
        { get { return question15; } set { question15 = value; } }

        public bool Question16
        { get { return question16; } set { question16 = value; } }

        public bool Question17
        { get { return question17; } set { question17 = value; } }

        public string Question18
        { get { return question18; } set { question18 = value; } }

        public bool Question19
        { get { return question19; } set { question19 = value; } }

        public bool Question20
        { get { return question20; } set { question20 = value; } }

        public bool Question21
        { get { return question21; } set { question21 = value; } }

        public string Question22
        { get { return question22; } set { question22 = value; } }

        public bool Question23
        { get { return question23; } set { question23 = value; } }

        public bool Question24
        { get { return question25; } set { question24 = value; } }

        public bool Question25
        { get { return question25; } set { question25 = value; } }

        public bool Question26
        { get { return question26; } set { question26 = value; } }

        public bool Question27
        { get { return question27; } set { question27 = value; } }

        public bool Question28
        { get { return question28; } set { question28 = value; } }

        public bool Question29
        { get { return question29; } set { question29 = value; } }

        public string Question30
        { get { return question30; } set { question30 = value; } }

        public string Question31
        { get { return question31; } set { question31 = value; } }

        public string Question32
        { get { return question32; } set { question32 = value; } }
    }
}