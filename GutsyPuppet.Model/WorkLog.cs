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
    
    public partial class WorkLog
    {
        public int WorkLogId { get; set; }
        public System.DateTime WorkLogDateTime { get; set; }
        public int ItemId { get; set; }
        public int ItemTypeId { get; set; }
        public int UserId { get; set; }
        public float WorkDone { get; set; }
        public int WorkUnitTypeId { get; set; }
        public string Description { get; set; }
        public int WorkLogTypeId { get; set; }
        public int SourceType { get; set; }
        public int SourceId { get; set; }
        public int ReleaseWorkEntryId { get; set; }
    }
}