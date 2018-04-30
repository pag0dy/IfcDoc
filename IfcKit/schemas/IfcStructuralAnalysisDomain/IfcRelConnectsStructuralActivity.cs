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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public partial class IfcRelConnectsStructuralActivity : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[Description("Reference to an instance of IfcStructuralItem or IfcBuildingElement (or its subclasses) to which the specified action is applied.")]
		[Required()]
		public IfcStructuralActivityAssignmentSelect RelatingElement { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to an instance of IfcStructuralActivity (or its subclasses) which is acting upon the specified structural element (represented by a respective structural representation entity). ")]
		[Required()]
		public IfcStructuralActivity RelatedStructuralActivity { get; set; }
	
	
		public IfcRelConnectsStructuralActivity(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcStructuralActivityAssignmentSelect __RelatingElement, IfcStructuralActivity __RelatedStructuralActivity)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingElement = __RelatingElement;
			this.RelatedStructuralActivity = __RelatedStructuralActivity;
		}
	
	
	}
	
}
