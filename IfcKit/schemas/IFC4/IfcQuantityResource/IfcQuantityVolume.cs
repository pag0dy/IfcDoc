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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcQuantityResource
{
	[Guid("16ed104c-4bf5-4f35-8815-8c5337893a7a")]
	public partial class IfcQuantityVolume : IfcPhysicalSimpleQuantity
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcVolumeMeasure _VolumeValue;
	
	
		[Description("Volume measure value of this quantity.")]
		public IfcVolumeMeasure VolumeValue { get { return this._VolumeValue; } set { this._VolumeValue = value;} }
	
	
	}
	
}
