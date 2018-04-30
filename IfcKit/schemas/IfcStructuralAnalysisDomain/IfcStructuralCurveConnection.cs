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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public partial class IfcStructuralCurveConnection : IfcStructuralConnection
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Direction which is used in the definition of the local z axis.  <em>Axis</em> is specified relative to the so-called global coordinate system, i.e. the <em>SELF\\IfcProduct.ObjectPlacement</em>.    <blockquote class=\"note\">NOTE&nbsp; It is desirable and usually possible that many instances of <em>IfcStructuralCurveConnection</em> and <em>IfcStructuralCurveMember</em> share a common instance of <em>IfcDirection</em> as their <em>Axis</em> attribute.</blockquote>")]
		[Required()]
		public IfcDirection Axis { get; set; }
	
	
		public IfcStructuralCurveConnection(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcBoundaryCondition __AppliedCondition, IfcDirection __Axis)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __AppliedCondition)
		{
			this.Axis = __Axis;
		}
	
	
	}
	
}
