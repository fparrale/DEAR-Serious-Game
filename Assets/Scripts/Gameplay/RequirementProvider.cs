
using System.Collections.Generic;
using Gameplay.Data;
using UnityEngine;

namespace Gameplay
{
    public abstract class RequirementProvider : MonoBehaviour
    {
        public abstract List<Requirement> GetRequirements();
    }
}