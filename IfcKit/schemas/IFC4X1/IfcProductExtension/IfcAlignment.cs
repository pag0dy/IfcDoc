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
	[Guid("f0f46021-4b22-4e3c-9d17-8854d90a4457")]
	public partial class IfcAlignment : IfcLinearPositioningElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcAlignmentTypeEnum? _PredefinedType;
	
	
		public IfcAlignment()
		{
		}
	
		public IfcAlignment(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcCurve __Axis, IfcAlignmentTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Axis)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Predefined generic types for an alignment that are specified in an enumeration. \r" +
	    "\n<blockquote class=\"note\">NOTE&nbsp; This attribute is reserved for future use.<" +
	    "/blockquote>")]
		public IfcAlignmentTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
