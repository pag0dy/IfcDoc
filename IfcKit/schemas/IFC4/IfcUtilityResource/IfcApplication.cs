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
	[Guid("88190cb4-3569-4c42-9b7d-8778145e179e")]
	public partial class IfcApplication
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcOrganization")]
		[Required()]
		IfcOrganization _ApplicationDeveloper;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Version;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _ApplicationFullName;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _ApplicationIdentifier;
	
	
		[Description("Name of the application developer.\r\n")]
		public IfcOrganization ApplicationDeveloper { get { return this._ApplicationDeveloper; } set { this._ApplicationDeveloper = value;} }
	
		[Description("The version number of this software as specified by the developer of the applicat" +
	    "ion.")]
		public IfcLabel Version { get { return this._Version; } set { this._Version = value;} }
	
		[Description("The full name of the application as specified by the application developer.")]
		public IfcLabel ApplicationFullName { get { return this._ApplicationFullName; } set { this._ApplicationFullName = value;} }
	
		[Description("Short identifying name for the application.")]
		public IfcIdentifier ApplicationIdentifier { get { return this._ApplicationIdentifier; } set { this._ApplicationIdentifier = value;} }
	
	
	}
	
}
