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
	[Guid("70b10571-8732-44f7-a5b2-3fdb229d547b")]
	public partial class IfcDoor : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _OverallHeight;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _OverallWidth;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcDoorTypeEnum? _PredefinedType;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcDoorTypeOperationEnum? _OperationType;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedOperationType;
	
	
		[Description(@"<EPM-HTML>Overall measure of the height, it reflects the Z Dimension of a bounding box, enclosing the <strike>body of the</strike> door opening. If omitted, the <em>OverallHeight</em> should be taken from the geometric representation of the <em>IfcOpening</em> in which the door is inserted. 
	  <blockquote class=""note"">NOTE&nbsp; The body of the door might be taller then the door opening (e.g. in cases where the door lining includes a casing). In these cases the <em>OverallHeight</em> shall still be given as the door opening height, and not as the total height of the door lining.</blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? OverallHeight { get { return this._OverallHeight; } set { this._OverallHeight = value;} }
	
		[Description(@"<EPM-HTML>Overall measure of the width, it reflects the X Dimension of a bounding box, enclosing the <strike>body of the</strike> door opening. If omitted, the <em>OverallWidth</em> should be taken from the geometric representation of the <em>IfcOpening</em> in which the door is inserted. 
	  <blockquote class=""note"">NOTE&nbsp; The body of the door might be wider then the door opening (e.g. in cases where the door lining includes a casing). In these cases the <em>OverallWidth</em> shall still be given as the door opening width, and not as the total width of the door lining.</blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? OverallWidth { get { return this._OverallWidth; } set { this._OverallWidth = value;} }
	
		[Description(@"<EPM-HTML>
	Predefined generic type for a door that is specified in an enumeration. There may be a property set given specificly for the predefined types.
	<blockquote class=""note"">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcDoorType</em> is assigned, providing its own <em>IfcDoorType.PredefinedType</em>.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  The attribute has been added at the end of the entity definition.</blockquote>
	</EPM-HTML> ")]
		public IfcDoorTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"<EPM-HTML>
	Type defining the general layout and operation of the door type in terms of the partitioning of panels and panel operations. 
	<blockquote class=""note"">NOTE&nbsp; The <em>OperationType</em> shall only be used, if no type object <em>IfcDoorType</em> is assigned, providing its own <em>IfcDoorType.OperationType</em>.
	  </blockquote>
	  <blockquote class=""change-ifc2x4"">IFC4 CHANGE  The attribute has been added at the end of the entity definition.</blockquote>
	</EPM-HTML> ")]
		public IfcDoorTypeOperationEnum? OperationType { get { return this._OperationType; } set { this._OperationType = value;} }
	
		[Description("<EPM-HTML>\r\nDesignator for the user defined operation type, shall only be provide" +
	    "d, if the value of <em>OperationType</em> is set to USERDEFINED.\r\n</EPM-HTML>")]
		public IfcLabel? UserDefinedOperationType { get { return this._UserDefinedOperationType; } set { this._UserDefinedOperationType = value;} }
	
	
	}
	
}
