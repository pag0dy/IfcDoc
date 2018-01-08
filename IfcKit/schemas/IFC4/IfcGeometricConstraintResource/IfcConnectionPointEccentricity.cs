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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("bdf3901b-3ab4-45b6-805b-4eebca105729")]
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
