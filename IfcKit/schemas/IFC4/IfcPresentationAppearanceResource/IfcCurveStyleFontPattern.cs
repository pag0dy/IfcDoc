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
	[Guid("da500633-fe56-47a8-9405-98c6a95e757b")]
	public partial class IfcCurveStyleFontPattern : IfcPresentationItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _VisibleSegmentLength;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _InvisibleSegmentLength;
	
	
		[Description(@"<EPM-HTML>
	The length of the visible segment in the pattern definition.
	<blockquote class=""note"">NOTE&nbsp; For a visible segment representing a point, the value 0. should be assigned.</blockquote>
	<blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The datatype has been changed to IfcLengthMeasure with upward compatibility for file-based exchange.</blockquote>
	</EPM-HTML>")]
		public IfcLengthMeasure VisibleSegmentLength { get { return this._VisibleSegmentLength; } set { this._VisibleSegmentLength = value;} }
	
		[Description("The length of the invisible segment in the pattern definition.")]
		public IfcPositiveLengthMeasure InvisibleSegmentLength { get { return this._InvisibleSegmentLength; } set { this._InvisibleSegmentLength = value;} }
	
	
	}
	
}
