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
	[Guid("a2354718-4c92-40a9-b220-50e7c23e5faf")]
	public abstract partial class IfcAddress :
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcAddressTypeEnum? _Purpose;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedPurpose;
	
		[InverseProperty("Addresses")] 
		ISet<IfcPerson> _OfPerson = new HashSet<IfcPerson>();
	
		[InverseProperty("Addresses")] 
		ISet<IfcOrganization> _OfOrganization = new HashSet<IfcOrganization>();
	
	
		[Description("Identifies the logical location of the address.")]
		public IfcAddressTypeEnum? Purpose { get { return this._Purpose; } set { this._Purpose = value;} }
	
		[Description("Text that relates the nature of the address.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"Allows for specification of user specific purpose of the address beyond the 
	enumeration values provided by Purpose attribute of type IfcAddressTypeEnum. 
	When a value is provided for attribute UserDefinedPurpose, in parallel the 
	attribute Purpose shall have enumeration value USERDEFINED.")]
		public IfcLabel? UserDefinedPurpose { get { return this._UserDefinedPurpose; } set { this._UserDefinedPurpose = value;} }
	
		[Description("The inverse relationship to Person to whom address is associated.")]
		public ISet<IfcPerson> OfPerson { get { return this._OfPerson; } }
	
		[Description("The inverse relationship to Organization to whom address is associated.")]
		public ISet<IfcOrganization> OfOrganization { get { return this._OfOrganization; } }
	
	
	}
	
}
