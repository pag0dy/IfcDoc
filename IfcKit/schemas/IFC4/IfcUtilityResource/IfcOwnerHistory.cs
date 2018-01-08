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
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcUtilityResource
{
	[Guid("6ef8f949-8689-4582-bbae-9259e7c2d559")]
	public partial class IfcOwnerHistory
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcPersonAndOrganization")]
		[Required()]
		IfcPersonAndOrganization _OwningUser;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcApplication")]
		[Required()]
		IfcApplication _OwningApplication;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcStateEnum? _State;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcChangeActionEnum? _ChangeAction;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcTimeStamp? _LastModifiedDate;
	
		[DataMember(Order=5)] 
		[XmlElement("IfcPersonAndOrganization")]
		IfcPersonAndOrganization _LastModifyingUser;
	
		[DataMember(Order=6)] 
		[XmlElement("IfcApplication")]
		IfcApplication _LastModifyingApplication;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		[Required()]
		IfcTimeStamp _CreationDate;
	
	
		[Description("Direct reference to the end user who currently \"owns\" this object. Note that IFC " +
	    "includes the concept of ownership transfer from one user to another and therefor" +
	    "e distinguishes between the Owning User and Creating User.")]
		public IfcPersonAndOrganization OwningUser { get { return this._OwningUser; } set { this._OwningUser = value;} }
	
		[Description(@"Direct reference to the application which currently ""owns"" this object on behalf of the owning user of the application. Note that IFC includes the concept of ownership transfer from one application to another and therefore distinguishes between the Owning Application and Creating Application.")]
		public IfcApplication OwningApplication { get { return this._OwningApplication; } set { this._OwningApplication = value;} }
	
		[Description("Enumeration that defines the current access state of the object.")]
		public IfcStateEnum? State { get { return this._State; } set { this._State = value;} }
	
		[Description("Enumeration that defines the actions associated with changes made to the object.")]
		public IfcChangeActionEnum? ChangeAction { get { return this._ChangeAction; } set { this._ChangeAction = value;} }
	
		[Description("Date and Time expressed in UTC (Universal Time Coordinated, formerly Greenwich Me" +
	    "an Time or GMT) at which the last modification was made by LastModifyingUser and" +
	    " LastModifyingApplication.")]
		public IfcTimeStamp? LastModifiedDate { get { return this._LastModifiedDate; } set { this._LastModifiedDate = value;} }
	
		[Description("User who carried out the last modification using LastModifyingApplication.")]
		public IfcPersonAndOrganization LastModifyingUser { get { return this._LastModifyingUser; } set { this._LastModifyingUser = value;} }
	
		[Description("Application used to make the last modification.")]
		public IfcApplication LastModifyingApplication { get { return this._LastModifyingApplication; } set { this._LastModifyingApplication = value;} }
	
		[Description("The date and time expressed in UTC (Universal Time Coordinated, formerly Greenwic" +
	    "h Mean Time or GMT) when first created by the original OwningApplication. Once d" +
	    "efined this value remains unchanged through the lifetime of the entity. ")]
		public IfcTimeStamp CreationDate { get { return this._CreationDate; } set { this._CreationDate = value;} }
	
	
	}
	
}
