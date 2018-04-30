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
	public partial class IfcConnectionPointGeometry : IfcConnectionGeometry
	{
		[DataMember(Order = 0)] 
		[Description("Point at which the connected object is aligned at the relating element, given in the LCS of the relating element.")]
		[Required()]
		public IfcPointOrVertexPoint PointOnRelatingElement { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Point at which connected objects are aligned at the related element, given in the LCS of the related element. If the information is omitted, then the origin of the related element is used.  ")]
		public IfcPointOrVertexPoint PointOnRelatedElement { get; set; }
	
	
		public IfcConnectionPointGeometry(IfcPointOrVertexPoint __PointOnRelatingElement, IfcPointOrVertexPoint __PointOnRelatedElement)
		{
			this.PointOnRelatingElement = __PointOnRelatingElement;
			this.PointOnRelatedElement = __PointOnRelatedElement;
		}
	
	
	}
	
}
