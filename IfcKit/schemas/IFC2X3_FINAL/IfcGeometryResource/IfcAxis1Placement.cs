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

using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("d1ae4b1d-77e6-4cca-89c2-90634a02431c")]
	public partial class IfcAxis1Placement : IfcPlacement
	{
		[DataMember(Order=0)] 
		IfcDirection _Axis;
	
	
		public IfcAxis1Placement()
		{
		}
	
		public IfcAxis1Placement(IfcCartesianPoint __Location, IfcDirection __Axis)
			: base(__Location)
		{
			this._Axis = __Axis;
		}
	
		[Description("The direction of the local Z axis.")]
		public IfcDirection Axis { get { return this._Axis; } set { this._Axis = value;} }
	
		public new IfcDirection Z { get { return null; } }
	
	
	}
	
}
