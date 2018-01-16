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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("4eb98543-6244-4c9d-b40a-05b26a73efe2")]
	public partial class IfcVertexPoint : IfcVertex,
		BuildingSmart.IFC.IfcGeometricConstraintResource.IfcPointOrVertexPoint
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcPoint _VertexGeometry;
	
	
		[Description("The geometric point, which defines the position in geometric space of the vertex." +
	    "")]
		public IfcPoint VertexGeometry { get { return this._VertexGeometry; } set { this._VertexGeometry = value;} }
	
	
	}
	
}
