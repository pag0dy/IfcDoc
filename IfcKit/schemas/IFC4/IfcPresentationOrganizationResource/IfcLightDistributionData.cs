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
	[Guid("cffe9f24-4de2-4238-8448-856d95446876")]
	public partial class IfcLightDistributionData
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPlaneAngleMeasure _MainPlaneAngle;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IList<IfcPlaneAngleMeasure> _SecondaryPlaneAngle = new List<IfcPlaneAngleMeasure>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IList<IfcLuminousIntensityDistributionMeasure> _LuminousIntensity = new List<IfcLuminousIntensityDistributionMeasure>();
	
	
		[Description("The main plane angle (A, B or C angles, according to the light distribution curve" +
	    " chosen).")]
		public IfcPlaneAngleMeasure MainPlaneAngle { get { return this._MainPlaneAngle; } set { this._MainPlaneAngle = value;} }
	
		[Description(@"<EPM-HTML>
	<p>The list of secondary plane angles (the &#945;, &#946; or &#947; angles) according to the light distribution curve chosen.
	</p>
	<blockquote class=""note"">NOTE&nbsp; The <em>SecondaryPlaneAngle</em> and <em>LuminousIntensity</em> lists are corresponding lists.
	</blockquote>
	</EPM-HTML>")]
		public IList<IfcPlaneAngleMeasure> SecondaryPlaneAngle { get { return this._SecondaryPlaneAngle; } }
	
		[Description("The luminous intensity distribution measure for this pair of main and secondary p" +
	    "lane angles according to the light distribution curve chosen.")]
		public IList<IfcLuminousIntensityDistributionMeasure> LuminousIntensity { get { return this._LuminousIntensity; } }
	
	
	}
	
}
