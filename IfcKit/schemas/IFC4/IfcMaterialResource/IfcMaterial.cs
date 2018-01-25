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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("b36052ed-896b-48e8-b655-a1b4cb67f826")]
	public partial class IfcMaterial : IfcMaterialDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Category;
	
		[InverseProperty("RepresentedMaterial")] 
		[XmlElement("IfcMaterialDefinitionRepresentation")]
		ISet<IfcMaterialDefinitionRepresentation> _HasRepresentation = new HashSet<IfcMaterialDefinitionRepresentation>();
	
		[InverseProperty("RelatedMaterials")] 
		ISet<IfcMaterialRelationship> _IsRelatedWith = new HashSet<IfcMaterialRelationship>();
	
		[InverseProperty("RelatingMaterial")] 
		ISet<IfcMaterialRelationship> _RelatesTo = new HashSet<IfcMaterialRelationship>();
	
	
		[Description(@"Name of the material. 
	<blockquote class=""example"">EXAMPLE A view definition may require <em>Material.Name</em> to uniquely specify e.g. concrete or steel grade, in which case the attribute Material.Category could take the value 'Concrete' or 'Steel'. </blockquote>
	  <blockquote class=""note"">
	NOTE&nbsp; Material grade may have different meaning in different view definitions, e.g. strength grade for structural design and analysis, or visible appearance grade in architectural application. Also, more elaborate material grade definition may be associated as classification via inverse attribute <em>HasExternalReferences</em>.
	</blockquote>")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Definition of the material in more descriptive terms than given by attributes <em" +
	    ">Name</em> or <em>Category</em>.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&" +
	    "nbsp; The attribute has been added at the end of attribute list.</blockquote>")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"Definition of the category (group or type) of material, in more general terms than given by attribute <em>Name</em>.  
	<blockquote class=""example"">EXAMPLE A view definition may require each <em>Material.Name</em> to be unique, e.g. for each concrete or steel grade used in a project, in which case <em>Material.Category</em> could take the values 'Concrete' or 'Steel'.</blockquote>
	  <blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been added at the end of attribute list.</blockquote>")]
		public IfcLabel? Category { get { return this._Category; } set { this._Category = value;} }
	
		[Description(@"Reference to the <em>IfcMaterialDefinitionRepresentation</em> that provides presentation information to a representation common to this material in style definitions.
	  <blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The inverse attribute <em>HasRepresentation</em> has been added.</blockquote>")]
		public ISet<IfcMaterialDefinitionRepresentation> HasRepresentation { get { return this._HasRepresentation; } }
	
		[Description("Reference to a material relationship indicating that this material is a part (or " +
	    "constituent) in a material composite.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CH" +
	    "ANGE&nbsp; The inverse attribute has been added.</blockquote>")]
		public ISet<IfcMaterialRelationship> IsRelatedWith { get { return this._IsRelatedWith; } }
	
		[Description("Reference to a material relationship indicating that this material composite has " +
	    "parts (or constituents).\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Th" +
	    "e inverse attribute has been added.</blockquote>")]
		public ISet<IfcMaterialRelationship> RelatesTo { get { return this._RelatesTo; } }
	
	
	}
	
}
