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
	[Guid("0110d280-1722-46bf-b12c-0b81868564a8")]
	public partial class IfcAxis2Placement2D : IfcPlacement,
		BuildingSmart.IFC.IfcGeometryResource.IfcAxis2Placement
	{
		[DataMember(Order=0)] 
		[XmlElement]
		IfcDirection _RefDirection;
	
	
		public IfcAxis2Placement2D()
		{
		}
	
		public IfcAxis2Placement2D(IfcCartesianPoint __Location, IfcDirection __RefDirection)
			: base(__Location)
		{
			this._RefDirection = __RefDirection;
		}
	
		[Description("The direction used to determine the direction of the local X axis. If a value is " +
	    "omited that it defaults to [1.0, 0.0.].\r\n</HTML>")]
		public IfcDirection RefDirection { get { return this._RefDirection; } set { this._RefDirection = value;} }
	
		public new IList<IfcDirection> P { get { return null; } }
	
	
	}
	
}
