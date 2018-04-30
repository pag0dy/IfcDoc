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

using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcRepresentationMap :
		BuildingSmart.IFC.IfcRepresentationResource.IfcProductRepresentationSelect
	{
		[DataMember(Order = 0)] 
		[Description("An axis2 placement that defines the position about which the mapped  representation is mapped.")]
		[Required()]
		public IfcAxis2Placement MappingOrigin { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("A representation that is mapped to at least one mapped item.")]
		[Required()]
		public IfcRepresentation MappedRepresentation { get; set; }
	
		[InverseProperty("PartOfProductDefinitionShape")] 
		[Description("Reference to the shape aspect that represents part of the shape or its feature distinctively.  <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; Inverse attribute added.  </blockquote>")]
		public ISet<IfcShapeAspect> HasShapeAspects { get; protected set; }
	
		[InverseProperty("MappingSource")] 
		public ISet<IfcMappedItem> MapUsage { get; protected set; }
	
	
		public IfcRepresentationMap(IfcAxis2Placement __MappingOrigin, IfcRepresentation __MappedRepresentation)
		{
			this.MappingOrigin = __MappingOrigin;
			this.MappedRepresentation = __MappedRepresentation;
			this.HasShapeAspects = new HashSet<IfcShapeAspect>();
			this.MapUsage = new HashSet<IfcMappedItem>();
		}
	
	
	}
	
}
