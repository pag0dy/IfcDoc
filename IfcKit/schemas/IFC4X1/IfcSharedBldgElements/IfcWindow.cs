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

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("0549964e-0238-4c15-94a8-d0eb3971f168")]
	public partial class IfcWindow : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _OverallHeight;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _OverallWidth;
	
	
		[Description(@"<EPM-HTML>Overall measure of the height, it reflects the Z Dimension of a bounding box, enclosing the <strike>body of the</strike> window opening. If omitted, the <i>OverallHeight</i> should be taken from the geometric representation of the <i>IfcOpening</i> in which the window is inserted. 
	  <blockquote> <small>
	NOTE&nbsp; The body of the window might be taller then the window opening (e.g. in cases where the window lining includes a casing). In these cases the <i>OverallHeight</i> shall still be given as the window opening height, and not as the total height of the window lining.</small></blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? OverallHeight { get { return this._OverallHeight; } set { this._OverallHeight = value;} }
	
		[Description(@"<EPM-HTML>Overall measure of the width, it reflects the X Dimension of a bounding box, enclosing the <strike>body of the</strike> window opening. If omitted, the <i>OverallWidth</i> should be taken from the geometric representation of the <i>IfcOpening</i> in which the window is inserted. 
	  <blockquote> <small>
	NOTE&nbsp; The body of the window might be wider then the window opening (e.g. in cases where the window lining includes a casing). In these cases the <i>OverallWidth</i> shall still be given as the window opening width, and not as the total width of the window lining.</small></blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? OverallWidth { get { return this._OverallWidth; } set { this._OverallWidth = value;} }
	
	
	}
	
}
