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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	public partial class IfcPile : IfcBuildingElement
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The predefined generic type of the pile according to function.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional.  Type information can be provided by <em>IfcRelDefinesByType</em> and <em>IfcPileType</em>.</blockquote>")]
		public IfcPileTypeEnum? PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Material profile association capability by means of <em>IfcRelAssociatesMaterial</em> has been added.  The attribute <em>ConstructionType</em> should not be used whenever its information can be provided by a material profile set, either associated with the <em>IfcPile</em> object or, if present, with a corresponding instance of <em>IfcPileType</em>.</blockquote>")]
		public IfcPileConstructionEnum? ConstructionType { get; set; }
	
	
		public IfcPile(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcPileTypeEnum? __PredefinedType, IfcPileConstructionEnum? __ConstructionType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this.PredefinedType = __PredefinedType;
			this.ConstructionType = __ConstructionType;
		}
	
	
	}
	
}
