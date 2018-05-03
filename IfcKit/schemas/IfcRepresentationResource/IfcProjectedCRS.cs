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

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	public partial class IfcProjectedCRS : IfcCoordinateReferenceSystem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Name by which the map projection is identified.    <blockquote class=\"examples\">EXAMPLE&nbsp; map projects include:  <ul class=\"note\">    <li class=\"note\">UTM</li>    <li class=\"note\">Gaus-Krueger</li>  </ul>")]
		public IfcIdentifier? MapProjection { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Name by which the map zone, relating to the <em>MapProjection</em>, is identified.     <blockquote class=\"examples\">EXAMPLE&nbsp;  <ul class=\"note\">    <li class=\"note\">for UTM, the zone number, like 32 for UTM32</li>    <li class=\"note\">for Gaus-Krueger, the zones of longitudinal width, like 3'</li>  </ul>  </blockquote>")]
		public IfcIdentifier? MapZone { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("Unit of the coordinate axes composing the map coordinate system.  <blockquote class=\"note\">NOTE&nbsp; Only length measures are in scope and all two or three axes of the map coordinate system shall have the same length unit.</blockquote>")]
		public IfcNamedUnit MapUnit { get; set; }
	
	
		public IfcProjectedCRS(IfcLabel __Name, IfcText? __Description, IfcIdentifier? __GeodeticDatum, IfcIdentifier? __VerticalDatum, IfcIdentifier? __MapProjection, IfcIdentifier? __MapZone, IfcNamedUnit __MapUnit)
			: base(__Name, __Description, __GeodeticDatum, __VerticalDatum)
		{
			this.MapProjection = __MapProjection;
			this.MapZone = __MapZone;
			this.MapUnit = __MapUnit;
		}
	
	
	}
	
}
