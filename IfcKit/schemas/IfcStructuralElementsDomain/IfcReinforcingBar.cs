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
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	public partial class IfcReinforcingBar : IfcReinforcingElement
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional and deprecated.  Use respective attribute at <em>IfcReinforcingBarType</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? NominalDiameter { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The effective cross-section area of the reinforcing bar or group of bars.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional.</blockquote>")]
		public IfcAreaMeasure? CrossSectionArea { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute deprecated.  Use respective attribute at <em>IfcReinforcingBarType</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? BarLength { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The role, purpose or usage of the bar, i.e. the kind of loads and stresses it is intended to carry.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute renamed from <em>BarRole</em> to <em>PredefinedType</em> and made optional.  Type changed from <em>IfcReinforcingBarRoleEnum</em> without changes to the range of enumeration items.</blockquote>")]
		public IfcReinforcingBarTypeEnum? PredefinedType { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional and deprecated.  Use respective attribute at <em>IfcReinforcingBarType</em> instead.</blockquote>")]
		public IfcReinforcingBarSurfaceEnum? BarSurface { get; set; }
	
	
		public IfcReinforcingBar(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcLabel? __SteelGrade, IfcPositiveLengthMeasure? __NominalDiameter, IfcAreaMeasure? __CrossSectionArea, IfcPositiveLengthMeasure? __BarLength, IfcReinforcingBarTypeEnum? __PredefinedType, IfcReinforcingBarSurfaceEnum? __BarSurface)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag, __SteelGrade)
		{
			this.NominalDiameter = __NominalDiameter;
			this.CrossSectionArea = __CrossSectionArea;
			this.BarLength = __BarLength;
			this.PredefinedType = __PredefinedType;
			this.BarSurface = __BarSurface;
		}
	
	
	}
	
}
