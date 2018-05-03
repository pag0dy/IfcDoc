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
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public abstract partial class IfcContext : IfcObjectDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The object type denotes a particular type that indicates the object further. The use has to be established at the level of instantiable subtypes.   <blockquote class=\"note\">  NOTE&nbsp; Subtypes of <em>IfcContext</em> do not introduce a <em>PredefinedType</em> attribute, therefore the usage of <em>ObjectType</em> is not bound to the selection of USERDEFINED within the <em>PredefinedType</em> enumaration.  </blockquote>")]
		public IfcLabel? ObjectType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Long name for the context as used for reference purposes.")]
		public IfcLabel? LongName { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Current project phase, or life-cycle phase of this project. Applicable values have to be agreed upon by view definitions or implementer agreements.   ")]
		public IfcLabel? Phase { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Context of the representations used within the context. When the context is a project and it includes shape representations for its components, one or several geometric representation contexts need to be included that define e.g. the world coordinate system, the coordinate space dimensions, and/or the precision factor.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been changed to be optional. Change made with upward compatibility for file based exchange.</blockquote>")]
		[MinLength(1)]
		public ISet<IfcRepresentationContext> RepresentationContexts { get; protected set; }
	
		[DataMember(Order = 4)] 
		[XmlElement]
		[Description("Units globally assigned to measure types used within the context.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been changed to be optional. Change made with upward compatibility for file based exchange.</blockquote>")]
		public IfcUnitAssignment UnitsInContext { get; set; }
	
		[InverseProperty("RelatedObjects")] 
		[XmlElement("IfcRelDefinesByProperties")]
		[Description("Set of relationships to property set definitions attached to this context. Those statically or dynamically defined properties contain alphanumeric information content that further defines the context.   <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; The data type has been changed from <em>IfcRelDefines</em> to <em>IfcRelDefinesByProperties</em> with upward compatibility for file based exchange.  </blockquote>")]
		public ISet<IfcRelDefinesByProperties> IsDefinedBy { get; protected set; }
	
		[InverseProperty("RelatingContext")] 
		[XmlElement("IfcRelDeclares")]
		[Description("Reference to the <em>IfcRelDeclares</em> relationship that assigns the uppermost entities of includes hierarchies to this context instance.  <blockquote class=\"note\">NOTE&nbsp; The spatial hiearchy is assigned to <em>IfcProject</em> using the <em>IfcRelAggregates</em> relationship. This is a single exception due to compatibility reasons with earlier releases.</blockquote>")]
		public ISet<IfcRelDeclares> Declares { get; protected set; }
	
	
		protected IfcContext(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcLabel? __LongName, IfcLabel? __Phase, IfcRepresentationContext[] __RepresentationContexts, IfcUnitAssignment __UnitsInContext)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.ObjectType = __ObjectType;
			this.LongName = __LongName;
			this.Phase = __Phase;
			this.RepresentationContexts = new HashSet<IfcRepresentationContext>(__RepresentationContexts);
			this.UnitsInContext = __UnitsInContext;
			this.IsDefinedBy = new HashSet<IfcRelDefinesByProperties>();
			this.Declares = new HashSet<IfcRelDeclares>();
		}
	
	
	}
	
}
