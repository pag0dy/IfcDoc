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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("99256c95-26f9-40c1-8626-d82861f2eecc")]
	public abstract partial class IfcAlignment2DSegment : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcBoolean? _TangentialContinuity;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _StartTag;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _EndTag;
	
	
		[Description("Connectivity between the continuous segments is not enforced per se to be tangent" +
	    "ial. Setting \"TangentialContinuity\" to True means that the current segment shall" +
	    " continue with tangential continuity to the previous one.")]
		public IfcBoolean? TangentialContinuity { get { return this._TangentialContinuity; } set { this._TangentialContinuity = value;} }
	
		[Description("Tag to annotate the start point of the alignment segment.")]
		public IfcLabel? StartTag { get { return this._StartTag; } set { this._StartTag = value;} }
	
		[Description("\tTag to annotate the end point of the alignment segment.")]
		public IfcLabel? EndTag { get { return this._EndTag; } set { this._EndTag = value;} }
	
	
	}
	
}
