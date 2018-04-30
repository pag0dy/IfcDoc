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
		[XmlAttribute]
		[Description("Overriding priorities at this connection. It overrides the standard priority given at the wall layer provided by <em>IfcMaterialLayer</em>.<em>Priority</em>. The list of <em>RelatingProperties</em> corresponds to the list of <em>IfcMaterialLayerSet</em>.<em>MaterialLayers</em> of the element referenced by <em>RelatingObject</em>.  <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; Data type changed to NUMBER and usage to hold a normalized ratio measure [0..1].  </blockquote>")]
		[Required()]
		public IList<IfcInteger> RelatingPriorities { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Overriding priorities at this connection. It overrides the standard priority given at the wall layer provided by <em>IfcMaterialLayer</em>.<em>Priority</em>. The list of <em>RelatedProperties</em> corresponds to the list of <em>IfcMaterialLayerSet</em>.<em>MaterialLayers</em> of the element referenced by <em>RelatedObject</em>.  <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; Data type changed to NUMBER and usage to hold a normalized ratio measure [0..1].  </blockquote>")]
		[Required()]
		public IList<IfcInteger> RelatedPriorities { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Indication of the connection type in relation to the path of the <em>RelatingObject</em>.  ")]
		[Required()]
		public IfcConnectionTypeEnum RelatedConnectionType { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Indication of the connection type in relation to the path of the <em>RelatingObject</em>.  ")]
		[Required()]
		public IfcConnectionTypeEnum RelatingConnectionType { get; set; }
	
	
		public IfcRelConnectsPathElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcConnectionGeometry __ConnectionGeometry, IfcElement __RelatingElement, IfcElement __RelatedElement, IfcInteger[] __RelatingPriorities, IfcInteger[] __RelatedPriorities, IfcConnectionTypeEnum __RelatedConnectionType, IfcConnectionTypeEnum __RelatingConnectionType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ConnectionGeometry, __RelatingElement, __RelatedElement)
		{
			this.RelatingPriorities = new List<IfcInteger>(__RelatingPriorities);
			this.RelatedPriorities = new List<IfcInteger>(__RelatedPriorities);
			this.RelatedConnectionType = __RelatedConnectionType;
			this.RelatingConnectionType = __RelatingConnectionType;
		}
	
	
	}
	
}
