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
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("8ab654a3-24e1-46b6-8dfd-39758b74dc21")]
	public partial class IfcFillAreaStyleTiles : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcFillStyleSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcOneDirectionRepeatFactor _TilingPattern;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcFillAreaStyleTileShapeSelect> _Tiles = new HashSet<IfcFillAreaStyleTileShapeSelect>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveRatioMeasure _TilingScale;
	
	
		[Description("A two direction repeat factor defining the shape and relative positioning of the " +
	    "tiles.")]
		public IfcOneDirectionRepeatFactor TilingPattern { get { return this._TilingPattern; } set { this._TilingPattern = value;} }
	
		[Description("A set of constituents of the tile.")]
		public ISet<IfcFillAreaStyleTileShapeSelect> Tiles { get { return this._Tiles; } }
	
		[Description("The scale factor applied to each tile as it is placed in the annotation fill area" +
	    ".")]
		public IfcPositiveRatioMeasure TilingScale { get { return this._TilingScale; } set { this._TilingScale = value;} }
	
	
	}
	
}
