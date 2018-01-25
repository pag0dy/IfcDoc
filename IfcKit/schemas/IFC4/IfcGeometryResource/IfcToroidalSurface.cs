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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("48f9b867-ec04-4a55-9138-f52b74f1b60e")]
	public partial class IfcToroidalSurface : IfcElementarySurface
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _MajorRadius;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _MinorRadius;
	
	
		[Description("The major radius of the torus.")]
		public IfcPositiveLengthMeasure MajorRadius { get { return this._MajorRadius; } set { this._MajorRadius = value;} }
	
		[Description("The minor radius of the torus.")]
		public IfcPositiveLengthMeasure MinorRadius { get { return this._MinorRadius; } set { this._MinorRadius = value;} }
	
	
	}
	
}
