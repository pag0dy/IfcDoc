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
	[Guid("ca6074f0-a8aa-4b5b-a402-931d20010f8b")]
	public abstract partial class IfcReinforcingElement : IfcElementComponent
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _SteelGrade;
	
	
		[Description("<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute deprecated.\r\nUse ma" +
	    "terial association at <em>IfcReinforcingElementType</em> instead.</blockquote>")]
		public IfcLabel? SteelGrade { get { return this._SteelGrade; } set { this._SteelGrade = value;} }
	
	
	}
	
}
