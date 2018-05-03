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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcSite : IfcSpatialStructureElement
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("World Latitude at reference point (most likely defined in legal description). Defined as integer values for degrees, minutes, seconds, and, optionally, millionths of seconds with respect to the world geodetic system WGS84.  <blockquote class=\"note\">NOTE&nbsp; Latitudes are measured relative to the geodetic equator, north of the equator by positive values - from 0 till +90,   south of the equator by negative values - from 0 till  -90.</blockquote>")]
		public IfcCompoundPlaneAngleMeasure? RefLatitude { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("World Longitude at reference point (most likely defined in legal description). Defined as integer values for degrees, minutes, seconds, and, optionally, millionths of seconds with respect to the world geodetic system WGS84.  <blockquote class=\"note\">NOTE&nbsp; Longitudes are measured relative to the geodetic zero meridian, nominally the same as the Greenwich prime meridian: longitudes west of the zero meridian have negative values - from 0 till -180, longitudes east of the zero meridian have positive values - from 0 till -180.</blockquote>  <blockquote class=\"example\">EXAMPLE&nbsp; Chicago Harbor Light has according to WGS84 a longitude -87.35.40 (or 87.35.40W) and a latitude 41.53.30 (or 41.53.30N).</blockquote>")]
		public IfcCompoundPlaneAngleMeasure? RefLongitude { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Datum elevation relative to sea level.  ")]
		public IfcLengthMeasure? RefElevation { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The land title number (designation of the site within a regional system).")]
		public IfcLabel? LandTitleNumber { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlElement]
		[Description("Address given to the site for postal purposes.")]
		public IfcPostalAddress SiteAddress { get; set; }
	
	
		public IfcSite(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcLabel? __LongName, IfcElementCompositionEnum? __CompositionType, IfcCompoundPlaneAngleMeasure? __RefLatitude, IfcCompoundPlaneAngleMeasure? __RefLongitude, IfcLengthMeasure? __RefElevation, IfcLabel? __LandTitleNumber, IfcPostalAddress __SiteAddress)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __LongName, __CompositionType)
		{
			this.RefLatitude = __RefLatitude;
			this.RefLongitude = __RefLongitude;
			this.RefElevation = __RefElevation;
			this.LandTitleNumber = __LandTitleNumber;
			this.SiteAddress = __SiteAddress;
		}
	
	
	}
	
}
