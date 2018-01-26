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
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("21ce7129-20ff-438a-bb0c-04ff211bddf4")]
	public partial class IfcRamp : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcRampTypeEnum? _PredefinedType;
	
	
		public IfcRamp()
		{
		}
	
		public IfcRamp(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcRampTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description(@"Predefined generic types for a ramp that are specified in an enumeration. There may be a property set given for the predefined types.
	<blockquote class=""note"">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcRampType</em> is assigned, providing its own <em>IfcRampType.PredefinedType</em>.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  The attribute has been renamed from ShapeType and changed to be OPTIONAL with upward compatibility for file based exchange.</blockquote>")]
		public IfcRampTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
