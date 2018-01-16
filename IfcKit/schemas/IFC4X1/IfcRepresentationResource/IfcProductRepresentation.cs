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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("ebb1e658-5b55-4231-9e88-68b1c85889f8")]
	public abstract partial class IfcProductRepresentation
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[Required()]
		IList<IfcRepresentation> _Representations = new List<IfcRepresentation>();
	
	
		[Description("The word or group of words by which the product representation is known.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("The word or group of words that characterize the product representation. It can b" +
	    "e used to add additional meaning to the name of the product representation.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Contained list of representations (including shape representations). Each member " +
	    "defines a valid representation of a particular type within a particular represen" +
	    "tation context.")]
		public IList<IfcRepresentation> Representations { get { return this._Representations; } }
	
	
	}
	
}
