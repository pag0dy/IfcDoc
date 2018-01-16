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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("eddbf896-fef4-49ba-b5c8-5315a44af82c")]
	public abstract partial class IfcParameterizedProfileDef : IfcProfileDef
	{
		[DataMember(Order=0)] 
		[XmlElement]
		IfcAxis2Placement2D _Position;
	
	
		[Description("Position coordinate system of the parameterized profile definition. If unspecifie" +
	    "d, no translation and no rotation is applied.\r\n")]
		public IfcAxis2Placement2D Position { get { return this._Position; } set { this._Position = value;} }
	
	
	}
	
}
