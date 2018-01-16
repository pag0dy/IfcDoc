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
	[Guid("55d837bf-64b2-4c83-9324-044e57cbaa9f")]
	public abstract partial class IfcCoordinateReferenceSystem :
		BuildingSmart.IFC.IfcRepresentationResource.IfcCoordinateReferenceSystemSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcIdentifier? _GeodeticDatum;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcIdentifier? _VerticalDatum;
	
		[InverseProperty("SourceCRS")] 
		ISet<IfcCoordinateOperation> _HasCoordinateOperation = new HashSet<IfcCoordinateOperation>();
	
	
		[Description(@"Name by which the coordinate reference system is identified.
	<blockquote class=""note"">NOTE&nbsp; The name shall be taken from the list recognized by the European Petroleum Survey Group EPSG. It should then be qualified by the EPSG name space, for example as 'EPSG:5555'.</blockquote>
	")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Informal description of this coordinate reference system.\r\n")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"Name by which this datum is identified. The geodetic datum is associated with the coordinate reference system and indicates the shape and size of the rotation ellipsoid and this ellipsoid's connection and orientation to the actual globe/earth. It needs to be provided, if the <em>Name</em> identifier does not unambiguously define the geodetic datum as well.
	
	<blockquote class=""examples"">EXAMPLE&nbsp; geodetic datums include:
	<ul class=""note"">
	  <li class=""note"">ED50</li>
	  <li class=""note"">EUREF89</li>
	  <li class=""note"">WSG84</li>
	<ul>
	</blockquote>")]
		public IfcIdentifier? GeodeticDatum { get { return this._GeodeticDatum; } set { this._GeodeticDatum = value;} }
	
		[Description(@"Name by which the vertical datum is identified. The vertical datum is associated with the height axis of the coordinate reference system and indicates the reference plane and fundamental point defining the origin of a height system. It needs to be provided, if the <em>Name</em> identifier does not unambiguously define the vertical datum as well and if the coordinate reference system is a 3D reference system.
	
	<blockquote class=""examples"">EXAMPLE&nbsp; vertical datums include:
	<ul class=""note"">
	  <li class=""note"">DHHN92: the German 'Haupth&ouml;hennetz'</li>
	  <li class=""note"">EVRS2007; the European Vertical Reference System</li>
	</ul>
	</blockquote>")]
		public IfcIdentifier? VerticalDatum { get { return this._VerticalDatum; } set { this._VerticalDatum = value;} }
	
		[Description("Indicates conversion between coordinate systems. In particular it refers to an <e" +
	    "m>IfcCoordinateOperation</em> between this coordinate reference system, and anot" +
	    "her Geographic coordinate reference system.")]
		public ISet<IfcCoordinateOperation> HasCoordinateOperation { get { return this._HasCoordinateOperation; } }
	
	
	}
	
}
