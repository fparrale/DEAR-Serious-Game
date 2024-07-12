using System.Collections.Generic;
using System.IO;
using Code.Requirements.Model;

namespace Code.Requirements.UseCases
{
    public class RequirementProvider
    {
        public List<Requirement> GetRequriements(string filePath)
        {
            List<Requirement> reqs = new List<Requirement>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] fields = line.Split(';');

                    Requirement req = new Requirement();

                    if (fields[0] == "A")
                        req.RequirementType = RequirementType.Ambiguous;
                    else
                        req.RequirementType = RequirementType.NoAmbiguous;

                    req.Description = fields[1];
                    req.HelpDescription = fields[2];

                    reqs.Add(req);
                }

            }

            return reqs;
        }
    }
}