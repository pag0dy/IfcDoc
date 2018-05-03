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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialConstituentSet : IfcMaterialDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The name by which the constituent set is known.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Definition of the material constituent set in descriptive terms.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Identification of the constituents from which the material constituent set is composed.")]
		[MinLength(1)]
		public ISet<IfcMaterialConstituent> MaterialConstituents { get; protected set; }
	
	
		public IfcMaterialConstituentSet(IfcLabel? __Name, IfcText? __Description, IfcMaterialConstituent[] __MaterialConstituents)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.MaterialConstituents = new HashSet<IfcMaterialConstituent>(__MaterialConstituents);
		}
	
	
	}
	
}
