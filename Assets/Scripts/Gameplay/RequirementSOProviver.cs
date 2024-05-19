using System.Collections;
using System.Collections.Generic;
using Gameplay;
using Gameplay.Data;
using UnityEngine;

public class RequirementSOProviver : RequirementProvider
{
    public List<RequirementSO> requirements;

    public override List<Requirement> GetRequirements()
    {
        List<Requirement> reqs = new List<Requirement>();

        foreach(RequirementSO r in requirements)
        {
            reqs.Add(r.GetRequirement());
        }

        return reqs;
    }

    
}
