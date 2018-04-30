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
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcConnectionPortGeometry : IfcConnectionGeometry
	{
		[DataMember(Order = 0)] 
		[Description("Local placement of the port relative to its distribution element's local placement. The element in question is that, which plays the role of the relating element in the connectivity relationship. ")]
		[Required()]
		public IfcAxis2Placement LocationAtRelatingElement { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Local placement of the port relative to its distribution element's local placement. The element in question is that, which plays the role of the related element in the connectivity relationship. ")]
		public IfcAxis2Placement LocationAtRelatedElement { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Profile that defines the port connection geometry. It is placed inside the XY plane of the location, given at the relating and (optionally) related distribution element.")]
		[Required()]
		public IfcProfileDef ProfileOfPort { get; set; }
	
	
		public IfcConnectionPortGeometry(IfcAxis2Placement __LocationAtRelatingElement, IfcAxis2Placement __LocationAtRelatedElement, IfcProfileDef __ProfileOfPort)
		{
			this.LocationAtRelatingElement = __LocationAtRelatingElement;
			this.LocationAtRelatedElement = __LocationAtRelatedElement;
			this.ProfileOfPort = __ProfileOfPort;
		}
	
	
	}
	
}
