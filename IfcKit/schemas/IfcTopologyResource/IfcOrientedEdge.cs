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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	public partial class IfcOrientedEdge : IfcEdge
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Edge entity used to construct this oriented edge.  ")]
		[Required()]
		public IfcEdge EdgeElement { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("BOOLEAN, If TRUE the topological orientation as used coincides with the orientation from start vertex to end vertex of the edge element. If FALSE otherwise.  ")]
		[Required()]
		public IfcBoolean Orientation { get; set; }
	
	
		public IfcOrientedEdge(IfcVertex __EdgeStart, IfcVertex __EdgeEnd, IfcEdge __EdgeElement, IfcBoolean __Orientation)
			: base(__EdgeStart, __EdgeEnd)
		{
			this.EdgeElement = __EdgeElement;
			this.Orientation = __Orientation;
		}
	
		public new IfcVertex EdgeStart { get { return null; } }
	
		public new IfcVertex EdgeEnd { get { return null; } }
	
	
	}
	
}
