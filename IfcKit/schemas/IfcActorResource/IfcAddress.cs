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

namespace BuildingSmart.IFC.IfcActorResource
{
	public abstract partial class IfcAddress :
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Identifies the logical location of the address.")]
		public IfcAddressTypeEnum? Purpose { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Text that relates the nature of the address.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Allows for specification of user specific purpose of the address beyond the   enumeration values provided by Purpose attribute of type IfcAddressTypeEnum.   When a value is provided for attribute UserDefinedPurpose, in parallel the   attribute Purpose shall have enumeration value USERDEFINED.")]
		public IfcLabel? UserDefinedPurpose { get; set; }
	
		[InverseProperty("Addresses")] 
		[Description("The inverse relationship to Person to whom address is associated.")]
		public ISet<IfcPerson> OfPerson { get; protected set; }
	
		[InverseProperty("Addresses")] 
		[Description("The inverse relationship to Organization to whom address is associated.")]
		public ISet<IfcOrganization> OfOrganization { get; protected set; }
	
	
		protected IfcAddress(IfcAddressTypeEnum? __Purpose, IfcText? __Description, IfcLabel? __UserDefinedPurpose)
		{
			this.Purpose = __Purpose;
			this.Description = __Description;
			this.UserDefinedPurpose = __UserDefinedPurpose;
			this.OfPerson = new HashSet<IfcPerson>();
			this.OfOrganization = new HashSet<IfcOrganization>();
		}
	
	
	}
	
}
