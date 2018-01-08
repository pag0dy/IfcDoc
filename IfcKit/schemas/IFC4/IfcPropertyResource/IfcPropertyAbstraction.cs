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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("3981f908-e217-4f02-92e8-517147b40572")]
	public abstract partial class IfcPropertyAbstraction :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcExternalReferenceRelationship> _HasExternalReferences = new HashSet<IfcExternalReferenceRelationship>();
	
	
		[Description("<EPM-HTML>\r\nReference to an external reference, e.g. library, classification, or " +
	    "document information, that is associated to the property definition.\r\n<blockquot" +
	    "e class=\"change-ifc2x4\">IFC4 CHANGE New inverse attribute.</blockquote>\r\n</EPM-H" +
	    "TML>")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReferences { get { return this._HasExternalReferences; } }
	
	
	}
	
}
