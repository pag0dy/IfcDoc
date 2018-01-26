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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("3b2d3faf-1d40-4dc0-807c-776a64e582ad")]
	public abstract partial class IfcLinearPositioningElement : IfcPositioningElement
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurve _Axis;
	
	
		public IfcLinearPositioningElement()
		{
		}
	
		public IfcLinearPositioningElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcCurve __Axis)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this._Axis = __Axis;
		}
	
		[Description("The curve to be used for positioning.")]
		public IfcCurve Axis { get { return this._Axis; } set { this._Axis = value;} }
	
	
	}
	
}
