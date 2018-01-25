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
	[Guid("fff1fb35-13c2-4e24-92f4-c2bfd5a9ba17")]
	public partial class IfcTextLiteral : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPresentableText _Literal;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcAxis2Placement _Placement;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcTextPath _Path;
	
	
		[Description("The text literal to be presented.")]
		public IfcPresentableText Literal { get { return this._Literal; } set { this._Literal = value;} }
	
		[Description("An <em>IfcAxis2Placement</em> that determines the placement and orientation of th" +
	    "e presented string.")]
		public IfcAxis2Placement Placement { get { return this._Placement; } set { this._Placement = value;} }
	
		[Description("The writing direction of the text literal.")]
		public IfcTextPath Path { get { return this._Path; } set { this._Path = value;} }
	
	
	}
	
}
