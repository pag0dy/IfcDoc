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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	public partial class IfcLightSourceSpot : IfcLightSourcePositional
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Definition from ISO/CD 10303-46:1992: This is the direction of the axis of the cone of the light source specified in the coordinate space of the representation being projected..  Definition from VRML97 - ISO/IEC 14772-1:1997: The direction field specifies the direction vector of the light's central axis defined in the local coordinate system.  ")]
		[Required()]
		public IfcDirection Orientation { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Definition from ISO/CD 10303-46:1992: This real is the exponent on the cosine of the angle between the line that starts at the position of the spot light source and is in the direction of the orientation of the spot light source and a line that starts at the position of the spot light source and goes through a point on the surface being shaded.  NOTE&nbsp; This attribute does not exists in ISO/IEC 14772-1:1997.")]
		public IfcReal? ConcentrationExponent { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Definition from ISO/CD 10303-46:1992: This planar angle measure is the angle between the line that starts at the position of the spot light source and is in the direction of the spot light source and any line on the boundary of the cone of influence.  Definition from VRML97 - ISO/IEC 14772-1:1997: The cutOffAngle (name of spread angle in VRML) field specifies the outer bound of the solid angle. The light source does not emit light outside of this solid angle.  ")]
		[Required()]
		public IfcPositivePlaneAngleMeasure SpreadAngle { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Definition from VRML97 - ISO/IEC 14772-1:1997: The beamWidth field specifies an inner solid angle in which the light source emits light at uniform full intensity. The light source's emission intensity drops off from the inner solid angle (beamWidthAngle) to the outer solid angle (spreadAngle).  ")]
		[Required()]
		public IfcPositivePlaneAngleMeasure BeamWidthAngle { get; set; }
	
	
		public IfcLightSourceSpot(IfcLabel? __Name, IfcColourRgb __LightColour, IfcNormalisedRatioMeasure? __AmbientIntensity, IfcNormalisedRatioMeasure? __Intensity, IfcCartesianPoint __Position, IfcPositiveLengthMeasure __Radius, IfcReal __ConstantAttenuation, IfcReal __DistanceAttenuation, IfcReal __QuadricAttenuation, IfcDirection __Orientation, IfcReal? __ConcentrationExponent, IfcPositivePlaneAngleMeasure __SpreadAngle, IfcPositivePlaneAngleMeasure __BeamWidthAngle)
			: base(__Name, __LightColour, __AmbientIntensity, __Intensity, __Position, __Radius, __ConstantAttenuation, __DistanceAttenuation, __QuadricAttenuation)
		{
			this.Orientation = __Orientation;
			this.ConcentrationExponent = __ConcentrationExponent;
			this.SpreadAngle = __SpreadAngle;
			this.BeamWidthAngle = __BeamWidthAngle;
		}
	
	
	}
	
}
