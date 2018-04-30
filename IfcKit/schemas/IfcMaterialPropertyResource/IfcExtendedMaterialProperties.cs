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

using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	public partial class IfcExtendedMaterialProperties : IfcMaterialProperties
	{
		[DataMember(Order = 0)] 
		[Description("The set of material properties defined by user for this material.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcProperty> ExtendedProperties { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Description for the set of extended properties.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The name given to the set of extended properties.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
	
		public IfcExtendedMaterialProperties(IfcMaterial __Material, IfcProperty[] __ExtendedProperties, IfcText? __Description, IfcLabel __Name)
			: base(__Material)
		{
			this.ExtendedProperties = new HashSet<IfcProperty>(__ExtendedProperties);
			this.Description = __Description;
			this.Name = __Name;
		}
	
	
	}
	
}
