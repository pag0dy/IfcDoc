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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("773e5eda-f463-41ec-a0f4-14681750a780")]
	public abstract partial class IfcStructuralAction : IfcStructuralActivity
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcBoolean? _DestabilizingLoad;
	
	
		[Description("Indicates if this action may cause a stability problem. If it is \'FALSE\', no furt" +
	    "her investigations regarding stability problems are necessary. ")]
		public IfcBoolean? DestabilizingLoad { get { return this._DestabilizingLoad; } set { this._DestabilizingLoad = value;} }
	
	
	}
	
}
