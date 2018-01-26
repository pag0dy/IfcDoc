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
	[Guid("89838619-890c-4334-86ee-ea4fbc8a7c89")]
	public partial class IfcConnectionPointGeometry : IfcConnectionGeometry
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcPointOrVertexPoint _PointOnRelatingElement;
	
		[DataMember(Order=1)] 
		IfcPointOrVertexPoint _PointOnRelatedElement;
	
	
		public IfcConnectionPointGeometry()
		{
		}
	
		public IfcConnectionPointGeometry(IfcPointOrVertexPoint __PointOnRelatingElement, IfcPointOrVertexPoint __PointOnRelatedElement)
		{
			this._PointOnRelatingElement = __PointOnRelatingElement;
			this._PointOnRelatedElement = __PointOnRelatedElement;
		}
	
		[Description("Point at which the connected object is aligned at the relating element, given in " +
	    "the LCS of the relating element.")]
		public IfcPointOrVertexPoint PointOnRelatingElement { get { return this._PointOnRelatingElement; } set { this._PointOnRelatingElement = value;} }
	
		[Description("Point at which connected objects are aligned at the related element, given in the" +
	    " LCS of the related element. If the information is omitted, then the origin of t" +
	    "he related element is used.\r\n")]
		public IfcPointOrVertexPoint PointOnRelatedElement { get { return this._PointOnRelatedElement; } set { this._PointOnRelatedElement = value;} }
	
	
	}
	
}
