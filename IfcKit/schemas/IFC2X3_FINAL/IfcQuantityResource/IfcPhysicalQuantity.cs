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

namespace BuildingSmart.IFC.IfcQuantityResource
{
	[Guid("3967c12b-b38d-4002-b7ab-f5ce83293bcf")]
	public abstract partial class IfcPhysicalQuantity
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[InverseProperty("HasQuantities")] 
		ISet<IfcPhysicalComplexQuantity> _PartOfComplex = new HashSet<IfcPhysicalComplexQuantity>();
	
	
		[Description("Name of the element quantity or measure. The name attribute has to be made recogn" +
	    "izable by further agreements.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Further explanation that might be given to the quantity.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Reference to a physical complex quantity in which the physical quantity may be co" +
	    "ntained.")]
		public ISet<IfcPhysicalComplexQuantity> PartOfComplex { get { return this._PartOfComplex; } }
	
	
	}
	
}
