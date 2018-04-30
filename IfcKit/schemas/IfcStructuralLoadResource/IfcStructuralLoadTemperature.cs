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

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	public partial class IfcStructuralLoadTemperature : IfcStructuralLoadStatic
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Temperature change which is applied to the complete section of the structural member. A positive value describes an increase in temperature.")]
		public IfcThermodynamicTemperatureMeasure? DeltaT_Constant { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Temperature change which is applied to the outer fiber of the positive Y-direction. A positive value describes an increase in temperature.")]
		public IfcThermodynamicTemperatureMeasure? DeltaT_Y { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Temperature change which is applied to the outer fiber of the positive Z-direction. A positive value describes an increase in temperature.")]
		public IfcThermodynamicTemperatureMeasure? DeltaT_Z { get; set; }
	
	
		public IfcStructuralLoadTemperature(IfcLabel? __Name, IfcThermodynamicTemperatureMeasure? __DeltaT_Constant, IfcThermodynamicTemperatureMeasure? __DeltaT_Y, IfcThermodynamicTemperatureMeasure? __DeltaT_Z)
			: base(__Name)
		{
			this.DeltaT_Constant = __DeltaT_Constant;
			this.DeltaT_Y = __DeltaT_Y;
			this.DeltaT_Z = __DeltaT_Z;
		}
	
	
	}
	
}
