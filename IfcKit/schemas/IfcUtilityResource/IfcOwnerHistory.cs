// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcUtilityResource
{
	public partial class IfcOwnerHistory
	{
		[DataMember(Order = 0)] 
		[Description("Direct reference to the end user who currently \"owns\" this object. Note that IFC includes the concept of ownership transfer from one user to another and therefore distinguishes between the Owning User and Creating User.")]
		[Required()]
		public IfcPersonAndOrganization OwningUser { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Direct reference to the application which currently \"Owns\" this object on behalf of the owning user, who uses this application. Note that IFC includes the concept of ownership transfer from one app to another and therefore distinguishes between the Owning Application and Creating Application.")]
		[Required()]
		public IfcApplication OwningApplication { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Enumeration that defines the current access state of the object.")]
		public IfcStateEnum? State { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Enumeration that defines the actions associated with changes made to the object.")]
		[Required()]
		public IfcChangeActionEnum ChangeAction { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Date and Time at which the last modification occurred.")]
		public IfcTimeStamp? LastModifiedDate { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("User who carried out the last modification.")]
		public IfcPersonAndOrganization LastModifyingUser { get; set; }
	
		[DataMember(Order = 6)] 
		[Description("Application used to carry out the last modification.")]
		public IfcApplication LastModifyingApplication { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Time and date of creation.")]
		[Required()]
		public IfcTimeStamp CreationDate { get; set; }
	
	
		public IfcOwnerHistory(IfcPersonAndOrganization __OwningUser, IfcApplication __OwningApplication, IfcStateEnum? __State, IfcChangeActionEnum __ChangeAction, IfcTimeStamp? __LastModifiedDate, IfcPersonAndOrganization __LastModifyingUser, IfcApplication __LastModifyingApplication, IfcTimeStamp __CreationDate)
		{
			this.OwningUser = __OwningUser;
			this.OwningApplication = __OwningApplication;
			this.State = __State;
			this.ChangeAction = __ChangeAction;
			this.LastModifiedDate = __LastModifiedDate;
			this.LastModifyingUser = __LastModifyingUser;
			this.LastModifyingApplication = __LastModifyingApplication;
			this.CreationDate = __CreationDate;
		}
	
	
	}
	
}
