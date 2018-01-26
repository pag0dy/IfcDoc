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
	[Guid("380d19f2-c934-472a-9c62-ffcfbdd23698")]
	public partial class IfcRepresentationMap
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAxis2Placement _MappingOrigin;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcRepresentation _MappedRepresentation;
	
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
	
		public ISet<IfcMappedItem> MapUsage { get { return this._MapUsage; } }
	
	
	}
	
}
