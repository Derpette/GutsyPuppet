//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GutsyPuppet.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OnTimeItem
    {
        public int OnTimeItemId { get; set; }
        public int ProjectId { get; set; }
        public int CreatedById { get; set; }
        public int ReportedById { get; set; }
        public int AssignedToId { get; set; }
        public int PriorityTypeId { get; set; }
        public int StatusTypeId { get; set; }
        public Nullable<int> SeverityTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BuildNumber { get; set; }
        public float EstimatedDuration { get; set; }
        public int DurationUnitTypeId { get; set; }
        public float ActualDuration { get; set; }
        public int ActualUnitTypeId { get; set; }
        public Nullable<System.DateTime> ReportedDate { get; set; }
        public System.DateTime CompletionDate { get; set; }
        public System.DateTime DueDate { get; set; }
        public string BuildNumberOfFix { get; set; }
        public string ReplicationProcedures { get; set; }
        public string Resolution { get; set; }
        public string Notes { get; set; }
        public byte[] LastUpdated { get; set; }
        public int WorkflowStepId { get; set; }
        public byte PercentComplete { get; set; }
        public int LastUpdatedById { get; set; }
        public System.DateTime LastUpdatedDateTime { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public bool PubliclyViewable { get; set; }
        public int ReportedByCustomerContactId { get; set; }
        public bool Archived { get; set; }
        public float RemainingDuration { get; set; }
        public int RemainingUnitTypeId { get; set; }
        public int ReleaseId { get; set; }
        public int ParentId { get; set; }
        public int SubitemType { get; set; }
        public float AggregateEstimatedMinutes { get; set; }
        public float AggregateActualMinutes { get; set; }
        public float AggregateRemainingMinutes { get; set; }
        public float EstimatedDurationMinutes { get; set; }
        public float ActualDurationMinutes { get; set; }
        public float RemainingDurationMinutes { get; set; }
        public int ItemId { get; set; }
        public string ItemNumber { get; set; }
        public int ItemType { get; set; }
        public Nullable<int> CategoryTypeId { get; set; }
        public Nullable<int> EscalationLevelId { get; set; }
        public Nullable<bool> IsCompleted { get; set; }
        public Nullable<bool> IsPublic { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public int FamilyId { get; set; }
        public Nullable<int> UniqueId { get; set; }
        public Nullable<int> UniqueFamilyId { get; set; }
        public Nullable<int> UniqueParentId { get; set; }
        public string CreatedByEmailAddress { get; set; }
        public int AssignedToType { get; set; }
    }
}