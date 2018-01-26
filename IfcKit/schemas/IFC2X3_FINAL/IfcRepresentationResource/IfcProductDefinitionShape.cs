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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("febadfb1-e97e-48d9-92f4-df4dbe98fdde")]
	public partial class IfcProductDefinitionShape : IfcProductRepresentation
	{
		[InverseProperty("Representation")] 
		[MinLength(1)]
		[MaxLength(1)]
		ISet<IfcProduct> _ShapeOfProduct = new HashSet<IfcProduct>();
	
		[InverseProperty("PartOfProductDefinitionShape")] 
		ISet<IfcShapeAspect> _HasShapeAspects = new HashSet<IfcShapeAspect>();
	
	
		public IfcProductDefinitionShape()
		{
		}
	
		public IfcProductDefinitionShape(IfcLabel? __Name, IfcText? __Description, IfcRepresentation[] __Representations)
			: base(__Name, __Description, __Representations)
		{
		}
	
		[Description(@"<EPM-HTML>
	The <i>IfcProductDefinitionShape</i> shall be used to provide a representation for a single instance of <i>IfcProduct</i>.
	<blockquote><small>
	  <font color=""#FF0000"">IFC2x Edition 3 CHANGE&nbsp; New inverse attribute.</font>
	</small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcProduct> ShapeOfProduct { get { return this._ShapeOfProduct; } }
	
		[Description("Reference to the shape aspect that represents part of the shape or its feature di" +
	    "stinctively.")]
		public ISet<IfcShapeAspect> HasShapeAspects { get { return this._HasShapeAspects; } }
	
	
	}
	
}
