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
	public partial class IfcMapConversion : IfcCoordinateOperation
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Specifies the location along the easting of the coordinate system of the target map coordinate reference system.  <blockquote class=\"note\">NOTE&nbsp; for right-handed Cartesian coordinate systems this would establish the location along the x axis.</blockquote>")]
		[Required()]
		public IfcLengthMeasure Eastings { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Specifies the location along the northing of the coordinate system of the target map coordinate reference system.  <blockquote class=\"note\">NOTE&nbsp; for right-handed Cartesian coordinate systems this would establish the location along the y axis</blockquote>")]
		[Required()]
		public IfcLengthMeasure Northings { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Orthogonal height relativ to the vertical datum specified.  <blockquote class=\"note\">NOTE&nbsp; for right-handed Cartesian coordinate systems this would establish the location along the z axis</blockquote>  ")]
		[Required()]
		public IfcLengthMeasure OrthogonalHeight { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description(" Specifies the value along the easing axis of the end point of a vector indicating the position of the local x axis of the engineering coordinate reference system.  <blockquote class=\"note\">NOTE&nbsp;1 for right-handed Cartesian coordinate systems this would establish the location along the x axis</blockquote>  <blockquote class=\"note\">NOTE&nbsp;2 together with the <em>XAxisOrdinate</em> it provides the direction of the local x axis within the horizontal plane of the map coordinate system</blockquote>")]
		public IfcReal? XAxisAbscissa { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description(" Specifies the value along the northing axis of the end point of a vector indicating the position of the local x axis of the engineering coordinate reference system.  <blockquote class=\"note\">NOTE&nbsp;1 for right-handed Cartesian coordinate systems this would establish the location along the y axis</blockquote>  <blockquote class=\"note\"NOTE&nbsp; together with the <em>XAxisAbscissa</em> it provides the direction of the local x axis within the horizontal plane of the map coordinate system.</blockquote>")]
		public IfcReal? XAxisOrdinate { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Scale to be used, when the units of the CRS are not identical to the units of the engineering coordinate system. If omited, the value of 1.0 is assumed.")]
		public IfcReal? Scale { get; set; }
	
	
		public IfcMapConversion(IfcCoordinateReferenceSystemSelect __SourceCRS, IfcCoordinateReferenceSystem __TargetCRS, IfcLengthMeasure __Eastings, IfcLengthMeasure __Northings, IfcLengthMeasure __OrthogonalHeight, IfcReal? __XAxisAbscissa, IfcReal? __XAxisOrdinate, IfcReal? __Scale)
			: base(__SourceCRS, __TargetCRS)
		{
			this.Eastings = __Eastings;
			this.Northings = __Northings;
			this.OrthogonalHeight = __OrthogonalHeight;
			this.XAxisAbscissa = __XAxisAbscissa;
			this.XAxisOrdinate = __XAxisOrdinate;
			this.Scale = __Scale;
		}
	
	
	}
	
}
