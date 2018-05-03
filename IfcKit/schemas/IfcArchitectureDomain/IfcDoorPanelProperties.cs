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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	public partial class IfcDoorPanelProperties : IfcPreDefinedPropertySet
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Depth of the door panel, measured perpendicular to the plane of the door leaf.")]
		public IfcPositiveLengthMeasure? PanelDepth { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The <em>PanelOperation</em> defines the way of operation of that panel. The <em>PanelOperation</em> of the door panel has to correspond with the <em>OperationType</em> of the <em>IfcDoorStyle</em> by which it is referenced.")]
		[Required()]
		public IfcDoorPanelOperationEnum PanelOperation { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Width of this panel, given as ratio relative to the total clear opening width of the door. If omited, it defaults to 1. A value has to be provided for all doors with <em>OperationType</em>'s at <em>IfcDoorStyle</em> defining a door with more then one panel.")]
		public IfcNormalisedRatioMeasure? PanelWidth { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Position of this panel within the door. The <em>PanelPosition</em> of the door panel has to correspond with the <em>OperationType</em> of the <em>IfcDoorStyle</em> by which it is referenced.")]
		[Required()]
		public IfcDoorPanelPositionEnum PanelPosition { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlElement]
		[Description("Pointer to the shape aspect, if given. The shape aspect reflects the part of the door shape, which represents the door panel.  <blockquote class=\"deprecated\">DEPRECATION&nbsp; The attribute is deprecated and shall no longer be used, i.e. the value shall be NIL ($).</blockquote>")]
		public IfcShapeAspect ShapeAspectStyle { get; set; }
	
	
		public IfcDoorPanelProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPositiveLengthMeasure? __PanelDepth, IfcDoorPanelOperationEnum __PanelOperation, IfcNormalisedRatioMeasure? __PanelWidth, IfcDoorPanelPositionEnum __PanelPosition, IfcShapeAspect __ShapeAspectStyle)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.PanelDepth = __PanelDepth;
			this.PanelOperation = __PanelOperation;
			this.PanelWidth = __PanelWidth;
			this.PanelPosition = __PanelPosition;
			this.ShapeAspectStyle = __ShapeAspectStyle;
		}
	
	
	}
	
}
