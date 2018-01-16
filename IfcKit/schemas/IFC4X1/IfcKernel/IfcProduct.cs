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
	[Guid("ed1b8d59-300e-45f5-b8df-fd0e833a761e")]
	public abstract partial class IfcProduct : IfcObject,
		BuildingSmart.IFC.IfcKernel.IfcProductSelect
	{
		[DataMember(Order=0)] 
		[XmlElement]
		IfcObjectPlacement _ObjectPlacement;
	
		[DataMember(Order=1)] 
		[XmlElement]
		IfcProductRepresentation _Representation;
	
		[InverseProperty("RelatingProduct")] 
		ISet<IfcRelAssignsToProduct> _ReferencedBy = new HashSet<IfcRelAssignsToProduct>();
	
	
		[Description(@"Placement of the product in space, the placement can either be absolute (relative to the world coordinate system), relative (relative to the object placement of another product), or constraint (e.g. relative to grid axes). It is determined by the various subtypes of IfcObjectPlacement, which includes the axis placement information to determine the  transformation for the object coordinate system.")]
		public IfcObjectPlacement ObjectPlacement { get { return this._ObjectPlacement; } set { this._ObjectPlacement = value;} }
	
		[Description(@"Reference to the representations of the product, being either a representation (IfcProductRepresentation) or as a special case a shape representations (IfcProductDefinitionShape). The product definition shape provides for multiple geometric representations of the shape property of the object within the same object coordinate system, defined by the object placement.")]
		public IfcProductRepresentation Representation { get { return this._Representation; } set { this._Representation = value;} }
	
		[Description("Reference to the <em>IfcRelAssignsToProduct</em> relationship, by which other pro" +
	    "ducts, processes, controls, resources or actors (as subtypes of <em>IfcObjectDef" +
	    "inition</em>) can be related to this product.")]
		public ISet<IfcRelAssignsToProduct> ReferencedBy { get { return this._ReferencedBy; } }
	
	
	}
	
}
