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
	
	
		[Description("<EPM-HTML>\r\nThe name by which the material constituent is known.\r\n</EPM-HTML>")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("<EPM-HTML>\r\nDefinition of the material constituent in descriptive terms.\r\n</EPM-H" +
	    "TML>")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("<EPM-HTML>\r\nReference to the material from which the constituent is constructed.\r" +
	    "\n</EPM-HTML>")]
		public IfcMaterial Material { get { return this._Material; } set { this._Material = value;} }
	
		[Description("<EPM-HTML>\r\nOptional provision of a fraction of the total amount (volume or weigh" +
	    "t) that applies to the <em>IfcMaterialConstituentSet</em> that is contributed by" +
	    " this <em>IfcMaterialConstituent</em>.\r\n</EPM-HTML>")]
		public IfcNormalisedRatioMeasure? Fraction { get { return this._Fraction; } set { this._Fraction = value;} }
	
		[Description("<EPM-HTML>\r\nCategory of the material constituent, e.g. the role it has in the con" +
	    "stituent set it belongs to.\r\n</EPM-HTML>")]
		public IfcLabel? Category { get { return this._Category; } set { this._Category = value;} }
	
		[Description("<EPM-HTML>\r\nMaterial constituent set in which this material constituent is includ" +
	    "ed.\r\n</EPM-HTML>")]
		public IfcMaterialConstituentSet ToMaterialConstituentSet { get { return this._ToMaterialConstituentSet; } set { this._ToMaterialConstituentSet = value;} }
	
	
	}
	
}
