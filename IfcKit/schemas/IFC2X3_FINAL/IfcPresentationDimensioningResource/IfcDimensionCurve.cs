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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationDimensioningResource
{
	[Guid("25dc1886-d49e-4538-9730-df93d93f9916")]
	public partial class IfcDimensionCurve : IfcAnnotationCurveOccurrence
	{
		[InverseProperty("AnnotatedCurve")] 
		ISet<IfcTerminatorSymbol> _AnnotatedBySymbols = new HashSet<IfcTerminatorSymbol>();
	
	
		[Description("Reference to the terminator symbols that may be assigned to the dimension curve. " +
	    "There shall be either zero, one or two terminator symbols assigned.")]
		public ISet<IfcTerminatorSymbol> AnnotatedBySymbols { get { return this._AnnotatedBySymbols; } }
	
	
	}
	
}
