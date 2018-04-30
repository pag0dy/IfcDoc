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
	public partial class IfcProject : IfcObject
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Long name for the project as used for reference purposes.")]
		public IfcLabel? LongName { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Current project phase, open to interpretation for all project partner, therefore given as IfcString.   ")]
		public IfcLabel? Phase { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Context of the representations used within the project. When the project includes shape representations for its components, one or several geometric representation contexts need to be included that define e.g. the world coordinate system, the coordinate space dimensions, and/or the precision factor.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcRepresentationContext> RepresentationContexts { get; protected set; }
	
		[DataMember(Order = 3)] 
		[Description("Units globally assigned to measure types used within the context of this project.")]
		[Required()]
		public IfcUnitAssignment UnitsInContext { get; set; }
	
	
		public IfcProject(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcLabel? __LongName, IfcLabel? __Phase, IfcRepresentationContext[] __RepresentationContexts, IfcUnitAssignment __UnitsInContext)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.LongName = __LongName;
			this.Phase = __Phase;
			this.RepresentationContexts = new HashSet<IfcRepresentationContext>(__RepresentationContexts);
			this.UnitsInContext = __UnitsInContext;
		}
	
	
	}
	
}
