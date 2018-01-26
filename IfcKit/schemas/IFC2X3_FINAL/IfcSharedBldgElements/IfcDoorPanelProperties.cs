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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("929c68e4-ea5c-422d-9ad7-0c692a608578")]
	public partial class IfcDoorPanelProperties : IfcPropertySetDefinition
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
		IfcShapeAspect _ShapeAspectStyle;
	
	
		public IfcDoorPanelProperties()
		{
		}
	
		public IfcDoorPanelProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPositiveLengthMeasure? __PanelDepth, IfcDoorPanelOperationEnum __PanelOperation, IfcNormalisedRatioMeasure? __PanelWidth, IfcDoorPanelPositionEnum __PanelPosition, IfcShapeAspect __ShapeAspectStyle)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._PanelDepth = __PanelDepth;
			this._PanelOperation = __PanelOperation;
			this._PanelWidth = __PanelWidth;
			this._PanelPosition = __PanelPosition;
			this._ShapeAspectStyle = __ShapeAspectStyle;
		}
	
		[Description("Depth of the door panel, measured perpendicular to the plane of the door leaf. ")]
		public IfcPositiveLengthMeasure? PanelDepth { get { return this._PanelDepth; } set { this._PanelDepth = value;} }
	
		[Description("The PanelOperation defines the way of operation of that panel. The PanelOperation" +
	    " of the door panel has to correspond with the OperationType of the IfcDoorStyle." +
	    "")]
		public IfcDoorPanelOperationEnum PanelOperation { get { return this._PanelOperation; } set { this._PanelOperation = value;} }
	
		[Description("Width of this panel, given as ratio relative to the total clear opening width of " +
	    "the door.")]
		public IfcNormalisedRatioMeasure? PanelWidth { get { return this._PanelWidth; } set { this._PanelWidth = value;} }
	
		[Description("Position of this panel within the door.")]
		public IfcDoorPanelPositionEnum PanelPosition { get { return this._PanelPosition; } set { this._PanelPosition = value;} }
	
		[Description("Pointer to the shape aspect, if given. The shape aspect reflects the part of the " +
	    "door shape, which represents the door panel.")]
		public IfcShapeAspect ShapeAspectStyle { get { return this._ShapeAspectStyle; } set { this._ShapeAspectStyle = value;} }
	
	
	}
	
}
