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
	[Guid("d0b09671-0848-4353-9710-4312d56ffea7")]
	public partial class IfcShapeAspect
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcShapeModel> _ShapeRepresentations = new List<IfcShapeModel>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=3)] 
		[Required()]
		Boolean? _ProductDefinitional;
	
		[DataMember(Order=4)] 
		[XmlIgnore]
		IfcProductRepresentationSelect _PartOfProductDefinitionShape;
	
	
		[Description(@"<EPM-HTML>List of <strike>shape</strike> representations. Each member defines a valid representation of a particular type within a particular representation context as being an aspect (or part) of a product definition.
	<blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The data type has been changed from <em>IfcShapeRepresentation</em> to <em>IfcShapeModel</em> with upward compatibility </blockquote>
	</EPM-HTML>")]
		public IList<IfcShapeModel> ShapeRepresentations { get { return this._ShapeRepresentations; } }
	
		[Description(@"The word or group of words by which the shape aspect is known. It is a tag to indicate the particular semantic of a component within the product definition shape, used to provide meaning. Example: use the tag ""Glazing"" to define which component of a window shape defines the glazing area.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("The word or group of words that characterize the shape aspect. It can be used to " +
	    "add additional meaning to the name of the aspect.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"An indication that the shape aspect is on the physical boundary of the product definition shape. If the value of this attribute is TRUE, it shall be asserted that the shape aspect being identified is on such a boundary. If the value is FALSE, it shall be asserted that the shape aspect being identified is not on such a boundary. If the value is UNKNOWN, it shall be asserted that it is not known whether or not the shape aspect being identified is on such a boundary. 
	---
	EXAMPLE: Would be FALSE for a center line, identified as shape aspect; would be TRUE for a cantilever.
	---")]
		public Boolean? ProductDefinitional { get { return this._ProductDefinitional; } set { this._ProductDefinitional = value;} }
	
		[Description(@"<EPM-HTML>
	Reference to the <em>IfcProductDefinitionShape</em> or the <em>IfcRepresentationMap</em> of which this shape is an aspect.
	<blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; Data type modified to be <em>IfcProductRepresentationSelect</em> allowing the assignment also to <em>IfcRepresentationMap</em>.
	</blockquote>
	</EPM-HTML>")]
		public IfcProductRepresentationSelect PartOfProductDefinitionShape { get { return this._PartOfProductDefinitionShape; } set { this._PartOfProductDefinitionShape = value;} }
	
	
	}
	
}
