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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("03421a5b-09f0-4284-a397-06d83f4f7684")]
	public partial class IfcProjectedCRS : IfcCoordinateReferenceSystem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _MapProjection;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcIdentifier? _MapZone;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcNamedUnit")]
		IfcNamedUnit _MapUnit;
	
	
		[Description("<EPM-HTML>Name by which the map projection is identified.\r\n<ul>\r\n  <li>UTM</li>\r\n" +
	    "  <li>Gaus-Krueger</li>\r\n</ul>\r\n</EPM-HTML>")]
		public IfcIdentifier? MapProjection { get { return this._MapProjection; } set { this._MapProjection = value;} }
	
		[Description(@"<EPM-HTML>Name by which the map zone, relating to the <em>MapProjection</em>, is identified. Examples are
	<ul>
	  <li>for UTM, the zone number, like 32 for UTM32</li>
	  <li>for Gaus-Krueger, the zones of longitudinal width, like 3'</li>
	</ul>
	</EPM-HTML>")]
		public IfcIdentifier? MapZone { get { return this._MapZone; } set { this._MapZone = value;} }
	
		[Description(@"<EPM-HTML>Unit of the coordinate axes composing the map coordinate system.
	<blockquote class=""note"">NOTE&nbsp; Only length measures are in scope and all two or three axes of the map coordinate system shall have the same length unit.</blockquote>
	</EPM-HTML>")]
		public IfcNamedUnit MapUnit { get { return this._MapUnit; } set { this._MapUnit = value;} }
	
	
	}
	
}
