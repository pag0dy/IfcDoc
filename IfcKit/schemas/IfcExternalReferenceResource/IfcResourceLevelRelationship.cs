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

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public abstract partial class IfcResourceLevelRelationship
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A name used to identify or qualify the relationship.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("A description that may apply additional information about the relationship.")]
		public IfcText? Description { get; set; }
	
	
		protected IfcResourceLevelRelationship(IfcLabel? __Name, IfcText? __Description)
		{
			this.Name = __Name;
			this.Description = __Description;
		}
	
	
	}
	
}
