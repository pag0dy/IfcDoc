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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialProfileSet : IfcMaterialDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The name by which the material profile set is known.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Definition of the material profile set in descriptive terms.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Identification of the profiles from which the material profile set is composed.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcMaterialProfile> MaterialProfiles { get; protected set; }
	
		[DataMember(Order = 3)] 
		[XmlElement]
		[Description("Reference to the composite profile definition for which this material profile set associates material to each of its individual profiles. If only a single material profile is used (the most typical case) then no <em>CompositeProfile</em> is asserted.    <blockquote class=\"note\">NOTE&nbsp; The referenced <em>IfcCompositeProfileDef</em> instance shall be composed of all of the <em>IfcProfileDef</em> instances which are used via the MaterialProfiles list in the current <em>IfcMaterialProfileSet</em>.  </blockquote>")]
		public IfcCompositeProfileDef CompositeProfile { get; set; }
	
	
		public IfcMaterialProfileSet(IfcLabel? __Name, IfcText? __Description, IfcMaterialProfile[] __MaterialProfiles, IfcCompositeProfileDef __CompositeProfile)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.MaterialProfiles = new List<IfcMaterialProfile>(__MaterialProfiles);
			this.CompositeProfile = __CompositeProfile;
		}
	
	
	}
	
}
