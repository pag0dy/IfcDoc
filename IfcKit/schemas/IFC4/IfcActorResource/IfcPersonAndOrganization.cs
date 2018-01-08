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

namespace BuildingSmart.IFC.IfcActorResource
{
	[Guid("52b0207c-cc6a-42c8-a632-c3d63a70b2a5")]
	public partial class IfcPersonAndOrganization :
		BuildingSmart.IFC.IfcActorResource.IfcActorSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcPerson")]
		[Required()]
		IfcPerson _ThePerson;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcOrganization")]
		[Required()]
		IfcOrganization _TheOrganization;
	
		[DataMember(Order=2)] 
		IList<IfcActorRole> _Roles = new List<IfcActorRole>();
	
	
		[Description("The person who is related to the organization.")]
		public IfcPerson ThePerson { get { return this._ThePerson; } set { this._ThePerson = value;} }
	
		[Description("The organization to which the person is related.")]
		public IfcOrganization TheOrganization { get { return this._TheOrganization; } set { this._TheOrganization = value;} }
	
		[Description("Roles played by the person within the context of an organization.  These may diff" +
	    "er from the roles in <em>ThePerson.Roles</em> which may be asserted without orga" +
	    "nizational context.\r\n")]
		public IList<IfcActorRole> Roles { get { return this._Roles; } }
	
	
	}
	
}
