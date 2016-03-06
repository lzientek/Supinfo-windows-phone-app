using System.Collections.Generic;

namespace SupinfoNote.Uni10.Core.JsonModels.Grade
{
    public class GradePromo
    {
        public string Title { get; set; }
        public int Ects { get; set; }
        public int MaxEcts { get; set; }

        public List<GradeMatiere> Matieres { get; set; }
    }
}