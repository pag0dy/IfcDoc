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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("7d23ec63-a69d-48c1-9db7-f4089326e1f2")]
	public abstract partial class IfcResource : IfcObject,
		BuildingSmart.IFC.IfcKernel.IfcResourceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Identification;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _LongDescription;
	
		[InverseProperty("RelatingResource")] 
		ISet<IfcRelAssignsToResource> _ResourceOf = new HashSet<IfcRelAssignsToResource>();
	
	
		[Description(@"<EPM-HTML>
	    An identifying designation given to a resource.
	    It is the identifier at the occurrence level. 
	    <blockquote class=""change-ifc2x4"">IFC4 CHANGE  Attribute promoted from subtype <em>IfcConstructionResource</em>.</blockquote>
	</EPM-HTML>")]
		public IfcIdentifier? Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description(@"<EPM-HTML>
	A detailed description of the resource (e.g. the skillset for a labor resource).  
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute <em>LongDescription</em> is added replacing the <em>ResourceGroup</em> attribute at subtype <em>IfcConstructionResource</em>.</blockquote>
	</EPM-HTML>")]
		public IfcText? LongDescription { get { return this._LongDescription; } set { this._LongDescription = value;} }
	
		[Description("<EPM-HTML>\r\nSet of relationships to other objects, e.g. products, processes, cont" +
	    "rols, resources or actors, for which this resource object is a resource.\r\n</EPM-" +
	    "HTML>")]
		public ISet<IfcRelAssignsToResource> ResourceOf { get { return this._ResourceOf; } }
	
	
	}
	
}
