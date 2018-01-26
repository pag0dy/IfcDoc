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
	[Guid("6d0d3a21-1b3c-4595-bc9a-29ddd67199f4")]
	public partial class IfcChimney : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcChimneyTypeEnum? _PredefinedType;
	
	
		public IfcChimney()
		{
		}
	
		public IfcChimney(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcChimneyTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description(@"Predefined generic type for a chimney that is specified in an enumeration. There may be a property set given specificly for the predefined types.
	<blockquote class=""note"">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcChimneyType</em> is assigned, providing its own <em>IfcChimneyType.PredefinedType</em>.</blockquote> ")]
		public IfcChimneyTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
