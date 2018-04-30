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
	public abstract partial class IfcSpatialElement : IfcProduct
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Long name for a spatial structure element, used for informal purposes. It should be used, if available, in conjunction with the inherited <em>Name</em> attribute.  <blockquote class=\"note\">    NOTE&nbsp; In many scenarios the <em>Name</em> attribute refers to the short name or number of a spacial element, and the <em>LongName</em> refers to the full descriptive name.  </blockquote>")]
		public IfcLabel? LongName { get; set; }
	
		[InverseProperty("RelatingStructure")] 
		[XmlElement("IfcRelContainedInSpatialStructure")]
		[Description("Set of spatial containment relationships, that holds those elements, which are contained within this element of the project spatial structure.  <blockquote class=\"note\">NOTE&nbsp; The spatial containment relationship, established by <em>IfcRelContainedInSpatialStructure</em>, is required to be an hierarchical relationship, where each element can only be assigned to 0 or 1 spatial structure element.</blockquote>")]
		public ISet<IfcRelContainedInSpatialStructure> ContainsElements { get; protected set; }
	
		[InverseProperty("RelatedBuildings")] 
		[Description("Set of relationships to systems, that provides a certain service to the spatial element for which it is defined. The relationship is handled by the objectified relationship <em>IfcRelServicesBuildings</em>.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute has been promoted to the new supertype <em>IfcSpatialElement</em> with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRelServicesBuildings> ServicedBySystems { get; protected set; }
	
		[InverseProperty("RelatingStructure")] 
		[XmlElement("IfcRelReferencedInSpatialStructure")]
		[Description("Set of spatial reference relationships, that holds those elements, which are referenced, but not contained, within this element of the project spatial structure.  <blockquote class=\"change-ifc2x4\">NOTE&nbsp; The spatial reference relationship, established by <em>IfcRelReferencedInSpatialStructure</em>, is not required to be an hierarchical relationship, i.e. each element can be assigned to 0, 1 or many spatial structure elements.</blockquote>  <blockquote class=\"example\">EXAMPLE&nbsp; A curtain wall maybe contained in the ground floor, but maybe referenced in all floors, it reaches.</blockquote>  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The inverse attribute has been added with upward compatibility for file based exchange.</blockquote>  <blockquote class=\"change-ifc2x4\">Ø\\X")]
		public ISet<IfcRelReferencedInSpatialStructure> ReferencesElements { get; protected set; }
	
	
		protected IfcSpatialElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcLabel? __LongName)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this.LongName = __LongName;
			this.ContainsElements = new HashSet<IfcRelContainedInSpatialStructure>();
			this.ServicedBySystems = new HashSet<IfcRelServicesBuildings>();
			this.ReferencesElements = new HashSet<IfcRelReferencedInSpatialStructure>();
		}
	
	
	}
	
}
