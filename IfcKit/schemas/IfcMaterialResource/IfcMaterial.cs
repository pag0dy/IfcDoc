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
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterial : IfcMaterialDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Name of the material.   <blockquote class=\"example\">EXAMPLE A view definition may require <em>Material.Name</em> to uniquely specify e.g. concrete or steel grade, in which case the attribute Material.Category could take the value 'Concrete' or 'Steel'. </blockquote>    <blockquote class=\"note\">  NOTE&nbsp; Material grade may have different meaning in different view definitions, e.g. strength grade for structural design and analysis, or visible appearance grade in architectural application. Also, more elaborate material grade definition may be associated as classification via inverse attribute <em>HasExternalReferences</em>.  </blockquote>")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Definition of the material in more descriptive terms than given by attributes <em>Name</em> or <em>Category</em>.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been added at the end of attribute list.</blockquote>")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Definition of the category (group or type) of material, in more general terms than given by attribute <em>Name</em>.    <blockquote class=\"example\">EXAMPLE A view definition may require each <em>Material.Name</em> to be unique, e.g. for each concrete or steel grade used in a project, in which case <em>Material.Category</em> could take the values 'Concrete' or 'Steel'.</blockquote>    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been added at the end of attribute list.</blockquote>")]
		public IfcLabel? Category { get; set; }
	
		[InverseProperty("RepresentedMaterial")] 
		[XmlElement]
		[Description("Reference to the <em>IfcMaterialDefinitionRepresentation</em> that provides presentation information to a representation common to this material in style definitions.    <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The inverse attribute <em>HasRepresentation</em> has been added.</blockquote>")]
		[MaxLength(1)]
		public ISet<IfcMaterialDefinitionRepresentation> HasRepresentation { get; protected set; }
	
		[InverseProperty("RelatedMaterials")] 
		[Description("Reference to a material relationship indicating that this material is a part (or constituent) in a material composite.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute has been added.</blockquote>")]
		public ISet<IfcMaterialRelationship> IsRelatedWith { get; protected set; }
	
		[InverseProperty("RelatingMaterial")] 
		[Description("Reference to a material relationship indicating that this material composite has parts (or constituents).  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute has been added.</blockquote>")]
		[MaxLength(1)]
		public ISet<IfcMaterialRelationship> RelatesTo { get; protected set; }
	
	
		public IfcMaterial(IfcLabel __Name, IfcText? __Description, IfcLabel? __Category)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.Category = __Category;
			this.HasRepresentation = new HashSet<IfcMaterialDefinitionRepresentation>();
			this.IsRelatedWith = new HashSet<IfcMaterialRelationship>();
			this.RelatesTo = new HashSet<IfcMaterialRelationship>();
		}
	
	
	}
	
}
