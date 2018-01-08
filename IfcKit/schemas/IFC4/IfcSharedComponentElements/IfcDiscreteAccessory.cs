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
	[Guid("5ba7cc3f-c0c3-42e3-bfe3-f54531a32ef7")]
	public partial class IfcDiscreteAccessory : IfcElementComponent
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcDiscreteAccessoryTypeEnum? _PredefinedType;
	
	
		[Description(@"<EPM-HTML>
	Subtype of discrete accessory.  If USERDEFINED, the type is further qualified by means of the inherited attribute <em>ObjectType</em>.  Refer to <em>IfcDiscreteAccessoryType</em> for a non-exclusive list of userdefined type designations which are applicable to <em>IfcDiscreteAccessory</em> as well.
	</EPM-HTML>
	")]
		public IfcDiscreteAccessoryTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
