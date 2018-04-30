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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public abstract partial class IfcSpatialStructureElement : IfcProduct
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Long name for a spatial structure element, used for informal purposes. Maybe used in conjunction with the inherited Name attribute.")]
		public IfcLabel? LongName { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Denotes, whether the predefined spatial structure element represents itself, or an aggregate (complex) or a part (part). The interpretation is given separately for each subtype of spatial structure element.")]
		[Required()]
		public IfcElementCompositionEnum CompositionType { get; set; }
	
		[InverseProperty("RelatingStructure")] 
		[Description("<EPM-HTML>  Set of spatial reference relationships, that holds those elements, which are referenced, but not contained, within this element of the project spatial structure.  <blockquote><small>  NOTE&nbsp; The spatial reference relationship, established by <i>IfcRelReferencedInSpatialStructure</i>, is not required to be an hierarchical relationship, i.e. each element can be assigned to 0, 1 or many spatial structure elements.<br>  EXAMPLE&nbsp; A curtain wall maybe contained in the ground floor, but maybe referenced in all floors, it reaches.<br><br>  <font color=\"#ff0000\">  IFC2x Edition 3 CHANGE&nbsp; The inverse attribute has been added with upward compatibility for file based exchange.  </font>  </small></blockquote>  </EPM-HTML>")]
		public ISet<IfcRelReferencedInSpatialStructure> ReferencesElements { get; protected set; }
	
		[InverseProperty("RelatedBuildings")] 
		[Description("Set of relationships to Systems, that provides a certain service to the Building. The relationship is handled by the objectified relationship IfcRelServicesBuildings.  ")]
		public ISet<IfcRelServicesBuildings> ServicedBySystems { get; protected set; }
	
		[InverseProperty("RelatingStructure")] 
		[Description("<EPM-HTML>  Set of spatial containment relationships, that holds those elements, which are contained within this element of the project spatial structure.  <blockquote><small>  NOTE&nbsp; The spatial containment relationship, established by <i>IfcRelContainedInSpatialStructure</i>, is required to be an hierarchical relationship, i.e. each element can only be assigned to 0 or 1 spatial structure element.  </small></blockquote>  </EPM-HTML>")]
		public ISet<IfcRelContainedInSpatialStructure> ContainsElements { get; protected set; }
	
	
		protected IfcSpatialStructureElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcLabel? __LongName, IfcElementCompositionEnum __CompositionType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this.LongName = __LongName;
			this.CompositionType = __CompositionType;
			this.ReferencesElements = new HashSet<IfcRelReferencedInSpatialStructure>();
			this.ServicedBySystems = new HashSet<IfcRelServicesBuildings>();
			this.ContainsElements = new HashSet<IfcRelContainedInSpatialStructure>();
		}
	
	
	}
	
}
