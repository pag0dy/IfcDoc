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
	public partial class IfcSurfaceReinforcementArea : IfcStructuralLoadOrResult
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Reinforcement at the face of the member which is located at the side of the positive local z direction of the surface member.  Specified as area per length, e.g. square metre per metre (hence length measure, e.g. metre).  The reinforcement area may be specified for two or three directions of reinforcement bars.")]
		[MinLength(2)]
		[MaxLength(3)]
		public IList<IfcLengthMeasure> SurfaceReinforcement1 { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Reinforcement at the face of the member which is located at the side of the negative local z direction of the surface member.  Specified as area per length, e.g. square metre per metre (hence length measure, e.g. metre).  The reinforcement area may be specified for two or three directions of reinforcement bars.")]
		[MinLength(2)]
		[MaxLength(3)]
		public IList<IfcLengthMeasure> SurfaceReinforcement2 { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Shear reinforcement.  Specified as area per area, e.g. square metre per square metre (hence ratio measure, i.e. unitless).")]
		public IfcRatioMeasure? ShearReinforcement { get; set; }
	
	
		public IfcSurfaceReinforcementArea(IfcLabel? __Name, IfcLengthMeasure[] __SurfaceReinforcement1, IfcLengthMeasure[] __SurfaceReinforcement2, IfcRatioMeasure? __ShearReinforcement)
			: base(__Name)
		{
			this.SurfaceReinforcement1 = new List<IfcLengthMeasure>(__SurfaceReinforcement1);
			this.SurfaceReinforcement2 = new List<IfcLengthMeasure>(__SurfaceReinforcement2);
			this.ShearReinforcement = __ShearReinforcement;
		}
	
	
	}
	
}
