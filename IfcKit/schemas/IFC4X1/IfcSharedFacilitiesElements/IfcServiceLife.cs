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
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcQuantityResource;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	[Guid("1ccc8f4a-e6f0-4f8e-abeb-1ed0dbf1709a")]
	public partial class IfcServiceLife : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcServiceLifeTypeEnum _ServiceLifeType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcTimeMeasure _ServiceLifeDuration;
	
	
		[Description("Predefined service life types from which that required may be set. ")]
		public IfcServiceLifeTypeEnum ServiceLifeType { get { return this._ServiceLifeType; } set { this._ServiceLifeType = value;} }
	
		[Description("The length or duration of a service life.")]
		public IfcTimeMeasure ServiceLifeDuration { get { return this._ServiceLifeDuration; } set { this._ServiceLifeDuration = value;} }
	
	
	}
	
}
