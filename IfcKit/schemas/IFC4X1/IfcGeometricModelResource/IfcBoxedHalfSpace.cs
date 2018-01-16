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
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("6d52ef81-4176-4ab5-a2d3-39b86c31c378")]
	public partial class IfcBoxedHalfSpace : IfcHalfSpaceSolid
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcBoundingBox _Enclosure;
	
	
		[Description("The box which bounds the resulting solid of the Boolean operation involving the h" +
	    "alf space solid for computational purposes only.\r\n")]
		public IfcBoundingBox Enclosure { get { return this._Enclosure; } set { this._Enclosure = value;} }
	
	
	}
	
}
