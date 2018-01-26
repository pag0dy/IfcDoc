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

using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcProfilePropertyResource
{
	[Guid("a39225eb-2fe7-4bcb-836c-e490b34f494c")]
	public partial class IfcSectionProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcSectionTypeEnum _SectionType;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcProfileDef _StartProfile;
	
		[DataMember(Order=2)] 
		IfcProfileDef _EndProfile;
	
	
		public IfcSectionProperties()
		{
		}
	
		public IfcSectionProperties(IfcSectionTypeEnum __SectionType, IfcProfileDef __StartProfile, IfcProfileDef __EndProfile)
		{
			this._SectionType = __SectionType;
			this._StartProfile = __StartProfile;
			this._EndProfile = __EndProfile;
		}
	
		[Description("An indicator whether a specific piece of a cross section is uniform or tapered in" +
	    " longitudinal direction.")]
		public IfcSectionTypeEnum SectionType { get { return this._SectionType; } set { this._SectionType = value;} }
	
		[Description("The cross section profile at the start point of the longitudinal section.")]
		public IfcProfileDef StartProfile { get { return this._StartProfile; } set { this._StartProfile = value;} }
	
		[Description("The cross section profile at the end point of the longitudinal section.")]
		public IfcProfileDef EndProfile { get { return this._EndProfile; } set { this._EndProfile = value;} }
	
	
	}
	
}
