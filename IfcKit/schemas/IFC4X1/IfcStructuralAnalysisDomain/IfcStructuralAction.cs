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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("db0b36c0-b174-4a54-9aee-a0ca2238d6ec")]
	public abstract partial class IfcStructuralAction : IfcStructuralActivity
	{
		[DataMember(Order=0)] 
		[Required()]
		Boolean _DestabilizingLoad;
	
		[DataMember(Order=1)] 
		IfcStructuralReaction _CausedBy;
	
	
		[Description("Indicates if this action may cause a stability problem. If it is \'FALSE\', no furt" +
	    "her investigations regarding stability problems are necessary. ")]
		public Boolean DestabilizingLoad { get { return this._DestabilizingLoad; } set { this._DestabilizingLoad = value;} }
	
		[Description("Optional reference to an instance of IfcStructuralReaction representing a result " +
	    "of another structural analysis model which creates this action upon the consider" +
	    "ed structural analysis model. ")]
		public IfcStructuralReaction CausedBy { get { return this._CausedBy; } set { this._CausedBy = value;} }
	
	
	}
	
}
