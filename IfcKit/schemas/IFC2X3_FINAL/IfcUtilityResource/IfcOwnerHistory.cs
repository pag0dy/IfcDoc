// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
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
	[Guid("d0f0db55-cbcd-4b65-b333-71b5c760d498")]
	public partial class IfcOwnerHistory
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcPersonAndOrganization _OwningUser;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcApplication _OwningApplication;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcStateEnum? _State;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcChangeActionEnum _ChangeAction;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcTimeStamp? _LastModifiedDate;
	
		[DataMember(Order=5)] 
		IfcPersonAndOrganization _LastModifyingUser;
	
		[DataMember(Order=6)] 
		IfcApplication _LastModifyingApplication;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		[Required()]
		IfcTimeStamp _CreationDate;
	
	
		public IfcOwnerHistory()
		{
		}
	
		public IfcOwnerHistory(IfcPersonAndOrganization __OwningUser, IfcApplication __OwningApplication, IfcStateEnum? __State, IfcChangeActionEnum __ChangeAction, IfcTimeStamp? __LastModifiedDate, IfcPersonAndOrganization __LastModifyingUser, IfcApplication __LastModifyingApplication, IfcTimeStamp __CreationDate)
		{
			this._OwningUser = __OwningUser;
			this._OwningApplication = __OwningApplication;
			this._State = __State;
			this._ChangeAction = __ChangeAction;
			this._LastModifiedDate = __LastModifiedDate;
			this._LastModifyingUser = __LastModifyingUser;
			this._LastModifyingApplication = __LastModifyingApplication;
			this._CreationDate = __CreationDate;
		}
	
		[Description("Direct reference to the end user who currently \"owns\" this object. Note that IFC " +
	    "includes the concept of ownership transfer from one user to another and therefor" +
	    "e distinguishes between the Owning User and Creating User.")]
		public IfcPersonAndOrganization OwningUser { get { return this._OwningUser; } set { this._OwningUser = value;} }
	
		[Description(@"Direct reference to the application which currently ""Owns"" this object on behalf of the owning user, who uses this application. Note that IFC includes the concept of ownership transfer from one app to another and therefore distinguishes between the Owning Application and Creating Application.")]
		public IfcApplication OwningApplication { get { return this._OwningApplication; } set { this._OwningApplication = value;} }
	
		[Description("Enumeration that defines the current access state of the object.")]
		public IfcStateEnum? State { get { return this._State; } set { this._State = value;} }
	
		[Description("Enumeration that defines the actions associated with changes made to the object.")]
		public IfcChangeActionEnum ChangeAction { get { return this._ChangeAction; } set { this._ChangeAction = value;} }
	
		[Description("Date and Time at which the last modification occurred.")]
		public IfcTimeStamp? LastModifiedDate { get { return this._LastModifiedDate; } set { this._LastModifiedDate = value;} }
	
		[Description("User who carried out the last modification.")]
		public IfcPersonAndOrganization LastModifyingUser { get { return this._LastModifyingUser; } set { this._LastModifyingUser = value;} }
	
		[Description("Application used to carry out the last modification.")]
		public IfcApplication LastModifyingApplication { get { return this._LastModifyingApplication; } set { this._LastModifyingApplication = value;} }
	
		[Description("Time and date of creation.")]
		public IfcTimeStamp CreationDate { get { return this._CreationDate; } set { this._CreationDate = value;} }
	
	
	}
	
}
