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
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialConstituent : IfcMaterialDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The name by which the material constituent is known.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Definition of the material constituent in descriptive terms.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("Reference to the material from which the constituent is constructed.")]
		[Required()]
		public IfcMaterial Material { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Optional provision of a fraction of the total amount (volume or weight) that applies to the <em>IfcMaterialConstituentSet</em> that is contributed by this <em>IfcMaterialConstituent</em>.")]
		public IfcNormalisedRatioMeasure? Fraction { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Category of the material constituent, e.g. the role it has in the constituent set it belongs to.")]
		public IfcLabel? Category { get; set; }
	
		[InverseProperty("MaterialConstituents")] 
		[Description("Material constituent set in which this material constituent is included.")]
		public IfcMaterialConstituentSet ToMaterialConstituentSet { get; set; }
	
	
		public IfcMaterialConstituent(IfcLabel? __Name, IfcText? __Description, IfcMaterial __Material, IfcNormalisedRatioMeasure? __Fraction, IfcLabel? __Category)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.Material = __Material;
			this.Fraction = __Fraction;
			this.Category = __Category;
		}
	
	
	}
	
}
