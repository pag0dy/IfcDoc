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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public abstract partial class IfcExtendedProperties : IfcPropertyAbstraction
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The name given to the set of properties. ")]
		public IfcIdentifier? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Description for the set of properties.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The set of properties provided for this extended property collection.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcProperty> Properties { get; protected set; }
	
	
		protected IfcExtendedProperties(IfcIdentifier? __Name, IfcText? __Description, IfcProperty[] __Properties)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.Properties = new HashSet<IfcProperty>(__Properties);
		}
	
	
	}
	
}
