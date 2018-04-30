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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public abstract partial class IfcConic : IfcCurve
	{
		[DataMember(Order = 0)] 
		[Description("The location and orientation of the conic. Further details of the interpretation of this attribute are given for the individual subtypes.\"   ")]
		[Required()]
		public IfcAxis2Placement Position { get; set; }
	
	
		protected IfcConic(IfcAxis2Placement __Position)
		{
			this.Position = __Position;
		}
	
	
	}
	
}
