using System.IO;
using UnityEngine;

namespace Code.Requirements.UseCases
{
    public class RequirementFileCreator
    {
        public void CreateFile(string pathToCreateFile)
        {
            if(pathToCreateFile == null || pathToCreateFile == string.Empty)
                return;

            var requirementFileBytes = Resources.Load<TextAsset>("requirements").bytes;
            File.WriteAllBytes(pathToCreateFile, requirementFileBytes);
            
        }


    }
}