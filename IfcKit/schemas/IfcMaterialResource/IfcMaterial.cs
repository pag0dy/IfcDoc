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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterial :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Name of the material.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[InverseProperty("RepresentedMaterial")] 
		[Description("<EPM-HTML>  Reference to the <i>IfcMaterialDefinitionRepresentation</i> that provides presentation information to a representation common to this material in style definitions.    <blockquote>  <small><font color=\"#ff0000\">IFC2x Edition 3 CHANGE&nbsp; The inverse attribute <i>HasRepresentation</i> has been added.</font></small>  </blockquote>  </EPM-HTML>")]
		[MaxLength(1)]
		public ISet<IfcMaterialDefinitionRepresentation> HasRepresentation { get; protected set; }
	
		[InverseProperty("ClassifiedMaterial")] 
		[Description("Reference to the relationship pointing to the classification(s) of the material.")]
		[MaxLength(1)]
		public ISet<IfcMaterialClassificationRelationship> ClassifiedAs { get; protected set; }
	
	
		public IfcMaterial(IfcLabel __Name)
		{
			this.Name = __Name;
			this.HasRepresentation = new HashSet<IfcMaterialDefinitionRepresentation>();
			this.ClassifiedAs = new HashSet<IfcMaterialClassificationRelationship>();
		}
	
	
	}
	
}
