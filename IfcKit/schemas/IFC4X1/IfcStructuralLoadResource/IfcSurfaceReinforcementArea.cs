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
	[Guid("5c929647-20a8-4225-a930-0d718d2b60e1")]
	public partial class IfcSurfaceReinforcementArea : IfcStructuralLoadOrResult
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IList<IfcLengthMeasure> _SurfaceReinforcement1 = new List<IfcLengthMeasure>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IList<IfcLengthMeasure> _SurfaceReinforcement2 = new List<IfcLengthMeasure>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcRatioMeasure? _ShearReinforcement;
	
	
		[Description(@"Reinforcement at the face of the member which is located at the side of the positive local z direction of the surface member.  Specified as area per length, e.g. square metre per metre (hence length measure, e.g. metre).  The reinforcement area may be specified for two or three directions of reinforcement bars.")]
		public IList<IfcLengthMeasure> SurfaceReinforcement1 { get { return this._SurfaceReinforcement1; } }
	
		[Description(@"Reinforcement at the face of the member which is located at the side of the negative local z direction of the surface member.  Specified as area per length, e.g. square metre per metre (hence length measure, e.g. metre).  The reinforcement area may be specified for two or three directions of reinforcement bars.")]
		public IList<IfcLengthMeasure> SurfaceReinforcement2 { get { return this._SurfaceReinforcement2; } }
	
		[Description("Shear reinforcement.  Specified as area per area, e.g. square metre per square me" +
	    "tre (hence ratio measure, i.e. unitless).")]
		public IfcRatioMeasure? ShearReinforcement { get { return this._ShearReinforcement; } set { this._ShearReinforcement = value;} }
	
	
	}
	
}
