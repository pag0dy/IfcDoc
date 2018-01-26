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
using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	[Guid("d92a896f-aee3-4a47-96d4-944a079645b4")]
	public partial class IfcLightSourcePositional : IfcLightSource
	{
		[DataMember(Order=0)] 
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
	
	
		public IfcLightSourcePositional()
		{
		}
	
		public IfcLightSourcePositional(IfcLabel? __Name, IfcColourRgb __LightColour, IfcNormalisedRatioMeasure? __AmbientIntensity, IfcNormalisedRatioMeasure? __Intensity, IfcCartesianPoint __Position, IfcPositiveLengthMeasure __Radius, IfcReal __ConstantAttenuation, IfcReal __DistanceAttenuation, IfcReal __QuadricAttenuation)
			: base(__Name, __LightColour, __AmbientIntensity, __Intensity)
		{
			this._Position = __Position;
			this._Radius = __Radius;
			this._ConstantAttenuation = __ConstantAttenuation;
			this._DistanceAttenuation = __DistanceAttenuation;
			this._QuadricAttenuation = __QuadricAttenuation;
		}
	
		[Description("Definition from ISO/CD 10303-46:1992: The Cartesian point indicates the position " +
	    "of the light source.\r\nDefinition from VRML97 - ISO/IEC 14772-1:1997: A Point lig" +
	    "ht node illuminates geometry within radius of its location.\r\n")]
		public IfcCartesianPoint Position { get { return this._Position; } set { this._Position = value;} }
	
		[Description("Definition from IAI: The maximum distance from the light source for a surface sti" +
	    "ll to be illuminated.\r\nDefinition from VRML97 - ISO/IEC 14772-1:1997: A Point li" +
	    "ght node illuminates geometry within radius of its location.\r\n")]
		public IfcPositiveLengthMeasure Radius { get { return this._Radius; } set { this._Radius = value;} }
	
		[Description("Definition from ISO/CD 10303-46:1992: This real indicates the value of the attenu" +
	    "ation in the lighting equation that is constant.\r\n")]
		public IfcReal ConstantAttenuation { get { return this._ConstantAttenuation; } set { this._ConstantAttenuation = value;} }
	
		[Description("Definition from ISO/CD 10303-46:1992: This real indicates the value of the attenu" +
	    "ation in the lighting equation that proportional to the distance from the light " +
	    "source.\r\n")]
		public IfcReal DistanceAttenuation { get { return this._DistanceAttenuation; } set { this._DistanceAttenuation = value;} }
	
		[Description("Definition from the IAI: This real indicates the value of the attenuation in the " +
	    "lighting equation that proportional to the square value of the distance from the" +
	    " light source.\r\n")]
		public IfcReal QuadricAttenuation { get { return this._QuadricAttenuation; } set { this._QuadricAttenuation = value;} }
	
	
	}
	
}
