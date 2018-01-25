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
	[Guid("0f9043b3-19f5-4f1b-b221-76018647d933")]
	public partial class IfcWindow : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _OverallHeight;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _OverallWidth;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcWindowTypeEnum? _PredefinedType;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcWindowTypePartitioningEnum? _PartitioningType;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedPartitioningType;
	
	
		[Description(@"Overall measure of the height, it reflects the Z Dimension of a bounding box, enclosing the window opening. If omitted, the <em>OverallHeight</em> should be taken from the geometric representation of the <em>IfcOpening</em> in which the window is inserted. 
	
	<blockquote class=""note"">NOTE&nbsp; The body of the window might be taller then the window opening (for example in cases where the window lining includes a casing). In these cases the <em>OverallHeight</em> shall still be given as the window opening height, and not as the total height of the window lining.</blockquote>")]
		public IfcPositiveLengthMeasure? OverallHeight { get { return this._OverallHeight; } set { this._OverallHeight = value;} }
	
		[Description(@"Overall measure of the width, it reflects the X Dimension of a bounding box, enclosing the window opening. If omitted, the <em>OverallWidth</em> should be taken from the geometric representation of the <em>IfcOpening</em> in which the window is inserted. 
	
	<blockquote class=""note"">NOTE&nbsp; The body of the window might be wider then the window opening (for example in cases where the window lining includes a casing). In these cases the <em>OverallWidth</em> shall still be given as the window opening width, and not as the total width of the window lining.</blockquote>")]
		public IfcPositiveLengthMeasure? OverallWidth { get { return this._OverallWidth; } set { this._OverallWidth = value;} }
	
		[Description(@"Predefined generic type for a window that is specified in an enumeration. There may be a property set given specificly for the predefined types.
	<blockquote class=""note"">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcWindowType</em> is assigned, providing its own <em>IfcWindowType.PredefinedType</em>.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  The attribute has been added at the end of the entity definition.</blockquote> ")]
		public IfcWindowTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"Type defining the general layout of the window in terms of the partitioning of panels. 
	<blockquote class=""note"">NOTE&nbsp; The <em>PartitioningType</em> shall only be used, if no type object <em>IfcWindowType</em> is assigned, providing its own <em>IfcWindowType.PartitioningType</em>.
	  </blockquote>
	  <blockquote class=""change-ifc2x4"">IFC4 CHANGE  The attribute has been added at the end of the entity definition.</blockquote> ")]
		public IfcWindowTypePartitioningEnum? PartitioningType { get { return this._PartitioningType; } set { this._PartitioningType = value;} }
	
		[Description("Designator for the user defined partitioning type, shall only be provided, if the" +
	    " value of <em>PartitioningType</em> is set to USERDEFINED.")]
		public IfcLabel? UserDefinedPartitioningType { get { return this._UserDefinedPartitioningType; } set { this._UserDefinedPartitioningType = value;} }
	
	
	}
	
}
