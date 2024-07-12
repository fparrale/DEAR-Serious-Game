namespace Code.Requirements.Model
{
    public class Requirement
    {
        public string Description {get;set;}
        public string HelpDescription {get;set;}
        public RequirementType RequirementType { get; set; }

        public Requirement(string description, string helpDescription, RequirementType requirementType)
        {
            this.Description = description;
            this.HelpDescription = helpDescription;
            this.RequirementType = requirementType;
        }

        public Requirement(){}

    }
    
}

