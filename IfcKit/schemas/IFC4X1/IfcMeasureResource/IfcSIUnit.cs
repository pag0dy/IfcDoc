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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;

namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("9cc2c277-dce2-45a4-83ff-50f25a31ece8")]
	public partial class IfcSIUnit : IfcNamedUnit
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcSIPrefix? _Prefix;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcSIUnitName _Name;
	
	
		[Description("The SI Prefix for defining decimal multiples and submultiples of the unit.")]
		public IfcSIPrefix? Prefix { get { return this._Prefix; } set { this._Prefix = value;} }
	
		[Description("The word, or group of words, by which the SI unit is referred to.\r\n\r\n<blockquote " +
	    "class=\"note\">NOTE&nbsp; Even though the SI system\'s base unit for mass is kilogr" +
	    "am, the <em>IfcSIUnit</em> for mass is gram if no <em>Prefix</em> is asserted.</" +
	    "blockquote>\r\n")]
		public IfcSIUnitName Name { get { return this._Name; } set { this._Name = value;} }
	
		public new IfcDimensionalExponents Dimensions { get { return null; } }
	
	
	}
	
}
