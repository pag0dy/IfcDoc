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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcSharedFacilitiesElements;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("f9754c40-1414-4a96-a587-2ff0a1c7e969")]
	public partial class IfcSpatialZoneType : IfcSpatialElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcSpatialZoneTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _LongName;
	
	
		[Description("Predefined types to define the particular type of the spatial zone. There may be " +
	    "property set definitions available for each predefined type.")]
		public IfcSpatialZoneTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"Long name for a spatial zone type, used for informal purposes. It should be used, if available, in conjunction with the inherited <em>Name</em> attribute.
	<blockquote class=""note"">
	  NOTE&nbsp; In many scenarios the <em>Name</em> attribute refers to the short name or number of a spatial zone, and the <em>LongName</em> refers to the full descriptive name.
	</blockquote>")]
		public IfcLabel? LongName { get { return this._LongName; } set { this._LongName = value;} }
	
	
	}
	
}
