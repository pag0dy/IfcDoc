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
	[Guid("beba5e9b-c73b-48e0-8a6d-b5d65ddbaaf1")]
	public partial class IfcMaterialConstituent : IfcMaterialDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcMaterial")]
		[Required()]
		IfcMaterial _Material;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _Fraction;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLabel? _Category;
	
		[InverseProperty("MaterialConstituents")] 
		IfcMaterialConstituentSet _ToMaterialConstituentSet;
	
	
		[Description("The name by which the material constituent is known.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Definition of the material constituent in descriptive terms.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Reference to the material from which the constituent is constructed.")]
		public IfcMaterial Material { get { return this._Material; } set { this._Material = value;} }
	
		[Description("Optional provision of a fraction of the total amount (volume or weight) that appl" +
	    "ies to the <em>IfcMaterialConstituentSet</em> that is contributed by this <em>If" +
	    "cMaterialConstituent</em>.")]
		public IfcNormalisedRatioMeasure? Fraction { get { return this._Fraction; } set { this._Fraction = value;} }
	
		[Description("Category of the material constituent, e.g. the role it has in the constituent set" +
	    " it belongs to.")]
		public IfcLabel? Category { get { return this._Category; } set { this._Category = value;} }
	
		[Description("Material constituent set in which this material constituent is included.")]
		public IfcMaterialConstituentSet ToMaterialConstituentSet { get { return this._ToMaterialConstituentSet; } set { this._ToMaterialConstituentSet = value;} }
	
	
	}
	
}
