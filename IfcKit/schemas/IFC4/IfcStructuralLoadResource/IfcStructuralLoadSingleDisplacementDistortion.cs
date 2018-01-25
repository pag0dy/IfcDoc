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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	[Guid("eea1aab8-29e8-4975-b676-396ce73e5468")]
	public partial class IfcStructuralLoadSingleDisplacementDistortion : IfcStructuralLoadSingleDisplacement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCurvatureMeasure? _Distortion;
	
	
		[Description("The distortion curvature (warping, i.e. a cross-sectional deplanation) given to t" +
	    "he displacement load.")]
		public IfcCurvatureMeasure? Distortion { get { return this._Distortion; } set { this._Distortion = value;} }
	
	
	}
	
}
