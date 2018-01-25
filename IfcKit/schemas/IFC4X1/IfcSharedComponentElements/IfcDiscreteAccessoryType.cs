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
	[Guid("fdfd0f31-eb16-42ce-a2d2-b2fccafaab2b")]
	public partial class IfcDiscreteAccessoryType : IfcElementComponentType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcDiscreteAccessoryTypeEnum _PredefinedType;
	
	
		[Description("Subtype of discrete accessory")]
		public IfcDiscreteAccessoryTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
