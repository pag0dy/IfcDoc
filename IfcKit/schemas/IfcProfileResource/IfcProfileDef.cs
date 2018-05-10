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
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	public partial class IfcProfileDef :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Defines the type of geometry into which this profile definition shall be resolved, either a curve or a surface area. In case of curve the profile should be referenced by a swept surface, in case of area the profile should be referenced by a swept area solid.")]
		[Required()]
		public IfcProfileTypeEnum ProfileType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Human-readable name of the profile, for example according to a standard profile table. As noted above, machine-readable standardized profile designations should be provided in <em>IfcExternalReference.Identification</em>.  ")]
		public IfcLabel? ProfileName { get; set; }
	
		[InverseProperty("RelatedResourceObjects")] 
		[Description("Reference to external information, e.g. library, classification, or document information, which is associated with the profile.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE New inverse attribute</blockquote>")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReference { get; protected set; }
	
		[InverseProperty("ProfileDefinition")] 
		[XmlElement("IfcProfileProperties")]
		[Description("Additional properties of the profile, for example mechanical properties.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE New inverse attribute</blockquote>")]
		public ISet<IfcProfileProperties> HasProperties { get; protected set; }
	
	
		public IfcProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName)
		{
			this.ProfileType = __ProfileType;
			this.ProfileName = __ProfileName;
			this.HasExternalReference = new HashSet<IfcExternalReferenceRelationship>();
			this.HasProperties = new HashSet<IfcProfileProperties>();
		}
	
	
	}
	
}
