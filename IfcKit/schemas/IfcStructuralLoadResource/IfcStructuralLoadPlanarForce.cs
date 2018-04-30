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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	public partial class IfcStructuralLoadPlanarForce : IfcStructuralLoadStatic
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Planar force value in x-direction. ")]
		public IfcPlanarForceMeasure? PlanarForceX { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Planar force value in y-direction. ")]
		public IfcPlanarForceMeasure? PlanarForceY { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Planar force value in z-direction. ")]
		public IfcPlanarForceMeasure? PlanarForceZ { get; set; }
	
	
		public IfcStructuralLoadPlanarForce(IfcLabel? __Name, IfcPlanarForceMeasure? __PlanarForceX, IfcPlanarForceMeasure? __PlanarForceY, IfcPlanarForceMeasure? __PlanarForceZ)
			: base(__Name)
		{
			this.PlanarForceX = __PlanarForceX;
			this.PlanarForceY = __PlanarForceY;
			this.PlanarForceZ = __PlanarForceZ;
		}
	
	
	}
	
}
