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
	[Guid("6430b90a-bc13-49fa-90e0-254576ac9316")]
	public abstract partial class IfcStructuralReaction : IfcStructuralActivity
	{
		[InverseProperty("CausedBy")] 
		ISet<IfcStructuralAction> _Causes = new HashSet<IfcStructuralAction>();
	
	
		[Description("Optional reference to instances of IfcStructuralAction which directly depend on t" +
	    "his reaction. This reference is only needed if dependencies between structural a" +
	    "nalysis models must be captured. ")]
		public ISet<IfcStructuralAction> Causes { get { return this._Causes; } }
	
	
	}
	
}
