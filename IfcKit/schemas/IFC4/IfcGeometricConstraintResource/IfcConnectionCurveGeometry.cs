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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("58546e7a-38b4-4ba4-a065-faf5537acab6")]
	public partial class IfcConnectionCurveGeometry : IfcConnectionGeometry
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurveOrEdgeCurve _CurveOnRelatingElement;
	
		[DataMember(Order=1)] 
		IfcCurveOrEdgeCurve _CurveOnRelatedElement;
	
	
		[Description("The bounded curve at which the connected objects are aligned at the relating elem" +
	    "ent, given in the LCS of the relating element.")]
		public IfcCurveOrEdgeCurve CurveOnRelatingElement { get { return this._CurveOnRelatingElement; } set { this._CurveOnRelatingElement = value;} }
	
		[Description("The bounded curve at which the connected objects are aligned at the related eleme" +
	    "nt, given in the LCS of the related element. If the information is omitted, then" +
	    " the origin of the related element is used.")]
		public IfcCurveOrEdgeCurve CurveOnRelatedElement { get { return this._CurveOnRelatedElement; } set { this._CurveOnRelatedElement = value;} }
	
	
	}
	
}
