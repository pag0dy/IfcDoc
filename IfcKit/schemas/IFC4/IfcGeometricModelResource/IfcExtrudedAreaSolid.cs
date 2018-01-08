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
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("f65777d3-6cb6-48f6-8a26-d79b570cdfb2")]
	public partial class IfcExtrudedAreaSolid : IfcSweptAreaSolid
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcDirection")]
		[Required()]
		IfcDirection _ExtrudedDirection;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Depth;
	
	
		[Description("<EPM-HTML>\r\nThe direction in which the surface, provided by <em>SweptArea</em> is" +
	    " to be swept.\r\n</EPM-HTML>")]
		public IfcDirection ExtrudedDirection { get { return this._ExtrudedDirection; } set { this._ExtrudedDirection = value;} }
	
		[Description("<EPM-HTML>\r\nThe distance the surface is to be swept along the <em>ExtrudedDirecti" +
	    "on</em>\r\n</EPM-HTML>.")]
		public IfcPositiveLengthMeasure Depth { get { return this._Depth; } set { this._Depth = value;} }
	
	
	}
	
}
