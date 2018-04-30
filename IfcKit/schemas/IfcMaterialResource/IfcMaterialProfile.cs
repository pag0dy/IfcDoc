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
	public partial class IfcMaterialProfile : IfcMaterialDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The name by which the material profile is known.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Definition of the material profile in descriptive terms.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("Optional reference to the material from which the profile is constructed.")]
		public IfcMaterial Material { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlElement]
		[Description("Identification of the profile for which this material profile is associating material.")]
		[Required()]
		public IfcProfileDef Profile { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The relative priority of the profile, expressed as normalised integer range [0..100]. Controls how profiles intersect in connections and corners of building elements: A profile from one element protrudes into (i.e. displaces) a profile from another element in a joint of these elements if the former element's profile has higher priority than the latter. The priority value for a material profile in an element has to be set and maintained by software applications in relation to the material profiles in connected elements.")]
		public IfcInteger? Priority { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Category of the material profile, e.g. the role it has in the profile set it belongs to. The list of keywords might be extended by model view definitions, however the following keywords shall apply in general:  <ul>   <li class=\"small\">'LoadBearing' &mdash; the material profile having a load bearing function.</li>   <li class=\"small\">'Insulation' &mdash; the material profile having an insolating function.</li>   <li class=\"small\">'Finish' &mdash; the material profile being the finish.</li>  </ul>")]
		public IfcLabel? Category { get; set; }
	
		[InverseProperty("MaterialProfiles")] 
		[Description("Material profile set in which this material profile is included.")]
		public IfcMaterialProfileSet ToMaterialProfileSet { get; set; }
	
	
		public IfcMaterialProfile(IfcLabel? __Name, IfcText? __Description, IfcMaterial __Material, IfcProfileDef __Profile, IfcInteger? __Priority, IfcLabel? __Category)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.Material = __Material;
			this.Profile = __Profile;
			this.Priority = __Priority;
			this.Category = __Category;
		}
	
	
	}
	
}
