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

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("d6a01043-67e3-44ca-af7e-8083992016d5")]
	public partial class IfcConnectionPointEccentricity : IfcConnectionPointGeometry
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLengthMeasure? _EccentricityInX;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLengthMeasure? _EccentricityInY;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLengthMeasure? _EccentricityInZ;
	
	
		public IfcConnectionPointEccentricity()
		{
		}
	
		public IfcConnectionPointEccentricity(IfcPointOrVertexPoint __PointOnRelatingElement, IfcPointOrVertexPoint __PointOnRelatedElement, IfcLengthMeasure? __EccentricityInX, IfcLengthMeasure? __EccentricityInY, IfcLengthMeasure? __EccentricityInZ)
			: base(__PointOnRelatingElement, __PointOnRelatedElement)
		{
			this._EccentricityInX = __EccentricityInX;
			this._EccentricityInY = __EccentricityInY;
			this._EccentricityInZ = __EccentricityInZ;
		}
	
		[Description("<EPM-HTML>\r\nDistance in x direction between the two points (or vertex points) eng" +
	    "aged in the point connection.\r\n</EPM-HTML>")]
		public IfcLengthMeasure? EccentricityInX { get { return this._EccentricityInX; } set { this._EccentricityInX = value;} }
	
		[Description("<EPM-HTML>\r\nDistance in y direction between the two points (or vertex points) eng" +
	    "aged in the point connection.\r\n</EPM-HTML>")]
		public IfcLengthMeasure? EccentricityInY { get { return this._EccentricityInY; } set { this._EccentricityInY = value;} }
	
		[Description("<EPM-HTML>\r\nDistance in z direction between the two points (or vertex points) eng" +
	    "aged in the point connection.\r\n</EPM-HTML>")]
		public IfcLengthMeasure? EccentricityInZ { get { return this._EccentricityInZ; } set { this._EccentricityInZ = value;} }
	
	
	}
	
}
