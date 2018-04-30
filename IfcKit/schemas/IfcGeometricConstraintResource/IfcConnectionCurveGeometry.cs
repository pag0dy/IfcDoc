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


namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcConnectionCurveGeometry : IfcConnectionGeometry
	{
		[DataMember(Order = 0)] 
		[Description("The bounded curve at which the connected objects are aligned at the relating element, given in the LCS of the relating element.")]
		[Required()]
		public IfcCurveOrEdgeCurve CurveOnRelatingElement { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The bounded curve at which the connected objects are aligned at the related element, given in the LCS of the related element. If the information is omitted, then the origin of the related element is used.")]
		public IfcCurveOrEdgeCurve CurveOnRelatedElement { get; set; }
	
	
		public IfcConnectionCurveGeometry(IfcCurveOrEdgeCurve __CurveOnRelatingElement, IfcCurveOrEdgeCurve __CurveOnRelatedElement)
		{
			this.CurveOnRelatingElement = __CurveOnRelatingElement;
			this.CurveOnRelatedElement = __CurveOnRelatedElement;
		}
	
	
	}
	
}
