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
    
    public partial class UserToken
    {
        public int UserId { get; set; }
        public string OAuthToken { get; set; }
        public string RefreshToken { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public int UserType { get; set; }
        public string Scope { get; set; }
        public string RedirectUri { get; set; }
        public string AuthorizationCode { get; set; }
        public string ClientId { get; set; }
        public int UserTokenId { get; set; }
        public Nullable<System.DateTime> ExpirationDateTime { get; set; }
        public int Provider { get; set; }
        public string OAuthSecret { get; set; }
    }
}