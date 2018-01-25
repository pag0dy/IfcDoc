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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("4ab54421-83da-48e9-9931-2e0f8051029b")]
	public partial class IfcTextLiteralWithExtent : IfcTextLiteral
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcPlanarExtent _Extent;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcBoxAlignment _BoxAlignment;
	
	
		[Description("The extent in the x and y direction of the text literal.")]
		public IfcPlanarExtent Extent { get { return this._Extent; } set { this._Extent = value;} }
	
		[Description("The alignment of the text literal relative to its position.")]
		public IfcBoxAlignment BoxAlignment { get { return this._BoxAlignment; } set { this._BoxAlignment = value;} }
	
	
	}
	
}
