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
	[Guid("b31f0891-e60f-4cc1-9b3b-9bbae1fde79c")]
	public abstract partial class IfcMaterialDefinition :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[InverseProperty("RelatingMaterial")] 
		ISet<IfcRelAssociatesMaterial> _AssociatedTo = new HashSet<IfcRelAssociatesMaterial>();
	
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcExternalReferenceRelationship> _HasExternalReferences = new HashSet<IfcExternalReferenceRelationship>();
	
		[InverseProperty("Material")] 
		[XmlElement]
		ISet<IfcMaterialProperties> _HasProperties = new HashSet<IfcMaterialProperties>();
	
	
		[Description(@"Use of the <em>IfcMaterialDefinition</em> subtypes within the material association of an element occurrence or element type. The association is established by the <em>IfcRelAssociatesMaterial</em> relationship.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The inverse attribute has been added.</blockquote>")]
		public ISet<IfcRelAssociatesMaterial> AssociatedTo { get { return this._AssociatedTo; } }
	
		[Description("Reference to external references, e.g. library, classification, or document infor" +
	    "mation, that are associated to the material.\r\n<blockquote class=\"change-ifc2x4\">" +
	    "IFC4 CHANGE&nbsp; The inverse attribute has been added.</blockquote> ")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReferences { get { return this._HasExternalReferences; } }
	
		[Description("Material properties assigned to instances of subtypes of <em>IfcMaterialDefinitio" +
	    "n</em>.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribu" +
	    "te has been added.</blockquote>")]
		public ISet<IfcMaterialProperties> HasProperties { get { return this._HasProperties; } }
	
	
	}
	
}
