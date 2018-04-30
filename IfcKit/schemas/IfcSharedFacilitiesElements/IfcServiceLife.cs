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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	public partial class IfcServiceLife : IfcControl
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Predefined service life types from which that required may be set. ")]
		[Required()]
		public IfcServiceLifeTypeEnum ServiceLifeType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The length or duration of a service life.")]
		[Required()]
		public IfcTimeMeasure ServiceLifeDuration { get; set; }
	
	
		public IfcServiceLife(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcServiceLifeTypeEnum __ServiceLifeType, IfcTimeMeasure __ServiceLifeDuration)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.ServiceLifeType = __ServiceLifeType;
			this.ServiceLifeDuration = __ServiceLifeDuration;
		}
	
	
	}
	
}
