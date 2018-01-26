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

using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("3968ca44-8f3e-43f2-ab19-855d7709487b")]
	public partial class IfcRepresentationMap :
		BuildingSmart.IFC.IfcRepresentationResource.IfcProductRepresentationSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAxis2Placement _MappingOrigin;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcRepresentation _MappedRepresentation;
	
		[InverseProperty("PartOfProductDefinitionShape")] 
		ISet<IfcShapeAspect> _HasShapeAspects = new HashSet<IfcShapeAspect>();
	
		[InverseProperty("MappingSource")] 
		ISet<IfcMappedItem> _MapUsage = new HashSet<IfcMappedItem>();
	
	
		public IfcRepresentationMap()
		{
		}
	
		public IfcRepresentationMap(IfcAxis2Placement __MappingOrigin, IfcRepresentation __MappedRepresentation)
		{
			this._MappingOrigin = __MappingOrigin;
			this._MappedRepresentation = __MappedRepresentation;
		}
	
		[Description("An axis2 placement that defines the position about which the mapped\r\nrepresentati" +
	    "on is mapped.")]
		public IfcAxis2Placement MappingOrigin { get { return this._MappingOrigin; } set { this._MappingOrigin = value;} }
	
		[Description("A representation that is mapped to at least one mapped item.")]
		public IfcRepresentation MappedRepresentation { get { return this._MappedRepresentation; } set { this._MappedRepresentation = value;} }
	
		[Description("Reference to the shape aspect that represents part of the shape or its feature di" +
	    "stinctively.\r\n<blockquote class=\"change-ifc2x4\">\r\nIFC4 CHANGE&nbsp; Inverse attr" +
	    "ibute added.\r\n</blockquote>")]
		public ISet<IfcShapeAspect> HasShapeAspects { get { return this._HasShapeAspects; } }
	
		public ISet<IfcMappedItem> MapUsage { get { return this._MapUsage; } }
	
	
	}
	
}
