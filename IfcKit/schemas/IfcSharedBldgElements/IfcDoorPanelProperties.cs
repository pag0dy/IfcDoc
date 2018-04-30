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

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public partial class IfcDoorPanelProperties : IfcPropertySetDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Depth of the door panel, measured perpendicular to the plane of the door leaf. ")]
		public IfcPositiveLengthMeasure? PanelDepth { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The PanelOperation defines the way of operation of that panel. The PanelOperation of the door panel has to correspond with the OperationType of the IfcDoorStyle.")]
		[Required()]
		public IfcDoorPanelOperationEnum PanelOperation { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Width of this panel, given as ratio relative to the total clear opening width of the door.")]
		public IfcNormalisedRatioMeasure? PanelWidth { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Position of this panel within the door.")]
		[Required()]
		public IfcDoorPanelPositionEnum PanelPosition { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("Pointer to the shape aspect, if given. The shape aspect reflects the part of the door shape, which represents the door panel.")]
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
