// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public partial class IfcPhysicalComplexQuantity : IfcPhysicalQuantity
	{
		[DataMember(Order = 0)] 
		[Description("Set of physical quantities that are grouped by this complex physical quantity according to a given discrimination.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcPhysicalQuantity> HasQuantities { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Identification of the discrimination by which this physical complex property is distinguished. Examples of discriminations are 'layer', 'steel bar diameter', etc.")]
		[Required()]
		public IfcLabel Discrimination { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Additional indication of a quality of the quantities that are grouped under this physical complex quantity.")]
		public IfcLabel? Quality { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Additional indication of a usage type of the quantities that are grouped under this physical complex quantity.")]
		public IfcLabel? Usage { get; set; }
	
	
		public IfcPhysicalComplexQuantity(IfcLabel __Name, IfcText? __Description, IfcPhysicalQuantity[] __HasQuantities, IfcLabel __Discrimination, IfcLabel? __Quality, IfcLabel? __Usage)
			: base(__Name, __Description)
		{
			this.HasQuantities = new HashSet<IfcPhysicalQuantity>(__HasQuantities);
			this.Discrimination = __Discrimination;
			this.Quality = __Quality;
			this.Usage = __Usage;
		}
	
	
	}
	
}
