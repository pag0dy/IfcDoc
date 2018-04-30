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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public abstract partial class IfcAlignment2DSegment : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Connectivity between the continuous segments is not enforced per se to be tangential. Setting \"TangentialContinuity\" to True means that the current segment shall continue with tangential continuity to the previous one.")]
		public IfcBoolean? TangentialContinuity { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Tag to annotate the start point of the alignment segment.")]
		public IfcLabel? StartTag { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("	Tag to annotate the end point of the alignment segment.")]
		public IfcLabel? EndTag { get; set; }
	
	
		protected IfcAlignment2DSegment(IfcBoolean? __TangentialContinuity, IfcLabel? __StartTag, IfcLabel? __EndTag)
		{
			this.TangentialContinuity = __TangentialContinuity;
			this.StartTag = __StartTag;
			this.EndTag = __EndTag;
		}
	
	
	}
	
}
