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

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	[Guid("7e7717df-e136-4b0d-8e8d-33dd81a892e9")]
	public partial class IfcStructuralLoadTemperature : IfcStructuralLoadStatic
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _DeltaT_Constant;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _DeltaT_Y;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _DeltaT_Z;
	
	
		public IfcStructuralLoadTemperature()
		{
		}
	
		public IfcStructuralLoadTemperature(IfcLabel? __Name, IfcThermodynamicTemperatureMeasure? __DeltaT_Constant, IfcThermodynamicTemperatureMeasure? __DeltaT_Y, IfcThermodynamicTemperatureMeasure? __DeltaT_Z)
			: base(__Name)
		{
			this._DeltaT_Constant = __DeltaT_Constant;
			this._DeltaT_Y = __DeltaT_Y;
			this._DeltaT_Z = __DeltaT_Z;
		}
	
		[Description("Temperature change which is applied to the complete section of the structural mem" +
	    "ber. A positive value describes an increase in temperature.")]
		public IfcThermodynamicTemperatureMeasure? DeltaT_Constant { get { return this._DeltaT_Constant; } set { this._DeltaT_Constant = value;} }
	
		[Description("Temperature change which is applied to the outer fiber of the positive Y-directio" +
	    "n. A positive value describes an increase in temperature.")]
		public IfcThermodynamicTemperatureMeasure? DeltaT_Y { get { return this._DeltaT_Y; } set { this._DeltaT_Y = value;} }
	
		[Description("Temperature change which is applied to the outer fiber of the positive Z-directio" +
	    "n. A positive value describes an increase in temperature.")]
		public IfcThermodynamicTemperatureMeasure? DeltaT_Z { get { return this._DeltaT_Z; } set { this._DeltaT_Z = value;} }
	
	
	}
	
}
