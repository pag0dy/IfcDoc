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
	public partial class IfcApplication
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Name of the application developer.  ")]
		[Required()]
		public IfcOrganization ApplicationDeveloper { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The version number of this software as specified by the developer of the application.")]
		[Required()]
		[CustomValidation(typeof(IfcApplication), "Unique")]
		public IfcLabel Version { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The full name of the application as specified by the application developer.")]
		[Required()]
		[CustomValidation(typeof(IfcApplication), "Unique")]
		public IfcLabel ApplicationFullName { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Short identifying name for the application.")]
		[Required()]
		[CustomValidation(typeof(IfcApplication), "Unique")]
		public IfcIdentifier ApplicationIdentifier { get; set; }
	
	
		public IfcApplication(IfcOrganization __ApplicationDeveloper, IfcLabel __Version, IfcLabel __ApplicationFullName, IfcIdentifier __ApplicationIdentifier)
		{
			this.ApplicationDeveloper = __ApplicationDeveloper;
			this.Version = __Version;
			this.ApplicationFullName = __ApplicationFullName;
			this.ApplicationIdentifier = __ApplicationIdentifier;
		}
	
	
	}
	
}
