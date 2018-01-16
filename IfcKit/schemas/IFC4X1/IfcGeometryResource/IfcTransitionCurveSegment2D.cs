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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("b77db604-8175-4a1a-a61b-41f170430693")]
	public partial class IfcTransitionCurveSegment2D : IfcCurveSegment2D
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _StartRadius;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _EndRadius;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _IsStartRadiusCCW;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _IsEndRadiusCCW;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcTransitionCurveType _TransitionCurveType;
	
	
		[Description("The radius of the curve at the start point. If the radius is not provided by a va" +
	    "lue, i.e. being “NIL” it is interpreted as INFINITE – the <i>StartPoint</i> is a" +
	    "t the point, where it does not have a curvature.")]
		public IfcPositiveLengthMeasure? StartRadius { get { return this._StartRadius; } set { this._StartRadius = value;} }
	
		[Description("The radius of the curve at the end point. If the radius is not provided by a valu" +
	    "e, i.e. being “NIL” it is interpreted as INFINITE – the end point is at the poin" +
	    "t, where it does not have a curvature.")]
		public IfcPositiveLengthMeasure? EndRadius { get { return this._EndRadius; } set { this._EndRadius = value;} }
	
		[Description(@"Indication of the curve starting counter-clockwise or clockwise. The orientation of the curve is IsCcw=”true”, if the spiral arc goes counter-clockwise as seen from the start point and start direction, or “to the left"", and with IsCcw=”false” if the spiral arc goes clockwise, or “to the right”.")]
		public IfcBoolean IsStartRadiusCCW { get { return this._IsStartRadiusCCW; } set { this._IsStartRadiusCCW = value;} }
	
		[Description(@"Indication of the curve ending counter-clockwise or clockwise. The orientation of the clothoidal arc is IsCcw=”true”, if the spiral arc goes counter-clockwise as seen towards the end point and end direction, or “to the left"", and with IsCcw=”false” if the spiral arc goes clockwise, or “to the right”.")]
		public IfcBoolean IsEndRadiusCCW { get { return this._IsEndRadiusCCW; } set { this._IsEndRadiusCCW = value;} }
	
		[Description("Indicates the specific type of transition curve.")]
		public IfcTransitionCurveType TransitionCurveType { get { return this._TransitionCurveType; } set { this._TransitionCurveType = value;} }
	
	
	}
	
}
