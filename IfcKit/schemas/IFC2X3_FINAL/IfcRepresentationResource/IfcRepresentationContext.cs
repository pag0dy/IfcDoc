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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("01b34d06-5983-40a5-8525-5fa6d569967d")]
	public partial class IfcRepresentationContext
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _ContextIdentifier;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _ContextType;
	
		[InverseProperty("ContextOfItems")] 
		ISet<IfcRepresentation> _RepresentationsInContext = new HashSet<IfcRepresentation>();
	
	
		public IfcRepresentationContext()
		{
		}
	
		public IfcRepresentationContext(IfcLabel? __ContextIdentifier, IfcLabel? __ContextType)
		{
			this._ContextIdentifier = __ContextIdentifier;
			this._ContextType = __ContextType;
		}
	
		[Description("The optional identifier of the representation context as used within a project.")]
		public IfcLabel? ContextIdentifier { get { return this._ContextIdentifier; } set { this._ContextIdentifier = value;} }
	
		[Description("The description of the type of a representation context. The supported values for" +
	    " context type are to be specified by implementers agreements.")]
		public IfcLabel? ContextType { get { return this._ContextType; } set { this._ContextType = value;} }
	
		[Description("All shape representations that are defined in the same representation context.")]
		public ISet<IfcRepresentation> RepresentationsInContext { get { return this._RepresentationsInContext; } }
	
	
	}
	
}
