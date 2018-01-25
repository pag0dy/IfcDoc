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
	[Guid("27535f79-e61d-421d-a55b-ea63de53cc7b")]
	public partial class IfcDerivedUnitElement
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcNamedUnit _Unit;
	
		[DataMember(Order=1)] 
		[Required()]
		Int64 _Exponent;
	
	
		[Description("The fixed quantity which is used as the mathematical factor.")]
		public IfcNamedUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
		[Description("The power that is applied to the unit attribute.")]
		public Int64 Exponent { get { return this._Exponent; } set { this._Exponent = value;} }
	
	
	}
	
}
