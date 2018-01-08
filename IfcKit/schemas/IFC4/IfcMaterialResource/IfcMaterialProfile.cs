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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("b6fed4e6-ea5a-425b-a9b3-54d96e75f62b")]
	public partial class IfcMaterialProfile : IfcMaterialDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcMaterial")]
		IfcMaterial _Material;
	
		[DataMember(Order=3)] 
		[XmlElement("IfcProfileDef")]
		[Required()]
		IfcProfileDef _Profile;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _Priority;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcLabel? _Category;
	
		[InverseProperty("MaterialProfiles")] 
		IfcMaterialProfileSet _ToMaterialProfileSet;
	
	
		[Description("The name by which the material profile is known.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Definition of the material profile in descriptive terms.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Optional reference to the material from which the profile is constructed.")]
		public IfcMaterial Material { get { return this._Material; } set { this._Material = value;} }
	
		[Description("Identification of the profile for which this material profile is associating mate" +
	    "rial.")]
		public IfcProfileDef Profile { get { return this._Profile; } set { this._Profile = value;} }
	
		[Description(@"<EPM-HTML>
	The relative priority of the profile, expressed as ratio measure, normalised to 0..1. Controls how profiles intersect in connections and corners of building elements: A profile from one element protrudes into (i.e. displaces) a profile from another element in a joint of these elements if the former element's profile has higher priority than the latter. The priority value for a material profile in an element has to be set and maintained by software applications in relation to the material profiles in connected elements.
	</EPM-HTML>")]
		public IfcNormalisedRatioMeasure? Priority { get { return this._Priority; } set { this._Priority = value;} }
	
		[Description("Category of the material profile, e.g. the role it has in the profile set it belo" +
	    "ngs to.")]
		public IfcLabel? Category { get { return this._Category; } set { this._Category = value;} }
	
		[Description("Material profile set in which this material profile is included.")]
		public IfcMaterialProfileSet ToMaterialProfileSet { get { return this._ToMaterialProfileSet; } set { this._ToMaterialProfileSet = value;} }
	
	
	}
	
}
