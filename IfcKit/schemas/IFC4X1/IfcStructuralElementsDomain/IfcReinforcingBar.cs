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
	[Guid("32b47fe2-32c4-4ac2-8217-42fe8d2afda9")]
	public partial class IfcReinforcingBar : IfcReinforcingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _NominalDiameter;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcAreaMeasure? _CrossSectionArea;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _BarLength;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcReinforcingBarTypeEnum? _PredefinedType;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcReinforcingBarSurfaceEnum? _BarSurface;
	
	
		public IfcReinforcingBar()
		{
		}
	
		public IfcReinforcingBar(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcLabel? __SteelGrade, IfcPositiveLengthMeasure? __NominalDiameter, IfcAreaMeasure? __CrossSectionArea, IfcPositiveLengthMeasure? __BarLength, IfcReinforcingBarTypeEnum? __PredefinedType, IfcReinforcingBarSurfaceEnum? __BarSurface)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag, __SteelGrade)
		{
			this._NominalDiameter = __NominalDiameter;
			this._CrossSectionArea = __CrossSectionArea;
			this._BarLength = __BarLength;
			this._PredefinedType = __PredefinedType;
			this._BarSurface = __BarSurface;
		}
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made" +
	    " optional and deprecated.  Use respective attribute at <em>IfcReinforcingBarType" +
	    "</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? NominalDiameter { get { return this._NominalDiameter; } set { this._NominalDiameter = value;} }
	
		[Description("The effective cross-section area of the reinforcing bar or group of bars.\r\n\r\n<blo" +
	    "ckquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional.</blockq" +
	    "uote>")]
		public IfcAreaMeasure? CrossSectionArea { get { return this._CrossSectionArea; } set { this._CrossSectionArea = value;} }
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute depr" +
	    "ecated.  Use respective attribute at <em>IfcReinforcingBarType</em> instead.</bl" +
	    "ockquote>")]
		public IfcPositiveLengthMeasure? BarLength { get { return this._BarLength; } set { this._BarLength = value;} }
	
		[Description(@"The role, purpose or usage of the bar, i.e. the kind of loads and stresses it is intended to carry.
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; Attribute renamed from <em>BarRole</em> to <em>PredefinedType</em> and made optional.  Type changed from <em>IfcReinforcingBarRoleEnum</em> without changes to the range of enumeration items.</blockquote>")]
		public IfcReinforcingBarTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made" +
	    " optional and deprecated.  Use respective attribute at <em>IfcReinforcingBarType" +
	    "</em> instead.</blockquote>")]
		public IfcReinforcingBarSurfaceEnum? BarSurface { get { return this._BarSurface; } set { this._BarSurface = value;} }
	
	
	}
	
}
