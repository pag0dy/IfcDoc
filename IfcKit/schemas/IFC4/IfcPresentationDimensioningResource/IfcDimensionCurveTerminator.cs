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
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationDimensioningResource
{
	[Guid("61f48939-b67a-4d76-bb45-eb7ea4b3793b")]
	public partial class IfcDimensionCurveTerminator : IfcTerminatorSymbol
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcDimensionExtentUsage _Role;
	
	
		[Description("Role of the dimension curve terminator within a dimension curve (being either an " +
	    "origin or target).")]
		public IfcDimensionExtentUsage Role { get { return this._Role; } set { this._Role = value;} }
	
	
	}
	
}
