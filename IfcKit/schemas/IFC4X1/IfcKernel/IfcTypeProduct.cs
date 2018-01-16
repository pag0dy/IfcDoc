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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("b442e2c7-0333-4c55-8b8b-df240b0d59af")]
	public partial class IfcTypeProduct : IfcTypeObject
	{
		[DataMember(Order=0)] 
		IList<IfcRepresentationMap> _RepresentationMaps = new List<IfcRepresentationMap>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Tag;
	
	
		[Description("List of unique representation maps. Each representation map describes a block def" +
	    "inition of the shape of the product style. By providing more than one representa" +
	    "tion map, a multi-view block definition can be given.")]
		public IList<IfcRepresentationMap> RepresentationMaps { get { return this._RepresentationMaps; } }
	
		[Description("The tag (or label) identifier at the particular type of a product, e.g. the artic" +
	    "le number (like the EAN). It is the identifier at the specific level.")]
		public IfcLabel? Tag { get { return this._Tag; } set { this._Tag = value;} }
	
	
	}
	
}
