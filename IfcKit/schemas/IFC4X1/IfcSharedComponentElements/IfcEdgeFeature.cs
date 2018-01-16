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
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcSharedComponentElements
{
	[Guid("8ea1afdf-5688-48ad-aa05-f3da62694d30")]
	public abstract partial class IfcEdgeFeature : IfcFeatureElementSubtraction
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _FeatureLength;
	
	
		[Description("The length of the feature in orthogonal direction from the feature cross section." +
	    "")]
		public IfcPositiveLengthMeasure? FeatureLength { get { return this._FeatureLength; } set { this._FeatureLength = value;} }
	
	
	}
	
}
