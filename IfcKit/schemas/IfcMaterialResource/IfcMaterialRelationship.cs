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

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Reference to the relating material (the composite).")]
		[Required()]
		public IfcMaterial RelatingMaterial { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to related materials (as constituents of composite material).")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcMaterial> RelatedMaterials { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Information about the material relationship refering for example to the amount of related materials in the composite material.   <blockquote class=\"note\">NOTE&nbsp; Any formal meaning of the <em>Expression</em> string value has to be established in model view definitions or implementer agreements. No such formal language is provided as part of this specification.</blockquote>")]
		public IfcLabel? Expression { get; set; }
	
	
		public IfcMaterialRelationship(IfcLabel? __Name, IfcText? __Description, IfcMaterial __RelatingMaterial, IfcMaterial[] __RelatedMaterials, IfcLabel? __Expression)
			: base(__Name, __Description)
		{
			this.RelatingMaterial = __RelatingMaterial;
			this.RelatedMaterials = new HashSet<IfcMaterial>(__RelatedMaterials);
			this.Expression = __Expression;
		}
	
	
	}
	
}
