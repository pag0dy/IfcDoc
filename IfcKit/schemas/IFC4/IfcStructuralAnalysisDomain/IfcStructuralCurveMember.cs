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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("b0527d1a-798c-4134-b9f1-056c3d7650af")]
	public partial class IfcStructuralCurveMember : IfcStructuralMember
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcStructuralCurveMemberTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcDirection")]
		[Required()]
		IfcDirection _Axis;
	
	
		[Description("Type of member with respect to its load carrying behavior in this analysis ideali" +
	    "zation.")]
		public IfcStructuralCurveMemberTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"Direction which is used in the definition of the local z axis.  <em>Axis</em> is specified relative to the so-called global coordinate system, i.e. the <em>SELF\IfcProduct.ObjectPlacement</em>.
	
	<blockquote class=""note"">NOTE&nbsp; It is desirable and usually possible that many instances of <em>IfcStructuralCurveConnection</em> and <em>IfcStructuralCurveMember</em> share a common instance of <em>IfcDirection</em> as their <em>Axis</em> attribute.</blockquote>")]
		public IfcDirection Axis { get { return this._Axis; } set { this._Axis = value;} }
	
	
	}
	
}
