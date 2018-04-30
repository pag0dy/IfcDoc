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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	public abstract partial class IfcParameterizedProfileDef : IfcProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Position coordinate system of the parameterized profile definition. If unspecified, no translation and no rotation is applied.  ")]
		public IfcAxis2Placement2D Position { get; set; }
	
	
		protected IfcParameterizedProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position)
			: base(__ProfileType, __ProfileName)
		{
			this.Position = __Position;
		}
	
	
	}
	
}
