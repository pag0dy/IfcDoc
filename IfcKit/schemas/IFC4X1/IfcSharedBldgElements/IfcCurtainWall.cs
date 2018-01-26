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
	[Guid("3395e66f-bd77-4cce-a82f-4ccb81430e2c")]
	public partial class IfcCurtainWall : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCurtainWallTypeEnum? _PredefinedType;
	
	
		public IfcCurtainWall()
		{
		}
	
		public IfcCurtainWall(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcCurtainWallTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description(@"Predefined generic type for a curtain wall that is specified in an enumeration. There may be a property set given specificly for the predefined types.
	<blockquote class=""note"">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcCurtainWallType</em> is assigned, providing its own <em>IfcCurtainWallType.PredefinedType</em>.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  The attribute has been added at the end of the entity definition.</blockquote> ")]
		public IfcCurtainWallTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
