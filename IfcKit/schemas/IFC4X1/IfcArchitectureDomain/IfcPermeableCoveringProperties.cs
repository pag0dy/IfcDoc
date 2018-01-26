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

namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	[Guid("86f03acb-40b6-4eb7-a6ab-18cd8f7ffd58")]
	public partial class IfcPermeableCoveringProperties : IfcPreDefinedPropertySet
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPermeableCoveringOperationEnum _OperationType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcWindowPanelPositionEnum _PanelPosition;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _FrameDepth;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _FrameThickness;
	
		[DataMember(Order=4)] 
		[XmlElement]
		IfcShapeAspect _ShapeAspectStyle;
	
	
		public IfcPermeableCoveringProperties()
		{
		}
	
		public IfcPermeableCoveringProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPermeableCoveringOperationEnum __OperationType, IfcWindowPanelPositionEnum __PanelPosition, IfcPositiveLengthMeasure? __FrameDepth, IfcPositiveLengthMeasure? __FrameThickness, IfcShapeAspect __ShapeAspectStyle)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._OperationType = __OperationType;
			this._PanelPosition = __PanelPosition;
			this._FrameDepth = __FrameDepth;
			this._FrameThickness = __FrameThickness;
			this._ShapeAspectStyle = __ShapeAspectStyle;
		}
	
		[Description("Types of permeable covering operations. Also used to assign standard symbolic pre" +
	    "sentations according to national building standards.\r\n")]
		public IfcPermeableCoveringOperationEnum OperationType { get { return this._OperationType; } set { this._OperationType = value;} }
	
		[Description("Position of this permeable covering panel within the overall window or door type." +
	    "")]
		public IfcWindowPanelPositionEnum PanelPosition { get { return this._PanelPosition; } set { this._PanelPosition = value;} }
	
		[Description("Depth of panel frame (used to include the permeable covering), measured from fron" +
	    "t face to back face horizontally (i.e. perpendicular to the window or door (elev" +
	    "ation) plane.")]
		public IfcPositiveLengthMeasure? FrameDepth { get { return this._FrameDepth; } set { this._FrameDepth = value;} }
	
		[Description("Width of panel frame (used to include the permeable covering), measured from insi" +
	    "de of panel (at permeable covering) to outside of panel (at lining), i.e. parall" +
	    "el to the window or door (elevation) plane.")]
		public IfcPositiveLengthMeasure? FrameThickness { get { return this._FrameThickness; } set { this._FrameThickness = value;} }
	
		[Description("Optional link to a shape aspect definition, which points to the part of the geome" +
	    "tric representation of the window style, which is used to represent the permeabl" +
	    "e covering.")]
		public IfcShapeAspect ShapeAspectStyle { get { return this._ShapeAspectStyle; } set { this._ShapeAspectStyle = value;} }
	
	
	}
	
}
