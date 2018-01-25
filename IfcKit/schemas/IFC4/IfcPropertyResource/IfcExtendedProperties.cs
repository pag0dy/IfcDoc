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
using BuildingSmart.IFC.IfcApprovalResource;
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
	[Guid("6eefdfa8-0f42-440b-a927-ddd04185cfd4")]
	public abstract partial class IfcExtendedProperties : IfcPropertyAbstraction
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[Required()]
		ISet<IfcProperty> _Properties = new HashSet<IfcProperty>();
	
	
		[Description("The name given to the set of properties. ")]
		public IfcIdentifier? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Description for the set of properties.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("The set of properties provided for this extended property collection.")]
		public ISet<IfcProperty> Properties { get { return this._Properties; } }
	
	
	}
	
}
