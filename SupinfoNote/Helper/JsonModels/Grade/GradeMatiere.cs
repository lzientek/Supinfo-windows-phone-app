using System.Collections.Generic;

namespace SupinfoNote.Helper.JsonModels
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