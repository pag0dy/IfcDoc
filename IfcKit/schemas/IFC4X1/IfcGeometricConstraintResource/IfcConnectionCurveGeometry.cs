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


namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("6198c9e5-dc6e-47b1-8fe3-b9ea5bef370e")]
	public partial class IfcConnectionCurveGeometry : IfcConnectionGeometry
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurveOrEdgeCurve _CurveOnRelatingElement;
	
		[DataMember(Order=1)] 
		IfcCurveOrEdgeCurve _CurveOnRelatedElement;
	
	
		public IfcConnectionCurveGeometry()
		{
		}
	
		public IfcConnectionCurveGeometry(IfcCurveOrEdgeCurve __CurveOnRelatingElement, IfcCurveOrEdgeCurve __CurveOnRelatedElement)
		{
			this._CurveOnRelatingElement = __CurveOnRelatingElement;
			this._CurveOnRelatedElement = __CurveOnRelatedElement;
		}
	
		[Description("The bounded curve at which the connected objects are aligned at the relating elem" +
	    "ent, given in the LCS of the relating element.")]
		public IfcCurveOrEdgeCurve CurveOnRelatingElement { get { return this._CurveOnRelatingElement; } set { this._CurveOnRelatingElement = value;} }
	
		[Description("The bounded curve at which the connected objects are aligned at the related eleme" +
	    "nt, given in the LCS of the related element. If the information is omitted, then" +
	    " the origin of the related element is used.")]
		public IfcCurveOrEdgeCurve CurveOnRelatedElement { get { return this._CurveOnRelatedElement; } set { this._CurveOnRelatedElement = value;} }
	
	
	}
	
}
