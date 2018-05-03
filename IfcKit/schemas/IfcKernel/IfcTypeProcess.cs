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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public abstract partial class IfcTypeProcess : IfcTypeObject,
		BuildingSmart.IFC.IfcKernel.IfcProcessSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("An identifying designation given to a process type.")]
		public IfcIdentifier? Identification { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("An long description, or text, describing the activity in detail.  <blockquote class=\"note\">NOTE&nbsp; The inherited <em>SELF\\IfcRoot.Description</em> attribute is used as the short description.</blockquote>")]
		public IfcText? LongDescription { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The type denotes a particular type that indicates the process further. The use has to be established at the level of instantiable subtypes. In particular it holds the user defined type, if the enumeration of the attribute 'PredefinedType' is set to USERDEFINED. ")]
		public IfcLabel? ProcessType { get; set; }
	
		[InverseProperty("RelatingProcess")] 
		[Description("Set of relationships to other objects, e.g. products, processes, controls, resources or actors that are operated on by the process type.  <blockquote class=\"history\">HISTORY  New inverse relationship in IFC4.</blockquote>")]
		public ISet<IfcRelAssignsToProcess> OperatesOn { get; protected set; }
	
	
		protected IfcTypeProcess(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcLabel? __ProcessType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets)
		{
			this.Identification = __Identification;
			this.LongDescription = __LongDescription;
			this.ProcessType = __ProcessType;
			this.OperatesOn = new HashSet<IfcRelAssignsToProcess>();
		}
	
	
	}
	
}
