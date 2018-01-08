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
	[Guid("506c5de0-1239-4940-bf42-bab69e86f4fd")]
	public partial class IfcMapConversion : IfcCoordinateOperation
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _Eastings;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _Northings;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _OrthogonalHeight;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcReal? _XAxisAbscissa;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcReal? _XAxisOrdinate;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcReal? _Scale;
	
	
		[Description(@"<EPM-HTML>Specifies the location along the easting of the coordinate system of the target map coordinate reference system.
	<blockquote class=""note"">NOTE&nbsp; for right-handed Cartesian coordinate systems this would establish the location along the x axis.</blockquote>
	</EPM-HTML>")]
		public IfcLengthMeasure Eastings { get { return this._Eastings; } set { this._Eastings = value;} }
	
		[Description(@"<EPM-HTML>Specifies the location along the northing of the coordinate system of the target map coordinate reference system.
	<blockquote class=""note"">NOTE&nbsp; for right-handed Cartesian coordinate systems this would establish the location along the y axis</blockquote>
	</EPM-HTML>")]
		public IfcLengthMeasure Northings { get { return this._Northings; } set { this._Northings = value;} }
	
		[Description("<EPM-HTML>Orthogonal height relativ to the vertical datum specified.\r\n<blockquote" +
	    " class=\"note\">NOTE&nbsp; for right-handed Cartesian coordinate systems this woul" +
	    "d establish the location along the z axis</blockquote>\r\n<EPM-HTML>")]
		public IfcLengthMeasure OrthogonalHeight { get { return this._OrthogonalHeight; } set { this._OrthogonalHeight = value;} }
	
		[Description(@"<EPM-HTML> Specifies the value along the easing axis of the end point of a vector indicating the position of the local x axis of the engineering coordinate reference system.
	<blockquote class=""note"">NOTE&nbsp;1 for right-handed Cartesian coordinate systems this would establish the location along the x axis</blockquote>
	<blockquote class=""note"">NOTE&nbsp;2 together with the <em>XAxisOrdinate</em> it provides the direction of the local x axis within the horizontal plane of the map coordinate system</blockquote>
	</EPM-HTML>")]
		public IfcReal? XAxisAbscissa { get { return this._XAxisAbscissa; } set { this._XAxisAbscissa = value;} }
	
		[Description(@"<EPM-HTML> Specifies the value along the northing axis of the end point of a vector indicating the position of the local x axis of the engineering coordinate reference system.
	<blockquote class=""note"">NOTE&nbsp;1 for right-handed Cartesian coordinate systems this would establish the location along the y axis</blockquote>
	<blockquote class=""note""NOTE&nbsp; together with the <em>XAxisAbscissa</em> it provides the direction of the local x axis within the horizontal plane of the map coordinate system.</blockquote>
	</EPM-HTML>")]
		public IfcReal? XAxisOrdinate { get { return this._XAxisOrdinate; } set { this._XAxisOrdinate = value;} }
	
		[Description("<EPM-HTML>Scale to be used, when the units of the CRS are not identical to the un" +
	    "its of the engineering coordinate system. If omited, the value of 1.0 is assumed" +
	    ".\r\n</EPM-HTML>")]
		public IfcReal? Scale { get { return this._Scale; } set { this._Scale = value;} }
	
	
	}
	
}
