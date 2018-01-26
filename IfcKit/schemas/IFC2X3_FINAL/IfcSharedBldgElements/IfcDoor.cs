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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("ebf3c617-cb2c-48fe-8dc0-d74e9b098b90")]
	public partial class IfcDoor : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _OverallHeight;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _OverallWidth;
	
	
		public IfcDoor()
		{
		}
	
		public IfcDoor(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcPositiveLengthMeasure? __OverallHeight, IfcPositiveLengthMeasure? __OverallWidth)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._OverallHeight = __OverallHeight;
			this._OverallWidth = __OverallWidth;
		}
	
		[Description(@"<EPM-HTML>Overall measure of the height, it reflects the Z Dimension of a bounding box, enclosing the <strike>body of the</strike> door opening. If omitted, the <i>OverallHeight</i> should be taken from the geometric representation of the <i>IfcOpening</i> in which the door is inserted. 
	  <blockquote><small>
	NOTE&nbsp; The body of the door might be taller then the door opening (e.g. in cases where the door lining includes a casing). In these cases the <i>OverallHeight</i> shall still be given as the door opening height, and not as the total height of the door lining.</small></blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? OverallHeight { get { return this._OverallHeight; } set { this._OverallHeight = value;} }
	
		[Description(@"<EPM-HTML>Overall measure of the width, it reflects the X Dimension of a bounding box, enclosing the <strike>body of the</strike> door opening. If omitted, the <i>OverallWidth</i> should be taken from the geometric representation of the <i>IfcOpening</i> in which the door is inserted. 
	  <blockquote> <small>
	NOTE&nbsp; The body of the door might be wider then the door opening (e.g. in cases where the door lining includes a casing). In these cases the <i>OverallWidth</i> shall still be given as the door opening width, and not as the total width of the door lining.</small></blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? OverallWidth { get { return this._OverallWidth; } set { this._OverallWidth = value;} }
	
	
	}
	
}
