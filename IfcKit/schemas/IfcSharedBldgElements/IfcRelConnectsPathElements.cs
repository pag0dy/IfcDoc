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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public partial class IfcRelConnectsPathElements : IfcRelConnectsElements
	{
		[DataMember(Order = 0)] 
		[Description("Priorities for connection. It refers to the layers of the RelatingObject.  ")]
		[Required()]
		public IList<Int64> RelatingPriorities { get; protected set; }
	
		[DataMember(Order = 1)] 
		[Description("Priorities for connection. It refers to the layers of the RelatedObject.  ")]
		[Required()]
		public IList<Int64> RelatedPriorities { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Indication of the connection type in relation to the path of the RelatingObject.  ")]
		[Required()]
		public IfcConnectionTypeEnum RelatedConnectionType { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Indication of the connection type in relation to the path of the RelatingObject.  ")]
		[Required()]
		public IfcConnectionTypeEnum RelatingConnectionType { get; set; }
	
	
		public IfcRelConnectsPathElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcConnectionGeometry __ConnectionGeometry, IfcElement __RelatingElement, IfcElement __RelatedElement, Int64[] __RelatingPriorities, Int64[] __RelatedPriorities, IfcConnectionTypeEnum __RelatedConnectionType, IfcConnectionTypeEnum __RelatingConnectionType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ConnectionGeometry, __RelatingElement, __RelatedElement)
		{
			this.RelatingPriorities = new List<Int64>(__RelatingPriorities);
			this.RelatedPriorities = new List<Int64>(__RelatedPriorities);
			this.RelatedConnectionType = __RelatedConnectionType;
			this.RelatingConnectionType = __RelatingConnectionType;
		}
	
	
	}
	
}
