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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	public partial class IfcTextLiteral : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The text literal to be presented.")]
		[Required()]
		public IfcPresentableText Literal { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("An <em>IfcAxis2Placement</em> that determines the placement and orientation of the presented string.")]
		[Required()]
		public IfcAxis2Placement Placement { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The writing direction of the text literal.")]
		[Required()]
		public IfcTextPath Path { get; set; }
	
	
		public IfcTextLiteral(IfcPresentableText __Literal, IfcAxis2Placement __Placement, IfcTextPath __Path)
		{
			this.Literal = __Literal;
			this.Placement = __Placement;
			this.Path = __Path;
		}
	
	
	}
	
}
