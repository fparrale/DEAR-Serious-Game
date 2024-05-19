
using System;
using UnityEngine;
using UnityEngine.Localization;

namespace Gameplay.Data
{
    [CreateAssetMenu(fileName = "New Requirement", menuName ="Game/New Requirement")]
    public class RequirementSO : ScriptableObject
    {
        public LocalizedString localizedDescription;
        public RequirementType requirementType;

        public Requirement GetRequirement()
        {
            Requirement requirement = new Requirement();
            requirement.description = localizedDescription.GetLocalizedString();
            requirement.requirementType = requirementType;
            return requirement;
        }
    }
}