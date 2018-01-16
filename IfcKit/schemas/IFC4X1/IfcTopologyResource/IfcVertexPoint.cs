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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("77f373d7-e77d-410a-a47e-47b03b73fc39")]
	public partial class IfcVertexPoint : IfcVertex,
		BuildingSmart.IFC.IfcGeometricConstraintResource.IfcPointOrVertexPoint
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcPoint _VertexGeometry;
	
	
		[Description("The geometric point, which defines the position in geometric space of the vertex." +
	    "")]
		public IfcPoint VertexGeometry { get { return this._VertexGeometry; } set { this._VertexGeometry = value;} }
	
	
	}
	
}
