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
	[Guid("1313c1ee-f455-43d1-99a2-89dea63a0fca")]
	public abstract partial class IfcPlacement : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcCartesianPoint _Location;
	
	
		public IfcPlacement()
		{
		}
	
		public IfcPlacement(IfcCartesianPoint __Location)
		{
			this._Location = __Location;
		}
	
		[Description("The geometric position of a reference point, such as the center of a circle, of t" +
	    "he item to be located.")]
		public IfcCartesianPoint Location { get { return this._Location; } set { this._Location = value;} }
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
