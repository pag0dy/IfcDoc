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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("94e16249-95c6-4654-92c9-5cfac4e1e234")]
	public partial class IfcFillAreaStyleTiles : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcFillStyleSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcVector> _TilingPattern = new List<IfcVector>();
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcStyledItem> _Tiles = new HashSet<IfcStyledItem>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveRatioMeasure _TilingScale;
	
	
		[Description("A two direction repeat factor defining the shape and relative positioning of the " +
	    "tiles.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute type h" +
	    "as changed to directly reference two <em>IfcVector</em>\'s.</blockquote>")]
		public IList<IfcVector> TilingPattern { get { return this._TilingPattern; } }
	
		[Description(@"A set of constituents of the tile being a styled item that is used as the annotation symbol for tiling the filled area.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  The data type has been changed to <em>IfcStyledItem</em>.</blockquote>
	<blockquote class=""note"">NOTE&nbsp; Only <em>IfcStyleItem</em>'s that refer to a compatible geometric representation item and presentation style shall be used.</blockquote>")]
		public ISet<IfcStyledItem> Tiles { get { return this._Tiles; } }
	
		[Description("The scale factor applied to each tile as it is placed in the annotation fill area" +
	    ".")]
		public IfcPositiveRatioMeasure TilingScale { get { return this._TilingScale; } set { this._TilingScale = value;} }
	
	
	}
	
}
