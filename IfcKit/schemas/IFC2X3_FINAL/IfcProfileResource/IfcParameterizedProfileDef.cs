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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("5f2b33b3-4a09-48ad-858a-b13264839494")]
	public abstract partial class IfcParameterizedProfileDef : IfcProfileDef
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAxis2Placement2D _Position;
	
	
		public IfcParameterizedProfileDef()
		{
		}
	
		public IfcParameterizedProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position)
			: base(__ProfileType, __ProfileName)
		{
			this._Position = __Position;
		}
	
		[Description("Position coordinate system of the parameterized profile definition.")]
		public IfcAxis2Placement2D Position { get { return this._Position; } set { this._Position = value;} }
	
	
	}
	
}
