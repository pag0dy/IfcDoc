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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("de22199b-0d1f-4205-842f-3dea858c822b")]
	public partial class IfcTypeProduct : IfcTypeObject,
		BuildingSmart.IFC.IfcKernel.IfcProductSelect
	{
		[DataMember(Order=0)] 
		IList<IfcRepresentationMap> _RepresentationMaps = new List<IfcRepresentationMap>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Tag;
	
		[InverseProperty("RelatingProduct")] 
		ISet<IfcRelAssignsToProduct> _ReferencedBy = new HashSet<IfcRelAssignsToProduct>();
	
	
		[Description("List of unique representation maps. Each representation map describes a block def" +
	    "inition of the shape of the product style. By providing more than one representa" +
	    "tion map, a multi-view block definition can be given.")]
		public IList<IfcRepresentationMap> RepresentationMaps { get { return this._RepresentationMaps; } }
	
		[Description("The tag (or label) identifier at the particular type of a product, e.g. the artic" +
	    "le number (like the EAN). It is the identifier at the specific level.")]
		public IfcLabel? Tag { get { return this._Tag; } set { this._Tag = value;} }
	
		[Description(@"Reference to the <em>IfcRelAssignsToProduct</em> relationship, by which other products, processes, controls, resources or actors (as subtypes of <em>IfcObjectDefinition</em>) can be related to this product type.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp;  New inverse relationship.</blockquote>")]
		public ISet<IfcRelAssignsToProduct> ReferencedBy { get { return this._ReferencedBy; } }
	
	
	}
	
}
