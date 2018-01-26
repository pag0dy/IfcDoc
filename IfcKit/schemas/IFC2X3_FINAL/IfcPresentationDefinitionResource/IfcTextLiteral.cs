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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("838aa023-edf8-4ede-9db6-6d86aae12e85")]
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
	
	
		public IfcTextLiteral()
		{
		}
	
		public IfcTextLiteral(IfcPresentableText __Literal, IfcAxis2Placement __Placement, IfcTextPath __Path)
		{
			this._Literal = __Literal;
			this._Placement = __Placement;
			this._Path = __Path;
		}
	
		[Description("<EPM-HTML>\r\nThe text literal to be presented.\r\n</EPM-HTML>")]
		public IfcPresentableText Literal { get { return this._Literal; } set { this._Literal = value;} }
	
		[Description(@"<EPM-HTML>
	An <i>IfcAxis2Placement</i> that determines the placement and orientation of the presented string.
	<blockquote><small>When used with a text style based on <i>IfcTextStyleWithBoxCharacteristics</i> then the y-axis is taken as the reference direction for the box rotation angle and the box slant angle.
	</small></blockquote>
	</EPM-HTML>")]
		public IfcAxis2Placement Placement { get { return this._Placement; } set { this._Placement = value;} }
	
		[Description("<EPM-HTML>\r\nThe writing direction of the text literal.\r\n</EPM-HTML>")]
		public IfcTextPath Path { get { return this._Path; } set { this._Path = value;} }
	
	
	}
	
}
