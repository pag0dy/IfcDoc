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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("1acc0179-b420-416d-95e1-71185b188860")]
	public partial class IfcRightCircularCylinder : IfcCsgPrimitive3D
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Height;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Radius;
	
	
		public IfcRightCircularCylinder()
		{
		}
	
		public IfcRightCircularCylinder(IfcAxis2Placement3D __Position, IfcPositiveLengthMeasure __Height, IfcPositiveLengthMeasure __Radius)
			: base(__Position)
		{
			this._Height = __Height;
			this._Radius = __Radius;
		}
	
		[Description("<EPM-HTML>\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure Height { get { return this._Height; } set { this._Height = value;} }
	
		[Description("<EPM-HTML>\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure Radius { get { return this._Radius; } set { this._Radius = value;} }
	
	
	}
	
}
