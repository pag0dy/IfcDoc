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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("f29818b8-d9e0-49fc-a593-993420817803")]
	public partial class IfcDistributionControlElement : IfcDistributionElement
	{
		[InverseProperty("RelatedControlElements")] 
		ISet<IfcRelFlowControlElements> _AssignedToFlowElement = new HashSet<IfcRelFlowControlElements>();
	
	
		[Description("Reference through the relationship object to related distribution flow elements.")]
		public ISet<IfcRelFlowControlElements> AssignedToFlowElement { get { return this._AssignedToFlowElement; } }
	
	
	}
	
}
