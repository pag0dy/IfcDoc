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

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	public partial class IfcLightDistributionData
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The main plane angle (A, B or C angles, according to the light distribution curve chosen).")]
		[Required()]
		public IfcPlaneAngleMeasure MainPlaneAngle { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("<p>The list of secondary plane angles (the &#945;, &#946; or &#947; angles) according to the light distribution curve chosen.  </p>  <blockquote class=\"note\">NOTE&nbsp; The <em>SecondaryPlaneAngle</em> and <em>LuminousIntensity</em> lists are corresponding lists.  </blockquote>")]
		[Required()]
		[MinLength(1)]
		public IList<IfcPlaneAngleMeasure> SecondaryPlaneAngle { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The luminous intensity distribution measure for this pair of main and secondary plane angles according to the light distribution curve chosen.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcLuminousIntensityDistributionMeasure> LuminousIntensity { get; protected set; }
	
	
		public IfcLightDistributionData(IfcPlaneAngleMeasure __MainPlaneAngle, IfcPlaneAngleMeasure[] __SecondaryPlaneAngle, IfcLuminousIntensityDistributionMeasure[] __LuminousIntensity)
		{
			this.MainPlaneAngle = __MainPlaneAngle;
			this.SecondaryPlaneAngle = new List<IfcPlaneAngleMeasure>(__SecondaryPlaneAngle);
			this.LuminousIntensity = new List<IfcLuminousIntensityDistributionMeasure>(__LuminousIntensity);
		}
	
	
	}
	
}
