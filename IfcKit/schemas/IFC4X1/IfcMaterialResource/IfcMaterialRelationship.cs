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

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("6e3cd925-5085-4070-91c6-868ff915e9ae")]
	public partial class IfcMaterialRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcMaterial _RelatingMaterial;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcMaterial> _RelatedMaterials = new HashSet<IfcMaterial>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Expression;
	
	
		public IfcMaterialRelationship()
		{
		}
	
		public IfcMaterialRelationship(IfcLabel? __Name, IfcText? __Description, IfcMaterial __RelatingMaterial, IfcMaterial[] __RelatedMaterials, IfcLabel? __Expression)
			: base(__Name, __Description)
		{
			this._RelatingMaterial = __RelatingMaterial;
			this._RelatedMaterials = new HashSet<IfcMaterial>(__RelatedMaterials);
			this._Expression = __Expression;
		}
	
		[Description("Reference to the relating material (the composite).")]
		public IfcMaterial RelatingMaterial { get { return this._RelatingMaterial; } set { this._RelatingMaterial = value;} }
	
		[Description("Reference to related materials (as constituents of composite material).")]
		public ISet<IfcMaterial> RelatedMaterials { get { return this._RelatedMaterials; } }
	
		[Description(@"Information about the material relationship refering for example to the amount of related materials in the composite material. 
	<blockquote class=""note"">NOTE&nbsp; Any formal meaning of the <em>Expression</em> string value has to be established in model view definitions or implementer agreements. No such formal language is provided as part of this specification.</blockquote>")]
		public IfcLabel? Expression { get { return this._Expression; } set { this._Expression = value;} }
	
	
	}
	
}
