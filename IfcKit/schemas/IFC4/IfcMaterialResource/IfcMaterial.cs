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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("455e45c2-6301-42ba-9118-8866fc7721d6")]
	public partial class IfcMaterial :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[InverseProperty("RepresentedMaterial")] 
		ISet<IfcMaterialDefinitionRepresentation> _HasRepresentation = new HashSet<IfcMaterialDefinitionRepresentation>();
	
		[InverseProperty("ClassifiedMaterial")] 
		ISet<IfcMaterialClassificationRelationship> _ClassifiedAs = new HashSet<IfcMaterialClassificationRelationship>();
	
	
		[Description("Name of the material.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description(@"<EPM-HTML>
	Reference to the <i>IfcMaterialDefinitionRepresentation</i> that provides presentation information to a representation common to this material in style definitions.
	  <blockquote>
	<small><font color=""#ff0000"">IFC2x Edition 3 CHANGE&nbsp; The inverse attribute <i>HasRepresentation</i> has been added.</font></small>
	</blockquote>
	</EPM-HTML>")]
		public ISet<IfcMaterialDefinitionRepresentation> HasRepresentation { get { return this._HasRepresentation; } }
	
		[Description("Reference to the relationship pointing to the classification(s) of the material.")]
		public ISet<IfcMaterialClassificationRelationship> ClassifiedAs { get { return this._ClassifiedAs; } }
	
	
	}
	
}
