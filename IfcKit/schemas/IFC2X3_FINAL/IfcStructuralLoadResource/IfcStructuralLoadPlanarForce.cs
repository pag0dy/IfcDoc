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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	[Guid("3ac88bd0-26de-492f-ba1e-663054a0c2e2")]
	public partial class IfcStructuralLoadPlanarForce : IfcStructuralLoadStatic
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPlanarForceMeasure? _PlanarForceX;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPlanarForceMeasure? _PlanarForceY;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPlanarForceMeasure? _PlanarForceZ;
	
	
		public IfcStructuralLoadPlanarForce()
		{
		}
	
		public IfcStructuralLoadPlanarForce(IfcLabel? __Name, IfcPlanarForceMeasure? __PlanarForceX, IfcPlanarForceMeasure? __PlanarForceY, IfcPlanarForceMeasure? __PlanarForceZ)
			: base(__Name)
		{
			this._PlanarForceX = __PlanarForceX;
			this._PlanarForceY = __PlanarForceY;
			this._PlanarForceZ = __PlanarForceZ;
		}
	
		[Description("Planar force value in x-direction. ")]
		public IfcPlanarForceMeasure? PlanarForceX { get { return this._PlanarForceX; } set { this._PlanarForceX = value;} }
	
		[Description("Planar force value in y-direction. ")]
		public IfcPlanarForceMeasure? PlanarForceY { get { return this._PlanarForceY; } set { this._PlanarForceY = value;} }
	
		[Description("Planar force value in z-direction. ")]
		public IfcPlanarForceMeasure? PlanarForceZ { get { return this._PlanarForceZ; } set { this._PlanarForceZ = value;} }
	
	
	}
	
}
