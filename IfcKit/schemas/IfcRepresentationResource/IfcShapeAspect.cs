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
	public partial class IfcShapeAspect
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>List of <strike>shape</strike> representations. Each member defines a valid representation of a particular type within a particular representation context as being an aspect (or part) of a product definition.  <blockquote><small><font color=\"#FF0000\">IFC2x Edition 3 CHANGE&nbsp; The data type has been changed from <i>IfcShapeRepresentation</i> to <i>IfcShapeModel</i> with upward compatibility </font></small></blockquote>  </EPM-HTML>")]
		[Required()]
		[MinLength(1)]
		public IList<IfcShapeModel> ShapeRepresentations { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The word or group of words by which the shape aspect is known. It is a tag to indicate the particular semantic of a component within the product definition shape, used to provide meaning. Example: use the tag \"Glazing\" to define which component of a window shape defines the glazing area.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The word or group of words that characterize the shape aspect. It can be used to add additional meaning to the name of the aspect.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("An indication that the shape aspect is on the physical boundary of the product definition shape. If the value of this attribute is TRUE, it shall be asserted that the shape aspect being identified is on such a boundary. If the value is FALSE, it shall be asserted that the shape aspect being identified is not on such a boundary. If the value is UNKNOWN, it shall be asserted that it is not known whether or not the shape aspect being identified is on such a boundary.   ---  EXAMPLE: Would be FALSE for a center line, identified as shape aspect; would be TRUE for a cantilever.  ---")]
		[Required()]
		public Boolean? ProductDefinitional { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("Reference to the product definition shape of which this class is an aspect.")]
		[Required()]
		public IfcProductDefinitionShape PartOfProductDefinitionShape { get; set; }
	
	
		public IfcShapeAspect(IfcShapeModel[] __ShapeRepresentations, IfcLabel? __Name, IfcText? __Description, Boolean? __ProductDefinitional, IfcProductDefinitionShape __PartOfProductDefinitionShape)
		{
			this.ShapeRepresentations = new List<IfcShapeModel>(__ShapeRepresentations);
			this.Name = __Name;
			this.Description = __Description;
			this.ProductDefinitional = __ProductDefinitional;
			this.PartOfProductDefinitionShape = __PartOfProductDefinitionShape;
		}
	
	
	}
	
}
