using System.Collections.Generic;

namespace SupinfoNote.Helper.JsonModels
{
    public class GradePromo
    {
        public string Title { get; set; }
        public int Ects { get; set; }
        public int MaxEcts { get; set; }

        public List<GradeMatiere> Matieres { get; set; }
    }
}