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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

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
		[XmlElement("IfcRepresentation")]
		[Required()]
		IfcRepresentation _MappedRepresentation;
	
		[InverseProperty("PartOfProductDefinitionShape")] 
		ISet<IfcShapeAspect> _HasShapeAspects = new HashSet<IfcShapeAspect>();
	
		[InverseProperty("MappingSource")] 
		ISet<IfcMappedItem> _MapUsage = new HashSet<IfcMappedItem>();
	
	
		[Description("An axis2 placement that defines the position about which the mapped\r\nrepresentati" +
	    "on is mapped.")]
		public IfcAxis2Placement MappingOrigin { get { return this._MappingOrigin; } set { this._MappingOrigin = value;} }
	
		[Description("A representation that is mapped to at least one mapped item.")]
		public IfcRepresentation MappedRepresentation { get { return this._MappedRepresentation; } set { this._MappedRepresentation = value;} }
	
		[Description("<EPM-HTML>\r\nReference to the shape aspect that represents part of the shape or it" +
	    "s feature distinctively.\r\n<blockquote class=\"change-ifc2x4\">\r\nIFC4 CHANGE&nbsp; " +
	    "Inverse attribute added.\r\n</blockquote>\r\n</EPM-HTML>")]
		public ISet<IfcShapeAspect> HasShapeAspects { get { return this._HasShapeAspects; } }
	
		public ISet<IfcMappedItem> MapUsage { get { return this._MapUsage; } }
	
	
	}
	
}
