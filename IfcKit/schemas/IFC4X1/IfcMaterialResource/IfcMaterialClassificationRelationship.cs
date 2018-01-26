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

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("5b9df3e2-be80-4922-9a85-8f8fb6e9cbef")]
	public partial class IfcMaterialClassificationRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcClassificationSelect> _MaterialClassifications = new HashSet<IfcClassificationSelect>();
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcMaterial _ClassifiedMaterial;
	
	
		public IfcMaterialClassificationRelationship()
		{
		}
	
		public IfcMaterialClassificationRelationship(IfcClassificationSelect[] __MaterialClassifications, IfcMaterial __ClassifiedMaterial)
		{
			this._MaterialClassifications = new HashSet<IfcClassificationSelect>(__MaterialClassifications);
			this._ClassifiedMaterial = __ClassifiedMaterial;
		}
	
		[Description("The material classifications identifying the type of material.")]
		public ISet<IfcClassificationSelect> MaterialClassifications { get { return this._MaterialClassifications; } }
	
		[Description("Material being classified.")]
		public IfcMaterial ClassifiedMaterial { get { return this._ClassifiedMaterial; } set { this._ClassifiedMaterial = value;} }
	
	
	}
	
}
