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
	[Guid("ae69801c-7451-4fd5-9784-4dba6d6e1616")]
	public partial class IfcPath : IfcTopologicalRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcOrientedEdge> _EdgeList = new List<IfcOrientedEdge>();
	
	
		[Description("The list of oriented edges which are concatenated together to form this path.")]
		public IList<IfcOrientedEdge> EdgeList { get { return this._EdgeList; } }
	
	
	}
	
}
