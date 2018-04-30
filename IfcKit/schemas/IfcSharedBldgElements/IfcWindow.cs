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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public partial class IfcWindow : IfcBuildingElement
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("<EPM-HTML>Overall measure of the height, it reflects the Z Dimension of a bounding box, enclosing the <strike>body of the</strike> window opening. If omitted, the <i>OverallHeight</i> should be taken from the geometric representation of the <i>IfcOpening</i> in which the window is inserted.     <blockquote> <small>  NOTE&nbsp; The body of the window might be taller then the window opening (e.g. in cases where the window lining includes a casing). In these cases the <i>OverallHeight</i> shall still be given as the window opening height, and not as the total height of the window lining.</small></blockquote>  </EPM-HTML>")]
		public IfcPositiveLengthMeasure? OverallHeight { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("<EPM-HTML>Overall measure of the width, it reflects the X Dimension of a bounding box, enclosing the <strike>body of the</strike> window opening. If omitted, the <i>OverallWidth</i> should be taken from the geometric representation of the <i>IfcOpening</i> in which the window is inserted.     <blockquote> <small>  NOTE&nbsp; The body of the window might be wider then the window opening (e.g. in cases where the window lining includes a casing). In these cases the <i>OverallWidth</i> shall still be given as the window opening width, and not as the total width of the window lining.</small></blockquote>  </EPM-HTML>")]
		public IfcPositiveLengthMeasure? OverallWidth { get; set; }
	
	
		public IfcWindow(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcPositiveLengthMeasure? __OverallHeight, IfcPositiveLengthMeasure? __OverallWidth)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this.OverallHeight = __OverallHeight;
			this.OverallWidth = __OverallWidth;
		}
	
	
	}
	
}
