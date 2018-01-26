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
	[Guid("048744df-7b72-4775-bb9d-23cb26297991")]
	public partial class IfcMaterialClassificationRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcClassificationNotationSelect> _MaterialClassifications = new HashSet<IfcClassificationNotationSelect>();
	
		[DataMember(Order=1)] 
		[Required()]
		IfcMaterial _ClassifiedMaterial;
	
	
		public IfcMaterialClassificationRelationship()
		{
		}
	
		public IfcMaterialClassificationRelationship(IfcClassificationNotationSelect[] __MaterialClassifications, IfcMaterial __ClassifiedMaterial)
		{
			this._MaterialClassifications = new HashSet<IfcClassificationNotationSelect>(__MaterialClassifications);
			this._ClassifiedMaterial = __ClassifiedMaterial;
		}
	
		[Description("The material classifications identifying the type of material.")]
		public ISet<IfcClassificationNotationSelect> MaterialClassifications { get { return this._MaterialClassifications; } }
	
		[Description("Material being classified.")]
		public IfcMaterial ClassifiedMaterial { get { return this._ClassifiedMaterial; } set { this._ClassifiedMaterial = value;} }
	
	
	}
	
}
