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
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("538f2550-e0fc-4704-97f7-66d555de1ae4")]
	public abstract partial class IfcCsgPrimitive3D : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcGeometricModelResource.IfcBooleanOperand,
		BuildingSmart.IFC.IfcGeometricModelResource.IfcCsgSelect
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcAxis2Placement3D _Position;
	
	
		public IfcCsgPrimitive3D()
		{
		}
	
		public IfcCsgPrimitive3D(IfcAxis2Placement3D __Position)
		{
			this._Position = __Position;
		}
	
		[Description("The placement coordinate system to which the parameters of each individual CSG pr" +
	    "imitive apply.")]
		public IfcAxis2Placement3D Position { get { return this._Position; } set { this._Position = value;} }
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
