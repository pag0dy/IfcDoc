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
	public partial class IfcRelDefinesByProperties : IfcRelDefines
	{
		[DataMember(Order = 0)] 
		[Description("Reference to the property set definition for that object or set of objects.  ")]
		[Required()]
		public IfcPropertySetDefinition RelatingPropertyDefinition { get; set; }
	
	
		public IfcRelDefinesByProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObject[] __RelatedObjects, IfcPropertySetDefinition __RelatingPropertyDefinition)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects)
		{
			this.RelatingPropertyDefinition = __RelatingPropertyDefinition;
		}
	
	
	}
	
}
