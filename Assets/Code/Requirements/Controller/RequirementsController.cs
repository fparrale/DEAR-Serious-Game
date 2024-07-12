using System.IO;
using System;
using UnityEngine;
using Code.Requirements.UseCases;
using UnityEditor;
using Code.Requirements.Model;
using System.Collections.Generic;

namespace Code.Requirements.Controller
{
    public class RequirementsController : MonoBehaviour
    {
        public string filePath { get; private set; }

        private RequirementFileValidator fileValidator;

        private RequirementFileCreator requirementFileCreator;

        private RequirementProvider requirementProvider;

        private void Awake()
        {
            fileValidator = new RequirementFileValidator();
            requirementFileCreator = new RequirementFileCreator();
            requirementProvider = new RequirementProvider();

            SetFilePath();
        }

        private void SetFilePath()
        {
#if UNITY_EDITOR == false
            filePath = AssetDatabase.GetAssetPath( Resources.Load("requirements"));
#else
            var folderPath = Path.Combine(Application.dataPath, "..");
            filePath = folderPath + "/requirements.csv";
#endif

            Debug.Log("Dirección de arrchivo: " + filePath);
        }


        public RequirementFileValidator.ValidationStatus ValidateFile()
        {
            if (fileValidator.ValidateIfExistFile(filePath) == RequirementFileValidator.ValidationStatus.FileNotFound)
            {
                requirementFileCreator.CreateFile(filePath);
                return RequirementFileValidator.ValidationStatus.Success;
            }

            return fileValidator.ValidateIfCorrect(filePath);
        }

        public List<Requirement> GetRequirements()
        {
            return requirementProvider.GetRequriements(filePath);
        }

    }

}

