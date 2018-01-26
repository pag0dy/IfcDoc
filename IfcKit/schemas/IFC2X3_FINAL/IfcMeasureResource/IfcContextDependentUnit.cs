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
	[Guid("1eb4e16c-04b8-49e2-b05b-ae0acdb64162")]
	public partial class IfcContextDependentUnit : IfcNamedUnit
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
	
		public IfcContextDependentUnit()
		{
		}
	
		public IfcContextDependentUnit(IfcDimensionalExponents __Dimensions, IfcUnitEnum __UnitType, IfcLabel __Name)
			: base(__Dimensions, __UnitType)
		{
			this._Name = __Name;
		}
	
		[Description("The word, or group of words, by which the context dependent unit is referred to.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
	
	}
	
}
