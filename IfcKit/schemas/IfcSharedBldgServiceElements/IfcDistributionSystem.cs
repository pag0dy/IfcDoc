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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	public partial class IfcDistributionSystem : IfcSystem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Long name for a distribution system, used for informal purposes. It should be used, if available, in conjunction with the inherited <em>Name</em> attribute.  <blockquote class=\"note\">NOTE&nbsp; In many scenarios the <em>Name</em> attribute refers to the short name or number of a distribution system or branch circuit, and the <em>LongName</em> refers to a descriptive name.  </blockquote>")]
		public IfcLabel? LongName { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Predefined types of distribution systems.")]
		public IfcDistributionSystemEnum? PredefinedType { get; set; }
	
	
		public IfcDistributionSystem(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcLabel? __LongName, IfcDistributionSystemEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.LongName = __LongName;
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}
