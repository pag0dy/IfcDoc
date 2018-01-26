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

using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcActorResource
{
	[Guid("22436df9-b9a1-47b7-872f-e3d35caded50")]
	public partial class IfcPersonAndOrganization :
		BuildingSmart.IFC.IfcActorResource.IfcActorSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcPerson _ThePerson;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcOrganization _TheOrganization;
	
		[DataMember(Order=2)] 
		[MinLength(1)]
		IList<IfcActorRole> _Roles = new List<IfcActorRole>();
	
	
		public IfcPersonAndOrganization()
		{
		}
	
		public IfcPersonAndOrganization(IfcPerson __ThePerson, IfcOrganization __TheOrganization, IfcActorRole[] __Roles)
		{
			this._ThePerson = __ThePerson;
			this._TheOrganization = __TheOrganization;
			this._Roles = new List<IfcActorRole>(__Roles);
		}
	
		[Description("The person who is related to the organization.")]
		public IfcPerson ThePerson { get { return this._ThePerson; } set { this._ThePerson = value;} }
	
		[Description("The organization to which the person is related.")]
		public IfcOrganization TheOrganization { get { return this._TheOrganization; } set { this._TheOrganization = value;} }
	
		[Description("Roles played by the person within the context of an organization.")]
		public IList<IfcActorRole> Roles { get { return this._Roles; } }
	
	
	}
	
}
