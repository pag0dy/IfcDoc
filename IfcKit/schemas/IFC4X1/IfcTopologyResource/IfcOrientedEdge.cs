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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("a0cbcd65-91d4-42a9-ba31-58d592875aa7")]
	public partial class IfcOrientedEdge : IfcEdge
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcEdge _EdgeElement;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _Orientation;
	
	
		public IfcOrientedEdge()
		{
		}
	
		public IfcOrientedEdge(IfcVertex __EdgeStart, IfcVertex __EdgeEnd, IfcEdge __EdgeElement, IfcBoolean __Orientation)
			: base(__EdgeStart, __EdgeEnd)
		{
			this._EdgeElement = __EdgeElement;
			this._Orientation = __Orientation;
		}
	
		[Description("Edge entity used to construct this oriented edge.\r\n")]
		public IfcEdge EdgeElement { get { return this._EdgeElement; } set { this._EdgeElement = value;} }
	
		[Description("BOOLEAN, If TRUE the topological orientation as used coincides with the orientati" +
	    "on from start vertex to end vertex of the edge element. If FALSE otherwise.\r\n")]
		public IfcBoolean Orientation { get { return this._Orientation; } set { this._Orientation = value;} }
	
		public new IfcVertex EdgeStart { get { return null; } }
	
		public new IfcVertex EdgeEnd { get { return null; } }
	
	
	}
	
}
