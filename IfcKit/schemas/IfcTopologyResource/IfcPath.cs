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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	public partial class IfcPath : IfcTopologicalRepresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("The list of oriented edges which are concatenated together to form this path.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcOrientedEdge> EdgeList { get; protected set; }
	
	
		public IfcPath(IfcOrientedEdge[] __EdgeList)
		{
			this.EdgeList = new List<IfcOrientedEdge>(__EdgeList);
		}
	
	
	}
	
}
