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
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _GeodeticDatum;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcIdentifier? _VerticalDatum;
	
	
		[Description("<EPM-HTML>Name by which the coordinate reference system is identified.\r\n<blockquo" +
	    "te class=\"note\">NOTE&nbsp; The name shall be taken from the list recognized by t" +
	    "he European Petroleum Survey Group EPSG.</blockquote>\r\n</EPM-HTML>\r\n")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("<EPM-HTML>Informal description of this coordinate reference system.<br></EPM-HTML" +
	    ">\r\n")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"<EPM-HTML>
	Name by which this datum is identified. The geodetic datum is associated with the coordinate reference system and indicates the shape and size of the rotation ellipsoid and this ellipsoid's connection and orientation to the actual globe/earth. Examples for geodetic datums include:
	<ul>
	  <li>ED50</li>
	  <li>EUREF89</li>
	  <li>WSG84</li>
	<ul>
	</EPM-HTML>
	")]
		public IfcIdentifier GeodeticDatum { get { return this._GeodeticDatum; } set { this._GeodeticDatum = value;} }
	
		[Description(@"<EPM-HTML>Name by which the vertical datum is identified. The vertical datum is associated with the height axis of the coordinate reference system and indicates the reference plane and fundamental point defining the origin of a height system. Examples for vertical datums include:
	<ul>
	  <li>height above mean sea level at Dover in 1952</li>
	  <li>other sea levels</li>
	</ul>
	</EPM-HTML>")]
		public IfcIdentifier? VerticalDatum { get { return this._VerticalDatum; } set { this._VerticalDatum = value;} }
	
	
	}
	
}
