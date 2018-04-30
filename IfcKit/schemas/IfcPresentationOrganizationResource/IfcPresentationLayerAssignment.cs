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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	public partial class IfcPresentationLayerAssignment
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Name of the layer.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Additional description of the layer.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The set of layered items, which are assigned to this layer.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcLayeredItem> AssignedItems { get; protected set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("An (internal) identifier assigned to the layer.")]
		public IfcIdentifier? Identifier { get; set; }
	
	
		public IfcPresentationLayerAssignment(IfcLabel __Name, IfcText? __Description, IfcLayeredItem[] __AssignedItems, IfcIdentifier? __Identifier)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.AssignedItems = new HashSet<IfcLayeredItem>(__AssignedItems);
			this.Identifier = __Identifier;
		}
	
	
	}
	
}
