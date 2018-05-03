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

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public abstract partial class IfcPropertyAbstraction :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[InverseProperty("RelatedResourceObjects")] 
		[Description("Reference to an external reference, e.g. library, classification, or document information, that is associated to the property definition.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE New inverse attribute.</blockquote>")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReferences { get; protected set; }
	
	
		protected IfcPropertyAbstraction()
		{
			this.HasExternalReferences = new HashSet<IfcExternalReferenceRelationship>();
		}
	
	
	}
	
}
