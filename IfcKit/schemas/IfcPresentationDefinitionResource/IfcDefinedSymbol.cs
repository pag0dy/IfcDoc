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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	public partial class IfcDefinedSymbol : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("An implicit description of the symbol, either predefined or externally defined.")]
		[Required()]
		public IfcDefinedSymbolSelect Definition { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("A description of the placement, orientation and (uniform or non-uniform) scaling of the defined symbol.")]
		[Required()]
		public IfcCartesianTransformationOperator2D Target { get; set; }
	
	
		public IfcDefinedSymbol(IfcDefinedSymbolSelect __Definition, IfcCartesianTransformationOperator2D __Target)
		{
			this.Definition = __Definition;
			this.Target = __Target;
		}
	
	
	}
	
}
