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
	public abstract partial class IfcCoordinateReferenceSystem :
		BuildingSmart.IFC.IfcRepresentationResource.IfcCoordinateReferenceSystemSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Name by which the coordinate reference system is identified.  <blockquote class=\"note\">NOTE&nbsp; The name shall be taken from the list recognized by the European Petroleum Survey Group EPSG. It should then be qualified by the EPSG name space, for example as 'EPSG:5555'.</blockquote>  ")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Informal description of this coordinate reference system.  ")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Name by which this datum is identified. The geodetic datum is associated with the coordinate reference system and indicates the shape and size of the rotation ellipsoid and this ellipsoid's connection and orientation to the actual globe/earth. It needs to be provided, if the <em>Name</em> identifier does not unambiguously define the geodetic datum as well.    <blockquote class=\"examples\">EXAMPLE&nbsp; geodetic datums include:  <ul class=\"note\">    <li class=\"note\">ED50</li>    <li class=\"note\">EUREF89</li>    <li class=\"note\">WSG84</li>  <ul>  </blockquote>")]
		public IfcIdentifier? GeodeticDatum { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Name by which the vertical datum is identified. The vertical datum is associated with the height axis of the coordinate reference system and indicates the reference plane and fundamental point defining the origin of a height system. It needs to be provided, if the <em>Name</em> identifier does not unambiguously define the vertical datum as well and if the coordinate reference system is a 3D reference system.    <blockquote class=\"examples\">EXAMPLE&nbsp; vertical datums include:  <ul class=\"note\">    <li class=\"note\">DHHN92: the German 'Haupth&ouml;hennetz'</li>    <li class=\"note\">EVRS2007; the European Vertical Reference System</li>  </ul>  </blockquote>")]
		public IfcIdentifier? VerticalDatum { get; set; }
	
		[InverseProperty("SourceCRS")] 
		[Description("Indicates conversion between coordinate systems. In particular it refers to an <em>IfcCoordinateOperation</em> between this coordinate reference system, and another Geographic coordinate reference system.")]
		[MaxLength(1)]
		public ISet<IfcCoordinateOperation> HasCoordinateOperation { get; protected set; }
	
	
		protected IfcCoordinateReferenceSystem(IfcLabel __Name, IfcText? __Description, IfcIdentifier? __GeodeticDatum, IfcIdentifier? __VerticalDatum)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.GeodeticDatum = __GeodeticDatum;
			this.VerticalDatum = __VerticalDatum;
			this.HasCoordinateOperation = new HashSet<IfcCoordinateOperation>();
		}
	
	
	}
	
}
