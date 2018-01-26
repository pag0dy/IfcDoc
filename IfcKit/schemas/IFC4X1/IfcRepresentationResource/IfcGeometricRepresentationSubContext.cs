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
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("2e4bdfcf-4532-4cf3-b45f-4372edb5bfb3")]
	public partial class IfcGeometricRepresentationSubContext : IfcGeometricRepresentationContext
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		IfcGeometricRepresentationContext _ParentContext;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _TargetScale;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcGeometricProjectionEnum _TargetView;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedTargetView;
	
	
		public IfcGeometricRepresentationSubContext()
		{
		}
	
		public IfcGeometricRepresentationSubContext(IfcLabel? __ContextIdentifier, IfcLabel? __ContextType, IfcDimensionCount __CoordinateSpaceDimension, IfcReal? __Precision, IfcAxis2Placement __WorldCoordinateSystem, IfcDirection __TrueNorth, IfcGeometricRepresentationContext __ParentContext, IfcPositiveRatioMeasure? __TargetScale, IfcGeometricProjectionEnum __TargetView, IfcLabel? __UserDefinedTargetView)
			: base(__ContextIdentifier, __ContextType, __CoordinateSpaceDimension, __Precision, __WorldCoordinateSystem, __TrueNorth)
		{
			this._ParentContext = __ParentContext;
			this._TargetScale = __TargetScale;
			this._TargetView = __TargetView;
			this._UserDefinedTargetView = __UserDefinedTargetView;
		}
	
		[Description("Parent context from which the sub context derives its world coordinate system, pr" +
	    "ecision, space coordinate dimension and true north.")]
		public IfcGeometricRepresentationContext ParentContext { get { return this._ParentContext; } set { this._ParentContext = value;} }
	
		[Description(@"The target <font color=""#ff0000"">plot</font> scale of the representation 
	to which this representation context applies.
	<blockquote class=""note"">NOTE&nbsp; Scale indicates the target plot scale for
	the representation sub context, all annotation styles are given in plot
	dimensions according to this target plot scale.<br>
	If multiple instances of <em>IfcGeometricRepresentationSubContext</em>
	are given having the same <em>TargetView</em> value, the target plot scale 
	applies up to the next smaller scale, or up to unlimited small scale.</blockquote>
	
	<blockquote class=""note"">NOTE&nbsp; Scale 1:100 (given as 0.01 within <em>TargetScale</em>)
	is bigger then 1:200 (given as 0.005 within <em>TargetScale</em>).</blockquote>")]
		public IfcPositiveRatioMeasure? TargetScale { get { return this._TargetScale; } set { this._TargetScale = value;} }
	
		[Description("Target view of the representation to which this representation context applies.")]
		public IfcGeometricProjectionEnum TargetView { get { return this._TargetView; } set { this._TargetView = value;} }
	
		[Description("User defined target view, this attribute value shall be given, if the TargetView " +
	    "attribute is set to USERDEFINED.")]
		public IfcLabel? UserDefinedTargetView { get { return this._UserDefinedTargetView; } set { this._UserDefinedTargetView = value;} }
	
		public new IfcAxis2Placement WorldCoordinateSystem { get { return null; } }
	
		public new IfcDimensionCount CoordinateSpaceDimension { get { return new IfcDimensionCount(); } }
	
		public new IfcDirection TrueNorth { get { return null; } }
	
		public new IfcReal Precision { get { return new IfcReal(); } }
	
	
	}
	
}
