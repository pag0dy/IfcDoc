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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcQuantityResource
{
	[Guid("b98590b4-3769-4d15-88cf-7716e2c2bada")]
	public partial class IfcPhysicalComplexQuantity : IfcPhysicalQuantity
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcPhysicalQuantity> _HasQuantities = new HashSet<IfcPhysicalQuantity>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Discrimination;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Quality;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _Usage;
	
	
		[Description("Set of physical quantities that are grouped by this complex physical quantity acc" +
	    "ording to a given discrimination.")]
		public ISet<IfcPhysicalQuantity> HasQuantities { get { return this._HasQuantities; } }
	
		[Description("Identification of the discrimination by which this physical complex property is d" +
	    "istinguished. Examples of discriminations are \'layer\', \'steel bar diameter\', etc" +
	    ".")]
		public IfcLabel Discrimination { get { return this._Discrimination; } set { this._Discrimination = value;} }
	
		[Description("Additional indication of a quality of the quantities that are grouped under this " +
	    "physical complex quantity.")]
		public IfcLabel? Quality { get { return this._Quality; } set { this._Quality = value;} }
	
		[Description("Additional indication of a usage type of the quantities that are grouped under th" +
	    "is physical complex quantity.")]
		public IfcLabel? Usage { get { return this._Usage; } set { this._Usage = value;} }
	
	
	}
	
}
