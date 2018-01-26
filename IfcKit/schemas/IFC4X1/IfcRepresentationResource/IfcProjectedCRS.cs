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

using BuildingSmart.IFC.IfcMeasureResource;

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
		[XmlElement]
		IfcNamedUnit _MapUnit;
	
	
		public IfcProjectedCRS()
		{
		}
	
		public IfcProjectedCRS(IfcLabel __Name, IfcText? __Description, IfcIdentifier? __GeodeticDatum, IfcIdentifier? __VerticalDatum, IfcIdentifier? __MapProjection, IfcIdentifier? __MapZone, IfcNamedUnit __MapUnit)
			: base(__Name, __Description, __GeodeticDatum, __VerticalDatum)
		{
			this._MapProjection = __MapProjection;
			this._MapZone = __MapZone;
			this._MapUnit = __MapUnit;
		}
	
		[Description("Name by which the map projection is identified.\r\n\r\n<blockquote class=\"examples\">E" +
	    "XAMPLE&nbsp; map projects include:\r\n<ul class=\"note\">\r\n  <li class=\"note\">UTM</l" +
	    "i>\r\n  <li class=\"note\">Gaus-Krueger</li>\r\n</ul>")]
		public IfcIdentifier? MapProjection { get { return this._MapProjection; } set { this._MapProjection = value;} }
	
		[Description(@"Name by which the map zone, relating to the <em>MapProjection</em>, is identified. 
	
	<blockquote class=""examples"">EXAMPLE&nbsp;
	<ul class=""note"">
	  <li class=""note"">for UTM, the zone number, like 32 for UTM32</li>
	  <li class=""note"">for Gaus-Krueger, the zones of longitudinal width, like 3'</li>
	</ul>
	</blockquote>")]
		public IfcIdentifier? MapZone { get { return this._MapZone; } set { this._MapZone = value;} }
	
		[Description("Unit of the coordinate axes composing the map coordinate system.\r\n<blockquote cla" +
	    "ss=\"note\">NOTE&nbsp; Only length measures are in scope and all two or three axes" +
	    " of the map coordinate system shall have the same length unit.</blockquote>")]
		public IfcNamedUnit MapUnit { get { return this._MapUnit; } set { this._MapUnit = value;} }
	
	
	}
	
}
