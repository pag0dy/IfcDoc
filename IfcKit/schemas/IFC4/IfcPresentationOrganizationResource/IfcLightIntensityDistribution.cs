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
	[Guid("bb394b9d-6446-4af5-b07e-add47d8c8b54")]
	public partial class IfcLightIntensityDistribution :
		BuildingSmart.IFC.IfcPresentationOrganizationResource.IfcLightDistributionDataSourceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLightDistributionCurveEnum _LightDistributionCurve;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcLightDistributionData> _DistributionData = new List<IfcLightDistributionData>();
	
	
		[Description("Standardized  light distribution curve used to define the luminous intensity of t" +
	    "he light in all directions.")]
		public IfcLightDistributionCurveEnum LightDistributionCurve { get { return this._LightDistributionCurve; } set { this._LightDistributionCurve = value;} }
	
		[Description(@"<p>Light distribution data applied to the light source. It is defined by a list of main plane angles (B or C according to the light distribution curve chosen) that includes (for each B or C angle) a second list of secondary plane angles (the &#946; or &#947; angles) and the according luminous intensity distribution measures.
	</p>")]
		public IList<IfcLightDistributionData> DistributionData { get { return this._DistributionData; } }
	
	
	}
	
}
