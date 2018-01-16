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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("986bf516-0c1c-465d-992a-2150e7aabe95")]
	public partial class IfcPile : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPileTypeEnum? _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPileConstructionEnum? _ConstructionType;
	
	
		[Description("The predefined generic type of the pile according to function.\r\n\r\n<blockquote cla" +
	    "ss=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional.  Type information " +
	    "can be provided by <em>IfcRelDefinesByType</em> and <em>IfcPileType</em>.</block" +
	    "quote>")]
		public IfcPileTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"Deprecated.
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; Material profile association capability by means of <em>IfcRelAssociatesMaterial</em> has been added.  The attribute <em>ConstructionType</em> should not be used whenever its information can be provided by a material profile set, either associated with the <em>IfcPile</em> object or, if present, with a corresponding instance of <em>IfcPileType</em>.</blockquote>")]
		public IfcPileConstructionEnum? ConstructionType { get { return this._ConstructionType; } set { this._ConstructionType = value;} }
	
	
	}
	
}
