using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SupinfoNote.Helper.JsonModels
{
    public static class Grades
    {
        public static List<GradePromo> GetGrades(string json)
        {
            var lst = new List<GradePromo>();
            JObject jObject = JObject.Parse(json);
            var array = jObject["response"].AsJEnumerable();
            foreach (var gradePromo in array)
            {
                var gradeP = new GradePromo
                {
                    Ects = (int) gradePromo["ects"],
                    Title = (string)gradePromo["title"],
                    MaxEcts = (int)gradePromo["max_ects"],
                    Matieres = new List<GradeMatiere>()
                };
                var gradeMatieres = gradePromo["subjects"].AsJEnumerable();
                foreach (var gradeMatiere in gradeMatieres)
                {
                    GradeMatiere matiere = ExtractGradeMatiere(gradeMatiere);
                    gradeP.Matieres.Add(matiere);
                }

                lst.Add(gradeP);
            }
            return lst;
        }

        private static GradeMatiere ExtractGradeMatiere(JToken gradeMatiere)
        {
            var matiere = new GradeMatiere()
            {
                Code = (string)gradeMatiere["code"],
                Title = (string)gradeMatiere["title"],
                Ects = (int)gradeMatiere["ects"],
                Status = (bool)gradeMatiere["status"],
                GradeEvals = new List<GradeEval>()
            };
            var gradesEvals = gradeMatiere["items"].AsJEnumerable();
            foreach (var gradesEval in gradesEvals)
            {
                matiere.GradeEvals.Add(new GradeEval()
                {
                    Title = (string)gradesEval["title"],
                    Grade = (double)gradesEval["grade"],
                });
            }

            return matiere;
        }
    }
}
