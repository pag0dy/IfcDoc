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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("94384d21-b0e3-4673-bcd6-b22f0283ff84")]
	public partial class IfcSubedge : IfcEdge
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcEdge _ParentEdge;
	
	
		[Description("The Edge, or Subedge, which contains the Subedge.")]
		public IfcEdge ParentEdge { get { return this._ParentEdge; } set { this._ParentEdge = value;} }
	
	
	}
	
}
