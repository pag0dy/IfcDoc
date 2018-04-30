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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcOneDirectionRepeatFactor : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcHatchLineDistanceSelect
	{
		[DataMember(Order = 0)] 
		[Description("A vector which specifies the relative positioning of hatch lines.")]
		[Required()]
		public IfcVector RepeatFactor { get; set; }
	
	
		public IfcOneDirectionRepeatFactor(IfcVector __RepeatFactor)
		{
			this.RepeatFactor = __RepeatFactor;
		}
	
	
	}
	
}
