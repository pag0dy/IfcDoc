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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("7c369ae9-9cbc-48a2-ab70-6a3d7a76f0a3")]
	public abstract partial class IfcSpatialStructureElement : IfcProduct
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _LongName;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcElementCompositionEnum _CompositionType;
	
		[InverseProperty("RelatingStructure")] 
		ISet<IfcRelReferencedInSpatialStructure> _ReferencesElements = new HashSet<IfcRelReferencedInSpatialStructure>();
	
		[InverseProperty("RelatedBuildings")] 
		ISet<IfcRelServicesBuildings> _ServicedBySystems = new HashSet<IfcRelServicesBuildings>();
	
		[InverseProperty("RelatingStructure")] 
		ISet<IfcRelContainedInSpatialStructure> _ContainsElements = new HashSet<IfcRelContainedInSpatialStructure>();
	
	
		[Description("Long name for a spatial structure element, used for informal purposes. Maybe used" +
	    " in conjunction with the inherited Name attribute.")]
		public IfcLabel? LongName { get { return this._LongName; } set { this._LongName = value;} }
	
		[Description("Denotes, whether the predefined spatial structure element represents itself, or a" +
	    "n aggregate (complex) or a part (part). The interpretation is given separately f" +
	    "or each subtype of spatial structure element.")]
		public IfcElementCompositionEnum CompositionType { get { return this._CompositionType; } set { this._CompositionType = value;} }
	
		[Description(@"<EPM-HTML>
	Set of spatial reference relationships, that holds those elements, which are referenced, but not contained, within this element of the project spatial structure.
	<blockquote><small>
	NOTE&nbsp; The spatial reference relationship, established by <i>IfcRelReferencedInSpatialStructure</i>, is not required to be an hierarchical relationship, i.e. each element can be assigned to 0, 1 or many spatial structure elements.<br>
	EXAMPLE&nbsp; A curtain wall maybe contained in the ground floor, but maybe referenced in all floors, it reaches.<br><br>
	<font color=""#ff0000"">
	IFC2x Edition 3 CHANGE&nbsp; The inverse attribute has been added with upward compatibility for file based exchange.
	</font>
	</small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcRelReferencedInSpatialStructure> ReferencesElements { get { return this._ReferencesElements; } }
	
		[Description("Set of relationships to Systems, that provides a certain service to the Building." +
	    " The relationship is handled by the objectified relationship IfcRelServicesBuild" +
	    "ings.\r\n")]
		public ISet<IfcRelServicesBuildings> ServicedBySystems { get { return this._ServicedBySystems; } }
	
		[Description(@"<EPM-HTML>
	Set of spatial containment relationships, that holds those elements, which are contained within this element of the project spatial structure.
	<blockquote><small>
	NOTE&nbsp; The spatial containment relationship, established by <i>IfcRelContainedInSpatialStructure</i>, is required to be an hierarchical relationship, i.e. each element can only be assigned to 0 or 1 spatial structure element.
	</small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcRelContainedInSpatialStructure> ContainsElements { get { return this._ContainsElements; } }
	
	
	}
	
}
