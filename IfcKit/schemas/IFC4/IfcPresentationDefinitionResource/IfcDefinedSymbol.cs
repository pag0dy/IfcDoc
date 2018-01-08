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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("c62063d9-11fc-48d5-ab7e-8457ea37b1d7")]
	public partial class IfcDefinedSymbol : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcDefinedSymbolSelect _Definition;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcCartesianTransformationOperator2D _Target;
	
	
		[Description("An implicit description of the symbol, either predefined or externally defined.")]
		public IfcDefinedSymbolSelect Definition { get { return this._Definition; } set { this._Definition = value;} }
	
		[Description("A description of the placement, orientation and (uniform or non-uniform) scaling " +
	    "of the defined symbol.")]
		public IfcCartesianTransformationOperator2D Target { get { return this._Target; } set { this._Target = value;} }
	
	
	}
	
}
