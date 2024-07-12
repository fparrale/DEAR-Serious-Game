using System.IO;
using System;
using UnityEngine;

namespace Code.Requirements.UseCases
{
    public class RequirementFileValidator
    {
        public ValidationStatus ValidateIfExistFile(string filePath)
        {
            if (File.Exists(filePath)) return ValidationStatus.Success;

            return ValidationStatus.FileNotFound;
        }

        public ValidationStatus ValidateIfCorrect(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    //Reading lines
                    string line = reader.ReadLine();
                    string[] fields = line.Split(';');

                    Debug.Log("ValidateFile: Linea: " + line);

                    //Fields 0 : ambiguity
                    //Fields 1 : description
                    //Fields 2 : help description

                    if (fields.Length != 3)
                    {
                        Debug.Log("ValidateFile: No existe dos columnas");
                        return ValidationStatus.MissingRequiredColumnsAmount;
                    }

                    if (fields[0] != "A" && fields[0] != "N")
                    {
                        Debug.Log("ValidateFile: No tiene A o N la fila, tiene: " + fields[0]);
                        return ValidationStatus.FirstColumnIsNotCorrect;
                    }

                    if (fields[1].Trim() == "")
                    {
                        Debug.Log("ValidateFile: El rerquerimiento está vacio");
                        return ValidationStatus.SecondColumnIsNotCorrect;
                    }

                    if (fields[2].Trim() == "")
                    {
                        Debug.Log("ValidateFile: La ayuda está vacia");
                        return ValidationStatus.ThirdColumnIsNotCorrect;
                    }
                }

            }

            return ValidationStatus.Success;
        }



        public enum ValidationStatus
        {
            Success,
            FileNotFound,
            MissingRequiredColumnsAmount,
            FirstColumnIsNotCorrect,
            SecondColumnIsNotCorrect,
            ThirdColumnIsNotCorrect
        }
    }




}

