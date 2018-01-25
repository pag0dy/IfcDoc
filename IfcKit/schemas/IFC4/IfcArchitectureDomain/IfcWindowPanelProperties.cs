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
	[Guid("f4aaef0e-c0aa-4a75-9bad-670fdf12d4e4")]
	public partial class IfcWindowPanelProperties : IfcPreDefinedPropertySet
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcWindowPanelOperationEnum _OperationType;
	
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
		[XmlElement("IfcShapeAspect")]
		IfcShapeAspect _ShapeAspectStyle;
	
	
		[Description("Types of window panel operations. Also used to assign standard symbolic presentat" +
	    "ions according to national building standards.\r\n")]
		public IfcWindowPanelOperationEnum OperationType { get { return this._OperationType; } set { this._OperationType = value;} }
	
		[Description("Position of this panel within the overall window style.")]
		public IfcWindowPanelPositionEnum PanelPosition { get { return this._PanelPosition; } set { this._PanelPosition = value;} }
	
		[Description("Depth of panel frame, measured from front face to back face horizontally (i.e. pe" +
	    "rpendicular to the window (elevation) plane.")]
		public IfcPositiveLengthMeasure? FrameDepth { get { return this._FrameDepth; } set { this._FrameDepth = value;} }
	
		[Description("Width of panel frame, measured from inside of panel (at glazing) to outside of pa" +
	    "nel (at lining), i.e. parallel to the window (elevation) plane.")]
		public IfcPositiveLengthMeasure? FrameThickness { get { return this._FrameThickness; } set { this._FrameThickness = value;} }
	
		[Description(@"Optional link to a shape aspect definition, which points to the part of the geometric representation of the window style, which is used to represent the panel.
	<blockquote class=""deprecated"">DEPRECATION&nbsp; The attribute is deprecated and shall no longer be used, i.e. the value shall be NIL ($).</blockquote>")]
		public IfcShapeAspect ShapeAspectStyle { get { return this._ShapeAspectStyle; } set { this._ShapeAspectStyle = value;} }
	
	
	}
	
}
