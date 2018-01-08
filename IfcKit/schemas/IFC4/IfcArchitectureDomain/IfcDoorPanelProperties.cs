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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;

namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	[Guid("9cba168e-4c79-497b-9481-9b26b7aa86d4")]
	public partial class IfcDoorPanelProperties : IfcPreDefinedPropertySet
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _PanelDepth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcDoorPanelOperationEnum _PanelOperation;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _PanelWidth;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcDoorPanelPositionEnum _PanelPosition;
	
		[DataMember(Order=4)] 
		[XmlElement("IfcShapeAspect")]
		IfcShapeAspect _ShapeAspectStyle;
	
	
		[Description("<EPM-HTML>\r\nDepth of the door panel, measured perpendicular to the plane of the d" +
	    "oor leaf.\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure? PanelDepth { get { return this._PanelDepth; } set { this._PanelDepth = value;} }
	
		[Description("<EPM-HTML>\r\nThe <em>PanelOperation</em> defines the way of operation of that pane" +
	    "l. The <em>PanelOperation</em> of the door panel has to correspond with the <em>" +
	    "OperationType</em> of the <em>IfcDoorStyle</em> by which it is referenced.\r\n</EP" +
	    "M-HTML>")]
		public IfcDoorPanelOperationEnum PanelOperation { get { return this._PanelOperation; } set { this._PanelOperation = value;} }
	
		[Description(@"<EPM-HTML>
	Width of this panel, given as ratio relative to the total clear opening width of the door. If omited, it defaults to 1. A value has to be provided for all doors with <em>OperationType</em>'s at <em>IfcDoorStyle</em> defining a door with more then one panel.
	</EPM-HTML>")]
		public IfcNormalisedRatioMeasure? PanelWidth { get { return this._PanelWidth; } set { this._PanelWidth = value;} }
	
		[Description("<EPM-HTML>\r\nPosition of this panel within the door. The <em>PanelPosition</em> of" +
	    " the door panel has to correspond with the <em>OperationType</em> of the <em>Ifc" +
	    "DoorStyle</em> by which it is referenced.\r\n</EPM-HTML>")]
		public IfcDoorPanelPositionEnum PanelPosition { get { return this._PanelPosition; } set { this._PanelPosition = value;} }
	
		[Description(@"<EPM-HTML>
	Pointer to the shape aspect, if given. The shape aspect reflects the part of the door shape, which represents the door panel.
	<blockquote class=""deprecated"">DEPRECATION&nbsp; The attribute is deprecated and shall no longer be used, i.e. the value shall be NIL ($).</blockquote>
	</EPM-HTML>")]
		public IfcShapeAspect ShapeAspectStyle { get { return this._ShapeAspectStyle; } set { this._ShapeAspectStyle = value;} }
	
	
	}
	
}
