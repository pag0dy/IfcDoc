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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcSharedComponentElements
{
	[Guid("f7f5c079-1ef8-4a9e-a64c-86800f526d37")]
	public partial class IfcFastener : IfcElementComponent
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcFastenerTypeEnum? _PredefinedType;
	
	
		[Description("Subtype of fastener")]
		public IfcFastenerTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
