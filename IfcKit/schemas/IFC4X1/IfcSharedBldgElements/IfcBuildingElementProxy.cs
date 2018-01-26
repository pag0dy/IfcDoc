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
	[Guid("3e4aa4b8-2c66-482c-8c4a-6913d68fc480")]
	public partial class IfcBuildingElementProxy : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcBuildingElementProxyTypeEnum? _PredefinedType;
	
	
		public IfcBuildingElementProxy()
		{
		}
	
		public IfcBuildingElementProxy(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcBuildingElementProxyTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description(@"Predefined generic type for a building element proxy that is specified in an enumeration. There may be a property set given specificly for the predefined types.
	<blockquote class=""note"">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcBuildingElementProxyType</em> is assigned, providing its own <em>IfcBuildingElementProxyType.PredefinedType</em>.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute <em>CompositionType</em> has been replaced by <em>PredefinedType</em>, being a superset of the enumerators.</blockquote>")]
		public IfcBuildingElementProxyTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
