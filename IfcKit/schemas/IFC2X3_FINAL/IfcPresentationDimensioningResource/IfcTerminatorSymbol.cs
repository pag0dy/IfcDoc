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
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationDimensioningResource
{
	[Guid("28c5a0d8-09fb-4d45-8d82-a6a6422ee6a1")]
	public partial class IfcTerminatorSymbol : IfcAnnotationSymbolOccurrence
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAnnotationCurveOccurrence _AnnotatedCurve;
	
	
		public IfcTerminatorSymbol()
		{
		}
	
		public IfcTerminatorSymbol(IfcRepresentationItem __Item, IfcPresentationStyleAssignment[] __Styles, IfcLabel? __Name, IfcAnnotationCurveOccurrence __AnnotatedCurve)
			: base(__Item, __Styles, __Name)
		{
			this._AnnotatedCurve = __AnnotatedCurve;
		}
	
		[Description("The curve being annotated by the terminator symbol.")]
		public IfcAnnotationCurveOccurrence AnnotatedCurve { get { return this._AnnotatedCurve; } set { this._AnnotatedCurve = value;} }
	
	
	}
	
}
