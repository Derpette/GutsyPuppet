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
    
    public partial class AuthUserLogin
    {
        public int AuthUserLoginId { get; set; }
        public int UserId { get; set; }
        public int ClientType { get; set; }
        public System.DateTime LoginDateTime { get; set; }
        public string LoginId { get; set; }
        public int LoginResult { get; set; }
        public string AdditionalInfo { get; set; }
        public int UserType { get; set; }
    }
}
