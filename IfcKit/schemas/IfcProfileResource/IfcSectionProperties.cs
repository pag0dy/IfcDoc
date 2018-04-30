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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	public partial class IfcSectionProperties : IfcPreDefinedProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("An indicator whether a specific piece of a cross section is uniform or tapered in longitudinal direction.")]
		[Required()]
		public IfcSectionTypeEnum SectionType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("The cross section profile at the start point of the longitudinal section.")]
		[Required()]
		public IfcProfileDef StartProfile { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("The cross section profile at the end point of the longitudinal section.")]
		public IfcProfileDef EndProfile { get; set; }
	
	
		public IfcSectionProperties(IfcSectionTypeEnum __SectionType, IfcProfileDef __StartProfile, IfcProfileDef __EndProfile)
		{
			this.SectionType = __SectionType;
			this.StartProfile = __StartProfile;
			this.EndProfile = __EndProfile;
		}
	
	
	}
	
}
