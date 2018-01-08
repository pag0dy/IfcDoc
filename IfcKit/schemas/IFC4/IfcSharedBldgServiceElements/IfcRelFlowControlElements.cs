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
	[Guid("e5a4f246-e6c4-40b9-85b6-af71acb30b68")]
	public partial class IfcRelFlowControlElements : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcDistributionControlElement> _RelatedControlElements = new HashSet<IfcDistributionControlElement>();
	
		[DataMember(Order=1)] 
		[XmlElement("IfcDistributionFlowElement")]
		[Required()]
		IfcDistributionFlowElement _RelatingFlowElement;
	
	
		[Description("References control elements which may be used to impart control on the Distributi" +
	    "on Element.\r\n")]
		public ISet<IfcDistributionControlElement> RelatedControlElements { get { return this._RelatedControlElements; } }
	
		[Description("Relationship to a distribution flow element\r\n")]
		public IfcDistributionFlowElement RelatingFlowElement { get { return this._RelatingFlowElement; } set { this._RelatingFlowElement = value;} }
	
	
	}
	
}
