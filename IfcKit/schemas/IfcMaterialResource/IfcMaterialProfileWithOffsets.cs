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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialProfileWithOffsets : IfcMaterialProfile
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The numerical value of profile offset, in the direction of the axis direction - always AXIS1 that is, the axis along the extrusion path. The <em>OffsetValues[1]</em> identifies the offset from the lower position along the axis direction (normally the start of the standard extrusion), the <em>OffsetValues[2]</em> identifies the offset from the upper position along the axis direction (normally the end of the standard extrusion).")]
		[Required()]
		[MinLength(1)]
		[MaxLength(2)]
		public IfcLengthMeasure[] OffsetValues { get; set; }
	
	
		public IfcMaterialProfileWithOffsets(IfcLabel? __Name, IfcText? __Description, IfcMaterial __Material, IfcProfileDef __Profile, IfcInteger? __Priority, IfcLabel? __Category, IfcLengthMeasure[] __OffsetValues)
			: base(__Name, __Description, __Material, __Profile, __Priority, __Category)
		{
			this.OffsetValues = __OffsetValues;
		}
	
	
	}
	
}
