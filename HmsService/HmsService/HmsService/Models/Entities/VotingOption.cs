//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HmsService.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class VotingOption
    {
        public int VotingOptionId { get; set; }
        public Nullable<int> VotingQuestionId { get; set; }
        public string VotingOptionContent { get; set; }
        public Nullable<int> NumberOfVoting { get; set; }
    
        public virtual VotingQuestion VotingQuestion { get; set; }
    }
}
