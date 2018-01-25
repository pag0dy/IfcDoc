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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	[Guid("32a170a7-e0ba-48c0-9f27-f2a1df1265d0")]
	public partial class IfcLightSourcePositional : IfcLightSource
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcCartesianPoint")]
		[Required()]
		IfcCartesianPoint _Position;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Radius;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcReal _ConstantAttenuation;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcReal _DistanceAttenuation;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcReal _QuadricAttenuation;
	
	
		[Description("Definition from ISO/CD 10303-46:1992: The Cartesian point indicates the position " +
	    "of the light source.\r\nDefinition from VRML97 - ISO/IEC 14772-1:1997: A Point lig" +
	    "ht node illuminates geometry within radius of its location.\r\n")]
		public IfcCartesianPoint Position { get { return this._Position; } set { this._Position = value;} }
	
		[Description("The maximum distance from the light source for a surface still to be illuminated." +
	    "\r\nDefinition from VRML97 - ISO/IEC 14772-1:1997: A Point light node illuminates " +
	    "geometry within radius of its location.\r\n")]
		public IfcPositiveLengthMeasure Radius { get { return this._Radius; } set { this._Radius = value;} }
	
		[Description("Definition from ISO/CD 10303-46:1992: This real indicates the value of the attenu" +
	    "ation in the lighting equation that is constant.\r\n")]
		public IfcReal ConstantAttenuation { get { return this._ConstantAttenuation; } set { this._ConstantAttenuation = value;} }
	
		[Description("Definition from ISO/CD 10303-46:1992: This real indicates the value of the attenu" +
	    "ation in the lighting equation that proportional to the distance from the light " +
	    "source.\r\n")]
		public IfcReal DistanceAttenuation { get { return this._DistanceAttenuation; } set { this._DistanceAttenuation = value;} }
	
		[Description("This real indicates the value of the attenuation in the lighting equation that pr" +
	    "oportional to the square value of the distance from the light source.\r\n")]
		public IfcReal QuadricAttenuation { get { return this._QuadricAttenuation; } set { this._QuadricAttenuation = value;} }
	
	
	}
	
}
