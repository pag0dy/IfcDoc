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

using BuildingSmart.IFC.IfcMeasureResource;
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
	
	
		public IfcResource()
		{
		}
	
		public IfcResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcText? __LongDescription)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._Identification = __Identification;
			this._LongDescription = __LongDescription;
		}
	
		[Description("    An identifying designation given to a resource.\r\n    It is the identifier at " +
	    "the occurrence level. \r\n    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  Attri" +
	    "bute promoted from subtype <em>IfcConstructionResource</em>.</blockquote>")]
		public IfcIdentifier? Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description(@"A detailed description of the resource (e.g. the skillset for a labor resource).  
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute <em>LongDescription</em> is added replacing the <em>ResourceGroup</em> attribute at subtype <em>IfcConstructionResource</em>.</blockquote>")]
		public IfcText? LongDescription { get { return this._LongDescription; } set { this._LongDescription = value;} }
	
		[Description("Set of relationships to other objects, e.g. products, processes, controls, resour" +
	    "ces or actors, for which this resource object is a resource.")]
		public ISet<IfcRelAssignsToResource> ResourceOf { get { return this._ResourceOf; } }
	
	
	}
	
}
