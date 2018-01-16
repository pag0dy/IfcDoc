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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcQuantityResource
{
	[Guid("992fb4f8-e3be-4df1-8101-f866b2fa8617")]
	public abstract partial class IfcPhysicalQuantity :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcExternalReferenceRelationship> _HasExternalReferences = new HashSet<IfcExternalReferenceRelationship>();
	
		[InverseProperty("HasQuantities")] 
		ISet<IfcPhysicalComplexQuantity> _PartOfComplex = new HashSet<IfcPhysicalComplexQuantity>();
	
	
		[Description("Name of the element quantity or measure. The name attribute has to be made recogn" +
	    "izable by further agreements.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Further explanation that might be given to the quantity.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Reference to an external reference, e.g. library, classification, or document inf" +
	    "ormation, that is associated to the quantity.\r\n<blockquote class=\"change-ifc2x4\"" +
	    ">IFC4 CHANGE New inverse attribute.</blockquote>")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReferences { get { return this._HasExternalReferences; } }
	
		[Description("Reference to a physical complex quantity in which the physical quantity may be co" +
	    "ntained.")]
		public ISet<IfcPhysicalComplexQuantity> PartOfComplex { get { return this._PartOfComplex; } }
	
	
	}
	
}
