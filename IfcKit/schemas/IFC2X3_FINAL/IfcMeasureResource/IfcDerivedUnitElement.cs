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


namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("2129b759-b439-40db-bc00-5909784c9e63")]
	public partial class IfcDerivedUnitElement
	{
		[DataMember(Order=0)] 
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
