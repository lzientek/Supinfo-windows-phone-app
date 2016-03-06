using System.Collections.Generic;

namespace SupinfoNote.Uni10.Core.JsonModels.Grade
{
    public class GradeMatiere
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int Ects { get; set; }
        public bool Status { get; set; }

        public List<GradeEval> GradeEvals { get; set; }
    }
}