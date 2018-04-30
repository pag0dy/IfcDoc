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

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialClassificationRelationship
	{
		[DataMember(Order = 0)] 
		[Description("The material classifications identifying the type of material.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcClassificationSelect> MaterialClassifications { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Material being classified.")]
		[Required()]
		public IfcMaterial ClassifiedMaterial { get; set; }
	
	
		public IfcMaterialClassificationRelationship(IfcClassificationSelect[] __MaterialClassifications, IfcMaterial __ClassifiedMaterial)
		{
			this.MaterialClassifications = new HashSet<IfcClassificationSelect>(__MaterialClassifications);
			this.ClassifiedMaterial = __ClassifiedMaterial;
		}
	
	
	}
	
}
