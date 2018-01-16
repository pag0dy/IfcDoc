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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("38217e82-b534-4baa-87a6-49402ed0a52c")]
	public abstract partial class IfcRepresentationContext
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _ContextIdentifier;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _ContextType;
	
		[InverseProperty("ContextOfItems")] 
		ISet<IfcRepresentation> _RepresentationsInContext = new HashSet<IfcRepresentation>();
	
	
		[Description("The optional identifier of the representation context as used within a project.")]
		public IfcLabel? ContextIdentifier { get { return this._ContextIdentifier; } set { this._ContextIdentifier = value;} }
	
		[Description("The description of the type of a representation context. The supported values for" +
	    " context type are to be specified by implementers agreements.")]
		public IfcLabel? ContextType { get { return this._ContextType; } set { this._ContextType = value;} }
	
		[Description("All shape representations that are defined in the same representation context.")]
		public ISet<IfcRepresentation> RepresentationsInContext { get { return this._RepresentationsInContext; } }
	
	
	}
	
}
