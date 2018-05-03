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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public abstract partial class IfcMaterialDefinition :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[InverseProperty("RelatingMaterial")] 
		[Description("Use of the <em>IfcMaterialDefinition</em> subtypes within the material association of an element occurrence or element type. The association is established by the <em>IfcRelAssociatesMaterial</em> relationship.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute has been added.</blockquote>")]
		public ISet<IfcRelAssociatesMaterial> AssociatedTo { get; protected set; }
	
		[InverseProperty("RelatedResourceObjects")] 
		[Description("Reference to external references, e.g. library, classification, or document information, that are associated to the material.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute has been added.</blockquote> ")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReferences { get; protected set; }
	
		[InverseProperty("Material")] 
		[XmlElement("IfcMaterialProperties")]
		[Description("Material properties assigned to instances of subtypes of <em>IfcMaterialDefinition</em>.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute has been added.</blockquote>")]
		public ISet<IfcMaterialProperties> HasProperties { get; protected set; }
	
	
		protected IfcMaterialDefinition()
		{
			this.AssociatedTo = new HashSet<IfcRelAssociatesMaterial>();
			this.HasExternalReferences = new HashSet<IfcExternalReferenceRelationship>();
			this.HasProperties = new HashSet<IfcMaterialProperties>();
		}
	
	
	}
	
}
