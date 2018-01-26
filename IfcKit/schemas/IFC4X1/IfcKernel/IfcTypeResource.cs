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
	[Guid("0fb1cf26-3a59-44f5-9a5e-adc7ac27e46a")]
	public abstract partial class IfcTypeResource : IfcTypeObject,
		BuildingSmart.IFC.IfcKernel.IfcResourceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Identification;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _LongDescription;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _ResourceType;
	
		[InverseProperty("RelatingResource")] 
		ISet<IfcRelAssignsToResource> _ResourceOf = new HashSet<IfcRelAssignsToResource>();
	
	
		public IfcTypeResource()
		{
		}
	
		public IfcTypeResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcLabel? __ResourceType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets)
		{
			this._Identification = __Identification;
			this._LongDescription = __LongDescription;
			this._ResourceType = __ResourceType;
		}
	
		[Description("An identifying designation given to a resource type.")]
		public IfcIdentifier? Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description("An long description, or text, describing the resource in detail.\r\n<blockquote cla" +
	    "ss=\"note\">NOTE&nbsp; The inherited <em>SELF\\IfcRoot.Description</em> attribute i" +
	    "s used as the short description.</blockquote>")]
		public IfcText? LongDescription { get { return this._LongDescription; } set { this._LongDescription = value;} }
	
		[Description(@"The type denotes a particular type that indicates the resource further. The use has to be established at the level of instantiable subtypes. In particular it holds the user defined type, if the enumeration of the attribute 'PredefinedType' is set to USERDEFINED. ")]
		public IfcLabel? ResourceType { get { return this._ResourceType; } set { this._ResourceType = value;} }
	
		[Description("Set of relationships to other objects, e.g. products, processes, controls, resour" +
	    "ces or actors to which this resource type is a resource.\r\n<blockquote class=\"his" +
	    "tory\">HISTORY New inverse relationship in IFC4.</blockquote>")]
		public ISet<IfcRelAssignsToResource> ResourceOf { get { return this._ResourceOf; } }
	
	
	}
	
}
