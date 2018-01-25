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
	[Guid("f8efd3b8-d3ea-429a-95d6-d19264324999")]
	public abstract partial class IfcRoot
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcGloballyUniqueId _GlobalId;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcOwnerHistory")]
		IfcOwnerHistory _OwnerHistory;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcText? _Description;
	
	
		[Description("Assignment of a globally unique identifier within the entire software world.\r\n")]
		public IfcGloballyUniqueId GlobalId { get { return this._GlobalId; } set { this._GlobalId = value;} }
	
		[Description(@"Assignment of the information about the current ownership of that object, including owning actor, application, local identification and information captured about the recent changes of the object, 
	
	<blockquote class=""note"">NOTE&nbsp; only the last modification in stored - either as addition, deletion or modification.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been changed to be OPTIONAL.</blockquote>")]
		public IfcOwnerHistory OwnerHistory { get { return this._OwnerHistory; } set { this._OwnerHistory = value;} }
	
		[Description("Optional name for use by the participating software systems or users. For some su" +
	    "btypes of IfcRoot the insertion of the Name attribute may be required. This woul" +
	    "d be enforced by a where rule.\r\n")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Optional description, provided for exchanging informative comments.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
	
	}
	
}
