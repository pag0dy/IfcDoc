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
	[Guid("98e999e6-cab0-446f-86bd-30e7ff79f6bc")]
	public partial class IfcConnectionPortGeometry : IfcConnectionGeometry
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAxis2Placement _LocationAtRelatingElement;
	
		[DataMember(Order=1)] 
		IfcAxis2Placement _LocationAtRelatedElement;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcProfileDef _ProfileOfPort;
	
	
		[Description("Local placement of the port relative to its distribution element\'s local placemen" +
	    "t. The element in question is that, which plays the role of the relating element" +
	    " in the connectivity relationship. ")]
		public IfcAxis2Placement LocationAtRelatingElement { get { return this._LocationAtRelatingElement; } set { this._LocationAtRelatingElement = value;} }
	
		[Description("Local placement of the port relative to its distribution element\'s local placemen" +
	    "t. The element in question is that, which plays the role of the related element " +
	    "in the connectivity relationship. ")]
		public IfcAxis2Placement LocationAtRelatedElement { get { return this._LocationAtRelatedElement; } set { this._LocationAtRelatedElement = value;} }
	
		[Description("Profile that defines the port connection geometry. It is placed inside the XY pla" +
	    "ne of the location, given at the relating and (optionally) related distribution " +
	    "element.")]
		public IfcProfileDef ProfileOfPort { get { return this._ProfileOfPort; } set { this._ProfileOfPort = value;} }
	
	
	}
	
}
