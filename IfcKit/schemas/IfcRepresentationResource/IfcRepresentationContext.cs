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

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	public abstract partial class IfcRepresentationContext
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The optional identifier of the representation context as used within a project.")]
		public IfcLabel? ContextIdentifier { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The description of the type of a representation context. The supported values for context type are to be specified by implementers agreements.")]
		public IfcLabel? ContextType { get; set; }
	
		[InverseProperty("ContextOfItems")] 
		[Description("All shape representations that are defined in the same representation context.")]
		public ISet<IfcRepresentation> RepresentationsInContext { get; protected set; }
	
	
		protected IfcRepresentationContext(IfcLabel? __ContextIdentifier, IfcLabel? __ContextType)
		{
			this.ContextIdentifier = __ContextIdentifier;
			this.ContextType = __ContextType;
			this.RepresentationsInContext = new HashSet<IfcRepresentation>();
		}
	
	
	}
	
}
